// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public abstract Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
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
        public abstract Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected internal abstract Task UpdateCheckpointAsync(EventData eventData,
                                                               PartitionContext context);
    }
}
