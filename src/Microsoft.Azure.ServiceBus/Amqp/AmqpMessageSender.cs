// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
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
        }

        string Path { get; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        public override Task CloseAsync()
        {
            return this.SendLinkManager.CloseAsync();
        }

        protected override async Task OnSendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.OperationTimeout, true);
            using (AmqpMessage amqpMessage = AmqpMessageConverter.BrokeredMessagesToAmqpMessage(brokeredMessages, true))
            {
                SendingAmqpLink amqpLink = await this.SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
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
                    throw Fx.Exception.AsError(AmqpExceptionHelper.ToMessagingContract(rejected.Error));
                }
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

        void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
            link.Session.SafeClose();
        }
    }
}