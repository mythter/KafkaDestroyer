using System.Text.Json.Serialization;

namespace KafkaDestroyer.Models
{
	public class KafkaTopic
	{
		public string Name { get; set; }

		public List<TopicMessage> Messages { get; } = [];

		public KafkaTopic(string name)
		{
			Name = name;
		}

		[JsonConstructor]
		public KafkaTopic(string name, List<TopicMessage> messages)
		{
			Name = name;
			Messages = messages ?? [];
		}
	}
}
