// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Amqp;
    using Microsoft.Azure.Amqp;
    using Core;
    using Primitives;

    /// <summary>
    /// A session client can be used to accept session objects which can be used to interact with all messages with the same sessionId.
    /// </summary>
    /// <remarks>
    /// You can accept any session or a given session (identified by <see cref="MessageSession.SessionId"/> using a session client.
    /// Once you accept a session, you can use it as a <see cref="MessageReceiver"/> which receives only messages having the same session id.
    /// See <see cref="MessageSession"/> for usage of session object.
    /// This uses AMQP protocol to communicate with the service.
    /// </remarks>
    /// <example>
    /// To create a new SessionClient
    /// <code>
    /// SessionClient sessionClient = new SessionClient(
    ///     namespaceConnectionString,
    ///     queueName,
    ///     ReceiveMode.PeekLock);
    /// </code>
    ///
    /// To receive a session object for a given sessionId
    /// <code>
    /// MessageSession session = await sessionClient.AcceptMessageSessionAsync(sessionId);
    /// </code>
    ///
    /// To receive any session
    /// <code>
    /// MessageSession session = await sessionClient.AcceptMessageSessionAsync();
    /// </code>
    /// </example>
    /// <seealso cref="MessageSession"/>
    public sealed class SessionClient
    {
        const int DefaultPrefetchCount = 0;
        readonly ServiceBusDiagnosticSource diagnosticSource;
        
        internal ClientEntity ClientEntity { get; set; }

        /// <summary>
        /// Creates a new SessionClient from a <see cref="ServiceBusConnectionStringBuilder"/>
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> having entity level connection details.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is used for all the sessions objects accepted using this client.</remarks>
        internal SessionClient(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            int prefetchCount = DefaultPrefetchCount,
            AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, receiveMode, prefetchCount, options)
        {
        }

        /// <summary>
        /// Creates a new SessionClient from a specified connection string and entity path.
        /// </summary>
        /// <param name="connectionString">Namespace connection string used to communicate with Service Bus. Must not contain entity details.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the full path.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is used for all the sessions objects accepted using this client.</remarks>
        public SessionClient(
            string connectionString,
            string entityPath,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            int prefetchCount = DefaultPrefetchCount,
            AmqpClientOptions options = null)
            : this(nameof(SessionClient),
                  entityPath,
                  null,
                  receiveMode,
                  prefetchCount,
                  new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString)),
                  null,
                  options)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new SessionClient from a specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public SessionClient(
            string endpoint,
            string entityPath,
            TokenCredential tokenProvider,
            TransportType transportType = TransportType.Amqp,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            AmqpClientOptions options = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(nameof(SessionClient),
                entityPath,
                null,
                receiveMode,
                prefetchCount,
                new ServiceBusConnection(endpoint, tokenProvider, options),
                null,
                options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new SessionClient on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the full path.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        public SessionClient(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            ReceiveMode receiveMode,
            AmqpClientOptions options = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(nameof(SessionClient),
                entityPath,
                null,
                receiveMode,
                prefetchCount,
                serviceBusConnection,
                null,
                options)
        {
            ClientEntity.OwnsConnection = false;
        }

        internal SessionClient(
            string clientTypeName,
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            int prefetchCount,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            AmqpClientOptions options)
        {
            ClientEntity = new ClientEntity(options, entityPath);
            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.EntityPath = entityPath;
            this.EntityType = entityType;
            this.ReceiveMode = receiveMode;
            this.PrefetchCount = prefetchCount;
            ClientEntity.ServiceBusConnection.ThrowIfClosed();

            if (cbsTokenProvider != null)
            {
                this.CbsTokenProvider = cbsTokenProvider;
            }
            else if (ClientEntity.ServiceBusConnection.TokenCredential != null)
            {
                this.CbsTokenProvider = new TokenProviderAdapter(ClientEntity.ServiceBusConnection.TokenCredential, ClientEntity.ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            this.diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);
        }

        ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Gets the path of the entity. This is either the name of the queue, or the full path of the subscription.
        /// </summary>
        public string EntityPath { get; }

        /// <summary>
        /// Gets the path of the entity. This is either the name of the queue, or the full path of the subscription.
        /// </summary>
        public string Path => this.EntityPath;

        MessagingEntityType? EntityType { get; }

        internal int PrefetchCount { get; set; }

        ICbsTokenProvider CbsTokenProvider { get; }

        /// <summary>
        /// Gets a session object of any <see cref="MessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<MessageSession> AcceptMessageSessionAsync()
        {
            return this.AcceptMessageSessionAsync(ClientEntity.ServiceBusConnection.OperationTimeout);
        }

        /// <summary>
        /// Gets a session object of any <see cref="MessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="operationTimeout">Amount of time for which the call should wait to fetch the next session.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<MessageSession> AcceptMessageSessionAsync(TimeSpan operationTimeout)
        {
            return this.AcceptMessageSessionAsync(null, operationTimeout);
        }

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<MessageSession> AcceptMessageSessionAsync(string sessionId)
        {
            return this.AcceptMessageSessionAsync(sessionId, ClientEntity.ServiceBusConnection.OperationTimeout);
        }

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <param name="operationTimeout">Amount of time for which the call should wait to fetch the next session.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public async Task<MessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan operationTimeout)
        {
            ClientEntity.ThrowIfClosed();

            MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStart(
                ClientEntity.ClientId,
                this.EntityPath,
                this.ReceiveMode,
                this.PrefetchCount,
                sessionId);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.AcceptMessageSessionStart(sessionId) : null;
            Task acceptMessageSessionTask = null;

            var session = new MessageSession(
                this.EntityPath,
                this.EntityType,
                this.ReceiveMode,
                ClientEntity.ServiceBusConnection,
                this.CbsTokenProvider,
                ClientEntity.Options,
                this.PrefetchCount,
                sessionId,
                true);

            try
            {
                acceptMessageSessionTask = ClientEntity.RetryPolicy.RunOperation(
                    () => session.GetSessionReceiverLinkAsync(operationTimeout),
                    operationTimeout);
                await acceptMessageSessionTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled && !(exception is ServiceBusTimeoutException))
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionException(
                    ClientEntity.ClientId,
                    this.EntityPath,
                    exception);

                await session.CloseAsync().ConfigureAwait(false);
                throw AmqpExceptionHelper.GetClientException(exception);
            }
            finally
            {
                this.diagnosticSource.AcceptMessageSessionStop(activity, session.SessionId, acceptMessageSessionTask?.Status);
            }

            MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStop(
                ClientEntity.ClientId,
                this.EntityPath,
                session.SessionIdInternal);

            session.ClientEntity.UpdateClientId(ClientEntity.GenerateClientId(nameof(MessageSession), $"{this.EntityPath}_{session.SessionId}"));

            return session;
        }
        
        public Task CloseAsync() => ClientEntity.CloseAsync(OnClosingAsync);

        internal Task OnClosingAsync()
        {
            return Task.CompletedTask;
        }
    }
}