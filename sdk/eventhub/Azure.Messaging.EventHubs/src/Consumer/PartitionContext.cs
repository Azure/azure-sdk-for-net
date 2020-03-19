// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// <returns>The set of properties for the last event that was enqueued to the partition.</returns>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using an Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="EventHubsException">Occurs when the Event Hubs client needed to read this information is no longer available.</exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> set.</exception>
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
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        /// <param name="consumer">The <see cref="TransportConsumer" /> for this context to use as the source for information.</param>
        ///
        /// <remarks>
        ///   The <paramref name="consumer" />, if provided, will be held in a weak reference to ensure that it
        ///   does not impact resource use should the partition context be held beyond the lifespan of the
        ///   consumer instance.
        /// </remarks>
        ///
        internal PartitionContext(string partitionId,
                                  TransportConsumer consumer) : this(partitionId)
        {
            Argument.AssertNotNull(consumer, nameof(consumer));
            SourceConsumer = new WeakReference<TransportConsumer>(consumer);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this context is associated with.</param>
        ///
        protected internal PartitionContext(string partitionId)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            PartitionId = partitionId;
        }
    }
}
