// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that an <see cref="IPartitionProcessor" /> will
    ///   be processing events from.
    /// </summary>
    ///
    public class PartitionContext
    {
        /// <summary>
        ///   The path of the specific Event Hub that the context is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this context is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this context is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The path of the specific Event Hub this context is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        ///
        internal PartitionContext(string eventHubName,
                                  string consumerGroup,
                                  string ownerIdentifier,
                                  string partitionId)
        {
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
        }
    }
}
