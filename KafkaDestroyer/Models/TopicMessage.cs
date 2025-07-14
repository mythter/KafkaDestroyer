using System.Text.Json.Serialization;

using KafkaDestroyer.Interfaces;

namespace KafkaDestroyer.Models
{
	public class TopicMessage : ITopicMessage
	{
		public Guid Id { get; } = Guid.NewGuid();
		public string Title { get; private set; }
		public string? Key { get; set; }
		public string? Body { get; set; }

		public TopicMessage(string title)
		{
			Title = title;
		}

		[JsonConstructor]
		public TopicMessage(Guid id, string title, string? key, string? body)
		{
			Id = id;
			Title = title;
			Key = key;
			Body = body;
		}

		public void SetTitle(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));

			Title = title;
		}
	}
}
