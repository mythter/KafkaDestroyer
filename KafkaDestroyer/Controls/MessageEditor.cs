using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

using KafkaDestroyer.Interfaces;
using KafkaDestroyer.Models;
using KafkaDestroyer.Properties;

using Microsoft.Web.WebView2.Core;

namespace KafkaDestroyer.Controls
{
	public partial class MessageEditor : UserControl
	{
		private const string SET_OBJECT_SCRIPT = "setObject({0});";

		private const string GET_OBJECT_SCRIPT = "getObject();";

		public event EventHandler? BackClick;

		public event EventHandler<TopicMessageUpdate>? SaveChangesClick;

		public event EventHandler<ITopicMessage>? SendMessageClick;

		private TopicMessage? _message;

		private readonly JsonSerializerOptions? _eventJsonSerializerOptions;

		public MessageEditor()
		{
			InitializeComponent();

			_eventJsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
		}

		public async Task Init(string editorPath, string? theme)
		{
			await MessageWebView.EnsureCoreWebView2Async(null);

			MessageWebView.NavigationCompleted += async (s, e) =>
			{
				if (!string.IsNullOrEmpty(theme))
				{
					await SetEditorTheme(theme);
				}
			};

			MessageWebView.CoreWebView2.WebMessageReceived += MessageWebView_WebMessageReceived;

			MessageWebView.Source = new Uri(editorPath);
		}

		public async Task SetMessage(TopicMessage message)
		{
			_message = message;

			MessageKeyTextBox.Text = message.Key;
			MessageTitleTextBox.Text = message.Title;

			string serializedObject = JsonSerializer.Serialize(message.Body);
			string script = string.Format(SET_OBJECT_SCRIPT, serializedObject);
			await MessageWebView.ExecuteScriptAsync(script);
		}

		public async Task SaveMessage()
		{
			if (_message is null)
			{
				return;
			}

			var editedMessage = await GetUpdatedMessage();

			SaveChangesClick?.Invoke(this, editedMessage!);
		}

		private async void MessageWebView_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
		{
			try
			{
				string json = e.WebMessageAsJson;
				var data = JsonSerializer.Deserialize<EventMessage>(json, _eventJsonSerializerOptions);

				if (data?.EventType == "editorThemeChanged")
				{
					Settings.Default.EditorTheme = data.Message;
				}
				else if (data?.EventType == "saveMessage")
				{
					await SaveMessage();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error occurred while deserializing the WebView2 event: " + ex.Message,
					"Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task SetEditorTheme(string theme)
		{
			string script = $"setTheme('{theme}');";
			await MessageWebView.ExecuteScriptAsync(script);
		}

		private void BackBtn_Click(object sender, EventArgs e)
		{
			BackClick?.Invoke(this, EventArgs.Empty);
		}

		private async void SaveChangesBtn_Click(object sender, EventArgs e)
		{
			await SaveMessage();
		}

		private async void SendMessageBtn_Click(object sender, EventArgs e)
		{
			if (_message is null)
			{
				return;
			}

			var message = await GetUpdatedMessage();

			SendMessageClick?.Invoke(this, message!);
		}

		[return: NotNullIfNotNull(nameof(_message))]
		private async Task<TopicMessageUpdate?> GetUpdatedMessage()
		{
			if (_message is null)
			{
				return null;
			}

			var value = await MessageWebView.CoreWebView2.ExecuteScriptAsync(GET_OBJECT_SCRIPT);

			if (!string.IsNullOrEmpty(value))
			{
				value = JsonSerializer.Deserialize<string>(value);
			}

			return new TopicMessageUpdate(
				_message.Id,
				title: MessageTitleTextBox.Text,
				key: MessageKeyTextBox.Text,
				body: value
			);
		}
	}
}
