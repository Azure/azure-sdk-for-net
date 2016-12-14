// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    public class AmqpSubscriptionClient : SubscriptionClient
    {
        public AmqpSubscriptionClient(ServiceBusConnection servicebusConnection, string topicPath, string subscriptionName, ReceiveMode mode)
            : base(servicebusConnection, topicPath, subscriptionName, mode)
        {
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(this.ServiceBusConnection.SasKeyName, this.ServiceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, this.ServiceBusConnection.OperationTimeout);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        protected override MessageReceiver OnCreateMessageReceiver()
        {
            return new AmqpMessageReceiver(this.SubscriptionPath, MessagingEntityType.Subscriber, this.Mode, this.ServiceBusConnection.PrefetchCount, this.ServiceBusConnection, this.CbsTokenProvider);
        }

        protected override async Task<MessageSession> OnAcceptMessageSessionAsync(string sessionId)
        {
            AmqpMessageReceiver receiver = new AmqpMessageReceiver(this.SubscriptionPath, MessagingEntityType.Subscriber, this.Mode, this.ServiceBusConnection.PrefetchCount, this.ServiceBusConnection, this.CbsTokenProvider, sessionId, true);
            try
            {
                await receiver.GetSessionReceiverLinkAsync().ConfigureAwait(false);
            }
            catch (AmqpException exception)
            {
                // ToDo: Abort the Receiver here
                AmqpExceptionHelper.ToMessagingContract(exception.Error, false);
            }
            MessageSession session = new AmqpMessageSession(receiver.SessionId, receiver.LockedUntilUtc, receiver);
            return session;
        }

        protected override Task OnCloseAsync()
        {
            // Closing the Connection will also close all Links associated with it.
            return this.ServiceBusConnection.CloseAsync();
        }
    }
}