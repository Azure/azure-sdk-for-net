// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs
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
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        ///   The set of unique identifiers for each partition in the Event Hub.
        /// </summary>
        ///
        public string[] PartitionIds { get; }

        /// <summary>
        ///   A flag indicating whether or not the Event Hubs namespace has geo-replication enabled.
        /// </summary>
        ///
        public bool IsGeoReplicationEnabled { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdOn">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        /// <param name="isGeoReplicationEnabled">A flag indicating whether or not the Event Hubs namespace has geo-replication enabled.</param>
        ///
        protected internal EventHubProperties(string name,
                                              DateTimeOffset createdOn,
                                              string[] partitionIds,
                                              bool isGeoReplicationEnabled)
        {
            Name = name;
            CreatedOn = createdOn;
            PartitionIds = partitionIds;
            IsGeoReplicationEnabled = isGeoReplicationEnabled;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="name">The name of the Event Hub.</param>
        /// <param name="createdOn">The date and time at which the Event Hub was created.</param>
        /// <param name="partitionIds">The set of unique identifiers for each partition.</param>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected EventHubProperties(string name,
                                     DateTimeOffset createdOn,
                                     string[] partitionIds) : this(name, createdOn, partitionIds, false)
        {
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
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
