// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs
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
    }
}
