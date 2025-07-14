using KafkaDestroyer.Interfaces;

namespace KafkaDestroyer.Models
{
	public class TopicMessageUpdate : ITopicMessage
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string? Key { get; set; }
		public string? Body { get; set; }

		public TopicMessageUpdate(Guid id, string title, string? key = null, string? body = null)
		{
			Id = id;
			Title = title;
			Key = key;
			Body = body;
		}
	}
}
