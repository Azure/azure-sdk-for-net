// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   The position in a partition's event stream to use when updating a checkpoint, indicates that an event processor should begin reading from the next event.
    /// </summary>
    ///
    public struct CheckpointStartingPosition
    {
        /// <summary>
        ///   The offset to associate with the checkpoint. If there is a <see cref="SequenceNumber"/> associated with this checkpoint, then this value will be used for
        ///   informational metadata. If no <see cref="SequenceNumber"/> is associated, then this will be used for positioning when events are read.
        /// </summary>
        ///
        public long? Offset { get; }

        /// <summary>
        ///   The replication segment to associate with the checkpoint. Used in conjunction with the sequence number if using a geo replication enabled Event Hubs namespace.
        /// </summary>
        ///
        public string ReplicationSegment { get; }

        /// <summary>
        ///   The sequence number to associate with the checkpoint. If populated, it indicates that a processor should begin reading from the next event in the stream.
        /// </summary>
        ///
        public long? SequenceNumber { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointStartingPosition"/> struct.
        /// </summary>
        ///
        /// <remarks>
        ///   This constructor is generally used when updating checkpoints for non-Geo-DR enabled namespaces.
        /// </remarks>
        ///
        /// <param name="offset">The offset to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        ///
        public CheckpointStartingPosition(long offset)
        {
            Offset = offset;
            SequenceNumber = null;
            ReplicationSegment = null;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointStartingPosition"/> struct.
        /// </summary>
        ///
        /// <remarks>
        ///   This constructor is generally used when updating checkpoints for Geo-DR enabled namespaces.
        /// </remarks>
        ///
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="replicationSegment">The replication segment to associate with this checkpoint</param>
        /// <param name="offset">An optional offset to associate with the checkpoint, intended as informational metadata.</param>
        ///
        public CheckpointStartingPosition(long? sequenceNumber, string replicationSegment, long? offset = null)
        {
            Offset = offset;
            SequenceNumber = sequenceNumber;
            ReplicationSegment = replicationSegment;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointStartingPosition"/> from an <see cref="EventData"/> instance.
        /// </summary>
        ///
        /// <param name="eventData">The <see cref="EventData"/> to use to determine the starting point of a checkpoint, indicating that an event processor should begin reading from the next event in the stream.</param>
        ///
        public static CheckpointStartingPosition FromEvent(EventData eventData)
        {
            return new CheckpointStartingPosition(eventData.SequenceNumber, eventData.ReplicationSegment, eventData.Offset);
        }
    }
}
