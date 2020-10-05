﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   The position of events in an Event Hub partition, typically used in the creation of
    ///   an <see cref="EventHubConsumerClient" />.
    /// </summary>
    ///
    public struct EventPosition : IEquatable<EventPosition>
    {
        /// <summary>The token that represents the beginning event in the stream of a partition.</summary>
        private const string StartOfStreamOffset = "-1";

        /// <summary>The token that represents the last event in the stream of a partition.</summary>
        private const string EndOfStreamOffset = "@latest";

        /// <summary>
        ///   Corresponds to the location of the first event present in the partition.  Use this
        ///   position to begin receiving from the first event that was enqueued in the partition
        ///   which has not expired due to the retention policy.
        /// </summary>
        ///
        public static EventPosition Earliest => FromOffset(StartOfStreamOffset, false);

        /// <summary>
        ///   Corresponds to the end of the partition, where no more events are currently enqueued.  Use this
        ///   position to begin receiving from the next event to be enqueued in the partition after an <see cref="EventHubConsumerClient"/>
        ///   is created with this position.
        /// </summary>
        ///
        public static EventPosition Latest => FromOffset(EndOfStreamOffset, false);

        /// <summary>
        ///   The offset of the event identified by this position.
        /// </summary>
        ///
        /// <value>Expected to be <c>null</c> if the event position represents a sequence number or enqueue time.</value>
        ///
        /// <remarks>
        ///   The offset is the relative position for event in the context of the stream.  The offset
        ///   should not be considered a stable value, as the same offset may refer to a different event
        ///   as events reach the age limit for retention and are no longer visible within the stream.
        /// </remarks>
        ///
        internal string Offset { get; set; }

        /// <summary>
        ///   Indicates if the specified offset is inclusive of the event which it identifies.  This
        ///   information is only relevant if the event position was identified by an offset or sequence number.
        /// </summary>
        ///
        /// <value><c>true</c> if the offset is inclusive; otherwise, <c>false</c>.</value>
        ///
        internal bool IsInclusive { get; set; }

        /// <summary>
        ///   The enqueue time of the event identified by this position.
        /// </summary>
        ///
        /// <value>Expected to be <c>null</c> if the event position represents an offset or sequence number.</value>
        ///
        internal DateTimeOffset? EnqueuedTime { get; set; }

        /// <summary>
        ///   The sequence number of the event identified by this position.
        /// </summary>
        ///
        /// <value>Expected to be <c>null</c> if the event position represents an offset or enqueue time.</value>
        ///
        internal long? SequenceNumber { get; set; }

        /// <summary>
        ///   Corresponds to the event in the partition at the provided offset, inclusive of that event.
        /// </summary>
        ///
        /// <param name="offset">The offset of an event with respect to its relative position in the partition.</param>
        /// <param name="isInclusive">If true, the event with the <paramref name="offset"/> is included; otherwise the next event in sequence will be received.</param>
        ///
        /// <returns>The position of the specified event.</returns>
        ///
        public static EventPosition FromOffset(long offset,
                                               bool isInclusive = true) => FromOffset(offset.ToString(CultureInfo.InvariantCulture), isInclusive);

        /// <summary>
        ///   Corresponds to the event in the partition having a specified sequence number associated with it.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number assigned to an event when it was enqueued in the partition.</param>
        /// <param name="isInclusive">If true, the event with the <paramref name="sequenceNumber"/> is included; otherwise the next event in sequence will be received.</param>
        ///
        /// <returns>The position of the specified event.</returns>
        ///
        public static EventPosition FromSequenceNumber(long sequenceNumber,
                                                       bool isInclusive = true)
        {
            return new EventPosition
            {
                SequenceNumber = sequenceNumber,
                IsInclusive = isInclusive
            };
        }

        /// <summary>
        ///   Corresponds to a specific date and time within the partition to begin seeking an event; the event enqueued after the
        ///   requested <paramref name="enqueuedTime" /> will become the current position.
        /// </summary>
        ///
        /// <param name="enqueuedTime">The date and time, in UTC, from which the next available event should be chosen.</param>
        ///
        /// <returns>The position of the specified event.</returns>
        ///
        public static EventPosition FromEnqueuedTime(DateTimeOffset enqueuedTime)
        {
            return new EventPosition
            {
                EnqueuedTime = enqueuedTime
            };
        }

        /// <summary>
        ///   Determines whether the specified <see cref="EventPosition" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="other">The <see cref="EventPosition" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="EventPosition" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        public bool Equals(EventPosition other)
        {
            return (Offset == other.Offset)
                && (SequenceNumber == other.SequenceNumber)
                && (EnqueuedTime == other.EnqueuedTime)
                && (IsInclusive == other.IsInclusive);
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
                EventPosition other => Equals(other),
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
            hashCode.Add(Offset);
            hashCode.Add(SequenceNumber);
            hashCode.Add(EnqueuedTime);
            hashCode.Add(IsInclusive);

            return hashCode.ToHashCode();
        }

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() =>
            this switch
            {
                EventPosition _ when (Offset == StartOfStreamOffset) => nameof(Earliest),
                EventPosition _ when (Offset == EndOfStreamOffset) => nameof(Latest),
                EventPosition _ when (!string.IsNullOrEmpty(Offset)) => $"Offset: [{ Offset }] | Inclusive: [{ IsInclusive }]",
                EventPosition _ when (SequenceNumber.HasValue) => $"Sequence Number: [{ SequenceNumber }] | Inclusive: [{ IsInclusive }]",
                EventPosition _ when (EnqueuedTime.HasValue) => $"Enqueued: [{ EnqueuedTime }]",
                _ => base.ToString()
            };

        /// <summary>
        ///   Corresponds to the event in the partition at the provided offset.
        /// </summary>
        ///
        /// <param name="offset">The offset of an event with respect to its relative position in the partition.</param>
        /// <param name="isInclusive">If true, the event at the <paramref name="offset"/> is included; otherwise the next event in sequence will be received.</param>
        ///
        /// <returns>The position of the specified event.</returns>
        ///
        private static EventPosition FromOffset(string offset,
                                                bool isInclusive)
        {
            Argument.AssertNotNullOrWhiteSpace(nameof(offset), offset);

            return new EventPosition
            {
                Offset = offset,
                IsInclusive = isInclusive
            };
        }

        /// <summary>
        ///   Determines whether the specified <see cref="EventPosition" /> instances are equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="EventPosition" /> to consider.</param>
        /// <param name="right">The second <see cref="EventPosition" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="EventPosition" /> instances are equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator ==(EventPosition left,
                                       EventPosition right) => left.Equals(right);

        /// <summary>
        ///   Determines whether the specified <see cref="EventPosition" /> instances are not equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="EventPosition" /> to consider.</param>
        /// <param name="right">The second <see cref="EventPosition" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="EventPosition" /> instances are not equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator !=(EventPosition left,
                                       EventPosition right) => (!left.Equals(right));
    }
}
