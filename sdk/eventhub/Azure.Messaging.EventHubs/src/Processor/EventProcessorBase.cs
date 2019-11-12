// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public abstract class EventProcessorBase
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public abstract string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public abstract string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public abstract string ConsumerGroup { get; }

        /// <summary>
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys. TODO: make it private.
        /// </summary>
        ///
        protected Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; }

        /// <summary>
        ///   The function to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected virtual Task InitializeProcessingForPartitionAsync(PartitionContext context) => Task.CompletedTask;

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected virtual Task ProcessingForPartitionStoppedAsync(ProcessingStoppedReason reason,
                                                                  PartitionContext context) => Task.CompletedTask;

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="eventData">TODO.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract Task ProcessEventAsync(EventData eventData,
                                                  PartitionContext context);

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        /// </summary>
        ///
        /// <param name="exception">TODO.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract Task ProcessErrorAsync(Exception exception,
                                                  PartitionContext context);

        /// <summary>
        ///   Retrieves a complete ownership list from the chosen storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        protected abstract Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                    string eventHubName,
                                                                                    string consumerGroup);

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership instances.</returns>
        ///
        protected abstract Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract Task UpdateCheckpointAsync(EventData eventData,
                                                      PartitionContext context);

        /// <summary>
        ///   Creates a <see cref="PartitionOwnership" /> instance based on the provided information.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition ownership is associated with.</param>
        /// <param name="offset">The offset of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the ownership is being created at.</param>
        /// <param name="eTag">The entity tag needed to update the ownership.</param>
        ///
        /// <returns>A <see cref="PartitionOwnership" /> instance based on the provided information.</returns>
        ///
        protected abstract PartitionOwnership CreatePartitionOwnership(string partitionId,
                                                                       long? offset,
                                                                       long? sequenceNumber,
                                                                       DateTimeOffset? lastModifiedTime,
                                                                       string eTag);

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> instance.  The returned instance must not be returned again by other
        ///   <see cref="CreateConnection" /> calls.
        /// </summary>
        ///
        /// <returns>A new <see cref="EventHubConnection" /> instance.</returns>
        ///
        /// <remarks>
        ///   The abstract <see cref="EventProcessorBase" /> class has ownership of the returned connection and, therefore, is
        ///   responsible for closing it.  Attempting to close the connection in the derived class may result in undefined behavior.
        /// </remarks>
        ///
        protected abstract EventHubConnection CreateConnection();

        /// <summary>
        ///   Tries to claim ownership of the specified partition. TODO: make it private.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the ownership is associated with.</param>
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if the claim attempt failed.</returns>
        ///
        protected async Task<PartitionOwnership> ClaimOwnershipAsync(string partitionId,
                                                                     IEnumerable<PartitionOwnership> completeOwnershipEnumerable)
        {
            // We need the eTag from the most recent ownership of this partition, even if it's expired.  We want to keep the offset and
            // the sequence number as well.

            var oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);
            var newOwnership = CreatePartitionOwnership(partitionId, oldOwnership?.Offset, oldOwnership?.SequenceNumber, DateTimeOffset.UtcNow, oldOwnership?.ETag);

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            IEnumerable<PartitionOwnership> claimedOwnership = await ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership }).ConfigureAwait(false);

            return claimedOwnership.FirstOrDefault();
        }

        /// <summary>
        ///   Renews this instance's ownership so they don't expire. TODO: make it private.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected Task RenewOwnershipAsync()
        {
            IEnumerable<PartitionOwnership> ownershipToRenew = InstanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.FullyQualifiedNamespace,
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    ownership.OwnerIdentifier,
                    ownership.PartitionId,
                    ownership.Offset,
                    ownership.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    ownership.ETag
                ));

            // We cannot rely on the ownership returned by ClaimOwnershipAsync to update our InstanceOwnership dictionary.
            // If the user issues a checkpoint update, the associated ownership will have its eTag updated as well, so we
            // will fail in claiming it here, but this instance still owns it.

            return ClaimOwnershipAsync(ownershipToRenew);
        }
    }
}
