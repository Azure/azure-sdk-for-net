// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

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
        /// <param name="eventHubName">The name of the specific Event Hub this context is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
        ///
        protected internal PartitionContext(string eventHubName,
                                            string consumerGroup,
                                            string partitionId,
                                            string ownerIdentifier,
                                            PartitionManager partitionManager)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNullOrEmpty(ownerIdentifier, nameof(ownerIdentifier));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));

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
            Argument.AssertNotNull(eventData, nameof(eventData));
            Argument.AssertNotNull(eventData.Offset, nameof(eventData.Offset));
            Argument.AssertNotNull(eventData.SequenceNumber, nameof(eventData.SequenceNumber));

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
        public virtual async Task UpdateCheckpointAsync(long offset,
                                                  long sequenceNumber)
        {
            // Parameter validation is done by Checkpoint constructor.

            var checkpoint = new Checkpoint
            (
                EventHubName,
                ConsumerGroup,
                OwnerIdentifier,
                PartitionId,
                offset,
                sequenceNumber
            );

            using DiagnosticScope scope =
                EventDataInstrumentation.ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorCheckpointActivityName);
            scope.Start();

            try
            {
                await Manager.UpdateCheckpointAsync(checkpoint).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
            }
        }
    }
}
