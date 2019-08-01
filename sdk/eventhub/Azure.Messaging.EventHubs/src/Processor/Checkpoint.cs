// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains all the information needed to store the state of an <see cref="IPartitionProcessor" />.
    /// </summary>
    ///
    public class Checkpoint
    {
        /// <summary>
        ///   The path of the specific Event Hub this checkpoint is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this checkpoint is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this checkpoint is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The offset of the <see cref="EventData" /> this checkpoint is associated with.
        /// </summary>
        ///
        public long Offset { get; }

        /// <summary>
        ///   The sequence number assigned to the <see cref="EventData" /> this checkpoint is associated with.
        /// </summary>
        ///
        public long SequenceNumber { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Checkpoint"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The path of the specific Event Hub this checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this checkpoint is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this checkpoint is associated with.</param>
        /// <param name="offset">The offset of the <see cref="EventData" /> this checkpoint is associated with.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the <see cref="EventData" /> this checkpoint is associated with.</param>
        ///
        public Checkpoint(string eventHubName,
                          string consumerGroup,
                          string ownerIdentifier,
                          string partitionId,
                          long offset,
                          long sequenceNumber)
        {
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }
    }
}
