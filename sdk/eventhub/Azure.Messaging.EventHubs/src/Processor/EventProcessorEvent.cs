// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A <see cref="PartitionEvent" /> that is strongly tied to an <see cref="EventProcessorClient" />.  It
    ///   provides a means to create event processing checkpoints.
    /// </summary>
    ///
    public class EventProcessorEvent : PartitionEvent
    {
        /// <summary>
        ///   The <see cref="EventProcessorClient" /> this instance is related to.
        /// </summary>
        ///
        public EventProcessorClient Processor { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> class.
        /// </summary>
        ///
        /// <param name="processor">The <see cref="EventProcessorClient" /> this instance is related to.</param>
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        ///
        protected internal EventProcessorEvent(EventProcessorClient processor,
                                               PartitionContext partitionContext,
                                               EventData eventData) : base(partitionContext, eventData)
        {
            Argument.AssertNotNull(processor, nameof(processor));

            Processor = processor;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorEvent"/> class.
        /// </summary>
        ///
        protected EventProcessorEvent()
        {
        }
    }
}
