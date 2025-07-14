namespace KafkaDestroyer.Controls
{
	partial class MessagesControlList
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
			MessagesList = new GapableList();
			MessagesControlPanel = new Panel();
			AddMessageBtn = new RoundedButton();
			MessageTitleTextBox = new RoundedTextBox();
			MessagesControlPanel.SuspendLayout();
			SuspendLayout();
			// 
			// MessagesList
			// 
			MessagesList.Dock = DockStyle.Fill;
			MessagesList.Gap = 6;
			MessagesList.Location = new Point(0, 41);
			MessagesList.Name = "MessagesList";
			MessagesList.Size = new Size(479, 316);
			MessagesList.TabIndex = 0;
			// 
			// MessagesControlPanel
			// 
			MessagesControlPanel.AutoSize = true;
			MessagesControlPanel.Controls.Add(AddMessageBtn);
			MessagesControlPanel.Controls.Add(MessageTitleTextBox);
			MessagesControlPanel.Dock = DockStyle.Top;
			MessagesControlPanel.Location = new Point(0, 0);
			MessagesControlPanel.Name = "MessagesControlPanel";
			MessagesControlPanel.Size = new Size(479, 41);
			MessagesControlPanel.TabIndex = 1;
			// 
			// AddMessageBtn
			// 
			AddMessageBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			AddMessageBtn.BackColor = Color.DimGray;
			AddMessageBtn.BackgroundColor = Color.DimGray;
			AddMessageBtn.BackgroundImage = Properties.Resources.plus_gray;
			AddMessageBtn.BackgroundImageLayout = ImageLayout.Zoom;
			AddMessageBtn.BorderColor = Color.Transparent;
			AddMessageBtn.BorderSize = 0;
			AddMessageBtn.CornerRadius = 7;
			AddMessageBtn.FlatAppearance.BorderSize = 0;
			AddMessageBtn.FlatStyle = FlatStyle.Flat;
			AddMessageBtn.Font = new Font("Segoe UI", 11F);
			AddMessageBtn.ForeColor = Color.White;
			AddMessageBtn.Location = new Point(444, -1);
			AddMessageBtn.Name = "AddMessageBtn";
			AddMessageBtn.Size = new Size(34, 34);
			AddMessageBtn.TabIndex = 8;
			AddMessageBtn.TextColor = Color.White;
			AddMessageBtn.UseVisualStyleBackColor = false;
			AddMessageBtn.Click += AddMessageBtn_Click;
			// 
			// MessageTitleTextBox
			// 
			MessageTitleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			MessageTitleTextBox.BackColor = Color.Silver;
			MessageTitleTextBox.BorderStyle = BorderStyle.FixedSingle;
			MessageTitleTextBox.CornerRadius = 7;
			MessageTitleTextBox.Font = new Font("Segoe UI", 12F);
			MessageTitleTextBox.Location = new Point(-1, -1);
			MessageTitleTextBox.Margin = new Padding(3, 3, 3, 8);
			MessageTitleTextBox.Name = "MessageTitleTextBox";
			MessageTitleTextBox.PlaceholderText = "Message title";
			MessageTitleTextBox.Size = new Size(439, 34);
			MessageTitleTextBox.TabIndex = 7;
			// 
			// MessagesControlList
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(MessagesList);
			Controls.Add(MessagesControlPanel);
			Name = "MessagesControlList";
			Size = new Size(479, 357);
			MessagesControlPanel.ResumeLayout(false);
			MessagesControlPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GapableList MessagesList;
		private Panel MessagesControlPanel;
		private RoundedTextBox MessageTitleTextBox;
		private RoundedButton AddMessageBtn;
	}
}
