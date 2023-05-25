namespace EventHubProcessors;

using System.Diagnostics.CodeAnalysis;
using Azure.Messaging.EventHubs.Primitives;

/// <summary>
/// EventHubFixedPartitionProcessorOptions class.
/// </summary>
[ExcludeFromCodeCoverage]
public class EventHubFixedPartitionProcessorOptions : EventProcessorOptions
{
    /// <summary>
    /// Gets or sets the maximum number of partitions.
    /// </summary>
    public int MaxPartitions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to checkpoint or not.
    /// </summary>
    public bool ShouldCheckpoint { get; set; }
}
