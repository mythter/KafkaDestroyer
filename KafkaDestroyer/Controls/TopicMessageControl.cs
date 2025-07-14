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

		public new int Height
		{
			get => base.Height;
			set
			{
				base.Height = value;
				if (Height > 0)
				{
					SetButtonsSize(value);
				}
			}
		}

		// in case double click will be needed in the future
		//private System.Windows.Forms.Timer clickTimer;
		//private bool doubleClickFired = false;

		public TopicMessageControl(TopicMessage message)
		{
			InitializeComponent();

			//clickTimer = new System.Windows.Forms.Timer();
			//clickTimer.Interval = (int)(SystemInformation.DoubleClickTime * 0.4);
			//clickTimer.Tick += ClickTimer_Tick;

			_message = message ?? throw new ArgumentNullException(nameof(message));

			TopicMessageLabel.Text = message.Title;

			ShowButtons(false);
		}

		private void SetButtonsSize(int controlHeight)
		{
			var padding = 10;
			var size = controlHeight - padding;

			SendMessageBtn.Height = size;

			DeleteMessageBtn.Width = size;
			DeleteMessageBtn.Height = size;

			var m1 = DeleteMessageBtn.Margin;
			var m2 = SendMessageBtn.Margin;

			int spacing = m1.Right + m2.Left;

			int y = (ClientSize.Height - size) / 2;

			int totalButtonsWidth = DeleteMessageBtn.Width + SendMessageBtn.Width + spacing;
			int offsetX = ClientSize.Width - totalButtonsWidth;

			var x1 = offsetX - (padding / 2);
			int x2 = x1 + DeleteMessageBtn.Width + spacing;

			DeleteMessageBtn.SetBounds(x1, y, size, size);
			SendMessageBtn.SetBounds(x2, y, SendMessageBtn.Width, size);
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
			//doubleClickFired = false;
			//clickTimer.Start();

			Click?.Invoke(this, _message);
		}

		private void TopicMessageLabel_DoubleClick(object sender, EventArgs e)
		{
			//clickTimer.Stop();
			//doubleClickFired = true;

			// send event
		}

		//private void ClickTimer_Tick(object? sender, EventArgs e)
		//{
		//	clickTimer.Stop();

		//	if (!doubleClickFired)
		//	{
		//		Click?.Invoke(this, _message);
		//	}
		//}
	}
}
