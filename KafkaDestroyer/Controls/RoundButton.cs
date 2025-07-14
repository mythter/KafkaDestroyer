using System.Drawing.Drawing2D;

namespace KafkaDestroyer.Controls
{
	public class RoundButton : Button
	{
		public int CornerRadius { get; set; }

		public Color FillColor { get; set; } = Color.DodgerBlue;
		public Color BorderColor { get; set; } = Color.Black;
		public int BorderThickness { get; set; } = 4;

		public RoundButton()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw, true);
			DoubleBuffered = true;
			BackColor = Color.LightGray;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			using var path = GetRoundedRectanglePath(ClientRectangle, CornerRadius);
			Region = new Region(path);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (Parent != null)
			{
				using var brush = new SolidBrush(Parent.BackColor);
				e.Graphics.FillRectangle(brush, ClientRectangle);
			}
			else
			{
				base.OnPaintBackground(e);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			float borderHalf = BorderThickness / 2f;

			var rect = new RectangleF(
				borderHalf,
				borderHalf,
				Width - BorderThickness,
				Height - BorderThickness
			);

			using var path = GetRoundedRectanglePath(rect, CornerRadius);
			e.Graphics.SetClip(path);

			// 🔲 1. Заливаем FillColor или BackColor
			using (var fillBrush = new SolidBrush(FillColor.IsEmpty ? this.BackColor : FillColor))
			{
				e.Graphics.FillPath(fillBrush, path);
			}

			// 🖼️ 2. Рисуем изображение поверх заливки
			if (BackgroundImage != null)
			{
				Rectangle destRect = GetBackgroundImageRectangle(BackgroundImage, BackgroundImageLayout, ClientRectangle);
				e.Graphics.DrawImage(BackgroundImage, destRect);
			}

			e.Graphics.ResetClip();

			// 🔲 3. Рисуем границу
			using var borderPen = new Pen(BorderColor, BorderThickness) { Alignment = PenAlignment.Inset };
			e.Graphics.DrawPath(borderPen, path);

			// 📝 4. Текст
			TextRenderer.DrawText(
				e.Graphics,
				Text,
				Font,
				Rectangle.Round(rect),
				ForeColor,
				TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
			);
		}



		private GraphicsPath GetRoundedRectanglePath(RectangleF rect, int radius)
		{
			GraphicsPath path = new();
			float diameter = radius * 2;

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

		private void DrawZoomedImage(Graphics g, Image image, Rectangle bounds)
		{
			float imgRatio = (float)image.Width / image.Height;
			float boundsRatio = (float)bounds.Width / bounds.Height;

			Rectangle destRect;

			if (imgRatio > boundsRatio)
			{
				int width = bounds.Width;
				int height = (int)(width / imgRatio);
				int y = bounds.Top + (bounds.Height - height) / 2;
				destRect = new Rectangle(bounds.Left, y, width, height);
			}
			else
			{
				int height = bounds.Height;
				int width = (int)(height * imgRatio);
				int x = bounds.Left + (bounds.Width - width) / 2;
				destRect = new Rectangle(x, bounds.Top, width, height);
			}

			g.DrawImage(image, destRect);
		}

		private Rectangle GetBackgroundImageRectangle(Image image, ImageLayout layout, Rectangle bounds)
		{
			switch (layout)
			{
				case ImageLayout.Stretch:
					return bounds;

				case ImageLayout.Zoom:
					{
						float imgRatio = (float)image.Width / image.Height;
						float boundsRatio = (float)bounds.Width / bounds.Height;

						if (imgRatio > boundsRatio)
						{
							int width = bounds.Width;
							int height = (int)(width / imgRatio);
							int y = bounds.Top + (bounds.Height - height) / 2;
							return new Rectangle(bounds.Left, y, width, height);
						}
						else
						{
							int height = bounds.Height;
							int width = (int)(height * imgRatio);
							int x = bounds.Left + (bounds.Width - width) / 2;
							return new Rectangle(x, bounds.Top, width, height);
						}
					}

				case ImageLayout.Center:
					return new Rectangle(
						bounds.Left + (bounds.Width - image.Width) / 2,
						bounds.Top + (bounds.Height - image.Height) / 2,
						image.Width,
						image.Height);

				case ImageLayout.None:
					return new Rectangle(bounds.Left, bounds.Top, image.Width, image.Height);

				case ImageLayout.Tile:
					// Для Tile лучше реализовать отдельно, например через TextureBrush
					// Если нужно, могу показать пример
					return bounds;

				default:
					return bounds;
			}
		}

	}
}
