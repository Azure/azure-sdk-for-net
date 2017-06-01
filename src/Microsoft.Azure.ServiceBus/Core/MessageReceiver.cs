// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.ServiceBus.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// The MessageReceiver can be used to receive messages from Queues and Subscriptions.
    /// </summary>
    /// <remarks>
    /// The MessageReceiver provides advanced functionality that is not found in the 
    /// <see cref="QueueClient" /> or <see cref="SubscriptionClient" />. For instance, 
    /// <see cref="ReceiveAsync()"/>, which allows you to receive messages on demand, but also requires
    /// you to manually renew locks using <see cref="RenewLockAsync(string)"/>.
    /// </remarks>
    public class MessageReceiver : ClientEntity, IMessageReceiver
    {
        private static readonly TimeSpan DefaultBatchFlushInterval = TimeSpan.FromMilliseconds(20);
        private const int DefaultPrefetchCount = 0;

        readonly ConcurrentExpiringSet<Guid> requestResponseLockedMessages;
        readonly bool isSessionReceiver;
        readonly object messageReceivePumpSyncLock;
        readonly bool ownsConnection;

        int prefetchCount;
        long lastPeekedSequenceNumber;
        MessageReceivePump receivePump;
        CancellationTokenSource receivePumpCancellationTokenSource;

        /// <summary>
        /// Creates a new MessageReceiver from a <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> used for the connection details.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode.ReceiveMode"/> used to specify how messages are received.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver will actively receive regardless of whether a receive operation is pending.</param>
        public MessageReceiver(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder.EntityPath, receiveMode, retryPolicy, prefetchCount)
        {
        }

        /// <summary>
        /// Creates a new MessageReceiver from a specified connection string and entity path.
        /// </summary>
        /// <param name="connectionString">The connection string used to communicate with Service Bus.</param>
        /// <param name="entityPath">The path of the entity for this receiver. For Queues this will be the name, but for Subscriptions this will be the path. You can use <see cref="EntityNameHelper.FormatSubscriptionPath(string, string)"/>, to help create this path.</param>
        /// <param name="receiveMode">The <see cref="ReceiveMode.ReceiveMode"/> used to specify how messages are received.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus</param>
        /// <param name="prefetchCount">The <see cref="PrefetchCount"/> that specifies the upper limit of messages this receiver will actively receive regardless of whether a receive operation is pending.</param>
        public MessageReceiver(
            string connectionString,
            string entityPath,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(entityPath, null, receiveMode, new ServiceBusNamespaceConnection(connectionString), null, retryPolicy, prefetchCount)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }
            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            this.ownsConnection = true;
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(this.ServiceBusConnection.SasKeyName, this.ServiceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(tokenProvider, this.ServiceBusConnection.OperationTimeout);
        }

        internal MessageReceiver(
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy,
            int prefetchCount = DefaultPrefetchCount,
            string sessionId = null,
            bool isSessionReceiver = false)
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString(), retryPolicy ?? RetryPolicy.Default)
        {
            this.ReceiveMode = receiveMode;
            this.OperationTimeout = serviceBusConnection.OperationTimeout;
            this.Path = entityPath;
            this.EntityType = entityType;
            this.ServiceBusConnection = serviceBusConnection;
            this.CbsTokenProvider = cbsTokenProvider;
            this.SessionId = sessionId;
            this.isSessionReceiver = isSessionReceiver;
            this.ReceiveLinkManager = new FaultTolerantAmqpObject<ReceivingAmqpLink>(this.CreateLinkAsync, this.CloseSession);
            this.RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(this.CreateRequestResponseLinkAsync, this.CloseRequestResponseSession);
            this.requestResponseLockedMessages = new ConcurrentExpiringSet<Guid>();
            this.PrefetchCount = prefetchCount;
            this.messageReceivePumpSyncLock = new object();
        }

        /// <summary>
        /// This constructor should only be used by inherited members, such as the <see cref="IMessageSession"/>.
        /// </summary>
        /// <param name="receiveMode">The <see cref="ReceiveMode.ReceiveMode"/> used to specify how messages are received.</param>
        /// <param name="operationTimeout">The default operation timeout to be used.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> to be used.</param>
        protected MessageReceiver(ReceiveMode receiveMode, TimeSpan operationTimeout, RetryPolicy retryPolicy)
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString(), retryPolicy ?? RetryPolicy.Default)
        {
            this.ReceiveMode = receiveMode;
            this.OperationTimeout = operationTimeout;
            this.lastPeekedSequenceNumber = Constants.DefaultLastPeekedSequenceNumber;
            this.messageReceivePumpSyncLock = new object();
        }

        /// <summary>
        /// Gets a list of currently registered plugins.
        /// </summary>
        public IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Gets the <see cref="ReceiveMode.ReceiveMode"/> of the current receiver.
        /// </summary>
        public ReceiveMode ReceiveMode { get; protected set; }

        /// <summary>Gets or sets the number of messages that the message receiver can simultaneously request.</summary>
        /// <value>The number of messages that the message receiver can simultaneously request.</value>
        /// <remarks> Takes effect on the next receive call to the server. </remarks>
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
        /// <value>The sequence number of the last peeked message.</value>
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
        public virtual string Path { get; private set; }

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until. This is only applicable when Sessions are used.
        /// </summary>
        public DateTime LockedUntilUtc { get; protected set; }

        /// <summary>
        /// Gets the SessionId of the current receiver. This is only applicable when Sessions are used.
        /// </summary>
        public string SessionId { get; protected set; }

        internal TimeSpan OperationTimeout { get; private set; }

        internal MessagingEntityType? EntityType { get; private set; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLinkManager { get; }

        FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        private async Task<Message> ProcessMessage(Message message)
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
                    MessagingEventSource.Log.PluginCallFailed(plugin.Name, message.MessageId, ex.Message);
                    if (!plugin.ShouldContinueOnException)
                    {
                        throw;
                    }
                }
            }
            return processedMessage;
        }

        private async Task<IList<Message>> ProcessMessages(IList<Message> messageList)
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

        /// <summary>
        /// Asynchronously receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <returns>The asynchronous operation.</returns>
        public Task<Message> ReceiveAsync()
        {
            return this.ReceiveAsync(this.OperationTimeout);
        }

        /// <summary>
        /// Asynchronously receives a message. />.
        /// </summary>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        public async Task<Message> ReceiveAsync(TimeSpan serverWaitTime)
        {
            IList<Message> messages = await this.ReceiveAsync(1, serverWaitTime).ConfigureAwait(false);
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        /// <summary>
        /// Asynchronously receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <returns>The asynchronous operation.</returns>
        public Task<IList<Message>> ReceiveAsync(int maxMessageCount)
        {
            return this.ReceiveAsync(maxMessageCount, this.OperationTimeout);
        }

        /// <summary>
        /// Asynchronously receives a message. />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        public async Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            MessagingEventSource.Log.MessageReceiveStart(this.ClientId, maxMessageCount);

            IList<Message> unprocessedMessageList = null;
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        unprocessedMessageList = await this.OnReceiveAsync(maxMessageCount, serverWaitTime).ConfigureAwait(false);
                    }, serverWaitTime)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiveException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageReceiveStop(this.ClientId, unprocessedMessageList?.Count ?? 0);

            if (unprocessedMessageList == null)
            {
                return unprocessedMessageList;
            }

            return await this.ProcessMessages(unprocessedMessageList).ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <returns>The asynchronous operation.</returns>
        public async Task<Message> ReceiveBySequenceNumberAsync(long sequenceNumber)
        {
            IList<Message> messages = await this.ReceiveBySequenceNumberAsync(new long[] { sequenceNumber });
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        /// <summary>
        /// Receives an <see cref="IList{Message}"/> of messages using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <returns>The asynchronous operation.</returns>
        public async Task<IList<Message>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            this.ThrowIfNotPeekLockMode();
            int count = MessageReceiver.ValidateSequenceNumbers(sequenceNumbers);

            MessagingEventSource.Log.MessageReceiveBySequenceNumberStart(this.ClientId, count, sequenceNumbers);

            IList<Message> messages = null;
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        messages = await this.OnReceiveBySequenceNumberAsync(sequenceNumbers).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiveBySequenceNumberException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageReceiveBySequenceNumberStop(this.ClientId, messages?.Count ?? 0);

            return messages;
        }

        /// <summary>
        /// Completes a <see cref="Message"/> using a lock token.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task CompleteAsync(string lockToken)
        {
            return this.CompleteAsync(new[] { lockToken });
        }

        /// <summary>
        /// Completes a series of <see cref="Message"/> using a list of lock tokens.
        /// </summary>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <returns>The asynchronous operation.</returns>
        public async Task CompleteAsync(IEnumerable<string> lockTokens)
        {
            this.ThrowIfNotPeekLockMode();
            int count = MessageReceiver.ValidateLockTokens(lockTokens);

            MessagingEventSource.Log.MessageCompleteStart(this.ClientId, count, lockTokens);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnCompleteAsync(lockTokens).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageCompleteException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageCompleteStop(this.ClientId);
        }

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public async Task AbandonAsync(string lockToken)
        {
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageAbandonStart(this.ClientId, 1, lockToken);
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnAbandonAsync(lockToken).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageAbandonException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageAbandonStop(this.ClientId);
        }

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>. 
        /// In order to receive this message again in the future, you will need to use <see cref="Message.SystemPropertiesCollection.SequenceNumber"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public async Task DeferAsync(string lockToken)
        {
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageDeferStart(this.ClientId, 1, lockToken);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnDeferAsync(lockToken).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageDeferException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageDeferStop(this.ClientId);
        }

        /// <summary>
        /// Moves a message to the deadletter queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>. 
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path. You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public async Task DeadLetterAsync(string lockToken)
        {
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageDeadLetterStart(this.ClientId, 1, lockToken);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnDeadLetterAsync(lockToken).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageDeadLetterException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageDeadLetterStop(this.ClientId);
        }

        /// <summary>
        /// Renews the lock on the message specified by the lock token. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemProperties"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public async Task<DateTime> RenewLockAsync(string lockToken)
        {
            this.ThrowIfNotPeekLockMode();

            MessagingEventSource.Log.MessageRenewLockStart(this.ClientId, 1, lockToken);

            DateTime lockedUntilUtc = DateTime.Now;
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        lockedUntilUtc = await this.OnRenewLockAsync(lockToken).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageRenewLockException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageRenewLockStop(this.ClientId);
            return lockedUntilUtc;
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <returns>The asynchronous operation that returns the <see cref="Message" /> that represents the next message to be read.</returns>
        public Task<Message> PeekAsync()
        {
            return this.PeekBySequenceNumberAsync(this.lastPeekedSequenceNumber + 1);
        }

        /// <summary>
        /// Asynchronously reads the next batch of message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="maxMessageCount">The number of messages.</param>
        /// <returns>The asynchronous operation that returns a list of <see cref="Message" /> to be read.</returns>
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
        /// <param name="messageCount">The number of messages.</param>
        /// <returns>A batch of messages peeked.</returns>
        public async Task<IList<Message>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount)
        {
            IList<Message> messages = null;

            MessagingEventSource.Log.MessagePeekStart(this.ClientId, fromSequenceNumber, messageCount);
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        messages = await this.OnPeekAsync(fromSequenceNumber, messageCount).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessagePeekException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessagePeekStop(this.ClientId, messages?.Count ?? 0);
            return messages;
        }

        /// <summary>
        /// Registers a message handler and begins a new thread to receive messages.
        /// </summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler)
        {
            this.RegisterMessageHandler(handler, new MessageHandlerOptions());
        }

        /// <summary>
        /// Registers a message handler and begins a new thread to receive messages.
        /// </summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">The <see cref="MessageHandlerOptions"/> options used to register a message handler.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            messageHandlerOptions.MessageClientEntity = this;
            this.OnMessageHandlerAsync(messageHandlerOptions, handler).GetAwaiter().GetResult();
        }

        /// <summary></summary>
        /// <returns>The asynchronous operation.</returns>
        protected override async Task OnClosingAsync()
        {
            lock (this.messageReceivePumpSyncLock)
            {
                if (this.receivePump != null)
                {
                    this.receivePumpCancellationTokenSource.Cancel();
                    this.receivePumpCancellationTokenSource.Dispose();
                    this.receivePump = null;
                }
            }
            await this.ReceiveLinkManager.CloseAsync().ConfigureAwait(false);
            await this.RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);

            if (this.ownsConnection)
            {
                await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
            }
        }

        internal async Task GetSessionReceiverLinkAsync(TimeSpan serverWaitTime)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(serverWaitTime, true);
            ReceivingAmqpLink receivingAmqpLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            Source source = (Source)receivingAmqpLink.Settings.Source;
            string tempSessionId;
            if (!source.FilterSet.TryGetValue(AmqpClientConstants.SessionFilterName, out tempSessionId))
            {
                receivingAmqpLink.Session.SafeClose();
                throw new ServiceBusException(false, Resources.AmqpFieldSessionId);
            }
            if (!string.IsNullOrWhiteSpace(tempSessionId))
            {
                this.SessionId = tempSessionId;
            }
            long lockedUntilUtcTicks;
            this.LockedUntilUtc = receivingAmqpLink.Settings.Properties.TryGetValue(AmqpClientConstants.LockedUntilUtc, out lockedUntilUtcTicks) ? new DateTime(lockedUntilUtcTicks, DateTimeKind.Utc) : DateTime.MinValue;
        }

        internal async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            AmqpMessage amqpMessage = amqpRequestMessage.AmqpMessage;
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            RequestResponseAmqpLink requestResponseAmqpLink = await this.RequestResponseLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            AmqpMessage responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, timeoutHelper.RemainingTime(), c, s),
                (a) => requestResponseAmqpLink.EndRequest(a),
                this).ConfigureAwait(false);

            AmqpResponseMessage responseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);
            return responseMessage;
        }

        /// <summary></summary>
        /// <param name="maxMessageCount"></param>
        /// <param name="serverWaitTime"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task<IList<Message>> OnReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            ReceivingAmqpLink receiveLink = null;
            try
            {
                TimeoutHelper timeoutHelper = new TimeoutHelper(serverWaitTime, true);
                receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                IEnumerable<AmqpMessage> amqpMessages = null;
                bool hasMessages = await Task.Factory.FromAsync(
                    (c, s) => receiveLink.BeginReceiveRemoteMessages(maxMessageCount, DefaultBatchFlushInterval, timeoutHelper.RemainingTime(), c, s),
                    a => receiveLink.EndReceiveMessages(a, out amqpMessages),
                    this).ConfigureAwait(false);

                if (receiveLink.TerminalException != null)
                {
                    throw receiveLink.TerminalException;
                }

                if (hasMessages && amqpMessages != null)
                {
                    IList<Message> brokeredMessages = null;
                    foreach (var amqpMessage in amqpMessages)
                    {
                        if (brokeredMessages == null)
                        {
                            brokeredMessages = new List<Message>();
                        }

                        if (this.ReceiveMode == ReceiveMode.ReceiveAndDelete)
                        {
                            receiveLink.DisposeDelivery(amqpMessage, true, AmqpConstants.AcceptedOutcome);
                        }

                        Message message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        brokeredMessages.Add(message);
                    }

                    return brokeredMessages;
                }

                return null;
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception, receiveLink?.GetTrackingId());
            }
        }

        /// <summary></summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task<IList<Message>> OnPeekAsync(long fromSequenceNumber, int messageCount = 1)
        {
            try
            {
                AmqpRequestMessage requestMessage =
                    AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.PeekMessageOperation,
                        this.OperationTimeout,
                        null);

                requestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = fromSequenceNumber;
                requestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

                if (!string.IsNullOrWhiteSpace(this.SessionId))
                {
                    requestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionId;
                }

                List<Message> messages = new List<Message>();

                AmqpResponseMessage response = await this.ExecuteRequestResponseAsync(requestMessage).ConfigureAwait(false);
                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    Message message = null;
                    var messageList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (AmqpMap entry in messageList)
                    {
                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        AmqpMessage amqpMessage =
                            AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        messages.Add(message);
                    }

                    if (message != null)
                    {
                        this.LastPeekedSequenceNumber = message.SystemProperties.SequenceNumber;
                    }

                    return messages;
                }
                else if (response.StatusCode == AmqpResponseStatusCode.NoContent ||
                        (response.StatusCode == AmqpResponseStatusCode.NotFound && Equals(AmqpClientConstants.MessageNotFoundError, response.GetResponseErrorCondition())))
                {
                    return messages;
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
        }

        /// <summary></summary>
        /// <param name="sequenceNumbers"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task<IList<Message>> OnReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            List<Message> messages = new List<Message>();
            try
            {
                AmqpRequestMessage requestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.ReceiveBySequenceNumberOperation, this.OperationTimeout, null);
                requestMessage.Map[ManagementConstants.Properties.SequenceNumbers] = sequenceNumbers.ToArray();
                requestMessage.Map[ManagementConstants.Properties.ReceiverSettleMode] = (uint)(this.ReceiveMode == ReceiveMode.ReceiveAndDelete ? 0 : 1);

                AmqpResponseMessage response = await this.ExecuteRequestResponseAsync(requestMessage).ConfigureAwait(false);

                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    IEnumerable<AmqpMap> amqpMapList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (AmqpMap entry in amqpMapList)
                    {
                        ArraySegment<byte> payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        AmqpMessage amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        Message message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
                        Guid lockToken;
                        if (entry.TryGetValue(ManagementConstants.Properties.LockToken, out lockToken))
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

        /// <summary></summary>
        /// <param name="lockTokens"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task OnCompleteAsync(IEnumerable<string> lockTokens)
        {
            var lockTokenGuids = lockTokens.Select(lt => new Guid(lt));
            if (lockTokenGuids.Any(lt => this.requestResponseLockedMessages.Contains(lt)))
            {
                await this.DisposeMessageRequestResponseAsync(lockTokenGuids, DispositionStatus.Completed).ConfigureAwait(false);
            }
            else
            {
                await this.DisposeMessagesAsync(lockTokenGuids, AmqpConstants.AcceptedOutcome).ConfigureAwait(false);
            }
        }

        /// <summary></summary>
        /// <param name="lockToken"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task OnAbandonAsync(string lockToken)
        {
            IEnumerable<Guid> lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any((lt) => this.requestResponseLockedMessages.Contains(lt)))
            {
                await this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Abandoned).ConfigureAwait(false);
            }
            else
            {
                await this.DisposeMessagesAsync(lockTokens, new Modified()).ConfigureAwait(false);
            }
        }

        /// <summary></summary>
        /// <param name="lockToken"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task OnDeferAsync(string lockToken)
        {
            IEnumerable<Guid> lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any((lt) => this.requestResponseLockedMessages.Contains(lt)))
            {
                await this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Defered).ConfigureAwait(false);
            }
            else
            {
                await this.DisposeMessagesAsync(lockTokens, new Modified() { UndeliverableHere = true }).ConfigureAwait(false);
            }
        }

        /// <summary></summary>
        /// <param name="lockToken"></param>
        /// <returns>The asynchronous operation.</returns>
        protected virtual async Task OnDeadLetterAsync(string lockToken)
        {
            IEnumerable<Guid> lockTokens = new[] { new Guid(lockToken) };
            if (lockTokens.Any((lt) => this.requestResponseLockedMessages.Contains(lt)))
            {
                await this.DisposeMessageRequestResponseAsync(lockTokens, DispositionStatus.Suspended).ConfigureAwait(false);
            }
            else
            {
                await this.DisposeMessagesAsync(lockTokens, AmqpConstants.RejectedOutcome).ConfigureAwait(false);
            }
        }

        /// <summary></summary>
        /// <param name="lockToken"></param>
        /// <returns>The asynchronour operation.</returns>
        protected virtual async Task<DateTime> OnRenewLockAsync(string lockToken)
        {
            DateTime lockedUntilUtc = DateTime.MinValue;
            try
            {
                // Create an AmqpRequest Message to renew  lock
                AmqpRequestMessage requestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewLockOperation, this.OperationTimeout, null);
                requestMessage.Map[ManagementConstants.Properties.LockTokens] = new[] { new Guid(lockToken) };

                AmqpResponseMessage response = await this.ExecuteRequestResponseAsync(requestMessage).ConfigureAwait(false);

                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    IEnumerable<DateTime> lockedUntilUtcTimes = response.GetValue<IEnumerable<DateTime>>(ManagementConstants.Properties.Expirations);
                    lockedUntilUtc = lockedUntilUtcTimes.First();
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

            return lockedUntilUtc;
        }

        async Task DisposeMessagesAsync(IEnumerable<Guid> lockTokens, Outcome outcome)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            IList<ArraySegment<byte>> deliveryTags = this.ConvertLockTokensToDeliveryTags(lockTokens);

            ReceivingAmqpLink receiveLink = null;
            try
            {
                receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                Task<Outcome>[] disposeMessageTasks = new Task<Outcome>[deliveryTags.Count];
                int i = 0;
                foreach (ArraySegment<byte> deliveryTag in deliveryTags)
                {
                    disposeMessageTasks[i++] = Task.Factory.FromAsync(
                        (c, s) => receiveLink.BeginDisposeMessage(deliveryTag, outcome, true, timeoutHelper.RemainingTime(), c, s),
                        a => receiveLink.EndDisposeMessage(a),
                        this);
                }

                Outcome[] outcomes = await Task.WhenAll(disposeMessageTasks).ConfigureAwait(false);
                Error error = null;
                foreach (Outcome item in outcomes)
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
                            else
                            {
                                throw new MessageLockLostException(Resources.MessageLockLost);
                            }
                        }

                        throw AmqpExceptionHelper.ToMessagingContractException(error);
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is OperationCanceledException &&
                    receiveLink != null && receiveLink.State != AmqpObjectState.Opened)
                {
                    if (this.isSessionReceiver)
                    {
                        throw new SessionLockLostException(Resources.SessionLockExpiredOnMessageSession);
                    }

                    throw new MessageLockLostException(Resources.MessageLockLost);
                }

                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        async Task DisposeMessageRequestResponseAsync(IEnumerable<Guid> lockTokens, DispositionStatus dispositionStatus)
        {
            try
            {
                // Create an AmqpRequest Message to update disposition
                AmqpRequestMessage requestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.UpdateDispositionOperation, this.OperationTimeout, null);
                requestMessage.Map[ManagementConstants.Properties.LockTokens] = lockTokens.ToArray();
                requestMessage.Map[ManagementConstants.Properties.DispositionStatus] = dispositionStatus.ToString().ToLowerInvariant();

                AmqpResponseMessage amqpResponseMessage = await this.ExecuteRequestResponseAsync(requestMessage).ConfigureAwait(false);
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

        IList<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        async Task<ReceivingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            FilterSet filterMap = null;

            MessagingEventSource.Log.AmqpReceiveLinkCreateStart(this.ClientId, false, this.EntityType, this.Path);

            if (this.isSessionReceiver)
            {
                filterMap = new FilterSet { { AmqpClientConstants.SessionFilterName, this.SessionId } };
            }

            AmqpLinkSettings linkSettings = new AmqpLinkSettings
            {
                Role = true,
                TotalLinkCredit = (uint)this.PrefetchCount,
                AutoSendFlow = this.PrefetchCount > 0,
                Source = new Source { Address = this.Path, FilterSet = filterMap },
                SettleType = (this.ReceiveMode == ReceiveMode.PeekLock) ? SettleMode.SettleOnDispose : SettleMode.SettleOnSend
            };

            if (this.EntityType != null)
            {
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)this.EntityType);
            }

            linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.TotalMilliseconds);

            AmqpSendReceiveLinkCreator sendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(this.Path, this.ServiceBusConnection, new[] { ClaimConstants.Listen }, this.CbsTokenProvider, linkSettings);
            ReceivingAmqpLink receivingAmqpLink = (ReceivingAmqpLink)await sendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            MessagingEventSource.Log.AmqpReceiveLinkCreateStop(this.ClientId);

            return receivingAmqpLink;
        }

        // TODO: Consolidate the link creation paths
        async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            string entityPath = this.Path + '/' + AmqpClientConstants.ManagementAddress;

            MessagingEventSource.Log.AmqpReceiveLinkCreateStart(this.ClientId, true, this.EntityType, entityPath);
            AmqpLinkSettings linkSettings = new AmqpLinkSettings();
            linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            AmqpRequestResponseLinkCreator requestResponseLinkCreator = new AmqpRequestResponseLinkCreator(entityPath, this.ServiceBusConnection, new[] { ClaimConstants.Manage, ClaimConstants.Listen }, this.CbsTokenProvider, linkSettings);
            RequestResponseAmqpLink requestResponseAmqpLink = (RequestResponseAmqpLink)await requestResponseLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            MessagingEventSource.Log.AmqpReceiveLinkCreateStop(this.ClientId);
            return requestResponseAmqpLink;
        }

        void CloseSession(ReceivingAmqpLink link)
        {
            link.Session.SafeClose();
        }

        void CloseRequestResponseSession(RequestResponseAmqpLink requestResponseAmqpLink)
        {
            requestResponseAmqpLink.Session.SafeClose();
        }

        static int ValidateLockTokens(IEnumerable<string> lockTokens)
        {
            int count;
            if (lockTokens == null || (count = lockTokens.Count()) == 0)
            {
                throw Fx.Exception.ArgumentNull(nameof(lockTokens));
            }

            return count;
        }

        static int ValidateSequenceNumbers(IEnumerable<long> sequenceNumbers)
        {
            int count;
            if (sequenceNumbers == null || (count = sequenceNumbers.Count()) == 0)
            {
                throw Fx.Exception.ArgumentNull(nameof(sequenceNumbers));
            }

            return count;
        }

        void ThrowIfNotPeekLockMode()
        {
            if (this.ReceiveMode != ReceiveMode.PeekLock)
            {
                throw Fx.Exception.AsError(new InvalidOperationException("The operation is only supported in 'PeekLock' receive mode."));
            }
        }

        async Task OnMessageHandlerAsync(
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
                this.receivePump = new MessageReceivePump(this, registerHandlerOptions, callback, this.receivePumpCancellationTokenSource.Token);
            }

            try
            {
                await this.receivePump.StartPumpAsync().ConfigureAwait(false);
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
                        this.receivePump = null;
                    }
                }

                throw;
            }

            MessagingEventSource.Log.RegisterOnMessageHandlerStop(this.ClientId);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used for receiving messages from Service Bus.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register</param>
        public void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }
            else if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPlugin.Name))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(nameof(serviceBusPlugin)));
            }
            this.RegisteredPlugins.Add(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public void UnregisterPlugin(string serviceBusPluginName)
        {
            if (this.RegisteredPlugins == null)
            {
                return;
            }
            if (serviceBusPluginName == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPluginName)));
            }
            if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPluginName))
            {
                var plugin = this.RegisteredPlugins.First(p => p.Name == serviceBusPluginName);
                this.RegisteredPlugins.Remove(plugin);
            }
        }
    }
}