// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Amqp;
    using Primitives;

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
	    private int _deliveryCount;
	    private readonly ActiveClientLinkManager _clientLinkManager;
	    private readonly ServiceBusDiagnosticSource _diagnosticSource;
	    private readonly bool _isViaSender;

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
            : this(entityPath, null, null, new ServiceBusConnection(connectionString), null, retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new MessageSender
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="retryPolicy">Retry policy for queue operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageSender(
            string endpoint,
            string entityPath,
            ITokenProvider tokenProvider,
            TransportType transportType = TransportType.Amqp,
            RetryPolicy retryPolicy = null)
            : this(entityPath, null, null, new ServiceBusConnection(endpoint, transportType, retryPolicy) {TokenProvider = tokenProvider}, null, retryPolicy)
        {
            OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new AMQP MessageSender on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The path of the entity this sender should connect to.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        public MessageSender(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            RetryPolicy retryPolicy = null)
            : this(entityPath, null, null, serviceBusConnection, null, retryPolicy)
        {
            OwnsConnection = false;
        }

        /// <summary>
        /// Creates a ViaMessageSender. This can be used to send messages to a destination entity via another another entity.
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The final destination of the message.</param>
        /// <param name="viaEntityPath">The first destination of the message.</param>
        /// <param name="retryPolicy">The <see cref="RetryPolicy"/> that will be used when communicating with Service Bus. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>
        /// This is mainly to be used when sending messages in a transaction.
        /// When messages need to be sent across entities in a single transaction, this can be used to ensure
        /// all the messages land initially in the same entity/partition for local transactions, and then
        /// let service bus handle transferring the message to the actual destination.
        /// </remarks>
        public MessageSender(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            string viaEntityPath,
            RetryPolicy retryPolicy = null)
            :this(viaEntityPath, entityPath, null, serviceBusConnection, null, retryPolicy)
        {
            OwnsConnection = false;
        }

        internal MessageSender(
            string entityPath,
            string transferDestinationPath,
            MessagingEntityType? entityType,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy)
            : base(nameof(MessageSender), entityPath, retryPolicy ?? RetryPolicy.Default)
        {
            MessagingEventSource.Log.MessageSenderCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath);

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            Path = entityPath;
            SendingLinkDestination = entityPath;
            EntityType = entityType;
            ServiceBusConnection.ThrowIfClosed();

            if (cbsTokenProvider != null)
            {
                CbsTokenProvider = cbsTokenProvider;
            }
            else if (ServiceBusConnection.TokenProvider != null)
            {
                CbsTokenProvider = new TokenProviderAdapter(ServiceBusConnection.TokenProvider, ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(CreateLinkAsync, CloseSession);
            RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(CreateRequestResponseLinkAsync, CloseRequestResponseSession);
            _clientLinkManager = new ActiveClientLinkManager(this, CbsTokenProvider);
            _diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);

            if (!string.IsNullOrWhiteSpace(transferDestinationPath))
            {
                _isViaSender = true;
                TransferDestinationPath = transferDestinationPath;
                ViaEntityPath = entityPath;
            }

            MessagingEventSource.Log.MessageSenderCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, ClientId);
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this sender.
        /// </summary>
        /// <seealso cref="RegisterPlugin"/>
        public override IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Gets the entity path of the MessageSender. 
        /// In the case of a via-sender, this returns the path of the via entity.
        /// </summary>
        public override string Path { get; }

        /// <summary>
        /// In the case of a via-sender, gets the final destination path of the messages; null otherwise.
        /// </summary>
        public string TransferDestinationPath { get; }

        /// <summary>
        /// In the case of a via-sender, the message is sent to <see cref="TransferDestinationPath"/> via <see cref="ViaEntityPath"/>; null otherwise.
        /// </summary>
        public string ViaEntityPath { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout
        {
            get => ServiceBusConnection.OperationTimeout;
            set => ServiceBusConnection.OperationTimeout = value;
        }

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public override ServiceBusConnection ServiceBusConnection { get; }

        internal MessagingEntityType? EntityType { get; }

        internal string SendingLinkDestination { get; set; }

        private ICbsTokenProvider CbsTokenProvider { get; }

        private FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        private FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        /// <summary>
        /// Sends a message to the entity as described by <see cref="Path"/>.
        /// </summary>
        public Task SendAsync(Message message)
        {
            return SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to the entity as described by <see cref="Path"/>.
        /// When called on partitioned entities, messages meant for different partitions cannot be batched together.
        /// </summary>
        public async Task SendAsync(IList<Message> messageList)
        {
            ThrowIfClosed();

            var count = ValidateMessages(messageList);
            if (count <= 0)
            {
                return;
            }

            MessagingEventSource.Log.MessageSendStart(ClientId, count);

            var isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            var activity = isDiagnosticSourceEnabled ? _diagnosticSource.SendStart(messageList) : null;
            Task sendTask = null;

            try
            {
                var processedMessages = await ProcessMessages(messageList).ConfigureAwait(false);

                sendTask = RetryPolicy.RunOperation(() => OnSendAsync(processedMessages), OperationTimeout);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    _diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageSendException(ClientId, exception);
                throw;
            }
            finally
            {
                _diagnosticSource.SendStop(activity, messageList, sendTask?.Status);
            }

            MessagingEventSource.Log.MessageSendStop(ClientId);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> that needs to be scheduled.</param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public async Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            ThrowIfClosed();
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

            if (_isViaSender && Transaction.Current != null)
            {
                throw new ServiceBusException(false, $"{nameof(ScheduleMessageAsync)} method is not supported in a Via-Sender with transactions.");
            }

            message.ScheduledEnqueueTimeUtc = scheduleEnqueueTimeUtc.UtcDateTime;
            ValidateMessage(message);
            MessagingEventSource.Log.ScheduleMessageStart(ClientId, scheduleEnqueueTimeUtc);
            long result = 0;

            var isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            var activity = isDiagnosticSourceEnabled ? _diagnosticSource.ScheduleStart(message, scheduleEnqueueTimeUtc) : null;
            Task scheduleTask = null;

            try
            {
                var processedMessage = await ProcessMessage(message).ConfigureAwait(false);

                scheduleTask = RetryPolicy.RunOperation(
                    async () =>
                    {
                        result = await OnScheduleMessageAsync(processedMessage).ConfigureAwait(false);
                    }, OperationTimeout);
                await scheduleTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    _diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.ScheduleMessageException(ClientId, exception);
                throw;
            }
            finally
            {
                _diagnosticSource.ScheduleStop(activity, message, scheduleEnqueueTimeUtc, scheduleTask?.Status, result);
            }

            MessagingEventSource.Log.ScheduleMessageStop(ClientId);
            return result;
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        public async Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            ThrowIfClosed();
            if (Transaction.Current != null)
            {
                throw new ServiceBusException(false, $"{nameof(CancelScheduledMessageAsync)} method is not supported within a transaction.");
            }

            MessagingEventSource.Log.CancelScheduledMessageStart(ClientId, sequenceNumber);

            var isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            var activity = isDiagnosticSourceEnabled ? _diagnosticSource.CancelStart(sequenceNumber) : null;
            Task cancelTask = null;

            try
            {
                cancelTask = RetryPolicy.RunOperation(() => OnCancelScheduledMessageAsync(sequenceNumber),
                    OperationTimeout);
                await cancelTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    _diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.CancelScheduledMessageException(ClientId, exception);
                throw;
            }
            finally
            {
                _diagnosticSource.CancelStop(activity, sequenceNumber, cancelTask?.Status);
            }
            MessagingEventSource.Log.CancelScheduledMessageStop(ClientId);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this sender.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            ThrowIfClosed();
            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }

            if (RegisteredPlugins.Any(p => p.GetType() == serviceBusPlugin.GetType()))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(serviceBusPlugin.Name));
            }
            RegisteredPlugins.Add(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public override void UnregisterPlugin(string serviceBusPluginName)
        {
            ThrowIfClosed();
            if (string.IsNullOrWhiteSpace(serviceBusPluginName))
            {
                throw new ArgumentNullException(nameof(serviceBusPluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPluginName)));
            }
            if (RegisteredPlugins.Any(p => p.Name == serviceBusPluginName))
            {
                var plugin = RegisteredPlugins.First(p => p.Name == serviceBusPluginName);
                RegisteredPlugins.Remove(plugin);
            }
        }

        internal async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            var amqpMessage = amqpRequestMessage.AmqpMessage;
            var timeoutHelper = new TimeoutHelper(OperationTimeout, true);

            var transactionId = AmqpConstants.NullBinary;
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction != null)
            {
                transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, ServiceBusConnection).ConfigureAwait(false);
            }

            if (!RequestResponseLinkManager.TryGetOpenedObject(out var requestResponseAmqpLink))
            {
                requestResponseAmqpLink = await RequestResponseLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }

            var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, transactionId, timeoutHelper.RemainingTime(), c, s),
                a => requestResponseAmqpLink.EndRequest(a),
                this).ConfigureAwait(false);

            return AmqpResponseMessage.CreateResponse(responseAmqpMessage);
        }

        /// <summary>Closes the connection.</summary>
        protected override async Task OnClosingAsync()
        {
            _clientLinkManager.Close();
            await SendLinkManager.CloseAsync().ConfigureAwait(false);
            await RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);
        }

        private static int ValidateMessages(IList<Message> messageList)
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

        private static void ValidateMessage(Message message)
        {
            if (message.SystemProperties.IsLockTokenSet)
            {
                throw Fx.Exception.Argument(nameof(message), "Cannot send a message that was already received.");
            }
        }

        private static void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
            link.Session.SafeClose();
        }

        private static void CloseRequestResponseSession(RequestResponseAmqpLink requestResponseAmqpLink)
        {
            requestResponseAmqpLink.Session.SafeClose();
        }

        private async Task<Message> ProcessMessage(Message message)
        {
            var processedMessage = message;
            foreach (var plugin in RegisteredPlugins)
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

        private async Task<IList<Message>> ProcessMessages(IList<Message> messageList)
        {
            if (RegisteredPlugins.Count < 1)
            {
                return messageList;
            }

            var processedMessageList = new List<Message>();
            foreach (var message in messageList)
            {
                var processedMessage = await ProcessMessage(message).ConfigureAwait(false);
                processedMessageList.Add(processedMessage);
            }

            return processedMessageList;
        }

        private async Task OnSendAsync(IList<Message> messageList)
        {
            var timeoutHelper = new TimeoutHelper(OperationTimeout, true);
            using (var amqpMessage = AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messageList))
            {
                SendingAmqpLink amqpLink = null;
                try
                {
                    var transactionId = AmqpConstants.NullBinary;
                    var ambientTransaction = Transaction.Current;
                    if (ambientTransaction != null)
                    {
                        transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, ServiceBusConnection).ConfigureAwait(false);
                    }

                    if (!SendLinkManager.TryGetOpenedObject(out amqpLink))
                    {
                        amqpLink = await SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    }
                    if (amqpLink.Settings.MaxMessageSize.HasValue)
                    {
                        var size = (ulong)amqpMessage.SerializedMessageSize;
                        if (size > amqpLink.Settings.MaxMessageSize.Value)
                        {
                            throw new MessageSizeExceededException(Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value));
                        }
                    }

                    var outcome = await amqpLink.SendMessageAsync(amqpMessage, GetNextDeliveryTag(), transactionId, timeoutHelper.RemainingTime()).ConfigureAwait(false);

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

        private async Task<long> OnScheduleMessageAsync(Message message)
        {
            using (var amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message))
            {
                var request = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.ScheduleMessageOperation,
                        OperationTimeout,
                        null);

                SendingAmqpLink sendLink = null;

                try
                {
                    if (SendLinkManager.TryGetOpenedObject(out sendLink))
                    {
                        request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                    }

                    var payload = amqpMessage.GetPayload();
                    var buffer = new BufferListStream(payload);
                    var value = buffer.ReadBytes((int)buffer.Length);

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

                        if (!string.IsNullOrWhiteSpace(message.ViaPartitionKey))
                        {
                            entry[ManagementConstants.Properties.ViaPartitionKey] = message.ViaPartitionKey;
                        }
                    }

                    request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };

                    var response = await ExecuteRequestResponseAsync(request).ConfigureAwait(false);
                    if (response.StatusCode == AmqpResponseStatusCode.OK)
                    {
                        var sequenceNumbers = response.GetValue<long[]>(ManagementConstants.Properties.SequenceNumbers);
                        if (sequenceNumbers == null || sequenceNumbers.Length < 1)
                        {
                            throw new ServiceBusException(true, "Could not schedule message successfully.");
                        }

                        return sequenceNumbers[0];

                    }
                    else
                    {
                        throw response.ToMessagingContractException();
                    }
                }
                catch (Exception exception)
                {
                    throw AmqpExceptionHelper.GetClientException(exception, sendLink?.GetTrackingId(), null, sendLink?.Session.IsClosing() ?? false);
                }
            }
        }

        private async Task OnCancelScheduledMessageAsync(long sequenceNumber)
        {
            var request =
                AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.CancelScheduledMessageOperation,
                    OperationTimeout,
                    null);

            SendingAmqpLink sendLink = null;

            try
            {
                if (SendLinkManager.TryGetOpenedObject(out sendLink))
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                }

                request.Map[ManagementConstants.Properties.SequenceNumbers] = new[] { sequenceNumber };

                var response = await ExecuteRequestResponseAsync(request).ConfigureAwait(false);

                if (response.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw response.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception, sendLink?.GetTrackingId(), null, sendLink?.Session.IsClosing() ?? false);
            }
        }

        private async Task<SendingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            MessagingEventSource.Log.AmqpSendLinkCreateStart(ClientId, EntityType, SendingLinkDestination);

            var amqpLinkSettings = new AmqpLinkSettings
            {
                Role = false,
                InitialDeliveryCount = 0,
                Target = new Target { Address = SendingLinkDestination },
                Source = new Source { Address = ClientId },
            };
            if (EntityType != null)
            {
                amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)EntityType);
            }

            var endpointUri = new Uri(ServiceBusConnection.Endpoint, SendingLinkDestination);

            string[] audience;
            if (_isViaSender)
            {
                var transferDestinationEndpointUri = new Uri(ServiceBusConnection.Endpoint, TransferDestinationPath);
                audience = new[] { endpointUri.AbsoluteUri, transferDestinationEndpointUri.AbsoluteUri };
                amqpLinkSettings.AddProperty(AmqpClientConstants.TransferDestinationAddress, TransferDestinationPath);
            }
            else
            {
                audience = new[] { endpointUri.AbsoluteUri };
            }

            string[] claims = {ClaimConstants.Send};
            var amqpSendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(SendingLinkDestination, ServiceBusConnection, endpointUri, audience, claims, CbsTokenProvider, amqpLinkSettings, ClientId);
            var linkDetails = await amqpSendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var sendingAmqpLink = (SendingAmqpLink) linkDetails.Item1;
            var activeSendReceiveClientLink = new ActiveSendReceiveClientLink(
                sendingAmqpLink,
                endpointUri,
                audience,
                claims,
                linkDetails.Item2);

            _clientLinkManager.SetActiveSendReceiveLink(activeSendReceiveClientLink);

            MessagingEventSource.Log.AmqpSendLinkCreateStop(ClientId);
            return sendingAmqpLink;
        }

        private async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            var entityPath = SendingLinkDestination + '/' + AmqpClientConstants.ManagementAddress;
            var amqpLinkSettings = new AmqpLinkSettings();
            amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            var endpointUri = new Uri(ServiceBusConnection.Endpoint, entityPath);

            string[] audience;
            if (_isViaSender)
            {
                var transferDestinationEndpointUri = new Uri(ServiceBusConnection.Endpoint, TransferDestinationPath);
                audience = new[] { endpointUri.AbsoluteUri, transferDestinationEndpointUri.AbsoluteUri };
                amqpLinkSettings.AddProperty(AmqpClientConstants.TransferDestinationAddress, TransferDestinationPath);
            }
            else
            {
                audience = new[] { endpointUri.AbsoluteUri };
            }

            string[] claims = { ClaimConstants.Manage, ClaimConstants.Send };
            var amqpRequestResponseLinkCreator = new AmqpRequestResponseLinkCreator(
                entityPath,
                ServiceBusConnection,
                endpointUri,
                audience,
                claims,
                CbsTokenProvider,
                amqpLinkSettings,
                ClientId);

            var linkDetails =
                await amqpRequestResponseLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var requestResponseAmqpLink = (RequestResponseAmqpLink) linkDetails.Item1;
            var activeRequestResponseClientLink = new ActiveRequestResponseLink(
                requestResponseAmqpLink,
                endpointUri,
                audience,
                claims,
                linkDetails.Item2);
            _clientLinkManager.SetActiveRequestResponseLink(activeRequestResponseClientLink);

            return requestResponseAmqpLink;
        }

        private ArraySegment<byte> GetNextDeliveryTag()
        {
            var deliveryId = Interlocked.Increment(ref _deliveryCount);
            return new ArraySegment<byte>(BitConverter.GetBytes(deliveryId));
        }
    }
}
