using System.ComponentModel;

namespace KafkaDestroyer.Controls
{
	public partial class EditableLabel : UserControl
	{
		private Color _viewBackColor = Color.Transparent;
		private Color _editBackColor = SystemColors.Window;

		[Browsable(true)]
		[Category("Appearance")]
		[Description("Background color in view (label) mode.")]
		public Color ViewBackColor
		{
			get => _viewBackColor;
			set
			{
				_viewBackColor = value;
				ReadonlyLabel.BackColor = value;
				Invalidate();
			}
		}

		[Browsable(true)]
		[Category("Appearance")]
		[Description("Background color in edit (textbox) mode.")]
		public Color EditBackColor
		{
			get => _editBackColor;
			set
			{
				_editBackColor = value;
				EditableTextBox.BackColor = value;
				Invalidate();
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override string Text
		{
			get => ReadonlyLabel.Text;
			set
			{
				EditableTextBox.Text = value;
				ReadonlyLabel.Text = value;
			}
		}

		public bool Editing => EditableTextBox.Visible;


		public new event EventHandler? Click;

		public new event EventHandler? MouseEnter;

		public new event EventHandler? MouseLeave;

		public event EventHandler? EditingStarted;

		public EditableLabel()
		{
			InitializeComponent();

			SubscribeMouseEnter(this);
			SubscribeMouseLeave(this);

			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			ViewBackColor = Color.Transparent;
			EditBackColor = SystemColors.Window;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			if (string.IsNullOrEmpty(Text))
				return base.GetPreferredSize(proposedSize);

			using (var tempBox = new TextBox())
			{
				tempBox.Font = this.Font;
				Size textSize = TextRenderer.MeasureText(Text, Font);
				int height = tempBox.PreferredHeight;

				return new Size(textSize.Width + Padding.Horizontal, height + Padding.Vertical);
			}
		}

		private void SubscribeMouseEnter(Control control)
		{
			control.MouseEnter += Control_MouseEnter;

			foreach (Control child in control.Controls)
			{
				SubscribeMouseEnter(child);
			}
		}

		private void SubscribeMouseLeave(Control control)
		{
			control.MouseLeave += Control_MouseLeave;

			foreach (Control child in control.Controls)
			{
				SubscribeMouseLeave(child);
			}
		}

		private void Control_Click(object? sender, EventArgs e)
		{
			Click?.Invoke(this, e);
		}

		private void Control_MouseEnter(object? sender, EventArgs e)
		{
			MouseEnter?.Invoke(this, e);
		}

		private void Control_MouseLeave(object? sender, EventArgs e)
		{
			MouseLeave?.Invoke(this, e);
		}

		private void ReadonlyLabel_DoubleClick(object? sender, EventArgs e)
		{
			EditingStarted?.Invoke(this, e);
			EnterEditMode();
		}

		private void EnterEditMode()
		{
			EditableTextBox.Text = ReadonlyLabel.Text;
			EditableTextBox.Visible = true;
			ReadonlyLabel.Visible = false;
			EditableTextBox.Focus();
			EditableTextBox.SelectAll();
		}

		private void ExitEditMode(bool saveChanges)
		{
			if (saveChanges)
			{
				ReadonlyLabel.Text = EditableTextBox.Text;
			}

			EditableTextBox.Visible = false;
			ReadonlyLabel.Visible = true;
		}

		private void EditableTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ExitEditMode(saveChanges: true);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				ExitEditMode(saveChanges: false);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void TextBox_Leave(object sender, EventArgs e)
		{
			Text = EditableTextBox.Text;
			EditableTextBox.Visible = false;
			ReadonlyLabel.Visible = true;
			Invalidate();
		}
	}
}
