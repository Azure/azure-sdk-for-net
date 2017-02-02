// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.Messaging.Amqp;

    sealed class AmqpMessageSender : MessageSender
    {
        int deliveryCount;

        internal AmqpMessageSender(string entityName, MessagingEntityType entityType, ServiceBusConnection serviceBusConnection, ICbsTokenProvider cbsTokenProvider)
            : base(serviceBusConnection.OperationTimeout)
        {
            this.Path = entityName;
            this.EntityType = entityType;
            this.ServiceBusConnection = serviceBusConnection;
            this.CbsTokenProvider = cbsTokenProvider;
            this.SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(this.CreateLinkAsync, this.CloseSession);
            this.RequestResponseLinkManager = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(this.CreateRequestResponseLinkAsync, this.CloseRequestResponseSession);
        }

        string Path { get; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        FaultTolerantAmqpObject<RequestResponseAmqpLink> RequestResponseLinkManager { get; }

        public override async Task CloseAsync()
        {
            await this.SendLinkManager.CloseAsync().ConfigureAwait(false);
            await this.RequestResponseLinkManager.CloseAsync().ConfigureAwait(false);
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

        protected override async Task OnSendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            using (AmqpMessage amqpMessage = AmqpMessageConverter.BrokeredMessagesToAmqpMessage(brokeredMessages, true))
            {
                SendingAmqpLink amqpLink = null;
                try
                {
                    amqpLink = await this.SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    if (amqpLink.Settings.MaxMessageSize.HasValue)
                    {
                        ulong size = (ulong)amqpMessage.SerializedMessageSize;
                        if (size > amqpLink.Settings.MaxMessageSize.Value)
                        {
                            // TODO: Add MessageSizeExceededException
                            throw new NotImplementedException("MessageSizeExceededException: " + Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value));
                            ////throw Fx.Exception.AsError(new MessageSizeExceededException(
                            ////Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value)));
                        }
                    }

                    Outcome outcome = await amqpLink.SendMessageAsync(amqpMessage, this.GetNextDeliveryTag(), AmqpConstants.NullBinary, timeoutHelper.RemainingTime()).ConfigureAwait(false);
                    if (outcome.DescriptorCode != Accepted.Code)
                    {
                        Rejected rejected = (Rejected)outcome;
                        throw Fx.Exception.AsError(AmqpExceptionHelper.ToMessagingContractException(rejected.Error));
                    }
                }
                catch (Exception exception)
                {
                    throw AmqpExceptionHelper.GetClientException(exception, amqpLink?.GetTrackingId());
                }
            }
        }

        protected override async Task<long> OnScheduleMessageAsync(BrokeredMessage brokeredMessage)
        {
            // TODO: Ensure System.Transactions.Transaction.Current is null. Transactions are not supported by 1.0.0 version of dotnet core.
            using (AmqpMessage amqpMessage = AmqpMessageConverter.ClientGetMessage(brokeredMessage))
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
                    entry[ManagementConstants.Properties.MessageId] = brokeredMessage.MessageId;

                    if (!string.IsNullOrWhiteSpace(brokeredMessage.SessionId))
                    {
                        entry[ManagementConstants.Properties.SessionId] = brokeredMessage.SessionId;
                    }

                    if (!string.IsNullOrWhiteSpace(brokeredMessage.PartitionKey))
                    {
                        entry[ManagementConstants.Properties.PartitionKey] = brokeredMessage.PartitionKey;
                    }
                }

                request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };

                IEnumerable<long> sequenceNumbers = null;
                var response = await this.ExecuteRequestResponseAsync(request);
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

        protected override async Task OnCancelScheduledMessageAsync(long sequenceNumber)
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

        ArraySegment<byte> GetNextDeliveryTag()
        {
            int deliveryId = Interlocked.Increment(ref this.deliveryCount);
            return new ArraySegment<byte>(BitConverter.GetBytes(deliveryId));
        }

        async Task<SendingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            MessagingEventSource.Log.AmqpSendLinkCreateStart(this.ClientId, this.EntityType, this.Path);

            AmqpLinkSettings linkSettings = new AmqpLinkSettings
            {
                Role = false,
                InitialDeliveryCount = 0,
                Target = new Target { Address = this.Path },
                Source = new Source { Address = this.ClientId },
            };
            linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)this.EntityType);

            AmqpSendReceiveLinkCreator sendReceiveLinkCreator = new AmqpSendReceiveLinkCreator(this.Path, this.ServiceBusConnection, new[] { ClaimConstants.Send }, this.CbsTokenProvider, linkSettings);
            SendingAmqpLink sendingAmqpLink = (SendingAmqpLink)await sendReceiveLinkCreator.CreateAndOpenAmqpLinkAsync().ConfigureAwait(false);

            MessagingEventSource.Log.AmqpSendLinkCreateStop(this.ClientId);
            return sendingAmqpLink;
        }

        async Task<RequestResponseAmqpLink> CreateRequestResponseLinkAsync(TimeSpan timeout)
        {
            string entityPath = this.Path + '/' + AmqpClientConstants.ManagementAddress;
            AmqpLinkSettings linkSettings = new AmqpLinkSettings();
            linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);

            AmqpRequestResponseLinkCreator requestResponseLinkCreator = new AmqpRequestResponseLinkCreator(
                entityPath,
                this.ServiceBusConnection,
                new[] { ClaimConstants.Manage, ClaimConstants.Send },
                this.CbsTokenProvider,
                linkSettings);

            RequestResponseAmqpLink requestResponseAmqpLink =
                (RequestResponseAmqpLink)await requestResponseLinkCreator.CreateAndOpenAmqpLinkAsync()
                .ConfigureAwait(false);
            return requestResponseAmqpLink;
        }

        void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
            link.Session.SafeClose();
        }

        void CloseRequestResponseSession(RequestResponseAmqpLink requestResponseAmqpLink)
        {
            requestResponseAmqpLink.Session.SafeClose();
        }
    }
}