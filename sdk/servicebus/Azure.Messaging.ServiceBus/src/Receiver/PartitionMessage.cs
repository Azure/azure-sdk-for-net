// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///   Contains information about a partition that has attempted to receive an event from the Azure Event Hub
    ///   service, as well as the received event, if any.
    /// </summary>
    ///
    internal struct PartitionMessage
    {
        /// <summary>
        ///   The Event Hub partition that the <see cref="PartitionMessage.Message" /> is associated with.
        /// </summary>
        ///
        public PartitionContext Partition { get; }

        /// <summary>
        ///   An event that was read from the associated <see cref="PartitionMessage.Partition" />.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="EventData" /> read from the Event Hub partition, if data was available.
        ///   If a maximum wait time was specified when reading events and no event was available in that
        ///   time period, <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   Ownership of this data, including the memory that holds its <see cref="EventData" />,
        ///   is assumed to transfer to consumers of the <see cref="PartitionMessage" />.  It may be considered
        ///   immutable and is safe to access so long as the reference is held.
        /// </remarks>
        ///
        public ServiceBusMessage Message { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionMessage"/> structure.
        /// </summary>
        ///
        /// <param name="partition">The Event Hub partition that the <paramref name="message" /> is associated with.</param>
        /// <param name="message">The event that was read, if events were available; otherwise, <c>null</c>.</param>
        ///
        public PartitionMessage(PartitionContext partition,
                              ServiceBusMessage message)
        {
            Argument.AssertNotNull(partition, nameof(partition));

            Partition = partition;
            Message = message;
        }
    }
}
