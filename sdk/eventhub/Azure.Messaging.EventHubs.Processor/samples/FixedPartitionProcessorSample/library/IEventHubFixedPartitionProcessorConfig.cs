namespace EventHubProcessors;

using System;

/// <summary>
/// The configuration for EventHubFixedPartitionProcessor.
/// </summary>
public interface IEventHubFixedPartitionProcessorConfig
{
    /// <summary>
    /// Gets the connection string for the storage account used for partitioning and checkpointing.
    /// </summary>
    string STORAGE_CONNSTRING { get; }

    /// <summary>
    /// Gets the name of the container in the storage account used for partitioning and checkpointing.
    /// </summary>
    string STORAGE_CONTAINER_NAME { get; }

    /// <summary>
    /// Gets the event hub connection string if it is provided via env instead of Key Vault.
    /// </summary>
    string INBOUND_EVENTHUB_CONNSTRING { get; }

    /// <summary>
    /// Gets the name of the consumer group for consuming enriched events.
    /// </summary>
    string INBOUND_EVENTHUB_CONSUMER_GROUP { get; }

    /// <summary>
    /// Gets the maximum number of events to process in a batch.
    /// </summary>
    int INBOUND_EVENTHUB_MAX_BATCH_SIZE { get; }

    /// <summary>
    /// Gets the maximum number of partitions that this processor can handle.
    /// </summary>
    public int ASSIGN_TO_X_PARTITIONS { get; }

    /// <summary>
    /// Gets the Azure blob leasing time in seconds.
    /// </summary>
    TimeSpan LEASE_FOR_X_SEC { get; }

    /// <summary>
    /// Gets the Azure blob renewal time in seconds.
    /// </summary>
    TimeSpan RENEW_EVERY_X_SEC { get; }
}