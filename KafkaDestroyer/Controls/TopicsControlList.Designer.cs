namespace KafkaDestroyer.Controls
{
	partial class TopicsControlList
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
			TopicsControlPanel = new Panel();
			RefreshTopicsBtn = new RoundedButton();
			DeleteTopicBtn = new RoundedButton();
			AddTopicBtn = new RoundedButton();
			TopicNameTextBox = new RoundedTextBox();
			TopicsList = new GapableList();
			TopicsControlPanel.SuspendLayout();
			SuspendLayout();
			// 
			// TopicsControlPanel
			// 
			TopicsControlPanel.AutoSize = true;
			TopicsControlPanel.Controls.Add(RefreshTopicsBtn);
			TopicsControlPanel.Controls.Add(DeleteTopicBtn);
			TopicsControlPanel.Controls.Add(AddTopicBtn);
			TopicsControlPanel.Controls.Add(TopicNameTextBox);
			TopicsControlPanel.Dock = DockStyle.Top;
			TopicsControlPanel.Location = new Point(0, 0);
			TopicsControlPanel.Name = "TopicsControlPanel";
			TopicsControlPanel.Size = new Size(654, 41);
			TopicsControlPanel.TabIndex = 3;
			// 
			// RefreshTopicsBtn
			// 
			RefreshTopicsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			RefreshTopicsBtn.BackColor = Color.DimGray;
			RefreshTopicsBtn.BackgroundColor = Color.DimGray;
			RefreshTopicsBtn.BackgroundImage = Properties.Resources.refresh_gray;
			RefreshTopicsBtn.BackgroundImageLayout = ImageLayout.Zoom;
			RefreshTopicsBtn.BorderColor = Color.Transparent;
			RefreshTopicsBtn.BorderSize = 0;
			RefreshTopicsBtn.CornerRadius = 7;
			RefreshTopicsBtn.FlatAppearance.BorderSize = 0;
			RefreshTopicsBtn.FlatStyle = FlatStyle.Flat;
			RefreshTopicsBtn.ForeColor = Color.White;
			RefreshTopicsBtn.Location = new Point(620, -1);
			RefreshTopicsBtn.Margin = new Padding(2);
			RefreshTopicsBtn.Name = "RefreshTopicsBtn";
			RefreshTopicsBtn.Size = new Size(34, 34);
			RefreshTopicsBtn.TabIndex = 7;
			RefreshTopicsBtn.TextColor = Color.White;
			RefreshTopicsBtn.UseVisualStyleBackColor = false;
			RefreshTopicsBtn.Click += RefreshTopicsBtn_Click;
			// 
			// DeleteTopicBtn
			// 
			DeleteTopicBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			DeleteTopicBtn.BackColor = Color.DimGray;
			DeleteTopicBtn.BackgroundColor = Color.DimGray;
			DeleteTopicBtn.BackgroundImage = Properties.Resources.minus_gray;
			DeleteTopicBtn.BackgroundImageLayout = ImageLayout.Zoom;
			DeleteTopicBtn.BorderColor = Color.Transparent;
			DeleteTopicBtn.BorderSize = 0;
			DeleteTopicBtn.CornerRadius = 7;
			DeleteTopicBtn.FlatAppearance.BorderSize = 0;
			DeleteTopicBtn.FlatStyle = FlatStyle.Flat;
			DeleteTopicBtn.ForeColor = Color.White;
			DeleteTopicBtn.Location = new Point(582, -1);
			DeleteTopicBtn.Margin = new Padding(2);
			DeleteTopicBtn.Name = "DeleteTopicBtn";
			DeleteTopicBtn.Size = new Size(34, 34);
			DeleteTopicBtn.TabIndex = 6;
			DeleteTopicBtn.TextColor = Color.White;
			DeleteTopicBtn.UseVisualStyleBackColor = false;
			DeleteTopicBtn.Click += DeleteButton_Click;
			// 
			// AddTopicBtn
			// 
			AddTopicBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			AddTopicBtn.BackColor = Color.DimGray;
			AddTopicBtn.BackgroundColor = Color.DimGray;
			AddTopicBtn.BackgroundImage = Properties.Resources.plus_gray;
			AddTopicBtn.BackgroundImageLayout = ImageLayout.Zoom;
			AddTopicBtn.BorderColor = Color.Transparent;
			AddTopicBtn.BorderSize = 0;
			AddTopicBtn.CornerRadius = 7;
			AddTopicBtn.FlatAppearance.BorderSize = 0;
			AddTopicBtn.FlatStyle = FlatStyle.Flat;
			AddTopicBtn.ForeColor = Color.White;
			AddTopicBtn.Location = new Point(544, -1);
			AddTopicBtn.Margin = new Padding(2);
			AddTopicBtn.Name = "AddTopicBtn";
			AddTopicBtn.Size = new Size(34, 34);
			AddTopicBtn.TabIndex = 5;
			AddTopicBtn.TextColor = Color.White;
			AddTopicBtn.UseVisualStyleBackColor = false;
			AddTopicBtn.Click += AddButton_Click;
			// 
			// TopicNameTextBox
			// 
			TopicNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TopicNameTextBox.BackColor = Color.Silver;
			TopicNameTextBox.BorderStyle = BorderStyle.FixedSingle;
			TopicNameTextBox.CornerRadius = 7;
			TopicNameTextBox.Font = new Font("Segoe UI", 12F);
			TopicNameTextBox.Location = new Point(0, -1);
			TopicNameTextBox.Margin = new Padding(3, 3, 3, 8);
			TopicNameTextBox.Name = "TopicNameTextBox";
			TopicNameTextBox.PlaceholderText = "Topic name";
			TopicNameTextBox.Size = new Size(539, 34);
			TopicNameTextBox.TabIndex = 4;
			// 
			// TopicsList
			// 
			TopicsList.Dock = DockStyle.Fill;
			TopicsList.Gap = 6;
			TopicsList.Location = new Point(0, 41);
			TopicsList.Name = "TopicsList";
			TopicsList.Size = new Size(654, 660);
			TopicsList.TabIndex = 4;
			// 
			// TopicsControlList
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(TopicsList);
			Controls.Add(TopicsControlPanel);
			Name = "TopicsControlList";
			Size = new Size(654, 701);
			TopicsControlPanel.ResumeLayout(false);
			TopicsControlPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Panel TopicsControlPanel;
		private RoundedTextBox TopicNameTextBox;
		private GapableList TopicsList;
		private RoundedButton AddTopicBtn;
		private RoundedButton DeleteTopicBtn;
		private RoundedButton RefreshTopicsBtn;
	}
}
