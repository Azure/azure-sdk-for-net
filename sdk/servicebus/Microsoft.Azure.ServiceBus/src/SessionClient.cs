// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Amqp;
    using Azure.Amqp;
    using Core;
    using Primitives;

    /// <summary>
    /// A session client can be used to accept session objects which can be used to interact with all messages with the same sessionId.
    /// </summary>
    /// <remarks>
    /// You can accept any session or a given session (identified by <see cref="IMessageSession.SessionId"/> using a session client.
    /// Once you accept a session, you can use it as a <see cref="MessageReceiver"/> which receives only messages having the same session id.
    /// See <see cref="IMessageSession"/> for usage of session object.
    /// This uses AMQP protocol to communicate with the service.
    /// </remarks>
    /// <example>
    /// To create a new SessionClient
    /// <code>
    /// ISessionClient sessionClient = new SessionClient(
    ///     namespaceConnectionString,
    ///     queueName,
    ///     ReceiveMode.PeekLock);
    /// </code>
    ///
    /// To receive a session object for a given sessionId
    /// <code>
    /// IMessageSession session = await sessionClient.AcceptMessageSessionAsync(sessionId);
    /// </code>
    ///
    /// To receive any session
    /// <code>
    /// IMessageSession session = await sessionClient.AcceptMessageSessionAsync();
    /// </code>
    /// </example>
    /// <seealso cref="IMessageSession"/>
    public sealed class SessionClient : ClientEntity, ISessionClient
    {
        const int DefaultPrefetchCount = 0;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        /// <summary>
        /// Creates a new SessionClient from a <see cref="ServiceBusConnectionStringBuilder"/>
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> having entity level connection details.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with ServiceBus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is used for all the sessions objects accepted using this client.</remarks>
        public SessionClient(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, receiveMode, retryPolicy, prefetchCount)
        {
        }

        /// <summary>
        /// Creates a new SessionClient from a specified connection string and entity path.
        /// </summary>
        /// <param name="connectionString">Namespace connection string used to communicate with Service Bus. Must not contain entity details.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the full path.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with ServiceBus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is used for all the sessions objects accepted using this client.</remarks>
        public SessionClient(
            string connectionString,
            string entityPath,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(nameof(SessionClient),
                  entityPath,
                  null,
                  receiveMode,
                  prefetchCount,
                  new ServiceBusConnection(connectionString),
                  null,
                  retryPolicy,
                  null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new SessionClient from a specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for queue operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public SessionClient(
            string endpoint,
            string entityPath,
            ITokenProvider tokenProvider,
            TransportType transportType = TransportType.Amqp,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(nameof(SessionClient),
                entityPath,
                null,
                receiveMode,
                prefetchCount,
                new ServiceBusConnection(endpoint, transportType, retryPolicy) {TokenProvider = tokenProvider},
                null,
                retryPolicy,
                null)
        {
            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new SessionClient on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the full path.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with ServiceBus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages the session object
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        public SessionClient(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            ReceiveMode receiveMode,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(nameof(SessionClient),
                entityPath,
                null,
                receiveMode,
                prefetchCount,
                serviceBusConnection,
                null,
                retryPolicy,
                null)
        {
            this.OwnsConnection = false;
        }

        internal SessionClient(
            string clientTypeName,
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            int prefetchCount,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy,
            IList<ServiceBusPlugin> registeredPlugins)
            : base(clientTypeName, entityPath, retryPolicy ?? RetryPolicy.Default)
        {
            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.EntityPath = entityPath;
            this.EntityType = entityType;
            this.ReceiveMode = receiveMode;
            this.PrefetchCount = prefetchCount;
            this.ServiceBusConnection.ThrowIfClosed();

            if (cbsTokenProvider != null)
            {
                this.CbsTokenProvider = cbsTokenProvider;
            }
            else if (this.ServiceBusConnection.TokenProvider != null)
            {
                this.CbsTokenProvider = new TokenProviderAdapter(this.ServiceBusConnection.TokenProvider, this.ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            this.diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);

            // Register plugins on the message session.
            if (registeredPlugins != null)
            {
                foreach (var serviceBusPlugin in registeredPlugins)
                {
                    this.RegisterPlugin(serviceBusPlugin);
                }
            }
        }

        ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Gets the path of the entity. This is either the name of the queue, or the full path of the subscription.
        /// </summary>
        public string EntityPath { get; }

        /// <summary>
        /// Gets the path of the entity. This is either the name of the queue, or the full path of the subscription.
        /// </summary>
        public override string Path => this.EntityPath;

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout
        {
            get => this.ServiceBusConnection.OperationTimeout;
            set => this.ServiceBusConnection.OperationTimeout = value;
        }

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public override ServiceBusConnection ServiceBusConnection { get; }

        MessagingEntityType? EntityType { get; }

        internal int PrefetchCount { get; set; }

        ICbsTokenProvider CbsTokenProvider { get; }

        /// <summary>
        /// Gets a list of currently registered plugins.
        /// </summary>
        public override IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Gets a session object of any <see cref="IMessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<IMessageSession> AcceptMessageSessionAsync()
        {
            return this.AcceptMessageSessionAsync(this.ServiceBusConnection.OperationTimeout);
        }

        /// <summary>
        /// Gets a session object of any <see cref="IMessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="operationTimeout">Amount of time for which the call should wait to fetch the next session.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<IMessageSession> AcceptMessageSessionAsync(TimeSpan operationTimeout)
        {
            return this.AcceptMessageSessionAsync(null, operationTimeout);
        }

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public Task<IMessageSession> AcceptMessageSessionAsync(string sessionId)
        {
            return this.AcceptMessageSessionAsync(sessionId, this.ServiceBusConnection.OperationTimeout);
        }

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <param name="operationTimeout">Amount of time for which the call should wait to fetch the next session.</param>
        /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
        /// Individual sessions can further register additional plugins.</remarks>
        public async Task<IMessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan operationTimeout)
        {
            this.ThrowIfClosed();

            MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStart(
                this.ClientId,
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
                this.ServiceBusConnection,
                this.CbsTokenProvider,
                this.RetryPolicy,
                this.PrefetchCount,
                sessionId,
                true);

            try
            {
                acceptMessageSessionTask = this.RetryPolicy.RunOperation(
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
                    this.ClientId,
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
                this.ClientId,
                this.EntityPath,
                session.SessionIdInternal);

            session.UpdateClientId(ClientEntity.GenerateClientId(nameof(MessageSession), $"{this.EntityPath}_{session.SessionId}"));
            // Register plugins on the message session.
            foreach (var serviceBusPlugin in this.RegisteredPlugins)
            {
                session.RegisterPlugin(serviceBusPlugin);
            }

            return session;
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this receiver.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.ThrowIfClosed();

            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }
            if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPlugin.Name))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(nameof(serviceBusPlugin)));
            }
            this.RegisteredPlugins.Add(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The <see cref="ServiceBusPlugin.Name"/> of the plugin to be unregistered.</param>
        public override void UnregisterPlugin(string serviceBusPluginName)
        {
            this.ThrowIfClosed();

            if (this.RegisteredPlugins == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(serviceBusPluginName))
            {
                throw new ArgumentNullException(nameof(serviceBusPluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPluginName)));
            }
            if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPluginName))
            {
                var plugin = this.RegisteredPlugins.First(p => p.Name == serviceBusPluginName);
                this.RegisteredPlugins.Remove(plugin);
            }
        }

        protected override Task OnClosingAsync()
        {
            return Task.CompletedTask;
        }
    }
}