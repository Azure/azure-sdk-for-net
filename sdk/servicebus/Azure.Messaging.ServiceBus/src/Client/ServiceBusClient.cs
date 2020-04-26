// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
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
    public class ServiceBusClient : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusClient"/> has been disposed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; } = false;

        /// <summary>
        /// The transport type used for this <see cref="ServiceBusClient"/>.
        /// </summary>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        ///   A unique name used to identify this <see cref="ServiceBusClient"/>.
        /// </summary>
        internal string Identifier { get; }

        /// <summary>
        ///   The set of client options used for creation of client.
        /// </summary>
        ///
        private ServiceBusClientOptions Options { get; set; }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusConnection" />,
        ///   including ensuring that the connection itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync()
        {
            ServiceBusEventSource.Log.ClientDisposeStart(typeof(ServiceBusConnection), Identifier);
            IsDisposed = true;
            try
            {
                await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientDisposeException(typeof(ServiceBusConnection), Identifier, ex);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientDisposeComplete(typeof(ServiceBusConnection), Identifier);
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
            Connection = new ServiceBusConnection(connectionString, options);
            Options = Connection.Options;
            Identifier = DiagnosticUtilities.GenerateIdentifier(Connection.FullyQualifiedNamespace);
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
            Identifier = DiagnosticUtilities.GenerateIdentifier(fullyQualifiedNamespace);
            Connection = new ServiceBusConnection(
                fullyQualifiedNamespace,
                credential,
                options);
            Options = Connection.Options;
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
        public ServiceBusSender CreateSender(string queueOrTopicName)
        {
            ValidateEntityName(queueOrTopicName);

            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                viaEntityPath: null,
                connection: Connection);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> instance that can be used for sending messages to a specific
        /// queue or topic via a different queue or topic.
        /// </summary>
        ///
        /// <param name="queueOrTopicName">The queue or topic to create a <see cref="ServiceBusSender"/> for.</param>
        /// <param name="viaQueueOrTopicName"></param>
        ///
        /// <remarks>
        /// This is mainly to be used when sending messages in a transaction.
        /// When messages need to be sent across entities in a single transaction, this can be used to ensure
        /// all the messages land initially in the same entity/partition for local transactions, and then
        /// let Service Bus handle transferring the message to the actual destination.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSender"/> scoped to the specified queue or topic.</returns>
        public ServiceBusSender CreateSender(string queueOrTopicName, string viaQueueOrTopicName)
        {
            ValidateEntityName(viaQueueOrTopicName);
            ValidateEntityName(queueOrTopicName);

            return new ServiceBusSender(
                entityPath: queueOrTopicName,
                viaEntityPath: viaQueueOrTopicName,
                connection: Connection);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving and settling messages
        /// from a specific queue.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified queue.</returns>
        public ServiceBusReceiver CreateReceiver(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: queueName,
                isSessionEntity: false,
                options: new ServiceBusReceiverOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving and settling messages
        /// from a specific queue.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified queue.</returns>
        public ServiceBusReceiver CreateReceiver(
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
        /// settling messages from a specific subscription.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="subscriptionName">The subscription specific to the specified topic to create
        /// a <see cref="ServiceBusReceiver"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified subscription and topic.</returns>
        public ServiceBusReceiver CreateReceiver(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                isSessionEntity: false,
                options: new ServiceBusReceiverOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for
        /// receiving and settling messages from a specific subscription.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="subscriptionName">The subscription specific to the specified topic to create
        /// a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the specified subscription and topic.</returns>
        public ServiceBusReceiver CreateReceiver(
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
        /// and settling messages from a specific session-enabled queue.
        /// </summary>
        ///
        /// <param name="queueName">The session-enabled queue to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="sessionId">An optional session ID to scope the <see cref="ServiceBusSessionReceiver"/> to. If left blank,
        /// the next available session returned from the service will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is not specified, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusException.FailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> CreateSessionReceiverAsync(
            string queueName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(queueName);

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: queueName,
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionReceiver"/> instance that can be used for receiving
        /// and settling messages from a specific session-enabled subscription.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="subscriptionName">The session-enabled subscription to create a <see cref="ServiceBusSessionReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionReceiver"/>.</param>
        /// <param name="sessionId">An optional session ID to scope the <see cref="ServiceBusSessionReceiver"/> to. If left blank,
        /// the next available session returned from the service will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Because this is establishing a session lock, this method performs a service call. If the
        /// sessionId parameter is not specified, and there are no available messages in the queue, this will
        /// throw a <see cref="ServiceBusException"/> with <see cref="ServiceBusException.Reason"/> of <see cref="ServiceBusException.FailureReason.ServiceTimeout"/>.
        /// </remarks>
        ///
        /// <returns>A <see cref="ServiceBusSessionReceiver"/> scoped to the specified queue and a specific session.</returns>
        public virtual async Task<ServiceBusSessionReceiver> CreateSessionReceiverAsync(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options = default,
            string sessionId = default,
            CancellationToken cancellationToken = default)
        {
            ValidateEntityName(topicName);

            return await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                sessionId: sessionId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving from the
        /// dead letter queue for the specified queue.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the dead letter queue of the specified
        /// queue.</returns>
        public ServiceBusReceiver CreateDeadLetterReceiver(
            string queueName,
            ServiceBusReceiverOptions options = default)
        {
            ValidateEntityName(queueName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatDeadLetterPath(queueName),
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> instance that can be used for receiving from the
        /// dead letter queue for the specified subscription.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="subscriptionName">The subscription to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusReceiverOptions"/> to use for configuring the
        /// <see cref="ServiceBusReceiver"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusReceiver"/> scoped to the dead letter queue of the specified
        /// queue.</returns>
        public ServiceBusReceiver CreateDeadLetterReceiver(
            string topicName,
            string subscriptionName,
            ServiceBusReceiverOptions options = default)
        {
            ValidateEntityName(topicName);

            return new ServiceBusReceiver(
                connection: Connection,
                entityPath: EntityNameFormatter.FormatDeadLetterPath(
                    EntityNameFormatter.FormatSubscriptionPath(
                        topicName,
                        subscriptionName)),
                isSessionEntity: false,
                options: options);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusProcessor"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified queue.</returns>
        public ServiceBusProcessor CreateProcessor(string queueName)
        {
            ValidateEntityName(queueName);

            return new ServiceBusProcessor(
                entityPath: queueName,
                connection: Connection,
                isSessionEntity: false,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusProcessor"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified queue.</returns>
        public ServiceBusProcessor CreateProcessor(
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
        /// event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="subscriptionName">The subcription to create a <see cref="ServiceBusProcessor"/> for.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public ServiceBusProcessor CreateProcessor(
            string topicName,
            string subscriptionName)
        {
            ValidateEntityName(topicName);

            return new ServiceBusProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                isSessionEntity: false,
                options: new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that can be used to process messages using
        /// event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="subscriptionName">The subcription to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusProcessor"/>.</param>
        ///
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public ServiceBusProcessor CreateProcessor(
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
        /// event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="queueName">The queue to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusProcessorOptions"/> to use for configuring the
        /// <see cref="ServiceBusSessionProcessor"/>.</param>
        /// <param name="sessionId">An optional session ID to scope the <see cref="ServiceBusSessionProcessor"/> to.
        /// If left blank, the next available session returned from the service will be used.</param>
        /// <returns>A <see cref="ServiceBusSessionProcessor"/> scoped to the specified queue.</returns>
        public ServiceBusSessionProcessor CreateSessionProcessor(
            string queueName,
            ServiceBusProcessorOptions options = default,
            string sessionId = default)
        {
            ValidateEntityName(queueName);

            return new ServiceBusSessionProcessor(
                entityPath: queueName,
                connection: Connection,
                sessionId: sessionId,
                options: options ?? new ServiceBusProcessorOptions());
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSessionProcessor"/> instance that can be used to process
        /// messages using event handlers that are set on the processor.
        /// </summary>
        ///
        /// <param name="topicName">The topic to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="subscriptionName">The subcription to create a <see cref="ServiceBusSessionProcessor"/> for.</param>
        /// <param name="options">The set of <see cref="ServiceBusSessionProcessor"/> to use for configuring the
        /// <see cref="ServiceBusSessionProcessor"/>.</param>
        /// <param name="sessionId">An optional session ID to scope the <see cref="ServiceBusSessionProcessor"/> to.
        /// If left blank, the next available session returned from the service will be used.</param>
        /// <returns>A <see cref="ServiceBusProcessor"/> scoped to the specified topic and subscription.</returns>
        public ServiceBusSessionProcessor CreateSessionProcessor(
            string topicName,
            string subscriptionName,
            ServiceBusProcessorOptions options = default,
            string sessionId = default)
        {
            ValidateEntityName(topicName);

            return new ServiceBusSessionProcessor(
                entityPath: EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),
                connection: Connection,
                sessionId: sessionId,
                options: options ?? new ServiceBusProcessorOptions());
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
        public ServiceBusRuleManager CreateRuleManager(string topicName, string subscriptionName)
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
