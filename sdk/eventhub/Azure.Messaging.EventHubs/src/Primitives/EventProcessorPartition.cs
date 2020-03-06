// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   A set of contextual information about an Event Hub partition for which an
    ///   <see cref="EventProcessor{TPartition}" /> operation is being performed.
    /// </summary>
    ///
    /// <remarks>
    ///   This class represents a minimalist set of information and is intended to be
    ///   extended for scenarios which require additional context for partitions.
    /// </remarks>
    ///
    /// <seealso cref="EventProcessor{TPartition}" />
    ///
    public class EventProcessorPartition
    {
        /// <summary>
        ///   The identifier of the partition.
        /// </summary>
        ///
        public string PartitionId { get; internal set; }
    }
}
