// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// Contains information regarding Event Hubs.
    /// </summary>
    internal class EventHubRuntimeInformation
    {
        internal string Type { get; set; }

        /// <summary>Gets or sets the path to the Event Hub.</summary>
        public string Path { get; set; }

        /// <summary>Gets or sets the time at which the Event Hub was created.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the number of partitions in an Event Hub.</summary>
        public int PartitionCount { get; set; }

        /// <summary>Gets or sets the partition IDs for an Event Hub.</summary>
        public string[] PartitionIds { get; set; }
    }
}
