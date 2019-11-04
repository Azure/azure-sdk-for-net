// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Contains information about a partition that has attempted to receive an event from the Azure Event Hub
    ///   service, as well as the received event, if any.
    /// </summary>
    ///
    public struct PartitionEvent
    {
        /// <summary>
        ///   The Event Hub partition that the <see cref="PartitionEvent.Data" /> is associated with.
        /// </summary>
        ///
        public PartitionContext Context { get; }

        /// <summary>
        ///   An event that was read from the associated <see cref="PartitionEvent.Context" />.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="EventData" /> read from the Event Hub partition, if data was available.
        ///   If a maximum wait time was specified when reading events and no event was available in that
        ///   time period, <c>null</c>.
        /// </value>
        ///
        public EventData Data { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partitionContext">The Event Hub partition that the <paramref name="eventData" /> is associated with.</param>
        /// <param name="eventData">The event that was read, if events were available; otherwise, <c>null</c>.</param>
        ///
        public PartitionEvent(PartitionContext partitionContext,
                              EventData eventData)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));

            Context = partitionContext;
            Data = eventData;
        }
    }
}
