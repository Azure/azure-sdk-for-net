// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Service Bus entity Producer so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="ServiceBusSender" /> employ
    ///   a transport producer via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportSender
    {
        /// <summary>
        ///   Indicates whether or not this producer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the producer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public virtual bool IsClosed { get; }

        /// <summary>
        ///   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task SendAsync(
            IEnumerable<ServiceBusMessage> messages,
            CancellationToken cancellationToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            ServiceBusRetryPolicy retryPolicy,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CancelScheduledMessageAsync(
            long sequenceNumber,
            ServiceBusRetryPolicy retryPolicy,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///   Closes the connection to the transport producer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}
