// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Metadata
{
    /// <summary>
    ///   A set of information that can be used to initialize a <see cref="PartitionReceiver" /> to
    ///   begin reading at position of the event that it last received.
    /// </summary>
    ///
    public sealed class ReceiverCheckpointProperties
    {
        /// <summary>
        ///   The path of the Event Hub that contains the partitions, relative to the namespace
        ///   that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; private set; }

        /// <summary>
        ///   The identifier of the partition that was being received from, unique to the Event Hub which contains
        ///   it.
        /// </summary>
        ///
        public string PartitionId { get; private set; }

        /// <summary>
        ///   The sequence number of the event that was last received.
        /// </summary>
        ///
        public long SequenceNumber { get; private set; }

        /// <summary>
        ///   The offset the event that was last received.
        /// </summary>
        ///
        /// <remarks>
        ///   The offset is the relative position for event in the context of the stream.  The offset
        ///   should not be considered a stable value, as the same offset may refer to a different event
        ///   as events reach the age limit for retention and are no longer visible within the stream.
        /// </remarks>
        ///
        public int Offset { get; private set; }

        /// <summary>
        ///   The date and time, in UTC, of the event that was last received.
        /// </summary>
        ///
        public DateTime EnqueuedTimeUtc { get; private set; }

        /// <summary>
        ///   The date and time, in UTC, that the information was retrieved from the
        ///   Event Hub.
        /// </summary>
        ///
        public DateTime PropertyRetrievalTimeUtc { get; private set;}

        /// <summary>
        ///   Initializes a new instance of the <see cref="ReceiverCheckpointProperties"/> class.
        /// </summary>
        ///
        /// <param name="path">The path of the Event Hub that contains the partitions.</param>
        /// <param name="partitionId">The identifier of the partition.</param>
        ///
        internal ReceiverCheckpointProperties(string path,
                                              string partitionId)
        {
            EventHubPath = path;
            PartitionId = partitionId;
        }

        /// <summary>
        ///   Updates the current set of partition information using an <see cref="EventHubs.EventData" />
        ///   instance as the source.
        /// </summary>
        ///
        /// <param name="sourceEvent">The event to use as the information source for the updates.</param>
        ///
        internal void UpdateFromEvent(EventData sourceEvent)
        {
            Guard.ArgumentNotNull(nameof(sourceEvent), sourceEvent);

            SequenceNumber = sourceEvent.SequenceNumber;
            EnqueuedTimeUtc = sourceEvent.EnqueuedTimeUtc;
            PropertyRetrievalTimeUtc = sourceEvent.RetrievalTimeUtc;

            if (int.TryParse(sourceEvent.Offset, out var offset))
            {
                Offset = offset;
            }
        }
    }
}
