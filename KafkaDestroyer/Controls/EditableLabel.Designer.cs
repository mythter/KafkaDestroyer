namespace KafkaDestroyer.Controls
{
	partial class EditableLabel
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
			EditableTextBox = new TextBox();
			ReadonlyLabel = new Label();
			SuspendLayout();
			// 
			// EditableTextBox
			// 
			EditableTextBox.Dock = DockStyle.Fill;
			EditableTextBox.Location = new Point(0, 0);
			EditableTextBox.Multiline = true;
			EditableTextBox.Name = "EditableTextBox";
			EditableTextBox.Size = new Size(300, 50);
			EditableTextBox.TabIndex = 0;
			EditableTextBox.Visible = false;
			EditableTextBox.KeyDown += EditableTextBox_KeyDown;
			EditableTextBox.Leave += TextBox_Leave;
			// 
			// ReadonlyLabel
			// 
			ReadonlyLabel.Dock = DockStyle.Fill;
			ReadonlyLabel.Location = new Point(0, 0);
			ReadonlyLabel.Name = "ReadonlyLabel";
			ReadonlyLabel.Size = new Size(300, 50);
			ReadonlyLabel.TabIndex = 1;
			ReadonlyLabel.TextAlign = ContentAlignment.MiddleLeft;
			ReadonlyLabel.Click += Control_Click;
			ReadonlyLabel.DoubleClick += ReadonlyLabel_DoubleClick;
			// 
			// EditableLabel
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			Controls.Add(ReadonlyLabel);
			Controls.Add(EditableTextBox);
			Name = "EditableLabel";
			Size = new Size(300, 50);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox EditableTextBox;
		private Label ReadonlyLabel;
	}
}
