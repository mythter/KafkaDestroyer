namespace KafkaDestroyer.Controls
{
	public partial class GapableList : UserControl
	{
		private readonly List<Control> _controls = new List<Control>();
		private int _gap = 6;

		public int Gap
		{
			get => _gap;
			set
			{
				_gap = value;
				RepositionControls();
			}
		}

		public GapableList()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			_controls.Clear();
			ContainerPanel.Controls.Clear();

			ContainerPanel.AutoScrollPosition = Point.Empty;
			ContainerPanel.AutoScrollMinSize = Size.Empty;
		}

		public void Add(Control control)
		{
			if (control == null) return;

			_controls.Add(control);
			ContainerPanel.Controls.Add(control);
			RepositionControls();
		}

		public void Remove(Control control)
		{
			if (control == null || !_controls.Contains(control)) return;

			_controls.Remove(control);
			ContainerPanel.Controls.Remove(control);
			control.Dispose();
			RepositionControls();
		}

		public ControlCollection GetControls()
		{
			return ContainerPanel.Controls;
		}

		private void RepositionControls()
		{
			int y = 0;
			foreach (var ctrl in _controls)
			{
				ctrl.Location = new Point(0, y);
				ctrl.Width = ContainerPanel.ClientSize.Width;
				ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				y += ctrl.Height + Gap;
			}

			ContainerPanel.AutoScrollMinSize = new Size(0, y);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			var scrollPos = ContainerPanel.AutoScrollPosition;

			ContainerPanel.AutoScroll = false;
			RepositionControls();
			ContainerPanel.AutoScroll = true;

			if (ContainerPanel.VerticalScroll.Visible)
			{
				ContainerPanel.AutoScrollPosition = new Point(0, -scrollPos.Y);
			}
		}
	}
}
