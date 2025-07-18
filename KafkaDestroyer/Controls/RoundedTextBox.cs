﻿using System.ComponentModel;

namespace KafkaDestroyer.Controls
{
	public partial class RoundedTextBox : TextBox
	{
		[System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect, // X-coordinate of upper-left corner or padding at start
			int nTopRect,// Y-coordinate of upper-left corner or padding at the top of the textbox
			int nRightRect, // X-coordinate of lower-right corner or Width of the object
			int nBottomRect,// Y-coordinate of lower-right corner or Height of the object
			int nheightRect, //height of ellipse 
			int nweightRect //width of ellipse
		);

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int CornerRadius { get; set; } = 0;

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Region = Region.FromHrgn(CreateRoundRectRgn(2, 3, Width, Height, CornerRadius, CornerRadius));
		}
	}
}
