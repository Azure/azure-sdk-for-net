// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Metadata
{
    /// <summary>
    ///   A set of information about the enqueued state of a partition, as observed by the consumer.
    /// </summary>
    ///
    public class LastEnqueuedEventProperties
    {
        /// <summary>
        ///   The name of the Event Hub where the partitions reside, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The identifier of the partition, unique to the Event Hub which contains it.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The sequence number of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long? LastEnqueuedSequenceNumber { get; }

        /// <summary>
        ///   The offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long? LastEnqueuedOffset { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last observed event was enqueued in the partition.
        /// </summary>
        ///
        public DateTimeOffset? LastEnqueuedTime { get; }

        /// <summary>
        ///   The date and time, in UTC, that the information about the last enqueued event was received.
        /// </summary>
        ///
        public DateTimeOffset? InformationReceived { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        protected internal LastEnqueuedEventProperties(string eventHubName,
                                                       string partitionId,
                                                       long? lastSequenceNumber,
                                                       long? lastOffset,
                                                       DateTimeOffset? lastEnqueuedTime,
                                                       DateTimeOffset? lastReceivedTime)
        {
            EventHubName = eventHubName;
            PartitionId = partitionId;
            LastEnqueuedSequenceNumber = lastSequenceNumber;
            LastEnqueuedOffset = lastOffset;
            LastEnqueuedTime = lastEnqueuedTime;
            InformationReceived = lastReceivedTime;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="sourceEvent">The event to use as the source for the partition information.</param>
        ///
        internal LastEnqueuedEventProperties(string eventHubName,
                                             string partitionId,
                                             EventData sourceEvent) :
            this(eventHubName,
                 partitionId,
                 sourceEvent?.LastPartitionSequenceNumber,
                 sourceEvent?.LastPartitionOffset,
                 sourceEvent?.LastPartitionEnqueuedTime,
                 sourceEvent?.LastPartitionInformationRetrievalTime)
        {
        }
    }
}
