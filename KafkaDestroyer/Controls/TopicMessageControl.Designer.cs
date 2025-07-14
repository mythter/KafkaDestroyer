namespace KafkaDestroyer.Controls
{
	partial class TopicMessageControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DeleteMessageBtn = new RoundedButton();
			SendMessageBtn = new RoundedButton();
			TopicMessageLabel = new RoundedLabel();
			SuspendLayout();
			// 
			// DeleteMessageBtn
			// 
			DeleteMessageBtn.Anchor = AnchorStyles.Right;
			DeleteMessageBtn.BackColor = Color.FromArgb(61, 61, 61);
			DeleteMessageBtn.BackgroundColor = Color.FromArgb(61, 61, 61);
			DeleteMessageBtn.BackgroundImage = Properties.Resources.trash_gray;
			DeleteMessageBtn.BackgroundImageLayout = ImageLayout.Zoom;
			DeleteMessageBtn.BorderColor = Color.Transparent;
			DeleteMessageBtn.BorderSize = 0;
			DeleteMessageBtn.CornerRadius = 7;
			DeleteMessageBtn.FlatAppearance.BorderSize = 0;
			DeleteMessageBtn.FlatStyle = FlatStyle.Flat;
			DeleteMessageBtn.ForeColor = Color.White;
			DeleteMessageBtn.Location = new Point(461, 3);
			DeleteMessageBtn.Name = "DeleteMessageBtn";
			DeleteMessageBtn.Size = new Size(34, 34);
			DeleteMessageBtn.TabIndex = 3;
			DeleteMessageBtn.TextColor = Color.White;
			DeleteMessageBtn.UseVisualStyleBackColor = false;
			DeleteMessageBtn.Click += DeleteMessageBtn_Click;
			// 
			// SendMessageBtn
			// 
			SendMessageBtn.Anchor = AnchorStyles.Right;
			SendMessageBtn.BackColor = Color.FromArgb(61, 61, 61);
			SendMessageBtn.BackgroundColor = Color.FromArgb(61, 61, 61);
			SendMessageBtn.BorderColor = Color.Transparent;
			SendMessageBtn.BorderSize = 0;
			SendMessageBtn.CornerRadius = 7;
			SendMessageBtn.FlatAppearance.BorderSize = 0;
			SendMessageBtn.FlatStyle = FlatStyle.Flat;
			SendMessageBtn.Font = new Font("Segoe UI", 10F);
			SendMessageBtn.ForeColor = Color.White;
			SendMessageBtn.Location = new Point(501, 3);
			SendMessageBtn.Name = "SendMessageBtn";
			SendMessageBtn.Size = new Size(108, 34);
			SendMessageBtn.TabIndex = 4;
			SendMessageBtn.Text = "Send";
			SendMessageBtn.TextColor = Color.White;
			SendMessageBtn.UseVisualStyleBackColor = false;
			SendMessageBtn.Click += SendMessageBtn_Click;
			// 
			// TopicMessageLabel
			// 
			TopicMessageLabel.BackColor = Color.Transparent;
			TopicMessageLabel.BorderColor = Color.Empty;
			TopicMessageLabel.BorderThickness = 0;
			TopicMessageLabel.CornerRadius = 7;
			TopicMessageLabel.Dock = DockStyle.Fill;
			TopicMessageLabel.FillColor = Color.Transparent;
			TopicMessageLabel.Font = new Font("Segoe UI", 11F);
			TopicMessageLabel.ForeColor = Color.Black;
			TopicMessageLabel.Location = new Point(0, 0);
			TopicMessageLabel.Name = "TopicMessageLabel";
			TopicMessageLabel.Padding = new Padding(5, 0, 0, 0);
			TopicMessageLabel.Size = new Size(612, 41);
			TopicMessageLabel.TabIndex = 5;
			TopicMessageLabel.TextAlign = ContentAlignment.MiddleLeft;
			TopicMessageLabel.Click += TopicMessageLabel_Click;
			TopicMessageLabel.DoubleClick += TopicMessageLabel_DoubleClick;
			TopicMessageLabel.MouseEnter += TopicMessage_MouseEnter;
			TopicMessageLabel.MouseLeave += TopicMessage_MouseLeave;
			// 
			// TopicMessageControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Controls.Add(SendMessageBtn);
			Controls.Add(DeleteMessageBtn);
			Controls.Add(TopicMessageLabel);
			Name = "TopicMessageControl";
			Size = new Size(612, 41);
			MouseEnter += TopicMessage_MouseEnter;
			MouseLeave += TopicMessage_MouseLeave;
			ResumeLayout(false);
		}

		#endregion
		private RoundedButton DeleteMessageBtn;
		private RoundedButton SendMessageBtn;
		private RoundedLabel TopicMessageLabel;
	}
}
