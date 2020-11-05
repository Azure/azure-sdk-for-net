// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Event Consumer so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="EventHubConsumerClient" /> employ
    ///   a transport consumer via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportConsumer
    {
        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public virtual bool IsClosed { get; }

        /// <summary>
        ///   The most recent event received from the Event Hubs service by this consumer instance.
        /// </summary>
        ///
        /// <value>
        ///   <c>null</c>, if the tracking of the last enqueued event information was not requested; otherwise,
        ///   the most recently received event.
        /// </value>
        ///
        public EventData LastReceivedEvent { get; protected set; }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumEventCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait for events to become available, if no events can be read from the prefetch queue.  If not specified, the per-try timeout specified by the retry policy will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty set is returned.</returns>
        ///
        /// <remarks>
        ///   When events are available in the prefetch queue, they will be used to form the batch as quickly as possible without waiting for additional events from the
        ///   Event Hubs service to try and meet the requested <paramref name="maximumEventCount" />.  When no events are available in prefetch, the receiver will wait up
        ///   to the <paramref name="maximumWaitTime"/> for events to be read from the service.  Once any events are available, they will be used to form the batch immediately.
        /// </remarks>
        ///
        public abstract Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumEventCount,
                                                                    TimeSpan? maximumWaitTime,
                                                                    CancellationToken cancellationToken);

        /// <summary>
        ///   Closes the connection to the transport producer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}
