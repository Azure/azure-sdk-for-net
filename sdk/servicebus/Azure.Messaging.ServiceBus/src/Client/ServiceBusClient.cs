// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusClient"/> is the top-level client through which all Service Bus
    /// entities can be interacted with. Any lower level types retrieved from here, such
    /// as <see cref="ServiceBusSender"/> and <see cref="ServiceBusReceiver"/> will share the
    /// same AMQP connection. Disposing the <see cref="ServiceBusClient"/> will cause the AMQP
    /// connection to close.
    /// </summary>
    public class ServiceBusClient : IAsyncDisposable
    {
        private readonly ServiceBusClientOptions _options;

        /// <summary>
        ///   The fully qualified Service Bus namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// The transport type used for this <see cref="ServiceBusClient"/>.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        ///   A unique name used to identify this <see cref="ServiceBusClient"/>.
        /// </summary>
        internal string Identifier { get; }

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        /// The list of plugins for the client.
        /// </summary>
        internal IList<ServiceBusPlugin> Plugins { get; set; } = new List<ServiceBusPlugin>();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusConnection" />,
        ///   including ensuring that the connection itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync()
        {
            Logger.ClientCloseStart(typeof(ServiceBusClient), Identifier);
            IsClosed = true;
            try
            {
                await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.ClientCloseException(typeof(ServiceBusClient), Identifier, ex);
                throw;
            }
            finally
            {
                Logger.ClientCloseComplete(typeof(ServiceBusClient), Identifier);
            }
        }

        /// <summary>
        /// Can be used for mocking.
        /// </summary>
        protected ServiceBusClient()
        {
        }

        /// <summary>
        /// The connection that is used for the client.
        /// </summary>
        internal ServiceBusConnection Connection { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the
        /// Service Bus namespace.</param>
        ///
        /// <remarks>
        /// If the connection string specifies a specific entity name, any subsequent calls to
        /// <see cref="CreateSender(string)"/>, <see cref="CreateReceiver(string)"/>,
        /// <see cref="CreateProcessor(string)"/> etc. must still specify the same entity name.
        /// </remarks>
        public ServiceBusClient(string connectionString) :
            this(connectionString, new ServiceBusClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the
        /// Service Bus namespace.</param>
        /// <param name="options">The set of <see cref="ServiceBusClientOptions"/> to use for
        /// configuring this <see cref="ServiceBusClient"/>.</param>
        ///
        /// <remarks>
        /// If the connection string specifies a specific entity name, any subsequent calls to
        /// <see cref="CreateSender(string)"/>, <see cref="CreateReceiver(string)"/>,
        /// <see cref="CreateProcessor(string)"/> etc. must still specify the same entity name.
        /// </remarks>
        public ServiceBusClient(string connectionString, ServiceBusClientOptions options)
        {
            _options = options?.Clone() ?? new ServiceBusClientOptions();
            Connection = new ServiceBusConnection(connectionString, _options);
            Logger.ClientCreateStart(typeof(ServiceBusClient), FullyQualifiedNamespace);
            Identifier = DiagnosticUtilities.GenerateIdentifier(FullyQualifiedNamespace);
            Plugins = _options.Plugins;
            Logger.ClientCreateComplete(typeof(ServiceBusClient), Identifier);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="ServiceBusSharedAccessKeyCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        internal ServiceBusClient(string fullyQualifiedNamespace, ServiceBusSharedAccessKeyCredential credential) :
            this(fullyQualifiedNamespace, credential, new ServiceBusClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="ServiceBusSharedAccessKeyCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        /// <param name="options">The set of <see cref="ServiceBusClientOptions"/> to use for configuring this <see cref="ServiceBusClient"/>.</param>
        internal ServiceBusClient(
            string fullyQualifiedNamespace,
            ServiceBusSharedAccessKeyCredential credential,
            ServiceBusClientOptions options)
        {
            _options = options?.Clone() ?? new ServiceBusClientOptions();
            Logger.ClientCreateStart(typeof(ServiceBusClient), fullyQualifiedNamespace);
            Identifier = DiagnosticUtilities.GenerateIdentifier(fullyQualifiedNamespace);
            Connection = new ServiceBusConnection(
                fullyQualifiedNamespace,
                credential,
                _options);
            Plugins = _options.Plugins;
            Logger.ClientCreateComplete(typeof(ServiceBusClient), Identifier);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential) :
            this(fullyQualifiedNamespace, credential, new ServiceBusClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        /// <param name="options">The set of <see cref="ServiceBusClientOptions"/> to use for configuring this <see cref="ServiceBusClient"/>.</param>
        public ServiceBusClient(
            string fullyQualifiedNamespace,
            TokenCredential credential,
            ServiceBusClientOptions options)
        {
            _options = options?.Clone() ?? new ServiceBusClientOptions();
            Logger.ClientCreateStart(typeof(ServiceBusClient), fullyQualifiedNamespace);
            Identifier = DiagnosticUtilities.GenerateIdentifier(fullyQualifiedNamespace);
            Connection = new ServiceBusConnection(
                fullyQualifiedNamespace,
                credential,
                _options);
            Plugins = _options.Plugins;
            Logger.ClientCreateComplete(typeof(ServiceBusClient), Identifier);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> instance that can be used for sending messages to a specific
        /// queue or topic.
        /// </summary>
        ///
        /// <param name="queueOrTopicName">The queue or topic to create a <see cref="ServiceBusSender"/>
        /// for.</param>
        ///
        /// <returns>A <see cref="ServiceBusSender"/> scoped to the specified queue or topic.</returns>
        public virtual ServiceBusSender CreateSender(string queueOrTopicName)
        {
            ValidateEntityName(queueOrTopicName);

            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                options: new ServiceBusSenderOptions(),
                connection: Connection,
                plugins: Plugins);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> instance that can be used for sending messages to a specific
        /// queue or topic.
        /// </summary>
        ///
        /// <param name="queueOrTopicName">The queue or topic to create a <see cref="ServiceBusSender"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSenderOptions"/> to use for configuring
        /// this <see cref="ServiceBusSender"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusSender"/> scoped to the specified queue or topic.</returns>
        internal virtual ServiceBusSender CreateSender(string queueOrTopicName, ServiceBusSenderOptions options)
        {
            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                options: options,
                connection: Connection,
                plugins: Plugins);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving and settling messages
        /// from a specific queue. It uses <see cref="ServiceBusReceiveMode"/> to specify how messages are received. Defaults to PeekLock mode.
        /// If you want to change the <see cref="ServiceBusReceiveMode"/>, use <see cref="CreateReceiver(string, ServiceBusReceiverOptions)"/> method.
        /// The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified queue.</returns>
        public virtual ServiceBusReceiver CreateReceiver(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
                plugins: Plugins,
                options: new ServiceBusReceiverOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving and settling messages
        /// from a specific queue. It uses <see cref="ServiceBusReceiveMode"/> to specify how messages are received. Defaults to PeekLock mode.
        /// The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified queue.</returns>
        public virtual ServiceBusReceiver CreateReceiver(
            string queueName,
            ServiceBusReceiverOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
                plugins: Plugins,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving and
        /// settling messages from a specific subscription. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. If you want to change the <see cref="ServiceBusReceiveMode"/>,
        /// use <see cref="CreateReceiver(string, string, ServiceBusReceiverOptions)"/> method.
        /// The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="subscriptionName">The subscription specific to the specified topic to create
        /// a <see cref="ServiceBusReceiver"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified subscription and topic.</returns>
        public virtual ServiceBusReceiver CreateReceiver(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                isSessionEntity: false,
                plugins: Plugins,
                options: new ServiceBusReceiverOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for
        /// receiving and settling messages from a specific subscription. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="subscriptionName">The subscription specific to the specified topic to create
        /// a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified subscription and topic.</returns>
        public virtual ServiceBusReceiver CreateReceiver(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                isSessionEntity: false,
                plugins: Plugins,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a specific session-enabled queue. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="queueName">The session-enabled queue to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If there are no available messages in the queue,
        /// this will throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> AcceptNextSessionAsync(
            string queueName,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: queueName,
                connection: Connection,
                plugins: Plugins,
                options: options,
                sessionId: default,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a specific session-enabled subscription. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="subscriptionName">The session-enabled subscription to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If there are no available messages in the queue,
        /// this will throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> AcceptNextSessionAsync(
            string topicName,
            string subscriptionName,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(topicName);

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                plugins: Plugins,
                options: options,
                sessionId: default,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a specific session-enabled queue. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="queueName">The session-enabled queue to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="sessionId">Gets or sets a session ID to scope the <see cref="ServiceBusSessionReceiver"/> to.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is null, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> AcceptSessionAsync(
            string queueName,
            string sessionId,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);
            options ??= new ServiceBusSessionReceiverOptions();

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: queueName,
                connection: Connection,
                plugins: Plugins,
                options: options,
                sessionId: sessionId,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a specific session-enabled subscription. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusReceiverOptions"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="subscriptionName">The session-enabled subscription to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="sessionId">Gets or sets a session ID to scope the <see cref="ServiceBusSessionReceiver"/> to.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is null, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> AcceptSessionAsync(
            string topicName,
            string subscriptionName,
            string sessionId,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(topicName);
            options ??= new ServiceBusSessionReceiverOptions();

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                plugins: Plugins,
                options: options,
                sessionId: sessionId,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. If you want to change the <see cref="ServiceBusReceiveMode"/>,
        /// use <see cref="CreateProcessor(string, ServiceBusProcessorOptions)"/> method.
        /// The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusProcessor"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified queue.</returns>
        public virtual ServiceBusProcessor CreateProcessor(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                plugins: Plugins,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusProcessor"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified queue.</returns>
        public virtual ServiceBusProcessor CreateProcessor(
            string queueName,
            ServiceBusProcessorOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                plugins: Plugins,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. If you want to change the <see cref="ServiceBusReceiveMode"/>,
        /// use <see cref="CreateProcessor(string, string, ServiceBusProcessorOptions)"/> method.
        /// The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="subscriptionName">The subscription to create a <see cref="ServiceBusProcessor"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public virtual ServiceBusProcessor CreateProcessor(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                plugins: Plugins,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="subscriptionName">The subscription to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusProcessor"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public virtual ServiceBusProcessor CreateProcessor(
            string topicName,
            string subscriptionName,
            ServiceBusProcessorOptions options)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                plugins: Plugins,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionProcessor"/> instance that can be used to process session messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionProcessor"/>.</param>
        /// <returns>A <see cref="ServiceBusSessionProcessor"/> scoped to the specified queue.</returns>
        public virtual ServiceBusSessionProcessor CreateSessionProcessor(
            string queueName,
            ServiceBusSessionProcessorOptions options = default)
        {
            ValidateEntityName(queueName);

            return new ServiceBusSessionProcessor(
                entityPath: queueName,
                connection: Connection,
                plugins: Plugins,
                options: options ?? new ServiceBusSessionProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionProcessor"/> instance that can be used to process
        /// messages using event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="subscriptionName">The subscription to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionProcessor"/> to use for configuring the
        /// <see cref="ServiceBusSessionProcessor"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public virtual ServiceBusSessionProcessor CreateSessionProcessor(
            string topicName,
            string subscriptionName,
            ServiceBusSessionProcessorOptions options = default)
        {
            ValidateEntityName(topicName);

            return new ServiceBusSessionProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                plugins: Plugins,
                options: options ?? new ServiceBusSessionProcessorOptions());
        }

        /// <summary>
        /// The <see cref="ServiceBusRuleManager"/> is used to manage the rules for a subscription.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusRuleManager"/> for.</param>
        /// <param name="subscriptionName">The subscription specific to the specified topic to create
        /// a <see cref="ServiceBusRuleManager"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusRuleManager"/> scoped to the specified subscription and topic.</returns>
        internal ServiceBusRuleManager CreateRuleManager(string topicName, string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusRuleManager(
                connection: Connection,
                subscriptionPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName));
        }

        /// <summary>
        /// Validates that the specified entity name matches the entity path in the Connection,
        /// if an entity path is specified in the connection.
        /// </summary>
        ///
        /// <param name="entityName">Entity name to validate</param>
        private void ValidateEntityName(string entityName)
        {
            // The entity name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
            // value, then do not consider this a failure.

            if (!string.IsNullOrEmpty(Connection.EntityPath) && !string.Equals(entityName, Connection.EntityPath, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(Resources.OnlyOneEntityNameMayBeSpecified);
            }
        }
    }
}
