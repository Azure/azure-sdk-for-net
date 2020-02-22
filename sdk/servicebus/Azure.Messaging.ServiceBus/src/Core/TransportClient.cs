// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing an Service Bus entity client so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="ServiceBusConnection" /> employ
    ///   a transport client via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportClient : IAsyncDisposable
    {
        /// <summary>
        ///   Indicates whether or not this client has been closed.
        ///   </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public virtual bool IsClosed { get; }

        /// <summary>
        ///   The endpoint for the Service Bus service to which the client is associated.
        /// </summary>
        ///
        public virtual Uri ServiceEndpoint { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="timeout"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="sessionId"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<IEnumerable<ServiceBusMessage>> PeekAsync(
            TimeSpan timeout,
            long? fromSequenceNumber,
            int messageCount = 1,
            string sessionId = null,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            ServiceBusRetryPolicy retryPolicy,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CancelScheduledMessageAsync(
            long sequenceNumber,
            ServiceBusRetryPolicy retryPolicy,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="ServiceBusMessage" /> to the entity.
        /// </summary>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        ///
        public abstract TransportSender CreateSender(ServiceBusRetryPolicy retryPolicy);

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        /// </summary>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        ///
        public abstract TransportConsumer CreateConsumer(
            ServiceBusRetryPolicy retryPolicy,
            ReceiveMode receiveMode,
            uint? prefetchCount,
            string sessionId,
            bool isSessionReceiver);

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public abstract Task CloseAsync(CancellationToken cancellationToken);

        /// <summary>
        ///   Performs the task needed to clean up resources used by the client,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync(CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockTokens"></param>
        /// <param name="timeout"></param>
        /// <param name="sessionId"></param>
        /// <param name="receiveLinkName"></param>
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
            string receiveLinkName = null,
            IDictionary<string, object> propertiesToModify = null,
            string deadLetterReason = null,
            string deadLetterDescription = null);
    }
}
