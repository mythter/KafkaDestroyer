namespace KafkaDestroyer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			SplitContainer = new SplitContainer();
			TopicsListControl = new KafkaDestroyer.Controls.TopicsControlList();
			MessagesControlList = new KafkaDestroyer.Controls.MessagesControlList();
			ChooseTopicLabel = new KafkaDestroyer.Controls.RoundedLabel();
			MessageEditor = new KafkaDestroyer.Controls.MessageEditor();
			TableLayoutPanel = new TableLayoutPanel();
			TopPanel = new Panel();
			TestConnectionBtn = new KafkaDestroyer.Controls.RoundedButton();
			KafkaHostTextBox = new KafkaDestroyer.Controls.RoundedTextBox();
			((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
			SplitContainer.Panel1.SuspendLayout();
			SplitContainer.Panel2.SuspendLayout();
			SplitContainer.SuspendLayout();
			TableLayoutPanel.SuspendLayout();
			TopPanel.SuspendLayout();
			SuspendLayout();
			// 
			// SplitContainer
			// 
			SplitContainer.Dock = DockStyle.Fill;
			SplitContainer.Location = new Point(3, 50);
			SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			SplitContainer.Panel1.Controls.Add(TopicsListControl);
			// 
			// SplitContainer.Panel2
			// 
			SplitContainer.Panel2.Controls.Add(MessagesControlList);
			SplitContainer.Panel2.Controls.Add(ChooseTopicLabel);
			SplitContainer.Panel2.Controls.Add(MessageEditor);
			SplitContainer.Size = new Size(926, 572);
			SplitContainer.SplitterDistance = 308;
			SplitContainer.TabIndex = 5;
			// 
			// TopicsListControl
			// 
			TopicsListControl.AddTopicBtnEnabled = true;
			TopicsListControl.AllowSelecting = true;
			TopicsListControl.ControlsEnabled = true;
			TopicsListControl.Dock = DockStyle.Fill;
			TopicsListControl.Gap = 5;
			TopicsListControl.Location = new Point(0, 0);
			TopicsListControl.Name = "TopicsListControl";
			TopicsListControl.Padding = new Padding(0, 0, 5, 0);
			TopicsListControl.RefreshTopicsBtnEnabled = true;
			TopicsListControl.Size = new Size(308, 572);
			TopicsListControl.TabIndex = 2;
			TopicsListControl.TopicBackColor = Color.FromArgb(51, 51, 51);
			TopicsListControl.TopicFont = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TopicsListControl.TopicFontSize = 12F;
			TopicsListControl.TopicHeight = 50;
			TopicsListControl.TopicMargin = new Padding(2);
			TopicsListControl.TopicSelectedBackColor = Color.Gray;
			TopicsListControl.TopicSelectedTextColor = Color.White;
			TopicsListControl.TopicTextColor = Color.LightGray;
			TopicsListControl.AddTopic += TopicsListControl_AddTopic;
			TopicsListControl.DeleteTopic += TopicsListControl_DeleteTopic;
			TopicsListControl.RefreshTopics += RefreshTopicsBtn_Click;
			TopicsListControl.SelectionChanged += TopicsListControl_SelectionChanged;
			// 
			// MessagesControlList
			// 
			MessagesControlList.Dock = DockStyle.Fill;
			MessagesControlList.Location = new Point(0, 0);
			MessagesControlList.MessageBackColor = Color.FromArgb(99, 99, 99);
			MessagesControlList.MessageFont = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			MessagesControlList.MessageHeight = null;
			MessagesControlList.MessageSelectedBackColor = Color.DodgerBlue;
			MessagesControlList.MessageSelectedTextColor = Color.White;
			MessagesControlList.MessageTextColor = Color.WhiteSmoke;
			MessagesControlList.Name = "MessagesControlList";
			MessagesControlList.Padding = new Padding(5, 0, 0, 0);
			MessagesControlList.Size = new Size(614, 572);
			MessagesControlList.TabIndex = 3;
			MessagesControlList.Visible = false;
			MessagesControlList.AddMessage += MessagesControlList_AddMessage;
			MessagesControlList.DeleteMessage += MessagesControlList_DeleteMessage;
			MessagesControlList.SendMessage += OnSendMessage;
			MessagesControlList.MessageClick += MessagesControlList_MessageClick;
			// 
			// ChooseTopicLabel
			// 
			ChooseTopicLabel.BackColor = Color.Transparent;
			ChooseTopicLabel.BorderColor = Color.Empty;
			ChooseTopicLabel.BorderThickness = 0;
			ChooseTopicLabel.CornerRadius = 0;
			ChooseTopicLabel.Dock = DockStyle.Fill;
			ChooseTopicLabel.FillColor = Color.Empty;
			ChooseTopicLabel.Font = new Font("Segoe UI", 12F);
			ChooseTopicLabel.ForeColor = Color.WhiteSmoke;
			ChooseTopicLabel.Location = new Point(0, 0);
			ChooseTopicLabel.Name = "ChooseTopicLabel";
			ChooseTopicLabel.Size = new Size(614, 572);
			ChooseTopicLabel.TabIndex = 3;
			ChooseTopicLabel.Text = "Choose or create the topic you want to sent message to";
			ChooseTopicLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// MessageEditor
			// 
			MessageEditor.Dock = DockStyle.Fill;
			MessageEditor.Location = new Point(0, 0);
			MessageEditor.Name = "MessageEditor";
			MessageEditor.Size = new Size(614, 572);
			MessageEditor.TabIndex = 2;
			MessageEditor.Visible = false;
			MessageEditor.BackClick += MessageEditor_BackClick;
			MessageEditor.SaveChangesClick += MessageEditor_SaveChangesClick;
			MessageEditor.SendMessageClick += OnSendMessage;
			// 
			// TableLayoutPanel
			// 
			TableLayoutPanel.ColumnCount = 1;
			TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			TableLayoutPanel.Controls.Add(TopPanel, 0, 0);
			TableLayoutPanel.Controls.Add(SplitContainer, 0, 1);
			TableLayoutPanel.Dock = DockStyle.Fill;
			TableLayoutPanel.Location = new Point(0, 0);
			TableLayoutPanel.Name = "TableLayoutPanel";
			TableLayoutPanel.RowCount = 2;
			TableLayoutPanel.RowStyles.Add(new RowStyle());
			TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			TableLayoutPanel.Size = new Size(932, 625);
			TableLayoutPanel.TabIndex = 6;
			// 
			// TopPanel
			// 
			TopPanel.AutoSize = true;
			TopPanel.Controls.Add(TestConnectionBtn);
			TopPanel.Controls.Add(KafkaHostTextBox);
			TopPanel.Dock = DockStyle.Fill;
			TopPanel.Location = new Point(3, 3);
			TopPanel.Name = "TopPanel";
			TopPanel.Size = new Size(926, 41);
			TopPanel.TabIndex = 7;
			// 
			// TestConnectionBtn
			// 
			TestConnectionBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			TestConnectionBtn.BackColor = Color.DimGray;
			TestConnectionBtn.BackgroundColor = Color.DimGray;
			TestConnectionBtn.BorderColor = Color.Transparent;
			TestConnectionBtn.BorderSize = 0;
			TestConnectionBtn.CornerRadius = 5;
			TestConnectionBtn.FlatAppearance.BorderSize = 0;
			TestConnectionBtn.FlatStyle = FlatStyle.Flat;
			TestConnectionBtn.Font = new Font("Segoe UI", 10F);
			TestConnectionBtn.ForeColor = Color.WhiteSmoke;
			TestConnectionBtn.Location = new Point(782, 4);
			TestConnectionBtn.Name = "TestConnectionBtn";
			TestConnectionBtn.Size = new Size(141, 34);
			TestConnectionBtn.TabIndex = 1;
			TestConnectionBtn.Text = "Test Connection";
			TestConnectionBtn.TextColor = Color.WhiteSmoke;
			TestConnectionBtn.UseVisualStyleBackColor = false;
			TestConnectionBtn.Click += TestConnectionBtn_Click;
			// 
			// KafkaHostTextBox
			// 
			KafkaHostTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			KafkaHostTextBox.BackColor = Color.Silver;
			KafkaHostTextBox.BorderStyle = BorderStyle.FixedSingle;
			KafkaHostTextBox.CornerRadius = 7;
			KafkaHostTextBox.Font = new Font("Segoe UI", 12F);
			KafkaHostTextBox.ForeColor = SystemColors.WindowText;
			KafkaHostTextBox.Location = new Point(0, 3);
			KafkaHostTextBox.Name = "KafkaHostTextBox";
			KafkaHostTextBox.PlaceholderText = "Kafka server address";
			KafkaHostTextBox.Size = new Size(776, 34);
			KafkaHostTextBox.TabIndex = 0;
			KafkaHostTextBox.MouseLeave += KafkaHostTextBox_Leave;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(932, 625);
			Controls.Add(TableLayoutPanel);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "MainForm";
			Text = "KafkaDestroyer";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			KeyDown += MainForm_KeyDown;
			SplitContainer.Panel1.ResumeLayout(false);
			SplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
			SplitContainer.ResumeLayout(false);
			TableLayoutPanel.ResumeLayout(false);
			TableLayoutPanel.PerformLayout();
			TopPanel.ResumeLayout(false);
			TopPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private SplitContainer SplitContainer;
		private TableLayoutPanel TableLayoutPanel;
		private Panel TopPanel;
		private Controls.TopicsControlList TopicsListControl;
		private Controls.RoundedTextBox KafkaHostTextBox;
		private Controls.MessageEditor MessageEditor;
		private Controls.MessagesControlList MessagesControlList;
		private Controls.RoundedLabel ChooseTopicLabel;
		private Controls.RoundedButton TestConnectionBtn;
	}
}
