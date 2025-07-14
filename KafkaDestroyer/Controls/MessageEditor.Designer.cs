namespace KafkaDestroyer.Controls
{
	partial class MessageEditor
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
			MessageWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
			MessageEditorTopPanel = new Panel();
			MessageTitleTextBox = new RoundedTextBox();
			MessageTitleLabel = new Label();
			SendMessageBtn = new RoundedButton();
			SaveChangesBtn = new RoundedButton();
			BackBtn = new RoundedButton();
			MessageKeyTextBox = new RoundedTextBox();
			MessageKeyLabel = new Label();
			((System.ComponentModel.ISupportInitialize)MessageWebView).BeginInit();
			MessageEditorTopPanel.SuspendLayout();
			SuspendLayout();
			// 
			// MessageWebView
			// 
			MessageWebView.AllowExternalDrop = true;
			MessageWebView.CreationProperties = null;
			MessageWebView.DefaultBackgroundColor = Color.White;
			MessageWebView.Dock = DockStyle.Fill;
			MessageWebView.Location = new Point(0, 41);
			MessageWebView.Name = "MessageWebView";
			MessageWebView.Size = new Size(680, 578);
			MessageWebView.TabIndex = 0;
			MessageWebView.ZoomFactor = 1D;
			// 
			// MessageEditorTopPanel
			// 
			MessageEditorTopPanel.AutoSize = true;
			MessageEditorTopPanel.BackColor = Color.Transparent;
			MessageEditorTopPanel.Controls.Add(MessageTitleTextBox);
			MessageEditorTopPanel.Controls.Add(MessageTitleLabel);
			MessageEditorTopPanel.Controls.Add(SendMessageBtn);
			MessageEditorTopPanel.Controls.Add(SaveChangesBtn);
			MessageEditorTopPanel.Controls.Add(BackBtn);
			MessageEditorTopPanel.Controls.Add(MessageKeyTextBox);
			MessageEditorTopPanel.Controls.Add(MessageKeyLabel);
			MessageEditorTopPanel.Dock = DockStyle.Top;
			MessageEditorTopPanel.Location = new Point(0, 0);
			MessageEditorTopPanel.Name = "MessageEditorTopPanel";
			MessageEditorTopPanel.Size = new Size(680, 41);
			MessageEditorTopPanel.TabIndex = 1;
			// 
			// MessageTitleTextBox
			// 
			MessageTitleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			MessageTitleTextBox.BackColor = Color.Silver;
			MessageTitleTextBox.BorderStyle = BorderStyle.FixedSingle;
			MessageTitleTextBox.CornerRadius = 7;
			MessageTitleTextBox.Font = new Font("Segoe UI", 11F);
			MessageTitleTextBox.Location = new Point(338, 1);
			MessageTitleTextBox.Margin = new Padding(3, 3, 3, 8);
			MessageTitleTextBox.Name = "MessageTitleTextBox";
			MessageTitleTextBox.PlaceholderText = "Title";
			MessageTitleTextBox.Size = new Size(193, 32);
			MessageTitleTextBox.TabIndex = 13;
			// 
			// MessageTitleLabel
			// 
			MessageTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			MessageTitleLabel.AutoSize = true;
			MessageTitleLabel.Font = new Font("Segoe UI", 10F);
			MessageTitleLabel.ForeColor = Color.WhiteSmoke;
			MessageTitleLabel.Location = new Point(290, 6);
			MessageTitleLabel.Name = "MessageTitleLabel";
			MessageTitleLabel.Size = new Size(42, 23);
			MessageTitleLabel.TabIndex = 12;
			MessageTitleLabel.Text = "Title";
			// 
			// SendMessageBtn
			// 
			SendMessageBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			SendMessageBtn.BackColor = Color.DimGray;
			SendMessageBtn.BackgroundColor = Color.DimGray;
			SendMessageBtn.BackgroundImageLayout = ImageLayout.Zoom;
			SendMessageBtn.BorderColor = Color.Transparent;
			SendMessageBtn.BorderSize = 0;
			SendMessageBtn.CornerRadius = 7;
			SendMessageBtn.FlatAppearance.BorderSize = 0;
			SendMessageBtn.FlatStyle = FlatStyle.Flat;
			SendMessageBtn.Font = new Font("Segoe UI", 11F);
			SendMessageBtn.ForeColor = Color.White;
			SendMessageBtn.Location = new Point(577, 0);
			SendMessageBtn.Name = "SendMessageBtn";
			SendMessageBtn.Size = new Size(101, 34);
			SendMessageBtn.TabIndex = 11;
			SendMessageBtn.Text = "Send";
			SendMessageBtn.TextColor = Color.White;
			SendMessageBtn.UseVisualStyleBackColor = false;
			SendMessageBtn.Click += SendMessageBtn_Click;
			// 
			// SaveChangesBtn
			// 
			SaveChangesBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			SaveChangesBtn.BackColor = Color.DimGray;
			SaveChangesBtn.BackgroundColor = Color.DimGray;
			SaveChangesBtn.BackgroundImage = Properties.Resources.floppy_disk_gray;
			SaveChangesBtn.BackgroundImageLayout = ImageLayout.Zoom;
			SaveChangesBtn.BorderColor = Color.Transparent;
			SaveChangesBtn.BorderSize = 0;
			SaveChangesBtn.CornerRadius = 7;
			SaveChangesBtn.FlatAppearance.BorderSize = 0;
			SaveChangesBtn.FlatStyle = FlatStyle.Flat;
			SaveChangesBtn.Font = new Font("Segoe UI", 11F);
			SaveChangesBtn.ForeColor = Color.White;
			SaveChangesBtn.Location = new Point(537, 0);
			SaveChangesBtn.Name = "SaveChangesBtn";
			SaveChangesBtn.Size = new Size(34, 34);
			SaveChangesBtn.TabIndex = 10;
			SaveChangesBtn.TextColor = Color.White;
			SaveChangesBtn.UseVisualStyleBackColor = false;
			SaveChangesBtn.Click += SaveChangesBtn_Click;
			// 
			// BackBtn
			// 
			BackBtn.BackColor = Color.DimGray;
			BackBtn.BackgroundColor = Color.DimGray;
			BackBtn.BackgroundImage = Properties.Resources.arrow_left_gray;
			BackBtn.BackgroundImageLayout = ImageLayout.Zoom;
			BackBtn.BorderColor = Color.Transparent;
			BackBtn.BorderSize = 0;
			BackBtn.CornerRadius = 7;
			BackBtn.FlatAppearance.BorderSize = 0;
			BackBtn.FlatStyle = FlatStyle.Flat;
			BackBtn.Font = new Font("Segoe UI", 11F);
			BackBtn.ForeColor = Color.White;
			BackBtn.Location = new Point(3, 0);
			BackBtn.Name = "BackBtn";
			BackBtn.Size = new Size(34, 34);
			BackBtn.TabIndex = 9;
			BackBtn.TextColor = Color.White;
			BackBtn.UseVisualStyleBackColor = false;
			BackBtn.Click += BackBtn_Click;
			// 
			// MessageKeyTextBox
			// 
			MessageKeyTextBox.BackColor = Color.Silver;
			MessageKeyTextBox.BorderStyle = BorderStyle.FixedSingle;
			MessageKeyTextBox.CornerRadius = 7;
			MessageKeyTextBox.Font = new Font("Segoe UI", 11F);
			MessageKeyTextBox.Location = new Point(86, 1);
			MessageKeyTextBox.Margin = new Padding(3, 3, 3, 8);
			MessageKeyTextBox.Name = "MessageKeyTextBox";
			MessageKeyTextBox.PlaceholderText = "Message key (optional)";
			MessageKeyTextBox.Size = new Size(198, 32);
			MessageKeyTextBox.TabIndex = 4;
			// 
			// MessageKeyLabel
			// 
			MessageKeyLabel.AutoSize = true;
			MessageKeyLabel.Font = new Font("Segoe UI", 10F);
			MessageKeyLabel.ForeColor = Color.WhiteSmoke;
			MessageKeyLabel.Location = new Point(43, 6);
			MessageKeyLabel.Name = "MessageKeyLabel";
			MessageKeyLabel.Size = new Size(37, 23);
			MessageKeyLabel.TabIndex = 0;
			MessageKeyLabel.Text = "Key";
			// 
			// MessageEditor
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(MessageWebView);
			Controls.Add(MessageEditorTopPanel);
			Name = "MessageEditor";
			Size = new Size(680, 619);
			((System.ComponentModel.ISupportInitialize)MessageWebView).EndInit();
			MessageEditorTopPanel.ResumeLayout(false);
			MessageEditorTopPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Microsoft.Web.WebView2.WinForms.WebView2 MessageWebView;
		private Panel MessageEditorTopPanel;
		private Label MessageKeyLabel;
		private RoundedTextBox MessageKeyTextBox;
		private RoundedButton BackBtn;
		private RoundedButton SendMessageBtn;
		private RoundedButton SaveChangesBtn;
		private RoundedTextBox MessageTitleTextBox;
		private Label MessageTitleLabel;
	}
}
