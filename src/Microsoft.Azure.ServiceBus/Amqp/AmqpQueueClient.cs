// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    sealed class AmqpQueueClient : QueueClient
    {
        public AmqpQueueClient(ServiceBusConnection servicebusConnection, string entityPath, ReceiveMode mode)
            : base(servicebusConnection, entityPath, mode)
        {
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(this.ServiceBusConnection.SasKeyName, this.ServiceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, this.ServiceBusConnection.OperationTimeout);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        protected override MessageSender OnCreateMessageSender()
        {
            return new AmqpMessageSender(this.QueueName, MessagingEntityType.Queue, this.ServiceBusConnection, this.CbsTokenProvider);
        }

        protected override MessageReceiver OnCreateMessageReceiver()
        {
            return new AmqpMessageReceiver(this.QueueName, MessagingEntityType.Queue, this.Mode, this.ServiceBusConnection.PrefetchCount, this.ServiceBusConnection, this.CbsTokenProvider);
        }

        protected override async Task<MessageSession> OnAcceptMessageSessionAsync(string sessionId, TimeSpan serverWaitTime)
        {
            AmqpMessageReceiver receiver = new AmqpMessageReceiver(this.QueueName, MessagingEntityType.Queue, this.Mode, this.ServiceBusConnection.PrefetchCount, this.ServiceBusConnection, this.CbsTokenProvider, sessionId, true);
            try
            {
                await receiver.GetSessionReceiverLinkAsync(serverWaitTime).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await receiver.CloseAsync().ConfigureAwait(false);
                throw AmqpExceptionHelper.GetClientException(exception);
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