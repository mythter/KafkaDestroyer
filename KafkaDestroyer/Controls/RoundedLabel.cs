using System.Drawing.Drawing2D;

namespace KafkaDestroyer.Controls
{
	public partial class RoundedLabel : Label
	{
		public int CornerRadius { get; set; }
		public Color FillColor { get; set; }
		public Color BorderColor { get; set; }
		public int BorderThickness { get; set; }

		public RoundedLabel()
		{
			BackColor = Color.Transparent;
			ForeColor = Color.Black;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			var rect = ClientRectangle;
			rect.Width -= 1;
			rect.Height -= 1;

			using var path = GetRoundedRectanglePath(rect, CornerRadius);
			using var backgroundBrush = new SolidBrush(FillColor);
			using var borderPen = new Pen(BorderColor, BorderThickness);

			e.Graphics.FillPath(backgroundBrush, path);
			e.Graphics.DrawPath(borderPen, path);

			var flags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

			flags |= TextAlign switch
			{
				ContentAlignment.TopLeft => TextFormatFlags.Top | TextFormatFlags.Left,
				ContentAlignment.TopCenter => TextFormatFlags.Top | TextFormatFlags.HorizontalCenter,
				ContentAlignment.TopRight => TextFormatFlags.Top | TextFormatFlags.Right,

				ContentAlignment.MiddleLeft => TextFormatFlags.VerticalCenter | TextFormatFlags.Left,
				ContentAlignment.MiddleCenter => TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
				ContentAlignment.MiddleRight => TextFormatFlags.VerticalCenter | TextFormatFlags.Right,

				ContentAlignment.BottomLeft => TextFormatFlags.Bottom | TextFormatFlags.Left,
				ContentAlignment.BottomCenter => TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter,
				ContentAlignment.BottomRight => TextFormatFlags.Bottom | TextFormatFlags.Right,

				_ => TextFormatFlags.Left | TextFormatFlags.Top
			};

			var textRect = Rectangle.Inflate(rect, -Padding.Horizontal / 2, -Padding.Vertical / 2);

			TextRenderer.DrawText(
				e.Graphics,
				Text,
				Font,
				textRect,
				ForeColor,
				flags
			);
		}

		private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
		{
			var path = new GraphicsPath();
			int diameter = radius * 2;

			if (radius <= 0)
			{
				path.AddRectangle(rect);
			}
			else
			{
				path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
				path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
				path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
				path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
				path.CloseFigure();
			}

			return path;
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			Invalidate();
		}
	}
}
