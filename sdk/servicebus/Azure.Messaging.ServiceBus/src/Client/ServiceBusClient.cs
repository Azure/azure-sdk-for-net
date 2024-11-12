// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusClient"/> is the top-level client through which all Service Bus
    /// entities can be interacted with. Any lower level types retrieved from here, such
    /// as <see cref="ServiceBusSender"/> and <see cref="ServiceBusReceiver"/> will share the
    /// same AMQP connection. Disposing the <see cref="ServiceBusClient"/> will cause the AMQP
    /// connection to close.
    /// </summary>
    /// <remarks>
    /// The <see cref="ServiceBusClient" /> is safe to cache and use for the lifetime of an
    /// application, which is the best practice when the application is making use of Service Bus
    /// regularly or semi-regularly.  The client is responsible for ensuring efficient network, CPU,
    /// and memory use.  Calling <see cref="DisposeAsync" /> as the application is shutting down
    /// will ensure that network resources and other unmanaged objects are properly cleaned up.
    ///</remarks>
    public class ServiceBusClient : IAsyncDisposable
    {
        private readonly ServiceBusClientOptions _options;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        ///   The fully qualified Service Bus namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public virtual string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsClosed
        {
            get => _closed;
            private set => _closed = value;
        }

        /// <summary>
        /// The transport type used for this <see cref="ServiceBusClient"/>.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        ///   The name used to identify this <see cref="ServiceBusClient"/>.
        /// </summary>
        public virtual string Identifier { get; }

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async ValueTask DisposeAsync()
        {
            Logger.ClientCloseStart(typeof(ServiceBusClient), Identifier);
            IsClosed = true;
            try
            {
                await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                GC.SuppressFinalize(this);
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
        /// The connection that is used for the client.
        /// </summary>
        internal ServiceBusConnection Connection { get; }

        /// <summary>
        /// Can be used for mocking.
        /// </summary>
        protected ServiceBusClient()
        {
        }

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
        ///
        /// The connection string will recognize and apply properties populated by the
        /// Azure portal such as Endpoint, SharedAccessKeyName, SharedAccessKey, and EntityPath.
        /// Other values will be ignored; to configure the processor, please use the <see cref="ServiceBusClientOptions" />.
        /// </remarks>
        public ServiceBusClient(string connectionString) :
            this(connectionString, null as ServiceBusClientOptions)
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
        ///
        /// The connection string will recognize and apply properties populated by the
        /// Azure portal such as Endpoint, SharedAccessKeyName, SharedAccessKey, and EntityPath.
        /// Other values will be ignored; to configure the processor, please use the <see cref="ServiceBusClientOptions" />.
        /// </remarks>
        public ServiceBusClient(string connectionString, ServiceBusClientOptions options)
        {
            _options = options?.Clone() ?? new ServiceBusClientOptions();
            Connection = new ServiceBusConnection(connectionString, _options);
            Logger.ClientCreateStart(typeof(ServiceBusClient), FullyQualifiedNamespace);
            Identifier = string.IsNullOrEmpty(_options.Identifier) ? DiagnosticUtilities.GenerateIdentifier(FullyQualifiedNamespace) : _options.Identifier;
            TransportType = _options.TransportType;
            Logger.ClientCreateComplete(typeof(ServiceBusClient), Identifier);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="AzureNamedKeyCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        /// <param name="options">The set of <see cref="ServiceBusClientOptions"/> to use for configuring this <see cref="ServiceBusClient"/>.</param>
        public ServiceBusClient(
            string fullyQualifiedNamespace,
            AzureNamedKeyCredential credential,
            ServiceBusClientOptions options = default) :
                this(fullyQualifiedNamespace, (object)credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="AzureSasCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        /// <param name="options">The set of <see cref="ServiceBusClientOptions"/> to use for configuring this <see cref="ServiceBusClient"/>.</param>
        public ServiceBusClient(
            string fullyQualifiedNamespace,
            AzureSasCredential credential,
            ServiceBusClientOptions options = default) :
                this(fullyQualifiedNamespace, (object)credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace.</param>
        public ServiceBusClient(string fullyQualifiedNamespace, TokenCredential credential) :
            this(fullyQualifiedNamespace, (object)credential, null)
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
            ServiceBusClientOptions options) :
                this(fullyQualifiedNamespace, (object)credential, options)
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
        private ServiceBusClient(
            string fullyQualifiedNamespace,
            object credential,
            ServiceBusClientOptions options)
        {
            Logger.ClientCreateStart(typeof(ServiceBusClient), fullyQualifiedNamespace);
            _options = options?.Clone() ?? new ServiceBusClientOptions();
            Identifier = string.IsNullOrEmpty(_options.Identifier) ? DiagnosticUtilities.GenerateIdentifier(fullyQualifiedNamespace) : _options.Identifier;

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Connection = ServiceBusConnection.CreateWithCredential(
                fullyQualifiedNamespace,
                credential,
                _options);
            TransportType = _options.TransportType;
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueOrTopicName"/> value specified here.
        /// </exception>
        public virtual ServiceBusSender CreateSender(string queueOrTopicName) => CreateSender(queueOrTopicName, null);

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> instance that can be used for sending messages to a specific
        /// queue or topic.
        /// </summary>
        ///
        /// <param name="queueOrTopicName">The queue or topic to create a <see cref="ServiceBusSender"/>
        /// for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSenderOptions"/> to use when configuring
        /// the <see cref="ServiceBusSender"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusSender"/> scoped to the specified queue or topic.</returns>
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueOrTopicName"/> value specified here.
        /// </exception>
        public virtual ServiceBusSender CreateSender(string queueOrTopicName, ServiceBusSenderOptions options)
        {
            ValidateEntityName(queueOrTopicName);

            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                connection: Connection,
                options: options);
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueName"/> value specified here.
        /// </exception>
        public virtual ServiceBusReceiver CreateReceiver(string queueName) => CreateReceiver(queueName, new ServiceBusReceiverOptions());

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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueName"/> value specified here.
        /// </exception>
        public virtual ServiceBusReceiver CreateReceiver(
            string queueName,
            ServiceBusReceiverOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="topicName"/> value specified here.
        /// </exception>
        public virtual ServiceBusReceiver CreateReceiver(
            string topicName,
            string subscriptionName) => CreateReceiver(topicName, subscriptionName, new ServiceBusReceiverOptions());

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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="topicName"/> value specified here.
        /// </exception>
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
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a session-enabled queue by accepting the next unlocked session that contains Active messages. If there
        /// are no unlocked sessions with Active messages, then the call will timeout after the configured <see cref="ServiceBusRetryOptions.TryTimeout"/> value and throw
        /// a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> set to <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// The <see cref="ServiceBusReceiveMode"/> can be specified in the <see cref="ServiceBusReceiverOptions"/> to configure how messages are received.
        /// The default value is <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </summary>
        ///
        /// <param name="queueName">The session-enabled queue to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If there are no available messages in the queue,
        /// this will throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        /// <exception cref="ServiceBusException">
        ///   There are no unlocked sessions in the entity. This can occur if the entity has no Active messages, or if all of the messages
        ///   belong to sessions that are locked by other receivers.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.ServiceTimeout"/> in this case.
        /// </exception>
        public virtual async Task<ServiceBusSessionReceiver> AcceptNextSessionAsync(
            string queueName,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: queueName,
                connection: Connection,
                options: options,
                sessionId: default,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a session-enabled subscription by accepting the next unlocked session that contains Active messages. If there
        /// are no unlocked sessions with Active messages, then the call will timeout after the configured <see cref="ServiceBusRetryOptions.TryTimeout"/> value and throw
        /// a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> set to <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// The <see cref="ServiceBusReceiveMode"/> can be specified in the <see cref="ServiceBusReceiverOptions"/> to configure how messages are received.
        /// The default value is <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="subscriptionName">The session-enabled subscription to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If there are no available messages in the queue,
        /// this will throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        /// <exception cref="ServiceBusException">
        ///   There are no unlocked sessions in the entity. This can occur if the entity has no messages, or if all of the messages
        ///   belong to sessions that are locked by other receivers.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.ServiceTimeout"/> in this case.
        /// </exception>
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
                options: options,
                sessionId: default,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a session-enabled queue by accepting a specific session. The <see cref="ServiceBusReceiveMode"/> can be specified in
        /// the <see cref="ServiceBusReceiverOptions"/> to configure how messages are received.
        /// The default value is <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </summary>
        ///
        /// <param name="queueName">The session-enabled queue to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="sessionId">Gets or sets a session ID to scope the <see cref="ServiceBusSessionReceiver"/> to.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is null, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        /// <exception cref="ServiceBusException">
        ///   The <paramref name="sessionId"/> corresponds to a session that is currently locked by another receiver.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionCannotBeLocked"/> in this case.
        /// </exception>
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
                options: options,
                sessionId: sessionId,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a session-enabled subscription by accepting a specific session. The <see cref="ServiceBusReceiveMode"/> can be specified in
        /// the <see cref="ServiceBusReceiverOptions"/> to configure how messages are received.
        /// The default value is <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="subscriptionName">The session-enabled subscription to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="sessionId">Gets or sets a session ID to scope the <see cref="ServiceBusSessionReceiver"/> to.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is null, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusFailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        /// <exception cref="ServiceBusException">
        ///   The <paramref name="sessionId"/> corresponds to a session that is currently locked by another receiver.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.SessionCannotBeLocked"/> in this case.
        /// </exception>
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueName"/> value specified here.
        /// </exception>
        public virtual ServiceBusProcessor CreateProcessor(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                options: null);
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="queueName"/> value specified here.
        /// </exception>
        public virtual ServiceBusProcessor CreateProcessor(
            string queueName,
            ServiceBusProcessorOptions options)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
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
        /// <exception cref="ArgumentException">
        ///   The <see cref="ServiceBusClient"/> was constructed with a connection string containing the "EntityPath" token
        ///   that has a different value than the <paramref name="topicName"/> value specified here.
        /// </exception>
        public virtual ServiceBusProcessor CreateProcessor(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                options: null);
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
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionProcessor"/> instance that can be used to process session messages using
        /// event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionProcessorOptions"/> to use for configuring the
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
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionProcessor"/> instance that can be used to process
        /// messages using event handlers that are set on the processor. It uses <see cref="ServiceBusReceiveMode"/> to specify
        /// how messages are received. Defaults to PeekLock mode. The <see cref="ServiceBusReceiveMode"/> is set in <see cref="ServiceBusProcessorOptions"/> type.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="subscriptionName">The subscription to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionProcessorOptions"/> to use for configuring the
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
        public virtual ServiceBusRuleManager CreateRuleManager(string topicName, string subscriptionName)
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
        /// <param name="entityName">Entity name to validate.</param>
        internal void ValidateEntityName(string entityName)
        {
            // No entity path specified so the entity name is valid

            if (string.IsNullOrEmpty(Connection.EntityPath))
            {
                return;
            }

            // If the entity name is specified in the connection string,
            // validate that it is the same as the passed in entity name.

            if (string.Equals(entityName, Connection.EntityPath, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            // If the user is preformatting the subscription path into the queueName method, extract the topic name and use that
            // for comparison because subscription paths are not supported in SAS connection strings.
            // This is important for the Service Bus Functions extension which does pre-formatting of the entity path.
            // If this is the case the entity name will be in the format of {topic}/Subscriptions/{subscription}
            const string SubscriptionSlug = "/Subscriptions/";

            int subscriptionStart = entityName.IndexOf(SubscriptionSlug, StringComparison.InvariantCultureIgnoreCase);
            bool match = subscriptionStart switch
            {
                > 0 => subscriptionStart + SubscriptionSlug.Length < entityName.Length // ensure subscription is not empty as that would make it an invalid entity path
                       && string.Equals(entityName.Substring(0, subscriptionStart), Connection.EntityPath, StringComparison.InvariantCultureIgnoreCase),
                _ => false
            };

            if (!match)
            {
                throw new ArgumentException(Resources.OnlyOneEntityNameMayBeSpecified);
            }
        }
    }
}
