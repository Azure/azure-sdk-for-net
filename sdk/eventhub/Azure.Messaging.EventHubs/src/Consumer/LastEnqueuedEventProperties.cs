// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   A set of information about the enqueued state of a partition, as observed by the consumer.
    /// </summary>
    ///
    public struct LastEnqueuedEventProperties
    {
        /// <summary>
        ///   The sequence number of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long? SequenceNumber { get; }

        /// <summary>
        ///   The offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long? Offset { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last observed event was enqueued in the partition.
        /// </summary>
        ///
        public DateTimeOffset? EnqueuedTime { get; }

        /// <summary>
        ///   The date and time, in UTC, that the information about the last enqueued event was received.
        /// </summary>
        ///
        public DateTimeOffset? LastReceivedTime { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        public LastEnqueuedEventProperties(long? lastSequenceNumber,
                                           long? lastOffset,
                                           DateTimeOffset? lastEnqueuedTime,
                                           DateTimeOffset? lastReceivedTime)
        {
            SequenceNumber = lastSequenceNumber;
            Offset = lastOffset;
            EnqueuedTime = lastEnqueuedTime;
            LastReceivedTime = lastReceivedTime;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="sourceEvent">The event to use as the source for the partition information.</param>
        ///
        internal LastEnqueuedEventProperties(EventData sourceEvent) :
            this(sourceEvent?.LastPartitionSequenceNumber,
                 sourceEvent?.LastPartitionOffset,
                 sourceEvent?.LastPartitionEnqueuedTime,
                 sourceEvent?.LastPartitionPropertiesRetrievalTime)
        {
        }
    }
}
