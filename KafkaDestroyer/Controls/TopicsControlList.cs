using Confluent.Kafka;

using KafkaDestroyer.Extensions;

namespace KafkaDestroyer.Controls
{
	public partial class TopicsControlList : UserControl
	{
		private readonly List<RoundedLabel> _topicLabels = [];

		private RoundedLabel? _selectedLabel;

		public event EventHandler<string>? AddTopic;
		public event EventHandler<string?>? DeleteTopic;

		public event EventHandler? RefreshTopics;

		public event EventHandler<string>? SelectionChanged;

		public Color TopicBackColor { get; set; } = Color.LightGray;
		public Color TopicTextColor { get; set; } = SystemColors.ControlText;
		public Color TopicSelectedBackColor { get; set; } = Color.DodgerBlue;
		public Color TopicSelectedTextColor { get; set; } = Color.White;
		public Padding TopicMargin { get; set; } = new Padding(2);
		public Font TopicFont { get; set; } = SystemFonts.DefaultFont;
		public int? TopicHeight { get; set; }

		public int Gap { get; set; } = 5;

		public float TopicFontSize { get; set; } = 9;

		public string? SelectedTopic => _selectedLabel?.Text;

		public bool AddTopicBtnEnabled
		{
			get => AddTopicBtn.Enabled;
			set
			{
				AddTopicBtn.Enabled = value;
			}
		}

		public bool RefreshTopicsBtnEnabled
		{
			get => RefreshTopicsBtn.Enabled;
			set
			{
				RefreshTopicsBtn.ChangeButtonState(value);
			}
		}

		public string TopicNameText
		{
			get => TopicNameTextBox.Text;
			set
			{
				TopicNameTextBox.Text = value;
			}
		}

		private bool _controlsDisabled = true;
		public bool ControlsEnabled
		{
			get => _controlsDisabled;
			set
			{
				_controlsDisabled = value;
				ChangeControlsState(value);
			}
		}

		public bool AllowSelecting { get; set; } = true;

		public TopicsControlList()
		{
			InitializeComponent();

			DeleteTopicBtn.Enabled = false;

			TopicsList.Gap = Gap;
		}

		public void ClearTopics()
		{
			_topicLabels.Clear();
			TopicsList.Clear();
		}

		public void SetTopics(List<TopicMetadata>? topics)
		{
			ClearTopics();

			if (topics == null || topics.Count == 0)
			{
				return;
			}

			topics.ForEach(AddTopicInternal);
		}

		public void AddTopicToList(TopicMetadata topic)
		{
			AddTopicInternal(topic);
		}

		public void SetSelectedTopic(string? topicName)
		{
			if (string.IsNullOrEmpty(topicName))
			{
				return;
			}

			var label = _topicLabels.FirstOrDefault(label => label.Text == topicName);

			SetSelectedLabel(label);
		}

		private void AddTopicInternal(TopicMetadata topic)
		{
			if (topic == null || string.IsNullOrEmpty(topic.Topic))
				return;

			var label = new RoundedLabel
			{
				Text = topic.Topic,
				FillColor = TopicBackColor,
				ForeColor = TopicTextColor,
				Margin = TopicMargin,
				Font = new Font(TopicFont.FontFamily, TopicFontSize, FontStyle.Regular),
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleLeft,
				CornerRadius = 5,
			};

			if (TopicHeight > 0)
			{
				label.Height = TopicHeight.Value;
			}

			label.Click += TopicLabel_Click;

			_topicLabels.Add(label);
			TopicsList.Add(label);
		}

		private void ChangeControlsState(bool enabled)
		{
			AddTopicBtn.Enabled = enabled;
			DeleteTopicBtn.Enabled = enabled && _selectedLabel is not null;
			RefreshTopicsBtn.ChangeButtonState(enabled);
		}

		private void AddButton_Click(object? sender, EventArgs e)
		{
			AddTopic?.Invoke(this, TopicNameTextBox.Text);
		}

		private void DeleteButton_Click(object? sender, EventArgs e)
		{
			DeleteTopic?.Invoke(this, _selectedLabel?.Text);
		}

		private void RefreshTopicsBtn_Click(object sender, EventArgs e)
		{
			RefreshTopics?.Invoke(this, EventArgs.Empty);
		}

		private void TopicLabel_Click(object? sender, EventArgs e)
		{
			if (sender is not RoundedLabel clickedLabel || !AllowSelecting)
				return;

			SetSelectedLabel(clickedLabel);

			SelectionChanged?.Invoke(this, clickedLabel.Text);
		}

		private void SetSelectedLabel(RoundedLabel? label)
		{
			if (label is null)
			{
				return;
			}

			if (_selectedLabel != null)
			{
				_selectedLabel.FillColor = TopicBackColor;
				_selectedLabel.ForeColor = TopicTextColor;
			}

			_selectedLabel = label;
			_selectedLabel.FillColor = TopicSelectedBackColor;
			_selectedLabel.ForeColor = TopicSelectedTextColor;
			DeleteTopicBtn.Enabled = ControlsEnabled;
		}
	}
}
