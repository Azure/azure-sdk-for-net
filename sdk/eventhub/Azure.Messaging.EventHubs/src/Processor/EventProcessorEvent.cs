// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A <see cref="PartitionEvent" /> that is strongly tied to an <see cref="EventProcessorClient" />.  It
    ///   provides a means to create event processing checkpoints. TODO: fix.
    /// </summary>
    ///
    public class EventProcessorEvent
    {
        /// <summary>
        ///   The context of the Event Hub partition this instance is associated with.
        /// </summary>
        ///
        public PartitionContext Context { get; }

        /// <summary>
        ///   The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.
        /// </summary>
        ///
        public EventData Data { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        private WeakReference<EventProcessorClient> Processor { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> class.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        /// <param name="processor">TODO.</param>
        ///
        internal EventProcessorEvent(PartitionContext partitionContext,
                                     EventData eventData,
                                     EventProcessorClient processor)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));
            Argument.AssertNotNull(processor, nameof(processor));

            Context = partitionContext;
            Data = eventData;
            Processor = new WeakReference<EventProcessorClient>(processor);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> class.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        ///
        protected internal EventProcessorEvent(PartitionContext partitionContext,
                                               EventData eventData)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));

            Context = partitionContext;
            Data = eventData;
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service. TODO: add exceptions?
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public Task UpdateCheckpointAsync()
        {
            var processor = default(EventProcessorClient);

            if ((Processor)?.TryGetTarget(out processor) == false || (processor == null))
            {
                // If the processor instance was not available, treat it as a closed instance for
                // messaging consistency.

                Argument.AssertNotClosed(true, Resources.ClientNeededForThisInformation);
            }

            return processor.UpdateCheckpointAsync(Data, Context);
        }
    }
}
