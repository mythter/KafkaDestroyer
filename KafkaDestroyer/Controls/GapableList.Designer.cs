﻿namespace KafkaDestroyer.Controls
{
	partial class GapableList
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
			ContainerPanel = new Panel();
			SuspendLayout();
			// 
			// ContainerPanel
			// 
			ContainerPanel.AutoScroll = true;
			ContainerPanel.Dock = DockStyle.Fill;
			ContainerPanel.Location = new Point(0, 0);
			ContainerPanel.Name = "ContainerPanel";
			ContainerPanel.Size = new Size(150, 150);
			ContainerPanel.TabIndex = 0;
			// 
			// GapableList
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(ContainerPanel);
			Name = "GapableList";
			ResumeLayout(false);
		}

		#endregion

		private Panel ContainerPanel;
	}
}
