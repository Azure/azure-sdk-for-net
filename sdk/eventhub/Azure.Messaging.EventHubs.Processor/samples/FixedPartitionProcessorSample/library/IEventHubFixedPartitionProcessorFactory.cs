namespace EventHubProcessors;

using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;

/// <summary>
/// A factory to get or create EventHubFixedPartitionProcessor. This should be registered as a singleton.
/// </summary>
public interface IEventHubFixedPartitionProcessorFactory
{
    /// <summary>
    /// Get an existing instance.
    /// </summary>
    /// <returns>An EventHubFixedPartitionProcessor.</returns>
    Task<EventHubFixedPartitionProcessor> GetAsync();

    /// <summary>
    /// Get an existing instance or create a new instance.
    /// </summary>
    /// <param name="startingPosition">The starting position unless checkpoints are found and used.</param>
    /// <param name="shouldCheckpoint">Whether the processor should checkpoint.</param>
    /// <returns>An EventHubFixedPartitionProcessor.</returns>
    Task<EventHubFixedPartitionProcessor> GetOrCreateAsync(EventPosition startingPosition, bool shouldCheckpoint);
}
