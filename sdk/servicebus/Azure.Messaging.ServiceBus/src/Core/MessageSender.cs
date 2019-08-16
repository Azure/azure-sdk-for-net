// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Transactions;
    using Azure.Messaging.ServiceBus.Amqp;
    using Azure.Messaging.ServiceBus.Primitives;

    /// <summary>
    /// The MessageSender can be used to send messages to Queues or Topics.
    /// </summary>
    /// <example>
    /// Create a new MessageSender to send to a Queue
    /// <code>
    /// MessageSender messageSender = new MessageSender(
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
    public class MessageSender: IAsyncDisposable
    {
        private int deliveryCount;
        
        private readonly ActiveClientLinkManager clientLinkManager;
        private readonly ActiveClientLinkManager requestResponseLinkManager;

        private readonly ServiceBusDiagnosticSource diagnosticSource;

        private readonly bool isViaSender;

        /// <summary>
        /// Creates a new AMQP MessageSender.
        /// </summary>
        /// <param name="connectionStringBuilder">The <see cref="ServiceBusConnectionStringBuilder"/> having entity level connection details.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        internal MessageSender(
            ServiceBusConnectionStringBuilder connectionStringBuilder,
            AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, options)
        {
        }

        /// <summary>
        /// Creates a new AMQP MessageSender.
        /// </summary>
        /// <param name="connectionString">Namespace connection string used to communicate with Service Bus. Must not contain Entity details.</param>
        /// <param name="entityPath">The path of the entity this sender should connect to.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageSender(
            string connectionString,
            string entityPath,
            AmqpClientOptions options = null)
            : this(entityPath, null, null, new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString), options), options)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new MessageSender
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <remarks>Creates a new connection to the entity, which is opened during the first operation.</remarks>
        public MessageSender(
            string endpoint,
            string entityPath,
            TokenCredential tokenProvider,
            AmqpClientOptions options = null)
            : this(entityPath, null, null, new ServiceBusConnection(endpoint, tokenProvider, options), options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new AMQP MessageSender on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The path of the entity this sender should connect to.</param>
        internal MessageSender(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            AmqpClientOptions options = null)
            : this(entityPath, null, null, serviceBusConnection, options)
        {
            ClientEntity.OwnsConnection = false;
        }

        /// <summary>
        /// Creates a ViaMessageSender. This can be used to send messages to a destination entity via another another entity.
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">The final destination of the message.</param>
        /// <param name="viaEntityPath">The first destination of the message.</param>
        /// <remarks>
        /// This is mainly to be used when sending messages in a transaction.
        /// When messages need to be sent across entities in a single transaction, this can be used to ensure
        /// all the messages land initially in the same entity/partition for local transactions, and then
        /// let service bus handle transferring the message to the actual destination.
        /// </remarks>
        internal MessageSender(
            ServiceBusConnection serviceBusConnection,
            string entityPath,
            string viaEntityPath,
            AmqpClientOptions options = null)
            :this(viaEntityPath, entityPath, null, serviceBusConnection, options)
        {
            ClientEntity.OwnsConnection = false;
        }

        internal MessageSender(
            string entityPath,
            string transferDestinationPath,
            MessagingEntityType? entityType,
            ServiceBusConnection serviceBusConnection,
            AmqpClientOptions options)
        {
            this.ClientEntity = new ClientEntity(options, entityPath);
            MessagingEventSource.Log.MessageSenderCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath);

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.Path = entityPath;
            this.SendingLinkDestination = entityPath;
            this.EntityType = entityType;
            ClientEntity.ServiceBusConnection.ThrowIfClosed();

            this.SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(this.CreateLinkAsync, CloseSession);
            this.RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(this.CreateRequestResponseLinkAsync, CloseRequestResponseSession);
            this.clientLinkManager = new ActiveClientLinkManager(ClientEntity);
            this.requestResponseLinkManager = new ActiveClientLinkManager(ClientEntity);
            this.diagnosticSource = new ServiceBusDiagnosticSource(entityPath, serviceBusConnection.Endpoint);

            if (!string.IsNullOrWhiteSpace(transferDestinationPath))
            {
                this.isViaSender = true;
                this.TransferDestinationPath = transferDestinationPath;
                this.ViaEntityPath = entityPath;
            }

            MessagingEventSource.Log.MessageSenderCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, ClientEntity.ClientId);
        }

        internal ClientEntity ClientEntity { get; set; }

        /// <summary>
        /// Gets the entity path of the MessageSender.
        /// In the case of a via-sender, this returns the path of the via entity.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// In the case of a via-sender, gets the final destination path of the messages; null otherwise.
        /// </summary>
        public string TransferDestinationPath { get; }

        /// <summary>
        /// In the case of a via-sender, the message is sent to <see cref="TransferDestinationPath"/> via <see cref="ViaEntityPath"/>; null otherwise.
        /// </summary>
        public string ViaEntityPath { get; }

        internal MessagingEntityType? EntityType { get; }

        internal string SendingLinkDestination { get; set; }

        private FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        private FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        /// <summary>
        /// Sends a message to the entity as described by <see cref="Path"/>.
        /// </summary>
        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to the entity as described by <see cref="Path"/>.
        /// </summary>
        public async Task SendAsync(IList<Message> messageList)
        {
            ClientEntity.ThrowIfClosed();

            var count = MessageSender.ValidateMessages(messageList);
            if (count <= 0)
            {
                return;
            }

            MessagingEventSource.Log.MessageSendStart(ClientEntity.ClientId, count);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.SendStart(messageList) : null;
            Task sendTask = null;

            try
            {
                var processedMessages = await this.ProcessMessages(messageList).ConfigureAwait(false);

                sendTask = ClientEntity.RetryPolicy.RunOperation(() => this.OnSendAsync(processedMessages), ClientEntity.OperationTimeout);
                await sendTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.MessageSendException(ClientEntity.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.SendStop(activity, messageList, sendTask?.Status);
            }

            MessagingEventSource.Log.MessageSendStop(ClientEntity.ClientId);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> that needs to be scheduled.</param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public async Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            ClientEntity.ThrowIfClosed();
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

            if (this.isViaSender && Transaction.Current != null)
            {
                throw new ServiceBusException(false, $"{nameof(ScheduleMessageAsync)} method is not supported in a Via-Sender with transactions.");
            }

            message.ScheduledEnqueueTimeUtc = scheduleEnqueueTimeUtc.UtcDateTime;
            MessageSender.ValidateMessage(message);
            MessagingEventSource.Log.ScheduleMessageStart(ClientEntity.ClientId, scheduleEnqueueTimeUtc);
            long result = 0;

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.ScheduleStart(message, scheduleEnqueueTimeUtc) : null;
            Task scheduleTask = null;

            try
            {
                var processedMessage = await this.ProcessMessage(message).ConfigureAwait(false);

                scheduleTask = ClientEntity.RetryPolicy.RunOperation(
                    async () =>
                    {
                        result = await this.OnScheduleMessageAsync(processedMessage).ConfigureAwait(false);
                    }, ClientEntity.OperationTimeout);
                await scheduleTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.ScheduleMessageException(ClientEntity.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.ScheduleStop(activity, message, scheduleEnqueueTimeUtc, scheduleTask?.Status, result);
            }

            MessagingEventSource.Log.ScheduleMessageStop(ClientEntity.ClientId);
            return result;
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ReceivedMessage.SequenceNumber"/> of the message to be cancelled.</param>
        public async Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            ClientEntity.ThrowIfClosed();
            if (Transaction.Current != null)
            {
                throw new ServiceBusException(false, $"{nameof(CancelScheduledMessageAsync)} method is not supported within a transaction.");
            }

            MessagingEventSource.Log.CancelScheduledMessageStart(ClientEntity.ClientId, sequenceNumber);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.CancelStart(sequenceNumber) : null;
            Task cancelTask = null;

            try
            {
                cancelTask = ClientEntity.RetryPolicy.RunOperation(() => this.OnCancelScheduledMessageAsync(sequenceNumber),
                    ClientEntity.OperationTimeout);
                await cancelTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.CancelScheduledMessageException(ClientEntity.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.CancelStop(activity, sequenceNumber, cancelTask?.Status);
            }
            MessagingEventSource.Log.CancelScheduledMessageStop(ClientEntity.ClientId);
        }

        internal async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            var amqpMessage = amqpRequestMessage.AmqpMessage;
            var timeoutHelper = new TimeoutHelper(ClientEntity.OperationTimeout, true);

            ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction != null)
            {
                transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, ClientEntity.ServiceBusConnection).ConfigureAwait(false);
            }

            if (!this.RequestResponseLinkManager.TryGetOpenedObject(out var requestResponseAmqpLink))
            {
                requestResponseAmqpLink = await this.RequestResponseLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }

            var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, transactionId, timeoutHelper.RemainingTime(), c, s),
                a => requestResponseAmqpLink.EndRequest(a),
                this).ConfigureAwait(false);

            return AmqpResponseMessage.CreateResponse(responseAmqpMessage);
        }

        /// <summary>Closes the connection.</summary>
        internal async Task OnClosingAsync()
        {
            this.clientLinkManager.Close();
            await this.SendLinkManager.CloseAsync().ConfigureAwait(false);
            await this.RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);
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
            if (message is ReceivedMessage)
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
            foreach (var plugin in ClientEntity.RegisteredPlugins)
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
            if (ClientEntity.RegisteredPlugins.Count < 1)
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

        private async Task OnSendAsync(IList<Message> messageList)
        {
            var timeoutHelper = new TimeoutHelper(ClientEntity.OperationTimeout, true);
            using (var amqpMessage = AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messageList))
            {
                SendingAmqpLink amqpLink = null;
                try
                {
                    ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                    var ambientTransaction = Transaction.Current;
                    if (ambientTransaction != null)
                    {
                        transactionId = await AmqpTransactionManager.Instance.EnlistAsync(ambientTransaction, ClientEntity.ServiceBusConnection).ConfigureAwait(false);
                    }

                    if (!this.SendLinkManager.TryGetOpenedObject(out amqpLink))
                    {
                        amqpLink = await this.SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    }
                    if (amqpLink.Settings.MaxMessageSize.HasValue)
                    {
                        var size = (ulong)amqpMessage.SerializedMessageSize;
                        if (size > amqpLink.Settings.MaxMessageSize.Value)
                        {
                            throw new MessageSizeExceededException(Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value));
                        }
                    }

                    var outcome = await amqpLink.SendMessageAsync(amqpMessage, this.GetNextDeliveryTag(), transactionId, timeoutHelper.RemainingTime()).ConfigureAwait(false);

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
                        ClientEntity.OperationTimeout,
                        null);

                SendingAmqpLink sendLink = null;

                try
                {
                    if (this.SendLinkManager.TryGetOpenedObject(out sendLink))
                    {
                        request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                    }

                    ArraySegment<byte>[] payload = amqpMessage.GetPayload();
                    var buffer = new BufferListStream(payload);
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

                        if (!string.IsNullOrWhiteSpace(message.ViaPartitionKey))
                        {
                            entry[ManagementConstants.Properties.ViaPartitionKey] = message.ViaPartitionKey;
                        }
                    }

                    request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };

                    var response = await this.ExecuteRequestResponseAsync(request).ConfigureAwait(false);
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
                    ClientEntity.OperationTimeout,
                    null);

            SendingAmqpLink sendLink = null;

            try
            {
                if (this.SendLinkManager.TryGetOpenedObject(out sendLink))
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                }

                request.Map[ManagementConstants.Properties.SequenceNumbers] = new[] { sequenceNumber };

                var response = await this.ExecuteRequestResponseAsync(request).ConfigureAwait(false);

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
            MessagingEventSource.Log.AmqpSendLinkCreateStart(ClientEntity.ClientId, this.EntityType, this.SendingLinkDestination);

            var amqpLinkSettings = new AmqpLinkSettings
            {
                Role = false,
                InitialDeliveryCount = 0,
                Target = new Target { Address = this.SendingLinkDestination },
                Source = new Source { Address = ClientEntity.ClientId },
            };
            if (this.EntityType != null)
            {
                amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)this.EntityType);
            }

            var endpointUri = new Uri(ClientEntity.ServiceBusConnection.Endpoint, this.SendingLinkDestination);

            string[] audience;
            if (this.isViaSender)
            {
                var transferDestinationEndpointUri = new Uri(ClientEntity.ServiceBusConnection.Endpoint, this.TransferDestinationPath);
                audience = new string[] { endpointUri.AbsoluteUri, transferDestinationEndpointUri.AbsoluteUri };
                amqpLinkSettings.AddProperty(AmqpClientConstants.TransferDestinationAddress, this.TransferDestinationPath);
            }
            else
            {
                audience = new string[] { endpointUri.AbsoluteUri };
            }

            string[] claims = {ClaimConstants.Send};
            var amqpSendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(this.SendingLinkDestination, ClientEntity.ServiceBusConnection, endpointUri, audience, claims, amqpLinkSettings, ClientEntity.ClientId);
            (AmqpObject, DateTime) linkDetails = await amqpSendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var sendingAmqpLink = (SendingAmqpLink) linkDetails.Item1;
            var activeSendReceiveClientLink = new ActiveClientLinkObject(
                sendingAmqpLink,
                sendingAmqpLink.Session.Connection,
                endpointUri,
                audience,
                claims,
                linkDetails.Item2);

            this.clientLinkManager.SetLink(activeSendReceiveClientLink);

            MessagingEventSource.Log.AmqpSendLinkCreateStop(ClientEntity.ClientId);
            return sendingAmqpLink;
        }

        private async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            var entityPath = this.SendingLinkDestination + '/' + AmqpClientConstants.ManagementAddress;
            var amqpLinkSettings = new AmqpLinkSettings();
            amqpLinkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            var endpointUri = new Uri(ClientEntity.ServiceBusConnection.Endpoint, entityPath);

            string[] audience;
            if (this.isViaSender)
            {
                var transferDestinationEndpointUri = new Uri(ClientEntity.ServiceBusConnection.Endpoint, this.TransferDestinationPath);
                audience = new string[] { endpointUri.AbsoluteUri, transferDestinationEndpointUri.AbsoluteUri };
                amqpLinkSettings.AddProperty(AmqpClientConstants.TransferDestinationAddress, this.TransferDestinationPath);
            }
            else
            {
                audience = new string[] { endpointUri.AbsoluteUri };
            }

            string[] claims = { ClaimConstants.Manage, ClaimConstants.Send };
            var amqpRequestResponseLinkCreator = new AmqpRequestResponseLinkCreator(
                entityPath,
                ClientEntity.ServiceBusConnection,
                endpointUri,
                audience,
                claims,
                amqpLinkSettings,
                ClientEntity.ClientId);

            (AmqpObject, DateTime) linkDetails =
                await amqpRequestResponseLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            var requestResponseAmqpLink = (RequestResponseAmqpLink) linkDetails.Item1;
            var activeRequestResponseClientLink = new ActiveClientLinkObject(
                requestResponseAmqpLink,
                requestResponseAmqpLink.Session.Connection,
                endpointUri,
                audience,
                claims,
                linkDetails.Item2);
            this.requestResponseLinkManager.SetLink(activeRequestResponseClientLink);

            return requestResponseAmqpLink;
        }

        private ArraySegment<byte> GetNextDeliveryTag()
        {
            var deliveryId = Interlocked.Increment(ref this.deliveryCount);
            return new ArraySegment<byte>(BitConverter.GetBytes(deliveryId));
        }

        public  async ValueTask DisposeAsync()
        {
            await ClientEntity.CloseAsync(OnClosingAsync).ConfigureAwait(false);
        }
    }
}
