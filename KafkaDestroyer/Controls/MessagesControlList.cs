using KafkaDestroyer.Interfaces;
using KafkaDestroyer.Models;

namespace KafkaDestroyer.Controls
{
	public partial class MessagesControlList : UserControl
	{
		public event EventHandler<string>? AddMessage;
		public event EventHandler<Guid>? DeleteMessage;
		public event EventHandler<ITopicMessage>? SendMessage;

		public event EventHandler<TopicMessage>? MessageClick;

		public Color MessageBackColor { get; set; } = Color.LightGray;
		public Color MessageTextColor { get; set; } = SystemColors.ControlText;
		public Color MessageSelectedBackColor { get; set; } = Color.DodgerBlue;
		public Color MessageSelectedTextColor { get; set; } = Color.White;
		public Font MessageFont { get; set; } = SystemFonts.DefaultFont;
		public int? MessageHeight { get; set; }

		public MessagesControlList()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			MessagesList.Clear();
		}

		public void SetMessages(List<TopicMessage> messages)
		{
			Clear();
			foreach (var message in messages)
			{
				AddMessageToList(message);
			}
		}

		public void AddMessageToList(TopicMessage? message)
		{
			if (message is null)
				return;

			var messageControl = new TopicMessageControl(message)
			{
				BackColor = MessageBackColor,
				ForeColor = MessageTextColor,
				Font = MessageFont,
			};

			if (MessageHeight > 0)
			{
				messageControl.Height = MessageHeight.Value;
			}

			messageControl.SendMessageButtonClicked += OnSendMessage;
			messageControl.DeleteMessageButtonClicked += OnDeleteMessage;
			messageControl.Click += OnMessageClick;
			MessagesList.Add(messageControl);
		}

		public void RemoveMessageFromList(Guid messageId)
		{
			var control = MessagesList.GetControls()
				.OfType<TopicMessageControl>()
				.FirstOrDefault(c => c.Message.Id == messageId);

			if (control is not null)
			{
				control.SendMessageButtonClicked -= OnSendMessage;
				control.DeleteMessageButtonClicked -= OnDeleteMessage;
				MessagesList.Remove(control);
			}
		}

		private void AddMessageBtn_Click(object? sender, EventArgs e)
		{
			AddMessage?.Invoke(this, MessageTitleTextBox.Text);
			MessageTitleTextBox.Text = null;
		}

		private void OnDeleteMessage(object? sender, Guid messageId)
		{
			DeleteMessage?.Invoke(this, messageId);
		}

		private void OnSendMessage(object? sender, ITopicMessage message)
		{
			SendMessage?.Invoke(this, message);
		}

		private void OnMessageClick(object? sender, TopicMessage message)
		{
			MessageClick?.Invoke(this, message);
		}
	}
}
