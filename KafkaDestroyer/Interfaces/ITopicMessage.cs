namespace KafkaDestroyer.Interfaces
{
	public interface ITopicMessage
	{
		Guid Id { get; }
		string Title { get; }
		string? Key { get; }
		string? Body { get; }
	}
}
