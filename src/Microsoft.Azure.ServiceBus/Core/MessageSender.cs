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
    /// The MessageSender can be used to send messages to Queues or Topics.
    /// </summary>
    /// <example>
    /// Create a new MessageSender to send to a Queue
    /// <code>
    /// IMessageSender messageSender = new MessageSender(
    ///     namespaceConnectionString,
    ///     queueName)
    /// </code>
    ///
    /// Send message
    /// <code>
    /// byte[] data = GetData();
    /// await messageSender.SendAsync(data);
    /// </code>
    /// </example>
    /// <remarks>This uses AMQP protocol to communicate with service.</remarks>
    public class MessageSender : ClientEntity, IMessageSender
    {
        int deliveryCount;
        readonly bool ownsConnection;
        readonly ActiveClientLinkManager clientLinkManager;

        /// <summary>
        /// Creates a new AMQP MessageSender.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> having entity level connection details.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageSender(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            RetryPolicy retryPolicy = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, retryPolicy)
        {
        }

        /// <summary>
        /// Creates a new AMQP MessageSender.
        /// </summary>
        /// <param name="connectionString">Namespace connection string used to communicate with Service Bus. Must not contain Entity details.</param>
        /// <param name="entityPath">The path of the entity this sender should connect to.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageSender(
            string connectionString,
            string entityPath,
            RetryPolicy retryPolicy = null)
            : this(entityPath, null, new ServiceBusNamespaceConnection(connectionString), null, retryPolicy)
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
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                this.ServiceBusConnection.SasKeyName,
                this.ServiceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(tokenProvider, this.ServiceBusConnection.OperationTimeout);
        }

        internal MessageSender(
            string entityPath,
            MessagingEntityType? entityType,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy)
            : base(nameof(MessageSender), entityPath, retryPolicy ?? RetryPolicy.Default)
        {
            MessagingEventSource.Log.MessageSenderCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath);

            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.OperationTimeout = serviceBusConnection.OperationTimeout;
            this.Path = entityPath;
            this.EntityType = entityType;
            this.CbsTokenProvider = cbsTokenProvider;
            this.SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(this.CreateLinkAsync, CloseSession);
            this.RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(this.CreateRequestResponseLinkAsync, CloseRequestResponseSession);
            this.clientLinkManager = new ActiveClientLinkManager(this.ClientId, this.CbsTokenProvider);

            MessagingEventSource.Log.MessageSenderCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, this.ClientId);
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this sender.
        /// </summary>
        /// <seealso cref="RegisterPlugin"/>
        public override IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Gets the entity path of the MessageSender.
        /// </summary>
        public virtual string Path { get; private set; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout
        {
            get => this.ServiceBusConnection.OperationTimeout;
            set => this.ServiceBusConnection.OperationTimeout = value;
        }

        internal MessagingEntityType? EntityType { get; private set; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        /// <summary>
        /// Sends a message to the entity as described by <see cref="Path"/>.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> to send</param>
        /// <returns>An asynchronous operation</returns>
        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to the entity as described by <see cref="Path"/>.
        /// </summary>
        /// <param name="messageList">The <see cref="IList{Message}"/> to send</param>
        /// <returns>An asynchronous operation</returns>
        public async Task SendAsync(IList<Message> messageList)
        {
            this.ThrowIfClosed();
            var count = MessageSender.ValidateMessages(messageList);
            MessagingEventSource.Log.MessageSendStart(this.ClientId, count);

            var processedMessages = await this.ProcessMessages(messageList).ConfigureAwait(false);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnSendAsync(processedMessages).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageSendException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageSendStop(this.ClientId);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> that needs to be scheduled.</param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public async Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            this.ThrowIfClosed();
            if (message == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(message));
            }

            if (scheduleEnqueueTimeUtc.CompareTo(DateTimeOffset.UtcNow) < 0)
            {
                throw Fx.Exception.ArgumentOutOfRange(
                    nameof(scheduleEnqueueTimeUtc),
                    scheduleEnqueueTimeUtc.ToString(),
                    "Cannot schedule messages in the past");
            }

            message.ScheduledEnqueueTimeUtc = scheduleEnqueueTimeUtc.UtcDateTime;
            MessageSender.ValidateMessage(message);
            MessagingEventSource.Log.ScheduleMessageStart(this.ClientId, scheduleEnqueueTimeUtc);
            long result = 0;

            var processedMessage = await this.ProcessMessage(message).ConfigureAwait(false);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        result = await this.OnScheduleMessageAsync(processedMessage).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.ScheduleMessageException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.ScheduleMessageStop(this.ClientId);
            return result;
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        /// <returns>An asynchronous operation</returns>
        public async Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            this.ThrowIfClosed();
            MessagingEventSource.Log.CancelScheduledMessageStart(this.ClientId, sequenceNumber);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnCancelScheduledMessageAsync(sequenceNumber).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.CancelScheduledMessageException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.CancelScheduledMessageStop(this.ClientId);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this sender.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.ThrowIfClosed();
            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }

            if (this.RegisteredPlugins.Any(p => p.GetType() == serviceBusPlugin.GetType()))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(nameof(serviceBusPlugin)));
            }
            this.RegisteredPlugins.Add(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public override void UnregisterPlugin(string serviceBusPluginName)
        {
            this.ThrowIfClosed();
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

        internal async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            var amqpMessage = amqpRequestMessage.AmqpMessage;
            var timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);

            if (!this.RequestResponseLinkManager.TryGetOpenedObject(out var requestResponseAmqpLink))
            {
                requestResponseAmqpLink = await this.RequestResponseLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }

            var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, timeoutHelper.RemainingTime(), c, s),
                a => requestResponseAmqpLink.EndRequest(a),
                this).ConfigureAwait(false);

            return AmqpResponseMessage.CreateResponse(responseAmqpMessage);
        }

        /// <summary>Closes the connection.</summary>
        protected override async Task OnClosingAsync()
        {
            this.clientLinkManager.Close();
            await this.SendLinkManager.CloseAsync().ConfigureAwait(false);
            await this.RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);

            if (this.ownsConnection)
            {
                await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
            }
        }

        static int ValidateMessages(IList<Message> messageList)
        {
            var count = 0;
            if (messageList == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(messageList));
            }

            foreach (var message in messageList)
            {
                count++;
                ValidateMessage(message);
            }

            return count;
        }

        static void ValidateMessage(Message message)
        {
            if (message.SystemProperties.IsLockTokenSet)
            {
                throw Fx.Exception.Argument(nameof(message), "Cannot send a message that was already received.");
            }
        }

        static void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
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
                    processedMessage = await plugin.BeforeMessageSend(message).ConfigureAwait(false);
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

        async Task OnSendAsync(IList<Message> messageList)
        {
            var timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            using (var amqpMessage = AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messageList, true))
            {
                SendingAmqpLink amqpLink = null;
                try
                {
                    if (!this.SendLinkManager.TryGetOpenedObject(out amqpLink))
                    {
                        amqpLink = await this.SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    }
                    if (amqpLink.Settings.MaxMessageSize.HasValue)
                    {
                        var size = (ulong)amqpMessage.SerializedMessageSize;
                        if (size > amqpLink.Settings.MaxMessageSize.Value)
                        {
                            // TODO: Add MessageSizeExceededException
                            throw new NotImplementedException("MessageSizeExceededException: " + Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value));
                            ////throw Fx.Exception.AsError(new MessageSizeExceededException(
                            ////Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value)));
                        }
                    }

                    var outcome = await amqpLink.SendMessageAsync(amqpMessage, this.GetNextDeliveryTag(), AmqpConstants.NullBinary, timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    if (outcome.DescriptorCode != Accepted.Code)
                    {
                        var rejected = (Rejected)outcome;
                        throw Fx.Exception.AsError(rejected.Error.ToMessagingContractException());
                    }
                }
                catch (Exception exception)
                {
                    throw AmqpExceptionHelper.GetClientException(exception, amqpLink?.GetTrackingId(), null, amqpLink?.Session.IsClosing() ?? false);
                }
            }
        }

        async Task<long> OnScheduleMessageAsync(Message message)
        {
            // TODO: Ensure System.Transactions.Transaction.Current is null. Transactions are not supported by 1.0.0 version of dotnet core.
            using (var amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message))
            {
                var request = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.ScheduleMessageOperation,
                    this.OperationTimeout,
                    null);

                ArraySegment<byte>[] payload = amqpMessage.GetPayload();
                BufferListStream buffer = new BufferListStream(payload);
                ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);

                var entry = new AmqpMap();
                {
                    entry[ManagementConstants.Properties.Message] = value;
                    entry[ManagementConstants.Properties.MessageId] = message.MessageId;

                    if (!string.IsNullOrWhiteSpace(message.SessionId))
                    {
                        entry[ManagementConstants.Properties.SessionId] = message.SessionId;
                    }

                    if (!string.IsNullOrWhiteSpace(message.PartitionKey))
                    {
                        entry[ManagementConstants.Properties.PartitionKey] = message.PartitionKey;
                    }
                }

                request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };

                IEnumerable<long> sequenceNumbers = null;
                var response = await this.ExecuteRequestResponseAsync(request).ConfigureAwait(false);
                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    sequenceNumbers = response.GetValue<long[]>(ManagementConstants.Properties.SequenceNumbers);
                }
                else
                {
                    response.ToMessagingContractException();
                }

                return sequenceNumbers?.FirstOrDefault() ?? 0;
            }
        }

        async Task OnCancelScheduledMessageAsync(long sequenceNumber)
        {
            // TODO: Ensure System.Transactions.Transaction.Current is null. Transactions are not supported by 1.0.0 version of dotnet core.
            var request =
                AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.CancelScheduledMessageOperation,
                    this.OperationTimeout,
                    null);
            request.Map[ManagementConstants.Properties.SequenceNumbers] = new[] { sequenceNumber };

            var response = await this.ExecuteRequestResponseAsync(request).ConfigureAwait(false);

            if (response.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw response.ToMessagingContractException();
            }
        }

        async Task<SendingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            MessagingEventSource.Log.AmqpSendLinkCreateStart(this.ClientId, this.EntityType, this.Path);

            var amqpLinkSettings = new AmqpLinkSettings
            {
                Role = false,
                InitialDeliveryCount = 0,
                Target = new Target { Address = this.Path },
                Source = new Source { Address = this.ClientId },
            };
            if (this.EntityType != null)
            {
                amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)this.EntityType);
            }

            var endpointUri = new Uri(this.ServiceBusConnection.Endpoint, this.Path);
            string[] claims = {ClaimConstants.Send};
            var amqpSendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(this.Path, this.ServiceBusConnection, endpointUri, claims, this.CbsTokenProvider, amqpLinkSettings, this.ClientId);
            Tuple<AmqpObject, DateTime> linkDetails = await amqpSendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var sendingAmqpLink = (SendingAmqpLink) linkDetails.Item1;
            var activeSendReceiveClientLink = new ActiveSendReceiveClientLink(
                sendingAmqpLink,
                endpointUri,
                endpointUri.AbsoluteUri,
                claims,
                linkDetails.Item2);

            this.clientLinkManager.SetActiveSendReceiveLink(activeSendReceiveClientLink);

            MessagingEventSource.Log.AmqpSendLinkCreateStop(this.ClientId);
            return sendingAmqpLink;
        }

        async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            var entityPath = this.Path + '/' + AmqpClientConstants.ManagementAddress;
            var amqpLinkSettings = new AmqpLinkSettings();
            amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            var endpointUri = new Uri(this.ServiceBusConnection.Endpoint, entityPath);
            string[] claims = { ClaimConstants.Manage, ClaimConstants.Send };
            var amqpRequestResponseLinkCreator = new AmqpRequestResponseLinkCreator(
                entityPath,
                this.ServiceBusConnection,
                endpointUri,
                claims,
                this.CbsTokenProvider,
                amqpLinkSettings,
                this.ClientId);

            Tuple<AmqpObject, DateTime> linkDetails =
                await amqpRequestResponseLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var requestResponseAmqpLink = (RequestResponseAmqpLink) linkDetails.Item1;
            var activeRequestResponseClientLink = new ActiveRequestResponseLink(
                requestResponseAmqpLink,
                endpointUri,
                endpointUri.AbsoluteUri,
                claims,
                linkDetails.Item2);
            this.clientLinkManager.SetActiveRequestResponseLink(activeRequestResponseClientLink);

            return requestResponseAmqpLink;
        }

        ArraySegment<byte> GetNextDeliveryTag()
        {
            var deliveryId = Interlocked.Increment(ref this.deliveryCount);
            return new ArraySegment<byte>(BitConverter.GetBytes(deliveryId));
        }
    }
}