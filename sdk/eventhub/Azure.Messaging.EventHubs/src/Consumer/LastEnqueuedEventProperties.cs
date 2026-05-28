// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   A set of information about the enqueued state of a partition, as observed by the consumer.
    /// </summary>
    ///
    public struct LastEnqueuedEventProperties : IEquatable<LastEnqueuedEventProperties>
    {
        /// <summary>
        ///   The sequence number of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public long? SequenceNumber { get; }

        /// <summary>
        ///   Obsolete.
        ///   A numeric representation of the offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        /// <value>
        ///   This value is obsolete and should no longer be used.  Please use <see cref="OffsetString"/> instead.
        /// </value>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetPropertyObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Offset
        {
            get
            {
                if (string.IsNullOrEmpty(OffsetString))
                {
                    return null;
                }

                if (long.TryParse(OffsetString, out var value))
                {
                    return value;
                }

                throw new NotSupportedException(Resources.LongOffsetOffsetUnsupported);
            }
        }

        /// <summary>
        ///   The offset of the last observed event to be enqueued in the partition.
        /// </summary>
        ///
        public string OffsetString { get; }

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
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        /// <remarks>
        ///   This constructor is obsolete and should no longer be used.  Please use the string-based offset overload instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LastEnqueuedEventProperties(long? lastSequenceNumber,
                                           long lastOffset,
                                           DateTimeOffset? lastEnqueuedTime,
                                           DateTimeOffset? lastReceivedTime) : this(lastSequenceNumber,
                                                                                    (lastOffset > long.MinValue) ? lastOffset.ToString(CultureInfo.InvariantCulture) : null,
                                                                                    lastEnqueuedTime,
                                                                                    lastReceivedTime)
        {
        }

        /// <summary>
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffset">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        /// <remarks>
        ///   This constructor is obsolete and should no longer be used.  Please use the string-based offset overload instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetParameterObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LastEnqueuedEventProperties(long? lastSequenceNumber,
                                           long? lastOffset,
                                           DateTimeOffset? lastEnqueuedTime,
                                           DateTimeOffset? lastReceivedTime) : this(lastSequenceNumber,
                                                                                    lastOffset?.ToString(CultureInfo.InvariantCulture),
                                                                                    lastEnqueuedTime,
                                                                                    lastReceivedTime)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LastEnqueuedEventProperties"/> class.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number observed the last event to be enqueued in the partition.</param>
        /// <param name="lastOffsetString">The offset of the last event to be enqueued in the partition.</param>
        /// <param name="lastEnqueuedTime">The date and time, in UTC, that the last event was enqueued in the partition.</param>
        /// <param name="lastReceivedTime">The date and time, in UTC, that the information was last received.</param>
        ///
        public LastEnqueuedEventProperties(long? lastSequenceNumber,
                                           string lastOffsetString,
                                           DateTimeOffset? lastEnqueuedTime,
                                           DateTimeOffset? lastReceivedTime)
        {
            SequenceNumber = lastSequenceNumber;
            OffsetString = lastOffsetString;
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

        /// <summary>
        ///   Determines whether the specified <see cref="LastEnqueuedEventProperties" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="other">The <see cref="LastEnqueuedEventProperties" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="LastEnqueuedEventProperties" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        public bool Equals(LastEnqueuedEventProperties other)
        {
            return (OffsetString == other.OffsetString)
                && (SequenceNumber == other.SequenceNumber)
                && (EnqueuedTime == other.EnqueuedTime)
                && (LastReceivedTime == other.LastReceivedTime);
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
        public override bool Equals(object obj) =>
            obj switch
            {
                LastEnqueuedEventProperties other => Equals(other),
                _ => false
            };

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(OffsetString);
            hashCode.Add(SequenceNumber);
            hashCode.Add(EnqueuedTime);
            hashCode.Add(LastReceivedTime);

            return hashCode.ToHashCode();
        }

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => $"Sequence: [{ SequenceNumber }] | Offset: [{ OffsetString }] | Enqueued: [{ EnqueuedTime }] | Last Received: [{ LastReceivedTime }]";

        /// <summary>
        ///   Determines whether the specified <see cref="LastEnqueuedEventProperties" /> instances are equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="LastEnqueuedEventProperties" /> to consider.</param>
        /// <param name="right">The second <see cref="LastEnqueuedEventProperties" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="LastEnqueuedEventProperties" /> instances are equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator ==(LastEnqueuedEventProperties left,
                                       LastEnqueuedEventProperties right) => left.Equals(right);

        /// <summary>
        ///   Determines whether the specified <see cref="LastEnqueuedEventProperties" /> instances are not equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="LastEnqueuedEventProperties" /> to consider.</param>
        /// <param name="right">The second <see cref="LastEnqueuedEventProperties" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="LastEnqueuedEventProperties" /> instances are not equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator !=(LastEnqueuedEventProperties left,
                                       LastEnqueuedEventProperties right) => (!left.Equals(right));
    }
}
