using System.Drawing.Imaging;

namespace KafkaDestroyer.Extensions
{
	public static class ButtonExtensions
	{
		public static void ChangeButtonState(this Button button, bool enabled)
		{
			if (button.Enabled == enabled)
				return;

			button.Enabled = enabled;

			if (enabled)
			{
				if (button.Tag is Image originalImage)
				{
					button.BackgroundImage = originalImage;
					button.Tag = null;
				}
			}
			else
			{
				if (button.BackgroundImage != null && button.Tag == null)
				{
					button.Tag = (Image)button.BackgroundImage.Clone();
				}

				if (button.BackgroundImage != null)
				{
					button.BackgroundImage = CreateDimmedImage(button.BackgroundImage, 0.4f);
				}
			}
		}

		private static Image CreateDimmedImage(Image image, float opacity)
		{
			Bitmap bmp = new Bitmap(image.Width, image.Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				ColorMatrix matrix = new ColorMatrix
				{
					Matrix33 = opacity
				};

				ImageAttributes attributes = new ImageAttributes();
				attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

				g.DrawImage(
					image,
					new Rectangle(0, 0, image.Width, image.Height),
					0, 0, image.Width, image.Height,
					GraphicsUnit.Pixel,
					attributes);
			}
			return bmp;
		}
	}
}
