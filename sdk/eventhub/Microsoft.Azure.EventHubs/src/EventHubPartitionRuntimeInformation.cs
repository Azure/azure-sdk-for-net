// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// Contains information regarding an event hub partition.
    /// </summary>
    public class EventHubPartitionRuntimeInformation
    {
        internal string Type { get; set; }

        /// <summary>Gets the path of the event hub.</summary>
        /// <value>The path of the event hub.</value>
        public string Path { get; set; }

        /// <summary>Gets the partition ID for a logical partition of an Event Hub.</summary>
        /// <value>The partition identifier.</value>
        public string PartitionId { get; set; }

        /// <summary>Gets the begin sequence number.</summary>
        /// <value>The begin sequence number.</value>
        public long BeginSequenceNumber { get; set; }

        /// <summary>Gets the end sequence number.</summary>
        /// <value>The end sequence number.</value>
        public long LastEnqueuedSequenceNumber { get; set; }

        /// <summary>Gets the offset of the last enqueued event.</summary>
        /// <value>The offset of the last enqueued event.</value>
        public string LastEnqueuedOffset { get; set; }

        /// <summary>Gets the enqueued UTC time of the last event.</summary>
        /// <value>The enqueued time of the last event.</value>
        public DateTime LastEnqueuedTimeUtc { get; set; }

        /// <summary>Gets whether partition is empty or not.</summary>
        public bool IsEmpty { get; set; }
    }
}
