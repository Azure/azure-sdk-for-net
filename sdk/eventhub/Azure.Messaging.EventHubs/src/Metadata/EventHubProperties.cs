// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Metadata
{
    /// <summary>
    ///   A set of information for an Event Hub.
    /// </summary>
    ///
    public class EventHubProperties
    {
        /// <summary>
        ///   The name of the Event Hub, specific to the namespace
        ///   that contains it.
        /// </summary>
        ///
        public string Name { get; }

        /// <summary>
        ///   The date and time, in UTC, at which the Event Hub was created.
        /// </summary>
        ///
        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        ///   The set of unique identifiers for each partition in the Event Hub.
        /// </summary>
        ///
        public string[] PartitionIds { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdAt">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        ///
        protected internal EventHubProperties(string name,
                                              DateTimeOffset createdAt,
                                              string[] partitionIds)
        {
            Name = name;
            CreatedAt = createdAt;
            PartitionIds = partitionIds;
        }
    }
}
