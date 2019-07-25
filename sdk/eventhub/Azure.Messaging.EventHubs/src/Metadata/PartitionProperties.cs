// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Metadata
{
    /// <summary>
    ///   A set of information for a single partition of an Event Hub.
    /// </summary>
    ///
    public sealed class PartitionProperties
    {
        /// <summary>
        ///   The path of the Event Hub that contains the partitions, relative to the namespace
        ///   that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; }

        /// <summary>
        ///   The identifier of the partition, unique to the Event Hub which contains it.
        /// </summary>
        ///
        public string Id { get; }

        /// <summary>
        ///   The first sequence number available for events in the partition.
        /// </summary>
        ///
        public long BeginningSequenceNumber { get; }

        /// <summary>
        ///   The sequence number observed the last event to be enqueued in the partition.
        /// </summary>
        ///
        public long LastEnqueuedSequenceNumber { get; }

        /// <summary>
        ///   The offset of the last event to be enqueued in the partition.
        /// </summary>
        ///
        /// <remarks>
        ///   The offset is the relative position for event in the context of the stream.  The offset
        ///   should not be considered a stable value, as the same offset may refer to a different event
        ///   as events reach the age limit for retention and are no longer visible within the stream.
        /// </remarks>
        ///
        public long LastEnqueuedOffset { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last event was enqueued in the partition.
        /// </summary>
        ///
        public DateTimeOffset LastEnqueuedTime { get; }

        /// <summary>
        ///   Indicates whether or not the partition is currently empty.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the partition is empty; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsEmpty { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionProperties"/> class.
        /// </summary>
        ///
        /// <param name="path">The path of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        ///
        internal PartitionProperties(string path,
                                     string partitionId,
                                     long beginningSequenceNumber,
                                     long lastSequenceNumber,
                                     long lastOffset,
                                     DateTimeOffset lastEnqueuedTime,
                                     bool isEmpty)
        {
            EventHubPath = path;
            Id = partitionId;
            BeginningSequenceNumber = beginningSequenceNumber;
            LastEnqueuedSequenceNumber = lastSequenceNumber;
            LastEnqueuedOffset = lastOffset;
            LastEnqueuedTime = lastEnqueuedTime;
            IsEmpty = isEmpty;
        }
    }
}
