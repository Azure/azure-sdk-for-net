// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Errors;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that has attempted to receive an event from the Azure Event Hub
    ///   service in an <c>EventProcessorClient</c> context, as well as the received event, if any.  It
    ///   also provides a way of creating a checkpoint based on the information contained in the associated event.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor" />
    ///
    public struct EventProcessorEvent
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
        ///   The <c>EventProcessorClient</c> for this instance to use for creation of checkpoints.
        /// </summary>
        ///
        private WeakReference<EventProcessorClient> Processor { get; }

        /// <summary>
        ///   The callback to be called upon <see cref="UpdateCheckpointAsync" /> call.
        /// </summary>
        ///
        private Func<EventData, PartitionContext, Task> UpdateCheckpointDelegate { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        /// <param name="processor">The <c>EventProcessorClient</c> for this instance to use for creating checkpoints.</param>
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
            UpdateCheckpointDelegate = default;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        /// <param name="updateCheckpointImplementation">The callback to be called upon <see cref="UpdateCheckpointAsync" /> call.</param>
        ///
        public EventProcessorEvent(PartitionContext partitionContext,
                                   EventData eventData,
                                   Func<EventData, PartitionContext, Task> updateCheckpointImplementation)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));
            Argument.AssertNotNull(updateCheckpointImplementation, nameof(updateCheckpointImplementation));

            Context = partitionContext;
            Data = eventData;
            Processor = default;
            UpdateCheckpointDelegate = updateCheckpointImplementation;
        }

        /// <summary>
        ///   Updates the checkpoint for the <see cref="PartitionContext" /> and <see cref="EventData" /> associated with
        ///   this event.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <exception cref="ArgumentNullException">Occurs when <see cref="Data" /> is <c>null</c>.</exception>
        /// <exception cref="EventHubsClientClosedException">Occurs when the <c>EventProcessorClient</c> needed to perform this operation is no longer available.</exception>
        ///
        public Task UpdateCheckpointAsync()
        {
            if (UpdateCheckpointDelegate != default)
            {
                return UpdateCheckpointDelegate(Data, Context);
            }

            var processor = default(EventProcessorClient);

            if ((Processor)?.TryGetTarget(out processor) == false || (processor == null))
            {
                // If the processor instance was not available, treat it as a closed instance for
                // messaging consistency.

                Argument.AssertNotClosed(true, Resources.ClientNeededForThisInformation);
            }

            // Data validation is done by the event processor.

            return processor.InternalUpdateCheckpointAsync(Data, Context);
        }
    }
}
