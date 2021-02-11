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
        ///   Creates a sender strongly aligned with the active protocol and transport,
        ///   responsible for sending <see cref="ServiceBusMessage" /> to the entity.
        /// </summary>
        /// <param name="entityPath">The entity path to send the message to.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="identifier">The identifier for the sender.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        ///
        public abstract TransportSender CreateSender(string entityPath, ServiceBusRetryPolicy retryPolicy, string identifier);

        /// <summary>
        ///   Creates a receiver strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Service Bus entity.
        /// </summary>
        /// <param name="entityPath"></param>
        ///
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="identifier"></param>
        /// <param name="sessionId"></param>
        /// <param name="isSessionReceiver"></param>
        ///
        /// <returns>A <see cref="TransportReceiver" /> configured in the requested manner.</returns>
        ///
        public abstract TransportReceiver CreateReceiver(
            string entityPath,
            ServiceBusRetryPolicy retryPolicy,
            ServiceBusReceiveMode receiveMode,
            uint prefetchCount,
            string identifier,
            string sessionId,
            bool isSessionReceiver);

        /// <summary>
        ///   Creates a rule manager strongly aligned with the active protocol and transport,
        ///   responsible for adding, removing and getting rules from the Service Bus subscription.
        /// </summary>
        ///
        /// <param name="subscriptionPath">The path of the Service Bus subscription to which the rule manager is bound.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="identifier">The identifier for the rule manager.</param>
        ///
        /// <returns>A <see cref="TransportRuleManager"/> configured in the requested manner.</returns>
        ///
        public abstract TransportRuleManager CreateRuleManager(
            string subscriptionPath,
            ServiceBusRetryPolicy retryPolicy,
            string identifier);

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
    }
}
