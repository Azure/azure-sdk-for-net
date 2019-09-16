// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that a partition processor will be processing
    ///   events from.  It's also responsible for the creation of checkpoints.  The interaction
    ///   with the chosen storage service is done via <see cref="PartitionManager" />.
    /// </summary>
    ///
    public class PartitionContext
    {
        /// <summary>
        ///   The name of the host used to connect to the associated Event Hubs namespace.
        /// </summary>
        ///
        public string EventHubsHostName { get; }

        /// <summary>
        ///   The name of the specific Event Hub that the context is associated with, relative
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
        ///   The identifier of the Event Hub partition this context is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor{T}" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints.
        /// </summary>
        ///
        private PartitionManager Manager { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="eventHubsHostName">The name of the host used to connect to the associated Event Hubs namespace.</param>
        /// <param name="eventHubName">The name of the specific Event Hub this context is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
        ///
        protected internal PartitionContext(string eventHubsHostName,
                                            string eventHubName,
                                            string consumerGroup,
                                            string partitionId,
                                            string ownerIdentifier,
                                            PartitionManager partitionManager)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubsHostName), eventHubsHostName);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNullOrEmpty(nameof(ownerIdentifier), ownerIdentifier);
            Guard.ArgumentNotNull(nameof(partitionManager), partitionManager);

            EventHubsHostName = eventHubsHostName;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            OwnerIdentifier = ownerIdentifier;
            Manager = partitionManager;
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task UpdateCheckpointAsync(EventData eventData)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);
            Guard.ArgumentNotNull(nameof(eventData.Offset), eventData.Offset);
            Guard.ArgumentNotNull(nameof(eventData.SequenceNumber), eventData.SequenceNumber);

            return UpdateCheckpointAsync(eventData.Offset.Value, eventData.SequenceNumber.Value);
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="offset">The offset of the <see cref="EventData" /> the new checkpoint will be associated with.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the <see cref="EventData" /> the new checkpoint will be associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task UpdateCheckpointAsync(long offset,
                                                  long sequenceNumber)
        {
            // Parameter validation is done by Checkpoint constructor.

            var checkpoint = new Checkpoint
            (
                EventHubsHostName,
                EventHubName,
                ConsumerGroup,
                OwnerIdentifier,
                PartitionId,
                offset,
                sequenceNumber
            );

            return Manager.UpdateCheckpointAsync(checkpoint);
        }
    }
}
