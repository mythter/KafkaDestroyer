using System.Text.Json;

using KafkaDestroyer.Models;

namespace KafkaDestroyer.Managers
{
	public static class StorageManager
	{
		private static readonly string FilePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			"KafkaDestroyer",
			"user_messages.json");

		private static readonly KafkaServers _data;

		private static readonly JsonSerializerOptions _jsonSerializerOptions;

		static StorageManager()
		{
			_data = LoadData();

			_jsonSerializerOptions = new JsonSerializerOptions
			{
				WriteIndented = true
			};
		}

		private static KafkaServers LoadData()
		{
			if (File.Exists(FilePath))
			{
				var json = File.ReadAllText(FilePath);
				return JsonSerializer.Deserialize<KafkaServers>(json) ?? new KafkaServers();
			}

			return new KafkaServers();
		}

		private static void SaveData()
		{
			Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
			var json = JsonSerializer.Serialize(_data, _jsonSerializerOptions);
			File.WriteAllText(FilePath, json);
		}

		public static void DeleteTopic(string kafkaAddress, string topicName)
		{
			if (_data.Servers.TryGetValue(kafkaAddress, out var server) &&
				server.Topics.Find(t => t.Name == topicName) is { } topicToRemove)
			{
				server.Topics.Remove(topicToRemove);
				SaveData();
			}
		}

		public static void SyncTopics(string kafkaAddress, List<string> actualTopics)
		{
			if (_data.Servers.TryGetValue(kafkaAddress, out var server))
			{
				var topicsToRemove = server.Topics
					.Where(t => actualTopics.Contains(t.Name))
					.ToList();

				foreach (var topic in topicsToRemove)
				{
					server.Topics.Remove(topic);
				}

				SaveData();
			}
		}

		public static List<TopicMessage>? GetMessages(string kafkaAddress, string topicName)
		{
			if (_data.Servers.TryGetValue(kafkaAddress, out var server) &&
				server.Topics.Find(t => t.Name == topicName) is { } topic)
			{
				return topic.Messages;
			}

			return null;
		}

		public static TopicMessage AddMessage(string kafkaAddress, string topicName, string title, string? body = null, string ? key = null)
		{
			if (!_data.Servers.TryGetValue(kafkaAddress, out var server))
			{
				server = new KafkaServerData();
				_data.Servers[kafkaAddress] = server;
			}

			var topic = server.Topics.Find(t => t.Name == topicName);

			if (topic is null)
			{
				topic = new KafkaTopic(topicName);
				server.Topics.Add(topic);
			}

			var message = new TopicMessage(title)
			{
				Key = key,
				Body = body
			};

			topic.Messages.Add(message);

			SaveData();

			return message;
		}

		public static bool UpdateMessage(string kafkaAddress, string topicName, TopicMessageUpdate message)
		{
			if (_data.Servers.TryGetValue(kafkaAddress, out var server) &&
				server.Topics.Find(t => t.Name == topicName) is { } topic)
			{
				var msg = topic.Messages.SingleOrDefault(m => m.Id == message.Id);
				if (msg != null)
				{
					msg.SetTitle(message.Title);
					msg.Key = message.Key;
					msg.Body = message.Body;

					SaveData();

					return true;
				}
			}

			return false;
		}

		public static bool DeleteMessage(string kafkaAddress, string topicName, Guid messageId)
		{
			if (_data.Servers.TryGetValue(kafkaAddress, out var server) &&
				server.Topics.Find(t => t.Name == topicName) is { } topic)
			{
				var msg = topic.Messages.SingleOrDefault(m => m.Id == messageId);
				if (msg != null)
				{
					topic.Messages.Remove(msg);

					SaveData();

					return true;
				}
			}

			return false;
		}
	}
}
