// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified to influence the way in which events
    ///   are published to the Event Hubs service.
    /// </summary>
    ///
    public class SendEventOptions
    {
        /// <summary>
        ///   Allows a hashing key to be provided for the batch of events, which instructs Event Hubs
        ///   to map the key to an automatically-assigned partition.
        ///
        ///   The selection of a partition is stable for a given partition key.  Should any other events
        ///   be published using the same exact partition key, Event Hubs will assign the same partition to them.
        ///
        ///   The partition key should be specified when there is a need to group events together, but the
        ///   partition to which they are assigned is unimportant.  If ensuring that a batch of events is assigned
        ///   a specific partition, it is recommended that the <see cref="PartitionId" /> be assigned instead.
        /// </summary>
        ///
        /// <value>
        ///   A value that can be used to identify events that should be published to the same partition.  If <c>null</c>,
        ///   the events will either respect the specified <see cref="PartitionId" /> or be automatically assigned to a partition.
        ///
        ///   The default partition key value is <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   If the <see cref="SendEventOptions.PartitionKey" /> is specified, then no <see cref="SendEventOptions.PartitionId" />
        ///   may be set when sending.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-features#mapping-of-events-to-partitions">Mapping events to partitions</seealso>
        ///
        public string PartitionKey { get; set; }

        /// <summary>
        ///   If specified, events be published to this specific partition.  If the identifier is not specified,
        ///   Event Hubs will be responsible for assigning events automatically to an available partition.
        /// </summary>
        ///
        /// <value>
        ///   The identifier of the desired partition to assign for the events, if <c>null</c>, the events will be
        ///   automatically assigned to a partition.
        ///
        ///   The default partition identifier value is <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   If the <see cref="SendEventOptions.PartitionId" /> is specified, then no <see cref="SendEventOptions.PartitionKey" />
        ///   may be set when sending.
        ///
        ///   <list type="bullet">
        ///     <listheader><description>Allowing automatic routing of partitions is recommended when:</description></listheader>
        ///     <item><description>The sending of events needs to be highly available.</description></item>
        ///     <item><description>The event data should be evenly distributed among all available partitions.</description></item>
        ///   </list>
        ///
        ///   <list type="number">
        ///     <listheader><description>If no partition is specified, the following rules are used for automatically selecting one:</description></listheader>
        ///     <item><description>Distribute the events equally amongst all available partitions using a round-robin approach.</description></item>
        ///     <item><description>If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</description></item>
        ///   </list>
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-features#mapping-of-events-to-partitions">Mapping events to partitions</seealso>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventOptions"/> class.
        /// </summary>
        ///
        public SendEventOptions()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventOptions"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which events should be sent.</param>
        /// <param name="partitionKey">The hashing key to use for influencing the partition to which the events are routed.</param>
        ///
        internal SendEventOptions(string partitionId,
                                  string partitionKey)
        {
            PartitionId = partitionId;
            PartitionKey = partitionKey;
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

        /// <summary>
        ///   Creates a new copy of the current <see cref="SendEventOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SendEventOptions" />.</returns>
        ///
        internal SendEventOptions Clone() =>
            new SendEventOptions
            {
                PartitionId = PartitionId,
                PartitionKey = PartitionKey
            };
    }
}
