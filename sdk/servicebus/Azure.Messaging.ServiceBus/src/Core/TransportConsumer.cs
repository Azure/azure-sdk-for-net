// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Event Consumer so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="ServiceBusReceiverClient" /> employ
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
        ///
        /// </summary>
        public FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLink { get; protected set; }

        /// <summary>
        /// The scope <see cref="TransportConnectionScope"/> associated with the
        /// <see cref="TransportConsumer"/>.
        /// </summary>
        public virtual TransportConnectionScope ConnectionScope { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string EntityName { get; }

        /// <summary>
        ///   Receives a batch of <see cref="ServiceBusMessage" /> from the Service Bus entity.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public abstract Task<IEnumerable<ServiceBusMessage>> ReceiveAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken);

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get the session Id corresponding to this consumer.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the DateTimeOffset for when the session is locked until.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<DateTimeOffset> GetSessionLockedUntilUtcAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockTokens"></param>
        /// <param name="outcome"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal abstract Task DisposeMessagesAsync(
            IEnumerable<Guid> lockTokens,
            Outcome outcome,
            TimeSpan timeout);

        /// <summary>
        ///
        /// </summary>
        internal abstract string GetReceiveLinkName();

        /// <summary>
        ///
        /// </summary>
        /// <param name="timeout"></param>
        internal abstract Task<ReceivingAmqpLink> GetOrCreateLinkAsync(TimeSpan timeout);

    }
}
