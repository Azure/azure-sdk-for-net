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

    public class MessageReceiver : ClientEntity, IMessageReceiver
    {
        public static readonly TimeSpan DefaultBatchFlushInterval = TimeSpan.FromMilliseconds(20);
        private const int DefaultPrefetchCount = 0;

        readonly ConcurrentExpiringSet<Guid> requestResponseLockedMessages;
        readonly bool isSessionReceiver;
        readonly object messageReceivePumpSyncLock;
        readonly bool ownsConnection;

        int prefetchCount;
        long lastPeekedSequenceNumber;
        MessageReceivePump receivePump;
        CancellationTokenSource receivePumpCancellationTokenSource;

        public MessageReceiver(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null,
            int prefetchCount = DefaultPrefetchCount)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder.EntityPath, receiveMode, retryPolicy, prefetchCount)
        {
        }

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

        protected MessageReceiver(ReceiveMode receiveMode, TimeSpan operationTimeout, RetryPolicy retryPolicy)
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString(), retryPolicy ?? RetryPolicy.Default)
        {
            this.ReceiveMode = receiveMode;
            this.OperationTimeout = operationTimeout;
            this.lastPeekedSequenceNumber = Constants.DefaultLastPeekedSequenceNumber;
            this.messageReceivePumpSyncLock = new object();
        }

        public ReceiveMode ReceiveMode { get; protected set; }

        /// <summary>
        /// Get Prefetch Count configured on the Receiver.
        /// </summary>
        /// <value>The upper limit of messages this receiver will actively receive regardless of whether a receive operation is pending.</value>
        public int PrefetchCount
        {
            get
            {
                return this.prefetchCount;
            }

            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(this.PrefetchCount), value, "Value cannot be less than 0.");
                }
                this.prefetchCount = value;
                ReceivingAmqpLink link;
                if (this.ReceiveLinkManager.TryGetOpenedObject(out link))
                {
                    link.SetTotalLinkCredit((uint)value, true, true);
                }
            }
        }

        public long LastPeekedSequenceNumber
        {
            get
            {
                return this.lastPeekedSequenceNumber;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.LastPeekedSequenceNumber), value.ToString());
                }

                this.lastPeekedSequenceNumber = value;
            }
        }

        public virtual string Path { get; private set; }

        public DateTime LockedUntilUtc { get; protected set; }

        public string SessionId { get; protected set; }

        internal TimeSpan OperationTimeout { get; private set; }

        internal MessagingEntityType? EntityType { get; private set; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLinkManager { get; }

        FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

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

            IList<Message> messages = null;
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        messages = await this.OnReceiveAsync(maxMessageCount, serverWaitTime).ConfigureAwait(false);
                    }, serverWaitTime)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiveException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageReceiveStop(this.ClientId, messages?.Count ?? 0);
            return messages;
        }

        public async Task<Message> ReceiveBySequenceNumberAsync(long sequenceNumber)
        {
            IList<Message> messages = await this.ReceiveBySequenceNumberAsync(new long[] { sequenceNumber });
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

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

        public Task CompleteAsync(string lockToken)
        {
            return this.CompleteAsync(new[] { lockToken });
        }

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

        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler)
        {
            this.RegisterMessageHandler(handler, new MessageHandlerOptions());
        }

        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            messageHandlerOptions.MessageClientEntity = this;
            this.OnMessageHandlerAsync(messageHandlerOptions, handler).GetAwaiter().GetResult();
        }

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
                    else
                    {
                        throw new MessageLockLostException(Resources.MessageLockLost);
                    }
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
    }
}