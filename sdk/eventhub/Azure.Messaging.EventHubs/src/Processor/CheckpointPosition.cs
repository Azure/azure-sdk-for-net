// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The position in a partition's event stream to use when updating a checkpoint, indicating that an event processor should begin reading from the next event.
    /// </summary>
    ///
    public struct CheckpointPosition : IEquatable<CheckpointPosition>
    {
        /// <summary>
        ///   The sequence number to associate with the checkpoint. The sequence number is intended to be informational, and will only be used for
        ///   positioning if no <see cref="Offset"/> is set.
        /// </summary>
        ///
        public long SequenceNumber { get; }

        /// <summary>
        ///   Obsolete.
        ///   A numeric representation of the offset to associate with the checkpoint. This indicates that a processor
        ///   should begin reading from the next event in the stream.
        /// </summary>
        ///
        /// <value>
        ///   This value is obsolete and should no longer be used.  Please use <see cref="OffsetString"/> instead.
        /// </value>
        ///
        [Obsolete(AttributeMessageText.LongOffsetOffsetPropertyObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long Offset
        {
            get
            {
                if (long.TryParse(OffsetString, out var value))
                {
                    return value;
                }

                throw new NotSupportedException(Resources.LongOffsetOffsetUnsupported);
            }
        }

        /// <summary>
        ///   The offset to associate with the checkpoint. This indicates that a processor should begin reading from the next event in the stream.
        /// </summary>
        ///
        public string OffsetString { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointPosition"/> struct.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint. This indicates that a processor should begin reading from the next event in the stream.</param>
        ///
        /// <remarks>
        ///   This constructor is not compatible when processing a geo-replicated Event Hub. Use <see cref="CheckpointPosition(string, long)"/> or
        ///   <see cref="FromEvent(EventData)"/> instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.SequenceNumberOnlyCheckpointObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckpointPosition(long sequenceNumber)
        {
            SequenceNumber = sequenceNumber;
        }

        /// <summary>
        ///   Obsolete.
        ///
        ///   Initializes a new instance of the <see cref="CheckpointPosition"/> struct.
        /// </summary>
        ///
        /// <param name="offset">The offset to associate with the checkpoint. This indicates that a processor should begin reading from the next event in the stream.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint. This is used as informational metadata.</param>
        ///
        /// <remarks>
        ///   This constructor is obsolete and should no longer be used.  Please use <see cref="CheckpointPosition(string, long)"/> instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetCheckpointObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CheckpointPosition(long offset,
                                  long sequenceNumber = long.MinValue)
        {
            SequenceNumber = sequenceNumber;
            OffsetString = (offset != long.MinValue) ? offset.ToString(CultureInfo.InvariantCulture) : null;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointPosition"/> struct.
        /// </summary>
        /// <param name="offsetString">The offset to associate with the checkpoint. This indicates that a processor should begin reading from the next event in the stream.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint. This is used as informational metadata.</param>
        ///
        public CheckpointPosition(string offsetString,
                                  long sequenceNumber = long.MinValue)
        {
            Argument.AssertNotNullOrEmpty(offsetString, nameof(offsetString));

            SequenceNumber = sequenceNumber;
            OffsetString = offsetString;
        }

        /// <summary>
        ///   Initializes an empty <see cref="CheckpointPosition"/> which can be used
        ///   to clear existing checkpoint data.
        /// </summary>
        ///
        public CheckpointPosition()
        {
            SequenceNumber = long.MinValue;
            OffsetString = null;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointPosition"/> from an <see cref="EventData"/> instance.
        /// </summary>
        ///
        /// <param name="eventData">The <see cref="EventData"/> to use to determine the starting point of a checkpoint, indicating that an event processor should begin reading from the next event in the stream.</param>
        ///
        public static CheckpointPosition FromEvent(EventData eventData) =>
            new CheckpointPosition(eventData.OffsetString, eventData.SequenceNumber);

        /// <summary>
        ///   Determines whether the specified <see cref="CheckpointPosition" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="other">The <see cref="CheckpointPosition" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="CheckpointPosition" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        public bool Equals(CheckpointPosition other)
        {
            return ((SequenceNumber == other.SequenceNumber)
                   && (OffsetString == other.OffsetString));
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
                CheckpointPosition other => Equals(other),
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
            hashCode.Add(SequenceNumber);
            hashCode.Add(OffsetString);

            return hashCode.ToHashCode();
        }

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents the position in the event stream.</returns>
        ///
        public override string ToString()
        {
            return $"Offset: [{OffsetString}] Sequence Number: [{SequenceNumber}]";
        }

        /// <summary>
        ///   Determines whether the specified <see cref="CheckpointPosition" /> instances are equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="CheckpointPosition" /> to consider.</param>
        /// <param name="right">The second <see cref="CheckpointPosition" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="CheckpointPosition" /> instances are equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator ==(CheckpointPosition left,
                                       CheckpointPosition right) => left.Equals(right);

        /// <summary>
        ///   Determines whether the specified <see cref="CheckpointPosition" /> instances are not equal to each other.
        /// </summary>
        ///
        /// <param name="left">The first <see cref="CheckpointPosition" /> to consider.</param>
        /// <param name="right">The second <see cref="CheckpointPosition" /> to consider.</param>
        ///
        /// <returns><c>true</c> if the two specified <see cref="CheckpointPosition" /> instances are not equal; otherwise, <c>false</c>.</returns>
        ///
        public static bool operator !=(CheckpointPosition left,
                                       CheckpointPosition right) => (!left.Equals(right));
    }
}
