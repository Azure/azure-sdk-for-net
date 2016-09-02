// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;

    sealed class AmqpMessageSender : MessageSender
    {
        int deliveryCount;

        internal AmqpMessageSender(AmqpQueueClient queueClient)
            : base(queueClient)
        {
            this.Path = queueClient.QueueName;
            this.SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(this.CreateLinkAsync, this.CloseSession);
        }

        string Path { get; }

        FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        public override Task CloseAsync()
        {
            return this.SendLinkManager.CloseAsync();
        }

        protected override async Task OnSendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            var timeoutHelper = new TimeoutHelper(this.QueueClient.ConnectionSettings.OperationTimeout, true);
            using (AmqpMessage amqpMessage = AmqpMessageConverter.BrokeredMessagesToAmqpMessage(brokeredMessages, true))
            {
                var amqpLink = await this.SendLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime());
                if (amqpLink.Settings.MaxMessageSize.HasValue)
                {
                    ulong size = (ulong)amqpMessage.SerializedMessageSize;
                    if (size > amqpLink.Settings.MaxMessageSize.Value)
                    {
                        // TODO: Add MessageSizeExceededException
                        throw new NotImplementedException("MessageSizeExceededException: " + Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value));
                        //throw Fx.Exception.AsError(new MessageSizeExceededException(
                        //    Resources.AmqpMessageSizeExceeded.FormatForUser(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value)));
                    }
                }

                Outcome outcome = await amqpLink.SendMessageAsync(amqpMessage, this.GetNextDeliveryTag(), AmqpConstants.NullBinary, timeoutHelper.RemainingTime());
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
            var amqpQueueClient = ((AmqpQueueClient)this.QueueClient);
            var connectionSettings = amqpQueueClient.ConnectionSettings;
            var timeoutHelper = new TimeoutHelper(connectionSettings.OperationTimeout);
            AmqpConnection connection = await amqpQueueClient.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime());

            // Authenticate over CBS
            var cbsLink = connection.Extensions.Find<AmqpCbsLink>();

            ICbsTokenProvider cbsTokenProvider = amqpQueueClient.CbsTokenProvider;
            Uri address = new Uri(connectionSettings.Endpoint, this.Path);
            string audience = address.AbsoluteUri;
            string resource = address.AbsoluteUri;
            var expiresAt = await cbsLink.SendTokenAsync(cbsTokenProvider, address, audience, resource, new[] { ClaimConstants.Send }, timeoutHelper.RemainingTime());

            AmqpSession session = null;
            try
            {
                // Create our Session
                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                //sessionSettings.Properties[AmqpClientConstants.BatchFlushIntervalName] = (uint)connectionSettings.BatchFlushInterval.TotalMilliseconds;
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime());

                // Create our Link
                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeoutHelper.RemainingTime().TotalMilliseconds);
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)MessagingEntityType.Queue);
                linkSettings.Role = false;
                linkSettings.InitialDeliveryCount = 0;
                linkSettings.Target = new Target { Address = address.AbsolutePath };
                linkSettings.Source = new Source { Address = this.ClientId };

                var link = new SendingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{amqpQueueClient.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";
                link.AttachTo(session);

                await link.OpenAsync(timeoutHelper.RemainingTime());
                return link;
            }
            catch (Exception)
            {
                // Cleanup any session (and thus link) in case of exception.
                session?.Abort();
                throw;
            }
        }

        void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
            link.Session.SafeClose();
        }
    }
}
