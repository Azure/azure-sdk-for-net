namespace EventHubProcessors;

using System;

/// <summary>
/// An exception thrown if a partition ID is not an integer between 0 and 31.
/// </summary>
public class PartitionIdOutOfRangeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PartitionIdOutOfRangeException"/> class.
    /// </summary>
    /// <param name="partitionId">The partition ID.</param>
    public PartitionIdOutOfRangeException(string partitionId)
        : base($"this processor is only designed to work with partition IDs that are integers between 0 and 31, not '{partitionId}'.")
    {
    }
}