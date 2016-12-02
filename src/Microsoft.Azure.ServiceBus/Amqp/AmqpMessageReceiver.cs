// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;

    sealed class AmqpMessageReceiver : MessageReceiver
    {
        public static readonly TimeSpan DefaultBatchFlushInterval = TimeSpan.FromMilliseconds(20);

        public AmqpMessageReceiver(QueueClient queueClient) 
            : base(queueClient.Mode)
        {
            this.QueueClient = queueClient;
            this.Path = queueClient.QueueName;
            this.ReceiveLinkManager = new FaultTolerantAmqpObject<ReceivingAmqpLink>(this.CreateLinkAsync, this.CloseSession);
            this.PrefetchCount = queueClient.PrefetchCount;
        }

        /// <summary>
        /// Get Prefetch Count configured on the Receiver.
        /// </summary>
        /// <value>The upper limit of events this receiver will actively receive regardless of whether a receive operation is pending.</value>
        public int PrefetchCount { get; set; }

        QueueClient QueueClient { get; }

        string Path { get; }

        FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLinkManager { get; }

        public override Task CloseAsync()
        {
            return this.ReceiveLinkManager.CloseAsync();
        }

        protected override async Task<IList<BrokeredMessage>> OnReceiveAsync(int maxMessageCount)
        {
            try
            {
                var timeoutHelper = new TimeoutHelper(this.QueueClient.ConnectionSettings.OperationTimeout, true);
                ReceivingAmqpLink receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                IEnumerable<AmqpMessage> amqpMessages = null;
                bool hasMessages = await Task.Factory.FromAsync(
                    (c, s) => receiveLink.BeginReceiveRemoteMessages(maxMessageCount, AmqpMessageReceiver.DefaultBatchFlushInterval, timeoutHelper.RemainingTime(), c, s),
                    a => receiveLink.EndReceiveMessages(a, out amqpMessages),
                    this).ConfigureAwait(false);

                if (receiveLink.TerminalException != null)
                {
                    throw receiveLink.TerminalException;
                }

                if (hasMessages && amqpMessages != null)
                {
                    IList<BrokeredMessage> brokeredMessages = null;
                    foreach (var amqpMessage in amqpMessages)
                    {
                        if (brokeredMessages == null)
                        {
                            brokeredMessages = new List<BrokeredMessage>();
                        }

                        if (this.QueueClient.Mode == ReceiveMode.ReceiveAndDelete)
                        {
                            receiveLink.DisposeDelivery(amqpMessage, true, AmqpConstants.AcceptedOutcome);
                        }

                        BrokeredMessage brokeredMessage = AmqpMessageConverter.ClientGetMessage(amqpMessage);
                        brokeredMessage.Receiver = this; // Associate the Message with this Receiver.
                        brokeredMessages.Add(brokeredMessage);
                    }

                    return brokeredMessages;
                }

                return null;
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnCompleteAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.DisposeMessagesAsync(lockTokens, AmqpConstants.AcceptedOutcome).ConfigureAwait(false);
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnAbandonAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.DisposeMessagesAsync(lockTokens, new Modified()).ConfigureAwait(false);
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnDeferAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.DisposeMessagesAsync(lockTokens, new Modified() { UndeliverableHere = true }).ConfigureAwait(false);
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnDeadLetterAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.DisposeMessagesAsync(lockTokens, AmqpConstants.RejectedOutcome).ConfigureAwait(false);
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        async Task DisposeMessagesAsync(IEnumerable<Guid> lockTokens, Outcome outcome)
        {
            var timeoutHelper = new TimeoutHelper(this.QueueClient.ConnectionSettings.OperationTimeout, true);
            IList<ArraySegment<byte>> deliveryTags = this.ConvertLockTokensToDeliveryTags(lockTokens);

            ReceivingAmqpLink receiveLink = await this.ReceiveLinkManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            Task<Outcome>[] disposeMessageTasks = new Task<Outcome>[deliveryTags.Count];
            int i = 0;
            foreach (ArraySegment<byte> deliveryTag in deliveryTags)
            {
                disposeMessageTasks[i++] = Task.Factory.FromAsync(
                        (c, s) => receiveLink.BeginDisposeMessage(deliveryTag, outcome, true, timeoutHelper.RemainingTime(), c, s),
                        a => receiveLink.EndDisposeMessage(a),
                        this);
            }

            await Task.WhenAll(disposeMessageTasks).ConfigureAwait(false);
        }

        IList<ArraySegment<byte>> ConvertLockTokensToDeliveryTags(IEnumerable<Guid> lockTokens)
        {
            return lockTokens.Select(lockToken => new ArraySegment<byte>(lockToken.ToByteArray())).ToList();
        }

        async Task<ReceivingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            var amqpQueueClient = (AmqpQueueClient)this.QueueClient;
            var connectionSettings = amqpQueueClient.ConnectionSettings;
            var timeoutHelper = new TimeoutHelper(connectionSettings.OperationTimeout);
            AmqpConnection connection = await amqpQueueClient.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            // Authenticate over CBS
            var cbsLink = connection.Extensions.Find<AmqpCbsLink>();

            ICbsTokenProvider cbsTokenProvider = amqpQueueClient.CbsTokenProvider;
            Uri address = new Uri(connectionSettings.Endpoint, this.Path);
            string audience = address.AbsoluteUri;
            string resource = address.AbsoluteUri;
            var expiresAt = await cbsLink.SendTokenAsync(cbsTokenProvider, address, audience, resource, new[] { ClaimConstants.Listen }, timeoutHelper.RemainingTime()).ConfigureAwait(false);

            AmqpSession session = null;
            bool succeeded = false;
            try
            {
                // Create our Session
                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                // Create our Link
                var linkSettings = new AmqpLinkSettings();
                linkSettings.Role = true;
                linkSettings.TotalLinkCredit = (uint)this.PrefetchCount;
                linkSettings.AutoSendFlow = this.PrefetchCount > 0;
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)MessagingEntityType.Queue);
                linkSettings.Source = new Source { Address = address.AbsolutePath };
                linkSettings.Target = new Target { Address = this.ClientId };
                linkSettings.SettleType = (this.QueueClient.Mode == ReceiveMode.PeekLock) ? SettleMode.SettleOnDispose : SettleMode.SettleOnSend;

                var link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{amqpQueueClient.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";
                link.AttachTo(session);

                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                succeeded = true;
                return link;
            }
            finally
            {
                if (!succeeded)
                {
                    // Cleanup any session (and thus link) in case of exception.
                    session?.Abort();
                }
            }
        }

        void CloseSession(ReceivingAmqpLink link)
        {
            link.Session.SafeClose();
        }
    }
}
