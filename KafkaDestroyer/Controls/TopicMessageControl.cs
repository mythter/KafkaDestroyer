using System.ComponentModel;

using KafkaDestroyer.Interfaces;
using KafkaDestroyer.Models;

namespace KafkaDestroyer.Controls
{
	public partial class TopicMessageControl : UserControl
	{
		[Category("Action")]
		[Description("Occurs when the Send message button is clicked.")]
		public event EventHandler<ITopicMessage>? SendMessageButtonClicked;

		[Category("Action")]
		[Description("Occurs when the Delete message button is clicked.")]
		public event EventHandler<Guid>? DeleteMessageButtonClicked;

		public new event EventHandler<TopicMessage>? Click;

		private bool _isEditing;

		private readonly TopicMessage _message;

		public TopicMessage Message => _message;

		public new Color BackColor
		{
			get => TopicMessageLabel.FillColor;
			set => TopicMessageLabel.FillColor = value;
		}

		public new Color ForeColor
		{
			get => TopicMessageLabel.ForeColor;
			set => TopicMessageLabel.ForeColor = value;
		}

		private System.Windows.Forms.Timer clickTimer;
		private bool doubleClickFired = false;

		public TopicMessageControl(TopicMessage message)
		{
			InitializeComponent();

			clickTimer = new System.Windows.Forms.Timer();
			clickTimer.Interval = (int)(SystemInformation.DoubleClickTime * 0.4);
			clickTimer.Tick += ClickTimer_Tick;

			_message = message ?? throw new ArgumentNullException(nameof(message));

			TopicMessageLabel.Text = message.Title;

			ShowButtons(false);
		}

		private void TopicMessage_MouseEnter(object sender, EventArgs e)
		{
			//if (TopicMessageLabel.Editing)
			//	return;

			ShowButtons(true);
		}

		private void TopicMessage_MouseLeave(object sender, EventArgs e)
		{
			if (GetChildAtPoint(PointToClient(MousePosition)) != null)
				return;

			ShowButtons(false);
		}

		private void SendMessageBtn_Click(object sender, EventArgs e)
		{
			SendMessageButtonClicked?.Invoke(this, _message);
		}

		private void DeleteMessageBtn_Click(object sender, EventArgs e)
		{
			DeleteMessageButtonClicked?.Invoke(this, _message.Id);
		}

		private void TopicMessageLabel_EditingStarted(object sender, EventArgs e)
		{
			//ShowButtons(false);
		}

		private void ShowButtons(bool boolean)
		{
			DeleteMessageBtn.Visible = boolean;
			SendMessageBtn.Visible = boolean;
		}

		private void TopicMessageLabel_Click(object sender, EventArgs e)
		{
			doubleClickFired = false;
			clickTimer.Start();
		}

		private void TopicMessageLabel_DoubleClick(object sender, EventArgs e)
		{
			clickTimer.Stop();
			doubleClickFired = true;

			int d = 3;
			// send event
		}

		private void ClickTimer_Tick(object? sender, EventArgs e)
		{
			clickTimer.Stop();

			if (!doubleClickFired)
			{
				Click?.Invoke(this, _message);
			}
		}
	}
}
