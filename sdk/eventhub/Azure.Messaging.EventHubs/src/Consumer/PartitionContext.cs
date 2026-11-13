// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   Represents an Event Hub partition and its relative state, as scoped to an associated
    ///   operation performed against it.
    /// </summary>
    ///
    public class PartitionContext
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace that this context is associated with.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that this context is associated with.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group that this context is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this context is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The <see cref="TransportConsumer" /> for this context to use as the source for information.
        /// </summary>
        ///
        private WeakReference<TransportConsumer> SourceConsumer { get; }

        /// <summary>
        ///   A set of information about the last enqueued event of a partition, as observed by the associated EventHubs client
        ///   associated with this context as events are received from the Event Hubs service.  This is only available if the consumer was
        ///   created with <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> set.
        /// </summary>
        ///
        /// <returns>The set of properties for the last event that was enqueued to the partition.  If no events were read or tracking was not set, the properties will be returned with default values.</returns>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using an Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">Occurs when the Event Hubs client needed to read this information is no longer available.</exception>
        ///
        public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties()
        {
            var consumer = default(TransportConsumer);

            if ((SourceConsumer?.TryGetTarget(out consumer) == false) || (consumer == null))
            {
                // If the consumer instance was not available, treat it as a closed instance for
                // messaging consistency.

                Argument.AssertNotClosed(true, Resources.ClientNeededForThisInformationNotAvailable);
            }

            return new LastEnqueuedEventProperties(consumer.LastReceivedEvent);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="consumer">The <see cref="TransportConsumer" /> for this context to use as the source for information.</param>
        ///
        /// <remarks>
        ///   The <paramref name="consumer" />, if provided, will be held in a weak reference to ensure that it
        ///   does not impact resource use should the partition context be held beyond the lifespan of the
        ///   consumer instance.
        /// </remarks>
        ///
        internal PartitionContext(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup,
                                  string partitionId,
                                  TransportConsumer consumer) : this(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId)
        {
            Argument.AssertNotNull(consumer, nameof(consumer));
            SourceConsumer = new WeakReference<TransportConsumer>(consumer);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this context is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub partition this context is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group this context is associated with.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        ///
        protected internal PartitionContext(string fullyQualifiedNamespace,
                                            string eventHubName,
                                            string consumerGroup,
                                            string partitionId)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        ///
        /// <remarks>
        ///   This overload should no longer be used; it does not set the members of
        ///   the context not specified.
        /// </remarks>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected PartitionContext(string partitionId)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            PartitionId = partitionId;
        }
    }
}
