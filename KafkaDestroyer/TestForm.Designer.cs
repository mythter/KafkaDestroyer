namespace KafkaDestroyer
{
	partial class TestForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			roundButton1 = new KafkaDestroyer.Controls.RoundButton();
			roundedButton1 = new KafkaDestroyer.Controls.RoundedButton();
			roundedButton2 = new KafkaDestroyer.Controls.RoundedButton();
			richTextBox1 = new RichTextBox();
			SuspendLayout();
			// 
			// roundButton1
			// 
			roundButton1.BackColor = Color.LightGray;
			roundButton1.BorderColor = Color.Transparent;
			roundButton1.BorderThickness = 0;
			roundButton1.CornerRadius = 10;
			roundButton1.FillColor = Color.DodgerBlue;
			roundButton1.Location = new Point(476, 198);
			roundButton1.Name = "roundButton1";
			roundButton1.Size = new Size(94, 29);
			roundButton1.TabIndex = 0;
			roundButton1.Text = "roundButton1";
			roundButton1.UseVisualStyleBackColor = false;
			// 
			// roundedButton1
			// 
			roundedButton1.BackColor = SystemColors.ActiveCaption;
			roundedButton1.BackgroundColor = SystemColors.ActiveCaption;
			roundedButton1.BorderColor = Color.PaleVioletRed;
			roundedButton1.BorderSize = 0;
			roundedButton1.CornerRadius = 10;
			roundedButton1.FlatStyle = FlatStyle.Flat;
			roundedButton1.ForeColor = Color.White;
			roundedButton1.Location = new Point(276, 115);
			roundedButton1.Name = "roundedButton1";
			roundedButton1.Size = new Size(94, 29);
			roundedButton1.TabIndex = 1;
			roundedButton1.Text = "roundedButton1";
			roundedButton1.TextColor = Color.White;
			roundedButton1.UseVisualStyleBackColor = false;
			// 
			// roundedButton2
			// 
			roundedButton2.BackColor = Color.LightGray;
			roundedButton2.BackgroundColor = Color.LightGray;
			roundedButton2.BackgroundImage = Properties.Resources.trash_gray;
			roundedButton2.BackgroundImageLayout = ImageLayout.Zoom;
			roundedButton2.BorderColor = Color.DimGray;
			roundedButton2.BorderSize = 1;
			roundedButton2.CornerRadius = 10;
			roundedButton2.FlatStyle = FlatStyle.Flat;
			roundedButton2.ForeColor = Color.White;
			roundedButton2.Location = new Point(486, 97);
			roundedButton2.Name = "roundedButton2";
			roundedButton2.Size = new Size(51, 47);
			roundedButton2.TabIndex = 2;
			roundedButton2.TextColor = Color.White;
			roundedButton2.UseVisualStyleBackColor = false;
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(79, 12);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(307, 46);
			richTextBox1.TabIndex = 3;
			richTextBox1.Text = "";
			// 
			// TestForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(richTextBox1);
			Controls.Add(roundedButton2);
			Controls.Add(roundedButton1);
			Controls.Add(roundButton1);
			Name = "TestForm";
			Text = "TestForm";
			ResumeLayout(false);
		}

		#endregion

		private Controls.RoundButton roundButton1;
		private Controls.RoundedButton roundedButton1;
		private Controls.RoundedButton roundedButton2;
		private RichTextBox richTextBox1;
	}
}