// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A <see cref="PartitionEvent" /> that is strongly tied to an <see cref="EventProcessorClient" />.  It
    ///   provides a means to create event processing checkpoints.
    /// </summary>
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
        ///   The function to call on checkpoint update.
        /// </summary>
        ///
        private Func<EventData, PartitionContext, Task> OnUpdateCheckpoint { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        /// <param name="onUpdateCheckpoint">The function to call on checkpoint update.</param>
        ///
        public EventProcessorEvent(PartitionContext partitionContext,
                                   EventData eventData,
                                   Func<EventData, PartitionContext, Task> onUpdateCheckpoint)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));
            Argument.AssertNotNull(onUpdateCheckpoint, nameof(onUpdateCheckpoint));

            Context = partitionContext;
            Data = eventData;
            OnUpdateCheckpoint = onUpdateCheckpoint;
        }

        /// <summary>
        ///   Updates the checkpoint for the <see cref="PartitionContext" /> and <see cref="EventData" /> associated with
        ///   this event.
        /// </summary>
        ///
        public Task UpdateCheckpointAsync() => OnUpdateCheckpoint(Data, Context);
    }
}
