// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }
}
