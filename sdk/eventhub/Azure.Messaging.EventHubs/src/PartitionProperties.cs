// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A set of information for a single partition of an Event Hub.
    /// </summary>
    ///
    public class PartitionProperties
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
        public string Id { get; }

        /// <summary>
        ///   The first sequence number available for events in the partition.
        /// </summary>
        ///
        public long BeginningSequenceNumber { get; }

        /// <summary>
        ///   The sequence number of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long LastEnqueuedSequenceNumber { get; }

        /// <summary>
        ///   The offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        [Obsolete(AttributeMessageText.LongLastEnqueuedOffsetOffsetObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long LastEnqueuedOffset
        {
            get
            {
                if (long.TryParse(LastEnqueuedOffsetString, out var value))
                {
                    return value;
                }

                throw new NotSupportedException(Resources.LongLastEnqueuedOffsetOffsetUnsupported);
            }
        }

        /// <summary>
        ///   The offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public string LastEnqueuedOffsetString { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last observed event was enqueued in the partition.
        /// </summary>
        ///
        public DateTimeOffset LastEnqueuedTime { get; }

        /// <summary>
        ///   Indicates whether or not the partition is currently empty.
        /// </summary>
        ///
        /// <value><c>true</c> if the partition is empty; otherwise, <c>false</c>.</value>
        ///
        public bool IsEmpty { get; }

        /// <summary>
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="PartitionProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        ///
        /// <remarks>
        ///   This constructor is obsolete and should no longer be used.  Please use the string-based offset overload instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal PartitionProperties(string eventHubName,
                                               string partitionId,
                                               bool isEmpty,
                                               long beginningSequenceNumber,
                                               long lastSequenceNumber,
                                               long lastOffset,
                                               DateTimeOffset lastEnqueuedTime) : this(eventHubName,
                                                                                       partitionId,
                                                                                       isEmpty,
                                                                                       beginningSequenceNumber,
                                                                                       lastSequenceNumber,
                                                                                       (lastOffset > long.MinValue) ? lastOffset.ToString(CultureInfo.InvariantCulture) : null,
                                                                                       lastEnqueuedTime)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionProperties"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        /// <param name="isEmpty">Indicates whether or not the partition is currently empty.</param>
        /// <param name="beginningSequenceNumber">The first sequence number available for events in the partition.</param>
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffsetString">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        ///
        protected internal PartitionProperties(string eventHubName,
                                               string partitionId,
                                               bool isEmpty,
                                               long beginningSequenceNumber,
                                               long lastSequenceNumber,
                                               string lastOffsetString,
                                               DateTimeOffset lastEnqueuedTime)
        {
            EventHubName = eventHubName;
            Id = partitionId;
            BeginningSequenceNumber = beginningSequenceNumber;
            LastEnqueuedSequenceNumber = lastSequenceNumber;
            LastEnqueuedOffsetString = lastOffsetString;
            LastEnqueuedTime = lastEnqueuedTime;
            IsEmpty = isEmpty;
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
