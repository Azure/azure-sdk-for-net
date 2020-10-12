// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Consumer
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
        public PartitionContext Partition { get; }

        /// <summary>
        ///   An event that was read from the associated <see cref="PartitionEvent.Partition" />.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="EventData" /> read from the Event Hub partition, if data was available.
        ///   If a maximum wait time was specified when reading events and no event was available in that
        ///   time period, <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   Ownership of this data, including the memory that holds its <see cref="EventData.EventBody" />,
        ///   is assumed to transfer to consumers of the <see cref="PartitionEvent" />.  It may be considered
        ///   immutable and is safe to access so long as the reference is held.
        /// </remarks>
        ///
        public EventData Data { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionEvent"/> structure.
        /// </summary>
        ///
        /// <param name="partition">The Event Hub partition that the <paramref name="data" /> is associated with.</param>
        /// <param name="data">The event that was read, if events were available; otherwise, <c>null</c>.</param>
        ///
        public PartitionEvent(PartitionContext partition,
                              EventData data)
        {
            Argument.AssertNotNull(partition, nameof(partition));

            Partition = partition;
            Data = data;
        }
    }
}
