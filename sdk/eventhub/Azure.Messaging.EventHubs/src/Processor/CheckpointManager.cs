// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Responsible for the creation of checkpoints.  The interaction with the chosen storage service is done
    ///   via <see cref="PartitionManager" />.
    /// </summary>
    ///
    public class CheckpointManager
    {
        /// <summary>
        ///   Contains information about the partition this instance is associated with.
        /// </summary>
        ///
        private PartitionContext Context { get; }

        /// <summary>
        ///   Interacts with the storage system, dealing with the creation of checkpoints.
        /// </summary>
        ///
        private PartitionManager Manager { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CheckpointManager"/> class.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition this instance will be associated with.</param>
        /// <param name="partitionManager">Interacts with the storage system, dealing with the creation of checkpoints.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
        ///
        internal CheckpointManager(PartitionContext partitionContext,
                                   PartitionManager partitionManager,
                                   string ownerIdentifier)
        {
            Context = partitionContext;
            Manager = partitionManager;
            OwnerIdentifier = ownerIdentifier;
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public Task UpdateCheckpointAsync(EventData eventData) => UpdateCheckpointAsync(eventData.Offset, eventData.SequenceNumber);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="offset">The offset of the <see cref="EventData" /> the new checkpoint will be associated with.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the <see cref="EventData" /> the new checkpoint will be associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task UpdateCheckpointAsync(long offset,
                                                long sequenceNumber)
        {
            // Parameter validation is done by Checkpoint constructor.

            var checkpoint = new Checkpoint
            (
                Context.EventHubName,
                Context.ConsumerGroup,
                OwnerIdentifier,
                Context.PartitionId,
                offset,
                sequenceNumber
            );

            await Manager.UpdateCheckpointAsync(checkpoint).ConfigureAwait(false);
        }
    }
}
