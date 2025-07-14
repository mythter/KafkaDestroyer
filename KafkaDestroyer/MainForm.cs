using Confluent.Kafka;
using Confluent.Kafka.Admin;

using KafkaDestroyer.Comparers;
using KafkaDestroyer.Controls;
using KafkaDestroyer.Interfaces;
using KafkaDestroyer.Managers;
using KafkaDestroyer.Models;
using KafkaDestroyer.Properties;
namespace KafkaDestroyer
{
	public partial class MainForm : Form
	{
		private AdminClientConfig? _adminClientConfig;

		private ProducerConfig? _producerConfig;

		private List<TopicMetadata>? _kafkaTopics;

		private string? _kafkaHost;

		private string? _selectedTopic;

		public MainForm()
		{
			InitializeComponent();

			KeyPreview = true;

			// setting splitter color
			var splitContainer = TableLayoutPanel.Controls[1];

			splitContainer.BackColor = Color.FromArgb(55,55,55);  // splitter color

			splitContainer.Controls[0].BackColor = BackColor;
			splitContainer.Controls[1].BackColor = BackColor;

			RestoreSettings();
		}

		private async void TestConnectionBtn_Click(object sender, EventArgs e)
		{
			var config = new ProducerConfig { BootstrapServers = KafkaHostTextBox.Text };

			try
			{
				TestConnectionBtn.Enabled = false;

				using var adminClient = new AdminClientBuilder(config).Build();

				await Task.Run(() =>
				{
					var meta = adminClient.GetMetadata(TimeSpan.FromSeconds(10));

					MessageBox.Show(this, $"Broker Name: {meta.OriginatingBrokerName}\nBroker ID: {meta.OriginatingBrokerId}",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				});

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error getting metadata:\n" + ex.Message,
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				TestConnectionBtn.Enabled = true;
			}
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			SetFormSizeAndLocation();

			string editorPath = Path.Combine(Application.StartupPath, "Resources/editor.html");
			await MessageEditor.Init(editorPath, Settings.Default.EditorTheme);

			await InitKafkaTopics();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.KafkaHost = KafkaHostTextBox.Text;
			Settings.Default.FormSize = Size;
			Settings.Default.FormLocation = Location;
			Settings.Default.Save();
		}

		private void SetFormSizeAndLocation()
		{
			if (Settings.Default.FormSize != Size.Empty)
			{
				Size = Settings.Default.FormSize;
			}

			if (Settings.Default.FormLocation != Point.Empty)
			{
				var screenBounds = Screen.FromPoint(Settings.Default.FormLocation).WorkingArea;
				var location = Settings.Default.FormLocation;
				if (screenBounds.Contains(new Rectangle(location, Size)))
				{
					Location = location;
				}
				else
				{
					StartPosition = FormStartPosition.CenterScreen;
				}
			}
			else
			{
				StartPosition = FormStartPosition.CenterScreen;
			}
		}

		private async Task InitKafkaTopics()
		{
			if (_adminClientConfig is null)
			{
				return;
			}

			try
			{
				TopicsListControl.ControlsEnabled = false;

				var topics = await GetKafkaTopics(_adminClientConfig);

				_kafkaTopics = [..
					topics
					.Where(t => !t.Topic.StartsWith("__"))
					.OrderBy(t => t.Topic, new NaturalStringComparer())
				];

				TopicsListControl.SetTopics(_kafkaTopics);
				TopicsListControl.SetSelectedTopic(_selectedTopic);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error occurred while obtainig Kafka topics: " + ex.Message,
					"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				TopicsListControl.ControlsEnabled = true;
			}
		}

		private void RestoreSettings()
		{
			_kafkaHost = Settings.Default.KafkaHost;
			KafkaHostTextBox.Text = _kafkaHost;

			UpdateKafkaHost(_kafkaHost);
		}

		private void KafkaHostTextBox_Leave(object sender, EventArgs e)
		{
			_kafkaHost = KafkaHostTextBox.Text.Trim();
			Settings.Default.KafkaHost = _kafkaHost;

			UpdateKafkaHost(_kafkaHost);
		}

		private void UpdateKafkaHost(string kafkaHost)
		{
			if (string.IsNullOrWhiteSpace(kafkaHost))
			{
				_adminClientConfig = null;
				_producerConfig = null;

				return;
			}

			_adminClientConfig = new AdminClientConfig
			{
				BootstrapServers = kafkaHost
			};

			_producerConfig = new ProducerConfig
			{
				BootstrapServers = kafkaHost
			};
		}

		private async void RefreshTopicsBtn_Click(object sender, EventArgs e)
		{
			ChooseTopicLabel.Visible = true;

			MessageEditor.Visible = false;
			MessagesControlList.Visible = false;

			_selectedTopic = null;
			_kafkaTopics?.Clear();
			TopicsListControl.ClearTopics();
			await InitKafkaTopics();
		}

		private static async Task<List<TopicMetadata>> GetKafkaTopics(AdminClientConfig adminClientConfig)
		{
			using var adminClient = new AdminClientBuilder(adminClientConfig).Build();

			var tcs = new TaskCompletionSource<List<TopicMetadata>>();

			await Task.Run(() =>
			{
				var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(10));
				tcs.SetResult([.. metadata.Topics.OrderBy(t => t.Topic, new NaturalStringComparer())]);
			});

			return await tcs.Task;
		}

		private static async Task CreateKafkaTopics(AdminClientConfig adminClientConfig, params TopicSpecification[] topicSpecification)
		{
			using var adminClient = new AdminClientBuilder(adminClientConfig).Build();

			await adminClient.CreateTopicsAsync(topicSpecification);
		}

		private static async Task DeleteKafkaTopics(AdminClientConfig adminClientConfig, params string[] topics)
		{
			using var adminClient = new AdminClientBuilder(adminClientConfig).Build();

			await adminClient.DeleteTopicsAsync(topics);
		}

		private static async Task<DeliveryResult<string, string>> SendKafkaMessage(ProducerConfig producerConfig, string topicName, ITopicMessage message)
		{
			using var producer = new ProducerBuilder<string, string>(producerConfig).Build();

			return await producer.ProduceAsync(topicName, new Message<string, string>
			{
				Key = message.Key!,
				Value = message.Body!
			});
		}

		private async void TopicsListControl_AddTopic(object sender, string topic)
		{
			if (_adminClientConfig is null)
			{
				return;
			}

			var topicName = topic.Trim();

			if (string.IsNullOrEmpty(topicName))
			{
				MessageBox.Show("Enter a valid topic name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				TopicsListControl.TopicNameText = string.Empty;
				TopicsListControl.ControlsEnabled = false;

				await CreateKafkaTopics(_adminClientConfig, new TopicSpecification
				{
					Name = topicName,
					NumPartitions = 1,
					ReplicationFactor = 1
				});

				await InitKafkaTopics();
			}
			catch (CreateTopicsException ex)
			{
				if (ex.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
				{
					MessageBox.Show($"Topic {topicName} already exists",
						"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show($"Error occurred while creating the topic: {ex.Results[0].Error.Reason}",
						"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			finally
			{
				TopicsListControl.ControlsEnabled = true;
			}
		}

		private async void TopicsListControl_DeleteTopic(object sender, string topicName)
		{
			if (_adminClientConfig is null || _kafkaHost is null)
			{
				return;
			}

			if (string.IsNullOrEmpty(topicName))
			{
				MessageBox.Show("Choose the topic you want to delete.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				TopicsListControl.ControlsEnabled = false;
				TopicsListControl.AllowSelecting = false;

				await DeleteKafkaTopics(_adminClientConfig, topicName);

				StorageManager.DeleteTopic(_kafkaHost, topicName);

				_selectedTopic = null;
				ChooseTopicLabel.Visible = true;
				MessageEditor.Visible = false;
				MessagesControlList.Visible = false;

				_kafkaTopics?.RemoveAll(t => t.Topic == topicName);
				TopicsListControl.SetTopics(_kafkaTopics);
			}
			catch (DeleteTopicsException ex)
			{
				if (ex.Results[0].Error.Code == ErrorCode.UnknownTopicOrPart)
				{
					MessageBox.Show($"Topic {topicName} not found",
						"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show($"Error occurred while deleting the topic: {ex.Results[0].Error.Reason}",
						"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			finally
			{
				TopicsListControl.ControlsEnabled = true;
				TopicsListControl.AllowSelecting = true;
			}
		}

		private void TopicsListControl_SelectionChanged(object sender, string topicName)
		{
			_selectedTopic = topicName;

			ShowMessagesListForTopic();
		}

		private void ShowMessagesListForTopic()
		{
			ChooseTopicLabel.Visible = false;
			MessageEditor.Visible = false;
			MessagesControlList.Visible = true;

			MessagesControlList.Clear();

			if (_kafkaHost is null || _selectedTopic is null)
			{
				return;
			}

			var messages = StorageManager.GetMessages(_kafkaHost, _selectedTopic);

			if (messages is not null)
			{
				MessagesControlList.SetMessages(messages);
			}
		}

		private void MessagesControlList_AddMessage(object sender, string messageTitle)
		{
			if (string.IsNullOrWhiteSpace(messageTitle))
			{
				MessageBox.Show("Enter valid message title.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			messageTitle = messageTitle.Trim();

			if (_kafkaHost is not null && _selectedTopic is not null)
			{
				var message = StorageManager.AddMessage(_kafkaHost, _selectedTopic, messageTitle, null, null);
				MessagesControlList.AddMessageToList(message);
			}
		}

		private void MessagesControlList_DeleteMessage(object sender, Guid messageId)
		{
			if (_kafkaHost is null || _selectedTopic is null)
				return;

			if (StorageManager.DeleteMessage(_kafkaHost, _selectedTopic, messageId))
			{
				MessagesControlList.RemoveMessageFromList(messageId);
			}
		}

		private async void OnSendMessage(object sender, ITopicMessage message)
		{
			if (_producerConfig is null || _selectedTopic is null)
			{
				return;
			}

			try
			{
				var result = await SendKafkaMessage(_producerConfig, _selectedTopic, message);
			}
			catch (ProduceException<string, string> ex)
			{
				MessageBox.Show($"Error occurred while sending the message: {ex.Error.Reason}",
					"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void MessagesControlList_MessageClick(object sender, TopicMessage message)
		{
			MessageEditor.Visible = true;
			MessagesControlList.Visible = false;

			await MessageEditor.SetMessage(message);
		}

		private void MessageEditor_BackClick(object sender, EventArgs e)
		{
			ShowMessagesListForTopic();
		}

		private void MessageEditor_SaveChangesClick(object sender, TopicMessageUpdate message)
		{
			if (_kafkaHost is null || _selectedTopic is null)
				return;

			StorageManager.UpdateMessage(_kafkaHost, _selectedTopic, message);
		}

		private async void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.S &&
				MessageEditor.Visible)
			{
				await MessageEditor.SaveMessage();
				e.Handled = true;
			}
		}
	}

	public class EventMessage
	{
		public string? EventType { get; set; }
		public string? Message { get; set; }
	}
}
