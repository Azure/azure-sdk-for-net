// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>Represents the approximate receiver runtime information for a logical partition of an Event Hub.</summary>
    internal class ReceiverRuntimeInformation
    {
        /// <summary>
        /// Construct a new instance for the given partition.
        /// </summary>
        /// <param name="partitionId"></param>
        public ReceiverRuntimeInformation(string partitionId)
        {
            PartitionId = partitionId;
        }

        /// <summary>Gets the partition ID for a logical partition of an Event Hub.</summary>
        /// <value>The partition identifier.</value>
        public string PartitionId { get; internal set; }

        /// <summary>Gets the last sequence number of the event within the partition stream of the Event Hub.</summary>
        /// <value>The logical sequence number of the event.</value>
        public long LastSequenceNumber { get; internal set; }

        /// <summary>Gets the enqueued UTC time of the last event.</summary>
        /// <value>The enqueued time of the last event.</value>
        public DateTime LastEnqueuedTimeUtc { get; internal set; }

        /// <summary>Gets the offset of the last enqueued event.</summary>
        /// <value>The offset of the last enqueued event.</value>
        public string LastEnqueuedOffset { get; internal set; }

        /// <summary>Gets the time of when the runtime info was retrieved.</summary>
        /// <value>The enqueued time of the last event.</value>
        public DateTime RetrievalTime { get; internal set; }

        /// <summary>
        /// Update the properties of this instance with the values from the given event.
        /// </summary>
        /// <param name="updateFrom"></param>
        public void Update(EventData updateFrom)
        {
            LastSequenceNumber = updateFrom.LastSequenceNumber;
            LastEnqueuedOffset = updateFrom.LastEnqueuedOffset;
            LastEnqueuedTimeUtc = updateFrom.LastEnqueuedTime;
            RetrievalTime = updateFrom.RetrievalTime;
        }
    }
}
