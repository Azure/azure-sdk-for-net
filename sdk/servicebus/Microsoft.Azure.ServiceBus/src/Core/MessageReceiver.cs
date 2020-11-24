// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.ServiceBus.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// The MessageReceiver can be used to receive messages from Queues and Subscriptions and acknowledge them.
    /// </summary>
    /// <example>
    /// Create a new MessageReceiver to receive a message from a Subscription
    /// <code>
    /// IMessageReceiver messageReceiver = new MessageReceiver(
    ///     namespaceConnectionString,
    ///     EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName),
    ///     ReceiveMode.PeekLock);
    /// </code>
    ///
    /// Receive a message from the Subscription.
    /// <code>
    /// var message = await messageReceiver.ReceiveAsync();
    /// await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
    /// </code>
    /// </example>
    /// <remarks>
    /// The MessageReceiver provides advanced functionality that is not found in the
    /// <see cref="QueueClient" /> or <see cref="SubscriptionClient" />. For instance,
    /// <see cref="ReceiveAsync()"/>, which allows you to receive messages on demand, but also requires
    /// you to manually renew locks using <see cref="RenewLockAsync(Message)"/>.
    /// It uses AMQP protocol to communicate with service.
    /// </remarks>
    public class MessageReceiver : ClientEntity, IMessageReceiver
    {
        private static readonly TimeSpan DefaultBatchFlushInterval = TimeSpan.FromMilliseconds(20);

        readonly ConcurrentExpiringSet<Guid> requestResponseLockedMessages;
        readonly bool isSessionReceiver;
        readonly object messageReceivePumpSyncLock;
        readonly ActiveClientLinkManager clientLinkManager;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        int prefetchCount;
        long lastPeekedSequenceNumber;
        MessageReceivePump receivePump;
        // Cancellation token to cancel the message pump. Once this is fired, all future message handling operations registered by application will be
        // cancelled. 
        CancellationTokenSource receivePumpCancellationTokenSource;
        // Cancellation token to cancel the inflight message handling operations registered by application in the message pump. 
        CancellationTokenSource runningTaskCancellationTokenSource;

        /// <summary>
        /// Creates a new MessageReceiver from a <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> having entity level connection details.</param>
        /// <param name="receiveMode">The <see cref="ServiceBus.ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/>.</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageReceiver(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = Constants.DefaultClientPrefetchCount)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, receiveMode, retryPolicy, prefetchCount)
        {
        }

        /// <summary>
        /// Creates a new MessageReceiver from a specified connection string and entity path.
        /// </summary>
        /// <param name="connectionString">Namespace connection string used to communicate with Service Bus. Must not contain Entity details.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the path.
        /// You can use <see cref="EntityNameHelper.FormatSubscriptionPath(string, string)"/>, to help create this path.</param>
        /// <param name="receiveMode">The <see cref="ServiceBus.ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageReceiver(
            string connectionString,
            string entityPath,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = Constants.DefaultClientPrefetchCount)
            : this(entityPath, null, receiveMode, new ServiceBusConnection(connectionString), null, retryPolicy, prefetchCount)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new MessageReceiver from a specified endpoint, entity path, and token provider.
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
        public MessageReceiver(
            string endpoint,
            string entityPath,
            ITokenProvider tokenProvider,
            TransportType transportType = TransportType.Amqp,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = Constants.DefaultClientPrefetchCount)
            : this(entityPath, null, receiveMode, new ServiceBusConnection(endpoint, transportType, retryPolicy) {TokenProvider = tokenProvider}, null, retryPolicy, prefetchCount)
        {
            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new AMQP MessageReceiver on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the path.
        /// You can use <see cref="EntityNameHelper.FormatSubscriptionPath(string, string)"/>, to help create this path.</param>
        /// <param name="receiveMode">The <see cref="ServiceBus.ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver
        /// will actively receive regardless of whether a receive operation is pending. Defaults to 0.</param>
        public MessageReceiver(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = Constants.DefaultClientPrefetchCount)
            : this(entityPath, null, receiveMode, serviceBusConnection, null, retryPolicy, prefetchCount)
        {
            this.OwnsConnection = false;
        }

        internal MessageReceiver(
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy,
            int prefetchCount = Constants.DefaultClientPrefetchCount,
            string sessionId = null,
            bool isSessionReceiver = false)
            : base(nameof(MessageReceiver), entityPath, retryPolicy ?? RetryPolicy.Default)
        {
            MessagingEventSource.Log.MessageReceiverCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath, receiveMode.ToString());

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.ReceiveMode = receiveMode;
            this.Path = entityPath;
            this.EntityType = entityType;
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

            this.SessionIdInternal = sessionId;
            this.isSessionReceiver = isSessionReceiver;
            this.ReceiveLinkManager = new FaultTolerantAmqpObject<ReceivingAmqpLink>(this.CreateLinkAsync, CloseSession);
            this.RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(this.CreateRequestResponseLinkAsync, CloseRequestResponseSession);
            this.requestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();
            this.PrefetchCount = prefetchCount;
            this.messageReceivePumpSyncLock = new object();
            this.clientLinkManager = new ActiveClientLinkManager(this, this.CbsTokenProvider);
            this.diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);
            MessagingEventSource.Log.MessageReceiverCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, this.ClientId);
        }

        /// <summary>
        /// Gets a list of currently registered plugins.
        /// </summary>
        public override IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Gets the <see cref="ServiceBus.ReceiveMode"/> of the current receiver.
        /// </summary>
        public ReceiveMode ReceiveMode { get; protected set; }

        /// <summary>
        /// Prefetch speeds up the message flow by aiming to have a message readily available for local retrieval when and before the application asks for one using Receive.
        /// Setting a non-zero value prefetches PrefetchCount number of messages.
        /// Setting the value to zero turns prefetch off.
        /// Defaults to 0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When Prefetch is enabled, the receiver will quietly acquire more messages, up to the PrefetchCount limit, than what the application
        /// immediately asks for. A single initial Receive/ReceiveAsync call will therefore acquire a message for immediate consumption
        /// that will be returned as soon as available, and the client will proceed to acquire further messages to fill the prefetch buffer in the background.
        /// </para>
        /// <para>
        /// While messages are available in the prefetch buffer, any subsequent ReceiveAsync calls will be immediately satisfied from the buffer, and the buffer is
        /// replenished in the background as space becomes available.If there are no messages available for delivery, the receive operation will drain the
        /// buffer and then wait or block as expected.
        /// </para>
        /// <para>Prefetch also works equivalently with the <see cref="RegisterMessageHandler(Func{Message,CancellationToken,Task}, Func{ExceptionReceivedEventArgs, Task})"/> APIs.</para>
        /// <para>Updates to this value take effect on the next receive call to the service.</para>
        /// </remarks>
        public int PrefetchCount
        {
            get => this.prefetchCount;

            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(this.PrefetchCount), value, "Value cannot be less than 0.");
                }
                this.prefetchCount = value;
                if (this.ReceiveLinkManager.TryGetOpenedObject(out var link))
                {
                    link.SetTotalLinkCredit((uint)value, true, true);
                }
            }
        }

        /// <summary>Gets the sequence number of the last peeked message.</summary>
        /// <seealso cref="PeekAsync()"/>
        public long LastPeekedSequenceNumber
        {
            get => this.lastPeekedSequenceNumber;

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.LastPeekedSequenceNumber), value.ToString());
                }

                this.lastPeekedSequenceNumber = value;
            }
        }

        /// <summary>The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the path.</summary>
        public override string Path { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout {
            get => this.ServiceBusConnection.OperationTimeout;
            set => this.ServiceBusConnection.OperationTimeout = value;
        }

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public override ServiceBusConnection ServiceBusConnection { get; }

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until. This is only applicable when Sessions are used.
        /// </summary>
        internal DateTime LockedUntilUtcInternal { get; set; }

        /// <summary>
        /// Gets the SessionId of the current receiver. This is only applicable when Sessions are used.
        /// </summary>
        internal string SessionIdInternal { get; set; }

        internal MessagingEntityType? EntityType { get; }

        Exception LinkException { get; set; }

        ICbsTokenProvider CbsTokenProvider { get; }

        internal FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLinkManager { get; }

        FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        /// <summary>
        /// Receive a message from the entity defined by <see cref="Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <returns>The message received. Returns null if no message is found.</returns>
        /// <remarks>Operation will time out after duration of <see cref="ClientEntity.OperationTimeout"/></remarks>
        public Task<Message> ReceiveAsync()
        {
            return this.ReceiveAsync(this.OperationTimeout);
        }

        /// <summary>
        /// Receive a message from the entity defined by <see cref="Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="operationTimeout">The time span the client waits for receiving a message before it times out.</param>
        /// <returns>The message received. Returns null if no message is found.</returns>
        /// <remarks>
        /// The parameter <paramref name="operationTimeout"/> includes the time taken by the receiver to establish a connection
        /// (either during the first receive or when connection needs to be re-established). If establishing the connection
        /// times out, this will throw <see cref="ServiceBusTimeoutException"/>.
        /// </remarks>
        public async Task<Message> ReceiveAsync(TimeSpan operationTimeout)
        {
            var messages = await this.ReceiveAsync(1, operationTimeout).ConfigureAwait(false);
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        /// <summary>
        /// Receives a maximum of <paramref name="maxMessageCount"/> messages from the entity defined by <see cref="Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <returns>List of messages received. Returns null if no message is found.</returns>
        /// <remarks>Receiving less than <paramref name="maxMessageCount"/> messages is not an indication of empty entity.</remarks>
        public Task<IList<Message>> ReceiveAsync(int maxMessageCount)
        {
            return this.ReceiveAsync(maxMessageCount, this.OperationTimeout);
        }

        /// <summary>
        /// Receives a maximum of <paramref name="maxMessageCount"/> messages from the entity defined by <see cref="Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="operationTimeout">The time span the client waits for receiving a message before it times out.</param>
        /// <returns>List of messages received. Returns null if no message is found.</returns>
        /// <remarks>Receiving less than <paramref name="maxMessageCount"/> messages is not an indication of empty entity.
        /// The parameter <paramref name="operationTimeout"/> includes the time taken by the receiver to establish a connection
        /// (either during the first receive or when connection needs to be re-established). If establishing the connection
        /// times out, this will throw <see cref="ServiceBusTimeoutException"/>.
        /// </remarks>
        public async Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan operationTimeout)
        {
            this.ThrowIfClosed();

            if (operationTimeout <= TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(nameof(operationTimeout), operationTimeout, Resources.TimeoutMustBePositiveNonZero.FormatForUser(nameof(operationTimeout), operationTimeout));
            }

            MessagingEventSource.Log.MessageReceiveStart(this.ClientId, maxMessageCount);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.ReceiveStart(maxMessageCount) : null;
            Task receiveTask = null;

            IList<Message> unprocessedMessageList = null;
            try
            {
                receiveTask = this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        unprocessedMessageList = await this.OnReceiveAsync(maxMessageCount, operationTimeout)
                            .ConfigureAwait(false);
                    }, operationTimeout);
                await receiveTask.ConfigureAwait(false);

            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageReceiveException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.ReceiveStop(activity, maxMessageCount, receiveTask?.Status, unprocessedMessageList);
            }

            MessagingEventSource.Log.MessageReceiveStop(this.ClientId, unprocessedMessageList?.Count ?? 0);

            if (unprocessedMessageList == null)
            {
                return unprocessedMessageList;
            }

            return await this.ProcessMessages(unprocessedMessageList).ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a specific deferred message identified by <paramref name="sequenceNumber"/>.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <returns>Message identified by sequence number <paramref name="sequenceNumber"/>. Returns null if no such message is found.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public async Task<Message> ReceiveDeferredMessageAsync(long sequenceNumber)
        {
            var messages = await this.ReceiveDeferredMessageAsync(new[] { sequenceNumber }).ConfigureAwait(false);
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        /// <summary>
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        public async Task<IList<Message>> ReceiveDeferredMessageAsync(IEnumerable<long> sequenceNumbers)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            if (sequenceNumbers == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(sequenceNumbers));
            }
            var sequenceNumberList = sequenceNumbers.ToArray();
            if (sequenceNumberList.Length == 0)
            {
                throw Fx.Exception.ArgumentNull(nameof(sequenceNumbers));
            }

            MessagingEventSource.Log.MessageReceiveDeferredMessageStart(this.ClientId, sequenceNumberList.Length, sequenceNumberList);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.ReceiveDeferredStart(sequenceNumberList) : null;
            Task receiveTask = null;

            IList<Message> messages = null;
            try
            {
                receiveTask = this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        messages = await this.OnReceiveDeferredMessageAsync(sequenceNumberList).ConfigureAwait(false);
                    }, this.OperationTimeout);
                await receiveTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageReceiveDeferredMessageException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.ReceiveDeferredStop(activity, sequenceNumberList, receiveTask?.Status, messages);
            }
            MessagingEventSource.Log.MessageReceiveDeferredMessageStop(this.ClientId, messages?.Count ?? 0);

            return messages;
        }

        /// <summary>
        /// Completes a <see cref="Message"/> using its lock token. This will delete the message from the service.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public Task CompleteAsync(string lockToken)
        {
            return this.CompleteAsync(new[] { lockToken });
        }

        /// <summary>
        /// Completes a series of <see cref="Message"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        public async Task CompleteAsync(IEnumerable<string> lockTokens)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();
            if (lockTokens == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(lockTokens));
            }
            var lockTokenList = lockTokens.ToList();
            if (lockTokenList.Count == 0)
            {
                throw Fx.Exception.Argument(nameof(lockTokens), Resources.ListOfLockTokensCannotBeEmpty);
            }

            MessagingEventSource.Log.MessageCompleteStart(this.ClientId, lockTokenList.Count, lockTokenList);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.CompleteStart(lockTokenList) : null;
            Task completeTask = null;

            try
            {
                completeTask =
                    this.RetryPolicy.RunOperation(() => this.OnCompleteAsync(lockTokenList), this.OperationTimeout);
                await completeTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageCompleteException(this.ClientId, exception);

                throw;
            }
            finally
            {
                this.diagnosticSource.CompleteStop(activity, lockTokenList, completeTask?.Status);
            }

            MessagingEventSource.Log.MessageCompleteStop(this.ClientId);
        }

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public async Task AbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageAbandonStart(this.ClientId, 1, lockToken);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.DisposeStart("Abandon", lockToken) : null;
            Task abandonTask = null;

            try
            {
                abandonTask = this.RetryPolicy.RunOperation(() => this.OnAbandonAsync(lockToken, propertiesToModify),
                    this.OperationTimeout);
                await abandonTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageAbandonException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.DisposeStop(activity, lockToken, abandonTask?.Status);
            }


            MessagingEventSource.Log.MessageAbandonStop(this.ClientId);
        }

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="Message.SystemPropertiesCollection.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public async Task DeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageDeferStart(this.ClientId, 1, lockToken);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.DisposeStart("Defer", lockToken) : null;
            Task deferTask = null;

            try
            {
                deferTask = this.RetryPolicy.RunOperation(() => this.OnDeferAsync(lockToken, propertiesToModify),
                    this.OperationTimeout);
                await deferTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageDeferException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.DisposeStop(activity, lockToken, deferTask?.Status);
            }
            MessagingEventSource.Log.MessageDeferStop(this.ClientId);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public async Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageDeadLetterStart(this.ClientId, 1, lockToken);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.DisposeStart("DeadLetter", lockToken) : null;
            Task deadLetterTask = null;

            try
            {
                deadLetterTask = this.RetryPolicy.RunOperation(() => this.OnDeadLetterAsync(lockToken, propertiesToModify),
                    this.OperationTimeout);
                await deadLetterTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageDeadLetterException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.DisposeStop(activity, lockToken, deadLetterTask?.Status);
            }
            MessagingEventSource.Log.MessageDeadLetterStop(this.ClientId);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public async Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageDeadLetterStart(this.ClientId, 1, lockToken);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.DisposeStart("DeadLetter", lockToken) : null;
            Task deadLetterTask = null;

            try
            {
                deadLetterTask =
                    this.RetryPolicy.RunOperation(
                        () => this.OnDeadLetterAsync(lockToken, null, deadLetterReason, deadLetterErrorDescription),
                        this.OperationTimeout);
                await deadLetterTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageDeadLetterException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.DisposeStop(activity, lockToken, deadLetterTask?.Status);
            }

            MessagingEventSource.Log.MessageDeadLetterStop(this.ClientId);
        }

        /// <summary>
        /// Renews the lock on the message specified by the lock token. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <remarks>
        /// When a message is received in <see cref="ServiceBus.ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        public async Task RenewLockAsync(Message message)
        {
            message.SystemProperties.LockedUntilUtc = await RenewLockAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        /// </summary>
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <remarks>
        /// When a message is received in <see cref="ServiceBus.ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        public async Task<DateTime> RenewLockAsync(string lockToken)
        {
            this.ThrowIfClosed();
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageRenewLockStart(this.ClientId, 1, lockToken);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.RenewLockStart(lockToken) : null;
            Task renewTask = null;

            var lockedUntilUtc = DateTime.MinValue;

            try
            {
                renewTask = this.RetryPolicy.RunOperation(
                    async () => lockedUntilUtc = await this.OnRenewLockAsync(lockToken).ConfigureAwait(false),
                    this.OperationTimeout);
                await renewTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageRenewLockException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.RenewLockStop(activity, lockToken, renewTask?.Status, lockedUntilUtc);
            }
            MessagingEventSource.Log.MessageRenewLockStop(this.ClientId);

            return lockedUntilUtc;
        }

        /// <summary>
        /// Fetches the next active message without changing the state of the receiver or the message source.
        /// </summary>
        /// <remarks>
        /// The first call to <see cref="PeekAsync()"/> fetches the first active message for this receiver. Each subsequent call
        /// fetches the subsequent message in the entity.
        /// Unlike a received message, peeked message will not have lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveAsync()"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns>The <see cref="Message" /> that represents the next message to be read. Returns null when nothing to peek.</returns>
        public Task<Message> PeekAsync()
        {
            return this.PeekBySequenceNumberAsync(this.lastPeekedSequenceNumber + 1);
        }

        /// <summary>
        /// Fetches the next batch of active messages without changing the state of the receiver or the message source.
        /// </summary>
        /// <remarks>
        /// The first call to <see cref="PeekAsync()"/> fetches the first active message for this receiver. Each subsequent call
        /// fetches the subsequent message in the entity.
        /// Unlike a received message, peeked message will not have lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveAsync()"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns>List of <see cref="Message" /> that represents the next message to be read. Returns null when nothing to peek.</returns>
        public Task<IList<Message>> PeekAsync(int maxMessageCount)
        {
            return this.PeekBySequenceNumberAsync(this.lastPeekedSequenceNumber + 1, maxMessageCount);
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">The sequence number from where to read the message.</param>
        /// <returns>The asynchronous operation that returns the <see cref="Message" /> that represents the next message to be read.</returns>
        public async Task<Message> PeekBySequenceNumberAsync(long fromSequenceNumber)
        {
            var messages = await this.PeekBySequenceNumberAsync(fromSequenceNumber, 1).ConfigureAwait(false);
            return messages?.FirstOrDefault();
        }

        /// <summary>Peeks a batch of messages.</summary>
        /// <param name="fromSequenceNumber">The starting point from which to browse a batch of messages.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>A batch of messages peeked.</returns>
        public async Task<IList<Message>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount)
        {
            this.ThrowIfClosed();
            IList<Message> messages = null;

            MessagingEventSource.Log.MessagePeekStart(this.ClientId, fromSequenceNumber, messageCount);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.PeekStart(fromSequenceNumber, messageCount) : null;
            Task peekTask = null;

            try
            {
                peekTask = this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        messages = await this.OnPeekAsync(fromSequenceNumber, messageCount).ConfigureAwait(false);
                    }, this.OperationTimeout);

                await peekTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessagePeekException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.PeekStop(activity, fromSequenceNumber, messageCount, peekTask?.Status, messages);
            }

            MessagingEventSource.Log.MessagePeekStop(this.ClientId, messages?.Count ?? 0);
            return messages;
        }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is used to notify exceptions.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            this.RegisterMessageHandler(handler, new MessageHandlerOptions(exceptionReceivedHandler));
        }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">The <see cref="MessageHandlerOptions"/> options used to configure the settings of the pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.</remarks>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            this.ThrowIfClosed();
            this.OnMessageHandler(messageHandlerOptions, handler);
        }

        /// <summary>
        /// Unregister message handler from the receiver if there is an active message handler registered. This operation waits for the completion
        /// of inflight receive and message handling operations to finish and unregisters future receives on the message handler which previously 
        /// registered. 
        /// </summary>
        /// <param name="inflightMessageHandlerTasksWaitTimeout"> is the waitTimeout for inflight message handling tasks.</param>
        public async Task UnregisterMessageHandlerAsync(TimeSpan inflightMessageHandlerTasksWaitTimeout)
        {
            this.ThrowIfClosed();

            if (inflightMessageHandlerTasksWaitTimeout <= TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(nameof(inflightMessageHandlerTasksWaitTimeout), inflightMessageHandlerTasksWaitTimeout, Resources.TimeoutMustBePositiveNonZero.FormatForUser(nameof(inflightMessageHandlerTasksWaitTimeout), inflightMessageHandlerTasksWaitTimeout));
            }

            MessagingEventSource.Log.UnregisterMessageHandlerStart(this.ClientId);
            lock (this.messageReceivePumpSyncLock)
            {
                if (this.receivePump == null || this.receivePumpCancellationTokenSource.IsCancellationRequested)
                {
                    // Silently return if handler has already been unregistered. 
                    return;
                }

                this.receivePumpCancellationTokenSource.Cancel();
                this.receivePumpCancellationTokenSource.Dispose();
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            while (this.receivePump != null
                && stopWatch.Elapsed < inflightMessageHandlerTasksWaitTimeout
                && this.receivePump.maxConcurrentCallsSemaphoreSlim.CurrentCount < this.receivePump.registerHandlerOptions.MaxConcurrentCalls)
            {
                await Task.Delay(10).ConfigureAwait(false);
            }

            lock (this.messageReceivePumpSyncLock)
            {
                this.runningTaskCancellationTokenSource.Cancel();
                this.runningTaskCancellationTokenSource.Dispose();
                this.receivePump = null;
            }
            MessagingEventSource.Log.UnregisterMessageHandlerStop(this.ClientId);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this receiver.
        /// </summary>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.ThrowIfClosed();
            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }
            if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPlugin.Name))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(serviceBusPlugin.Name));
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

        internal async Task GetSessionReceiverLinkAsync(TimeSpan serverWaitTime)
        {
            var timeoutHelper = new TimeoutHelper(serverWaitTime, true);
            var receivingAmqpLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            var source = (Source)receivingAmqpLink.Settings.Source;
            if (!source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
            {
                receivingAmqpLink.Session.SafeClose();
                throw new ServiceBusException(true, Resources.SessionFilterMissing);
            }

            if (string.IsNullOrWhiteSpace(tempSessionId))
            {
                receivingAmqpLink.Session.SafeClose();
                throw new ServiceBusException(true, Resources.AmqpFieldSessionId);
            }

            receivingAmqpLink.Closed += this.OnSessionReceiverLinkClosed;
            this.SessionIdInternal = tempSessionId;
            this.LockedUntilUtcInternal = receivingAmqpLink.Settings.Properties.TryGetValue<long>(AmqpClientConstants.LockedUntilUtc, out var lockedUntilUtcTicks)
                ? new DateTime(lockedUntilUtcTicks, DateTimeKind.Utc)
                : DateTime.MinValue;
        }

        internal async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            var amqpMessage = amqpRequestMessage.AmqpMessage;
            if (this.isSessionReceiver)
            {
                this.ThrowIfSessionLockLost();
            }

            var timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);

            ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction != null)
            {
                transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, this.ServiceBusConnection).ConfigureAwait(false);
            }

            if (!this.RequestResponseLinkManager.TryGetOpenedObject(out var requestResponseAmqpLink))
            {
                MessagingEventSource.Log.CreatingNewLink(this.ClientId, this.isSessionReceiver, this.SessionIdInternal, true, this.LinkException);
                requestResponseAmqpLink = await this.RequestResponseLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }

            var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, transactionId, timeoutHelper.RemainingTime(), c, s),
                (a) => requestResponseAmqpLink.EndRequest(a),
                this).ConfigureAwait(false);

            return AmqpResponseMessage.CreateResponse(responseAmqpMessage);
        }

        protected override async Task OnClosingAsync()
        {
            this.clientLinkManager.Close();
            lock (this.messageReceivePumpSyncLock)
            {
                if (this.receivePump != null)
                {
                    this.receivePumpCancellationTokenSource.Cancel();
                    this.receivePumpCancellationTokenSource.Dispose();
                    // For back-compatibility 
                    this.runningTaskCancellationTokenSource.Cancel();
                    this.runningTaskCancellationTokenSource.Dispose();
                    this.receivePump = null;
                }
            }
            await this.ReceiveLinkManager.CloseAsync().ConfigureAwait(false);
            await this.RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);
            this.requestResponseLockedMessages.Close();
        }

        protected virtual async Task<IList<Message>> OnReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            ReceivingAmqpLink receiveLink = null;

            if (this.isSessionReceiver)
            {
                this.ThrowIfSessionLockLost();
            }

            try
            {
                var timeoutHelper = new TimeoutHelper(serverWaitTime, true);
                if(!this.ReceiveLinkManager.TryGetOpenedObject(out receiveLink))
                {
                    MessagingEventSource.Log.CreatingNewLink(this.ClientId, this.isSessionReceiver, this.SessionIdInternal, false, this.LinkException);
                    receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                }

                IList<Message> brokeredMessages = null;
                this.ThrowIfClosed();

                IEnumerable<AmqpMessage> amqpMessages = null;
                var hasMessages = await Task.Factory.FromAsync(
                    (c, s) => receiveLink.BeginReceiveRemoteMessages(maxMessageCount, DefaultBatchFlushInterval, timeoutHelper.RemainingTime(), c, s),
                    a => receiveLink.EndReceiveMessages(a, out amqpMessages),
                    this).ConfigureAwait(false);
                Exception exception;
                if ((exception = receiveLink.GetInnerException()) != null)
                {
                    throw exception;
                }

                if (hasMessages && amqpMessages != null)
                {
                    foreach (var amqpMessage in amqpMessages)
                    {
                        if (this.ReceiveMode == ReceiveMode.ReceiveAndDelete)
                        {
                            receiveLink.DisposeDelivery(amqpMessage, true, AmqpConstants.AcceptedOutcome);
                        }

                        var message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        if (brokeredMessages == null)
                        {
                            brokeredMessages = new List<Message>();
                        }

                        brokeredMessages.Add(message);
                    }
                }

                return brokeredMessages;
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception, receiveLink?.GetTrackingId(), null, receiveLink?.IsClosing() ?? false);
            }
        }

        protected virtual async Task<IList<Message>> OnPeekAsync(long fromSequenceNumber, int messageCount = 1)
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.PeekMessageOperation,
                        this.OperationTimeout,
                        null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = fromSequenceNumber;
                amqpRequestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

                if (!string.IsNullOrWhiteSpace(this.SessionIdInternal))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;
                }

                var messages = new List<Message>();

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    Message message = null;
                    var messageList = amqpResponseMessage.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (AmqpMap entry in messageList)
                    {
                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage, true);
                        messages.Add(message);
                    }

                    if (message != null)
                    {
                        this.LastPeekedSequenceNumber = message.SystemProperties.SequenceNumber;
                    }

                    return messages;
                }

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NoContent ||
                    (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NotFound && Equals(AmqpClientConstants.MessageNotFoundError, amqpResponseMessage.GetResponseErrorCondition())))
                {
                    return messages;
                }

                throw amqpResponseMessage.ToMessagingContractException();
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        protected virtual async Task<IList<Message>> OnReceiveDeferredMessageAsync(long[] sequenceNumbers)
        {
            var messages = new List<Message>();
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.ReceiveBySequenceNumberOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }
                amqpRequestMessage.Map[ManagementConstants.Properties.SequenceNumbers] = sequenceNumbers;
                amqpRequestMessage.Map[ManagementConstants.Properties.ReceiverSettleMode] = (uint)(this.ReceiveMode == ReceiveMode.ReceiveAndDelete ? 0 : 1);
                if (!string.IsNullOrWhiteSpace(this.SessionIdInternal))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;
                }

                var response = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var amqpMapList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (var entry in amqpMapList)
                    {
                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        var message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        if (entry.TryGetValue<Guid>(ManagementConstants.Properties.LockToken, out var lockToken))
                        {
                            message.SystemProperties.LockTokenGuid = lockToken;
                            this.requestResponseLockedMessages.AddOrUpdate(lockToken, message.SystemProperties.LockedUntilUtc);
                        }

                        messages.Add(message);
                    }
                }
                else
                {
                    throw response.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }

            return messages;
        }

        protected virtual Task OnCompleteAsync(IEnumerable<string> lockTokens)
        {
            var lockTokenGuids = lockTokens.Select(lt => new Guid(lt)).ToArray();
            if (lockTokenGuids.Any(lt => this.requestResponseLockedMessages.Contains(lt)))
            {
                return this.DisposeMessageRequestResponseAsync(lockTokenGuids, DispositionStatus.Completed);
            }
            return this.DisposeMessagesAsync(lockTokenGuids, AmqpConstants.AcceptedOutcome);
        }

        protected virtual Task OnAbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any(lt => this.requestResponseLockedMessages.Contains(lt)))
            {
                return this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Abandoned, propertiesToModify);
            }
            return this.DisposeMessagesAsync(lockTokens, GetAbandonOutcome(propertiesToModify));
        }

        protected virtual Task OnDeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            var lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any(lt => this.requestResponseLockedMessages.Contains(lt)))
            {
                return this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Defered, propertiesToModify);
            }
            return this.DisposeMessagesAsync(lockTokens, GetDeferOutcome(propertiesToModify));
        }

        protected virtual Task OnDeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null, string deadLetterReason = null, string deadLetterErrorDescription = null)
        {
            if (deadLetterReason != null && deadLetterReason.Length > Constants.MaxDeadLetterReasonLength)
            {
                throw new ArgumentOutOfRangeException(nameof(deadLetterReason), $"Maximum permitted length is {Constants.MaxDeadLetterReasonLength}");
            }

            if (deadLetterErrorDescription != null && deadLetterErrorDescription.Length > Constants.MaxDeadLetterReasonLength)
            {
                throw new ArgumentOutOfRangeException(nameof(deadLetterErrorDescription), $"Maximum permitted length is {Constants.MaxDeadLetterReasonLength}");
            }

            var lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any(lt => this.requestResponseLockedMessages.Contains(lt)))
            {
                return this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Suspended, propertiesToModify, deadLetterReason, deadLetterErrorDescription);
            }

            return this.DisposeMessagesAsync(lockTokens, GetRejectedOutcome(propertiesToModify, deadLetterReason, deadLetterErrorDescription));
        }

        protected virtual async Task<DateTime> OnRenewLockAsync(string lockToken)
        {
            DateTime lockedUntilUtc;
            try
            {
                // Create an AmqpRequest Message to renew  lock
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewLockOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }
                amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = new[] { new Guid(lockToken) };

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var lockedUntilUtcTimes = amqpResponseMessage.GetValue<IEnumerable<DateTime>>(ManagementConstants.Properties.Expirations);
                    lockedUntilUtc = lockedUntilUtcTimes.First();
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }

            return lockedUntilUtc;
        }

        /// <summary> </summary>
        protected virtual void OnMessageHandler(
            MessageHandlerOptions registerHandlerOptions,
            Func<Message, CancellationToken, Task> callback)
        {
            MessagingEventSource.Log.RegisterOnMessageHandlerStart(this.ClientId, registerHandlerOptions);

            lock (this.messageReceivePumpSyncLock)
            {
                if (this.receivePump != null)
                {
                    throw new InvalidOperationException(Resources.MessageHandlerAlreadyRegistered);
                }

                this.receivePumpCancellationTokenSource = new CancellationTokenSource();

                if (this.runningTaskCancellationTokenSource == null)
                {
                    this.runningTaskCancellationTokenSource = new CancellationTokenSource();
                }

                this.receivePump = new MessageReceivePump(this, registerHandlerOptions, callback, this.ServiceBusConnection.Endpoint, this.receivePumpCancellationTokenSource.Token, this.runningTaskCancellationTokenSource.Token);
            }

            try
            {
                this.receivePump.StartPump();
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RegisterOnMessageHandlerException(this.ClientId, exception);
                lock (this.messageReceivePumpSyncLock)
                {
                    if (this.receivePump != null)
                    {
                        this.receivePumpCancellationTokenSource.Cancel();
                        this.receivePumpCancellationTokenSource.Dispose();
                        this.runningTaskCancellationTokenSource.Cancel();
                        this.runningTaskCancellationTokenSource.Dispose();
                        this.receivePump = null;
                    }
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnMessageHandlerStop(this.ClientId);
        }

        static void CloseSession(ReceivingAmqpLink link)
        {
            link.Session.SafeClose();
        }

        static void CloseRequestResponseSession(RequestResponseAmqpLink requestResponseAmqpLink)
        {
            requestResponseAmqpLink.Session.SafeClose();
        }

        async Task<Message> ProcessMessage(Message message)
        {
            var processedMessage = message;
            foreach (var plugin in this.RegisteredPlugins)
            {
                try
                {
                    MessagingEventSource.Log.PluginCallStarted(plugin.Name, message.MessageId);
                    processedMessage = await plugin.AfterMessageReceive(message).ConfigureAwait(false);
                    MessagingEventSource.Log.PluginCallCompleted(plugin.Name, message.MessageId);
                }
                catch (Exception ex)
                {
                    MessagingEventSource.Log.PluginCallFailed(plugin.Name, message.MessageId, ex);
                    if (!plugin.ShouldContinueOnException)
                    {
                        throw;
                    }
                }
            }
            return processedMessage;
        }

        async Task<IList<Message>> ProcessMessages(IList<Message> messageList)
        {
            if (this.RegisteredPlugins.Count < 1)
            {
                return messageList;
            }

            var processedMessageList = new List<Message>();
            foreach (var message in messageList)
            {
                var processedMessage = await this.ProcessMessage(message).ConfigureAwait(false);
                processedMessageList.Add(processedMessage);
            }

            return processedMessageList;
        }

        async Task DisposeMessagesAsync(IEnumerable<Guid> lockTokens, Outcome outcome)
        {
            if(this.isSessionReceiver)
            {
                this.ThrowIfSessionLockLost();
            }

            var timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            List<ArraySegment<byte>> deliveryTags = this.ConvertLockTokensToDeliveryTags(lockTokens);

            ReceivingAmqpLink receiveLink = null;
            try
            {
                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                var ambientTransaction = Transaction.Current;
                if (ambientTransaction != null)
                {
                    transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, this.ServiceBusConnection).ConfigureAwait(false);
                }

                if (!this.ReceiveLinkManager.TryGetOpenedObject(out receiveLink))
                {
                    MessagingEventSource.Log.CreatingNewLink(this.ClientId, this.isSessionReceiver, this.SessionIdInternal, false, this.LinkException);
                    receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                }

                var disposeMessageTasks = new Task<Outcome>[deliveryTags.Count];
                var i = 0;
                foreach (ArraySegment<byte> deliveryTag in deliveryTags)
                {
                    disposeMessageTasks[i++] = Task.Factory.FromAsync(
                        (c, s) => receiveLink.BeginDisposeMessage(deliveryTag, transactionId, outcome, true, timeoutHelper.RemainingTime(), c, s),
                        a => receiveLink.EndDisposeMessage(a),
                        this);
                }

                var outcomes = await Task.WhenAll(disposeMessageTasks).ConfigureAwait(false);
                Error error = null;
                foreach (var item in outcomes)
                {
                    var disposedOutcome = item.DescriptorCode == Rejected.Code && ((error = ((Rejected)item).Error) != null) ? item : null;
                    if (disposedOutcome != null)
                    {
                        if (error.Condition.Equals(AmqpErrorCode.NotFound))
                        {
                            if (this.isSessionReceiver)
                            {
                                throw new SessionLockLostException(Resources.SessionLockExpiredOnMessageSession);
                            }

                            throw new MessageLockLostException(Resources.MessageLockLost);
                        }

                        throw error.ToMessagingContractException();
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException &&
                    receiveLink != null && receiveLink.State != AmqpObjectState.Opened)
                {
                    // The link state is lost, We need to return a non-retriable error.
                    MessagingEventSource.Log.LinkStateLost(this.ClientId, receiveLink.Name, receiveLink.State, this.isSessionReceiver, exception);
                    if (this.isSessionReceiver)
                    {
                        throw new SessionLockLostException(Resources.SessionLockExpiredOnMessageSession);
                    }

                    throw new MessageLockLostException(Resources.MessageLockLost);
                }
                
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        async Task DisposeMessageRequestResponseAsync(Guid[] lockTokens, DispositionStatus dispositionStatus, IDictionary<string, object> propertiesToModify = null, string deadLetterReason = null, string deadLetterDescription = null)
        {
            try
            {
                // Create an AmqpRequest Message to update disposition
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.UpdateDispositionOperation, this.OperationTimeout, null);

                if (this.ReceiveLinkManager.TryGetOpenedObject(out var receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }
                amqpRequestMessage.Map[ManagementConstants.Properties.LockTokens] = lockTokens;
                amqpRequestMessage.Map[ManagementConstants.Properties.DispositionStatus] = dispositionStatus.ToString().ToLowerInvariant();

                if (deadLetterReason != null)
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.DeadLetterReason] = deadLetterReason;
                }

                if (deadLetterDescription != null)
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.DeadLetterDescription] = deadLetterDescription;
                }

                if (propertiesToModify != null)
                {
                    var amqpPropertiesToModify = new AmqpMap();
                    foreach (var pair in propertiesToModify)
                    {
                        if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                        {
                            amqpPropertiesToModify[new MapKey(pair.Key)] = amqpObject;
                        }
                        else
                        {
                            throw new NotSupportedException(
                                Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                        }
                    }

                    if (amqpPropertiesToModify.Count > 0)
                    {
                        amqpRequestMessage.Map[ManagementConstants.Properties.PropertiesToModify] = amqpPropertiesToModify;
                    }
                }

                if (!string.IsNullOrWhiteSpace(this.SessionIdInternal))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;
                }

                var amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        async Task<ReceivingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            FilterSet filterMap = null;

            MessagingEventSource.Log.AmqpReceiveLinkCreateStart(this.ClientId, false, this.EntityType, this.Path);

            if (this.isSessionReceiver)
            {
                filterMap = new FilterSet { { AmqpClientConstants.SessionFilterName, this.SessionIdInternal } };
            }

            var amqpLinkSettings = new AmqpLinkSettings
            {
                Role = true,
                TotalLinkCredit = (uint)this.PrefetchCount,
                AutoSendFlow = this.PrefetchCount > 0,
                Source = new Source { Address = this.Path, FilterSet = filterMap },
                SettleType = (this.ReceiveMode == ReceiveMode.PeekLock) ? SettleMode.SettleOnDispose : SettleMode.SettleOnSend
            };

            if (this.EntityType != null)
            {
                amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)this.EntityType);
            }

            amqpLinkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.TotalMilliseconds);

            var endpointUri = new Uri(this.ServiceBusConnection.Endpoint, this.Path);
            var claims = new[] { ClaimConstants.Listen };
            var amqpSendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(
                this.Path,
                this.ServiceBusConnection,
                endpointUri,
                new string[] { endpointUri.AbsoluteUri },
                claims,
                this.CbsTokenProvider,
                amqpLinkSettings,
                this.ClientId);

            Tuple<AmqpObject, DateTime> linkDetails = await amqpSendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var receivingAmqpLink = (ReceivingAmqpLink) linkDetails.Item1;
            var activeSendReceiveClientLink = new ActiveSendReceiveClientLink(
                receivingAmqpLink,
                endpointUri,
                new string[] { endpointUri.AbsoluteUri },
                claims,
                linkDetails.Item2);

            this.clientLinkManager.SetActiveSendReceiveLink(activeSendReceiveClientLink);

            MessagingEventSource.Log.AmqpReceiveLinkCreateStop(this.ClientId);

            return receivingAmqpLink;
        }

        // TODO: Consolidate the link creation paths
        async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            var entityPath = this.Path + '/' + AmqpClientConstants.ManagementAddress;

            MessagingEventSource.Log.AmqpReceiveLinkCreateStart(this.ClientId, true, this.EntityType, entityPath);
            var amqpLinkSettings = new AmqpLinkSettings();
            amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            var endpointUri = new Uri(this.ServiceBusConnection.Endpoint, entityPath);
            string[] claims = { ClaimConstants.Manage, ClaimConstants.Listen };
            var amqpRequestResponseLinkCreator = new AmqpRequestResponseLinkCreator(
                entityPath,
                this.ServiceBusConnection,
                endpointUri,
                new string[] { endpointUri.AbsoluteUri },
                claims,
                this.CbsTokenProvider,
                amqpLinkSettings,
                this.ClientId);

            var linkDetails = await amqpRequestResponseLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var requestResponseAmqpLink = (RequestResponseAmqpLink)linkDetails.Item1;
            var activeRequestResponseClientLink = new ActiveRequestResponseLink(
                requestResponseAmqpLink,
                endpointUri,
                new string[] { endpointUri.AbsoluteUri },
                claims,
                linkDetails.Item2);
            this.clientLinkManager.SetActiveRequestResponseLink(activeRequestResponseClientLink);

            MessagingEventSource.Log.AmqpReceiveLinkCreateStop(this.ClientId);
            return requestResponseAmqpLink;
        }

        void OnSessionReceiverLinkClosed(object sender, EventArgs e)
        {
            var receivingAmqpLink = (ReceivingAmqpLink)sender;
            if (receivingAmqpLink != null)
            {
                var exception = receivingAmqpLink.GetInnerException();
                if (!(exception is SessionLockLostException))
                {
                    exception = new SessionLockLostException("Session lock lost. Accept a new session", exception);
                }

                this.LinkException = exception;
                MessagingEventSource.Log.SessionReceiverLinkClosed(this.ClientId, this.SessionIdInternal, this.LinkException);
            }
        }

        List<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        void ThrowIfNotPeekLockMode()
        {
            if (this.ReceiveMode != ReceiveMode.PeekLock)
            {
                throw Fx.Exception.AsError(new InvalidOperationException("The operation is only supported in 'PeekLock' receive mode."));
            }
        }

        void ThrowIfSessionLockLost()
        {
            if (this.LinkException != null)
            {
                throw this.LinkException;
            }
        }

        Outcome GetAbandonOutcome(IDictionary<string, object> propertiesToModify)
        {
            return this.GetModifiedOutcome(propertiesToModify, false);
        }

        Outcome GetDeferOutcome(IDictionary<string, object> propertiesToModify)
        {
            return this.GetModifiedOutcome(propertiesToModify, true);
        }

        Outcome GetModifiedOutcome(IDictionary<string, object> propertiesToModify, bool undeliverableHere)
        {
            Modified modified = new Modified();
            if (undeliverableHere)
            {
                modified.UndeliverableHere = true;
            }

            if (propertiesToModify != null)
            {
                modified.MessageAnnotations = new Fields();
                foreach (var pair in propertiesToModify)
                {
                    if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                    {
                        modified.MessageAnnotations.Add(pair.Key, amqpObject);
                    }
                    else
                    {
                        throw new NotSupportedException(Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                    }
                }
            }

            return modified;
        }

        Rejected GetRejectedOutcome(IDictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription)
        {
            var rejected = AmqpConstants.RejectedOutcome;
            if (deadLetterReason != null || deadLetterErrorDescription != null || propertiesToModify != null)
            {
                rejected = new Rejected { Error = new Error { Condition = AmqpClientConstants.DeadLetterName, Info = new Fields() } };
                if (deadLetterReason != null)
                {
                    rejected.Error.Info.Add(Message.DeadLetterReasonHeader, deadLetterReason);
                }

                if (deadLetterErrorDescription != null)
                {
                    rejected.Error.Info.Add(Message.DeadLetterErrorDescriptionHeader, deadLetterErrorDescription);
                }

                if (propertiesToModify != null)
                {
                    foreach (var pair in propertiesToModify)
                    {
                        if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(pair.Value, MappingType.ApplicationProperty, out var amqpObject))
                        {
                            rejected.Error.Info.Add(pair.Key, amqpObject);
                        }
                        else
                        {
                            throw new NotSupportedException(Resources.InvalidAmqpMessageProperty.FormatForUser(pair.Key.GetType()));
                        }
                    }
                }
            }

            return rejected;
        }
    }
}
