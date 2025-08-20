// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.EventHubs.Amqp;
    using Microsoft.Azure.EventHubs.Primitives;

    /// <summary>
    /// Represents options can be set during the creation of a event hub receiver.
    /// </summary> 
    /// <summary>
    /// Defines a position of an <see cref="EventData" /> in the event hub partition.
    /// The position can be one of <see cref="EventData.SystemPropertiesCollection.Offset"/>, <see cref="EventData.SystemPropertiesCollection.SequenceNumber"/>
    /// or <see cref="EventData.SystemPropertiesCollection.EnqueuedTimeUtc"/>.
    /// </summary>
    public class EventPosition
    {
        const string StartOfStream = "-1";
        const string EndOfStream = "@latest";

        EventPosition() { }

        /// <summary>
        /// Returns the position for the start of a stream. Provide this position in receiver creation
        /// to starting receiving from the first available event in the partition.
        /// </summary>
        public static EventPosition FromStart()
        {
            return EventPosition.FromOffset(StartOfStream);
        }

        /// <summary>
        /// Returns the position for the end of a stream. Provide this position in receiver creation
        /// to start receiving from the next available event in the partition after the receiver is created.
        /// </summary>
        public static EventPosition FromEnd()
        {
            return EventPosition.FromOffset(EndOfStream);
        }

        /// <summary>
        /// Creates a position at the given offset.
        /// </summary>
        /// <param name="offset"><see cref="EventData.SystemPropertiesCollection.Offset"/> </param>
        /// <param name="inclusive">If true, the specified event is included; otherwise the next event is returned.</param>
        /// <returns>An <see cref="EventPosition"/> object.</returns>
        public static EventPosition FromOffset(string offset, bool inclusive = false)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(offset), offset);
          
            return new EventPosition { Offset = offset, IsInclusive = inclusive };
        }

        /// <summary>
        /// Creates a position at the given offset.
        /// </summary>
        /// <param name="sequenceNumber"><see cref="EventData.SystemPropertiesCollection.SequenceNumber"/></param>
        /// <param name="inclusive">If true, the specified event is included; otherwise the next event is returned.</param>
        /// <returns>An <see cref="EventPosition"/> object.</returns>
        public static EventPosition FromSequenceNumber(long sequenceNumber, bool inclusive = false)
        {
            return new EventPosition { SequenceNumber = sequenceNumber, IsInclusive = inclusive };
        }

        /// <summary>
        /// Creates a position at the given offset.
        /// </summary>
        /// <param name="enqueuedTimeUtc"><see cref="EventData.SystemPropertiesCollection.EnqueuedTimeUtc"/></param>
        /// <returns>An <see cref="EventPosition"/> object.</returns>
        public static EventPosition FromEnqueuedTime(DateTime enqueuedTimeUtc)
        {
            return new EventPosition { EnqueuedTimeUtc = enqueuedTimeUtc };
        }

        /// <summary>
        /// Gets the offset of the event at the position. It can be null if the position is just created
        /// from a sequence number or an enqueued time.
        /// </summary>
        internal string Offset { get; set; }

        /// <summary>
        /// Indicates if the current event at the specified offset is included or not.
        /// It is only applicable if offset is set.
        /// </summary>
        internal bool IsInclusive { get; set; }

        /// <summary>
        /// Gets the enqueued time of the event at the position. It can be null if the position is just created
        /// from an offset or a sequence number.
        /// </summary>
        internal DateTime? EnqueuedTimeUtc { get; set; }

        /// <summary>
        /// Gets the sequence number of the event at the position. It can be null if the position is just created
        /// from an offset or an enqueued time.
        /// </summary>
        public long? SequenceNumber { get; internal set; }

        internal string GetExpression()
        {
            // order of preference
            if (this.Offset != null)
            {
                return this.IsInclusive ?
                    $"{AmqpClientConstants.FilterOffsetPartName} >= {this.Offset}" :
                    $"{AmqpClientConstants.FilterOffsetPartName} > {this.Offset}";
            }

            if (this.SequenceNumber.HasValue)
            {
                return this.IsInclusive ?
                    $"{AmqpClientConstants.FilterSeqNumberName} >= {this.SequenceNumber.Value}" :
                    $"{AmqpClientConstants.FilterSeqNumberName} > {this.SequenceNumber.Value}";
            }

            if (this.EnqueuedTimeUtc.HasValue)
            {
                long ms = TimeStampEncodingGetMilliseconds(this.EnqueuedTimeUtc.Value);
                return $"{AmqpClientConstants.FilterReceivedAtPartNameV2} > {ms}";
            }

            throw new ArgumentException("No starting position was set");
        }

        // This is equivalent to Microsoft.Azure.Amqp's internal API TimeStampEncoding.GetMilliseconds
        static long TimeStampEncodingGetMilliseconds(DateTime value)
        {
            DateTime utcValue = value.ToUniversalTime();
            double milliseconds = (utcValue - AmqpConstants.StartOfEpoch).TotalMilliseconds;
            return (long)milliseconds;
        }
    }
}
