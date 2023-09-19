// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    /// TODO.
    /// </summary>
    public struct CheckpointStartingPosition
    {
        /// <summary>
        /// TODO.
        /// </summary>
        public long? Offset { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        public string ReplicationSegment { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        public long? SequenceNumber { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointStartingPosition"/> struct.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="sequenceNumber"></param>
        public CheckpointStartingPosition(long offset, long? sequenceNumber)
        {
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointStartingPosition"/> struct.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="sequenceNumber"></param>
        /// <param name="replicationSegment"></param>
        public CheckpointStartingPosition(long? offset, long sequenceNumber, string replicationSegment)
        {
            Offset = offset;
            SequenceNumber = sequenceNumber;
            ReplicationSegment = replicationSegment;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public static CheckpointStartingPosition FromEvent(EventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
