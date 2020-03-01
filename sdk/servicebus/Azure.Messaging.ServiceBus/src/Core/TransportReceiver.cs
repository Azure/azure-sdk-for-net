// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Event Consumer so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="ServiceBusProcessor" /> employ
    ///   a transport consumer via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportReceiver
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
        /// The scope <see cref="TransportConnectionScope"/> associated with the
        /// <see cref="TransportReceiver"/>.
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
        public abstract Task<IEnumerable<ServiceBusReceivedMessage>> ReceiveAsync(
            int maximumMessageCount,
            CancellationToken cancellationToken);

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);

        public abstract Task OpenLinkAsync(CancellationToken cancellationToken);

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
        /// <param name="timeout"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<IEnumerable<ServiceBusReceivedMessage>> PeekAsync(
            TimeSpan timeout,
            long? fromSequenceNumber,
            int messageCount = 1,
            string sessionId = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockTokens"></param>
        /// <param name="timeout"></param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        /// <param name="dispositionStatus"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterDescription"></param>
        /// <returns></returns>
        internal abstract Task DisposeMessageRequestResponseAsync(
            Guid[] lockTokens,
            TimeSpan timeout,
            DispositionStatus dispositionStatus,
            bool isSessionReceiver,
            string sessionId = null,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null);

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
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <param name="timeout"></param>
        public abstract Task<DateTime> RenewLockAsync(
            string lockToken,
            TimeSpan timeout);

        /// <summary>
        ///
        /// </summary>
        ///
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        ///
        /// <param name="sessionId"></param>
        /// <param name="timeout"></param>
        public abstract Task<DateTime> RenewSessionLockAsync(
            string sessionId,
            TimeSpan timeout);

        /// <summary>
        ///
        /// </summary>
        /// <param name="timeout"></param>
        internal abstract Task<ReceivingAmqpLink> GetOrCreateLinkAsync(TimeSpan timeout);

    }
}
