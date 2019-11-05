﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        ///   Initializes a new instance of the <see cref="PartitionEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="eventData">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
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
