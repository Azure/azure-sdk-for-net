// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Core;

    sealed class AmqpSessionClient : IMessageSessionEntity
    {
        public AmqpSessionClient(
            string clientId,
            string entityPath,
            MessagingEntityType entityType,
            ReceiveMode receiveMode,
            int prefetchCount,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy)
        {
            this.ClientId = clientId;
            this.EntityPath = entityPath;
            this.EntityType = entityType;
            this.ReceiveMode = receiveMode;
            this.PrefetchCount = prefetchCount;
            this.ServiceBusConnection = serviceBusConnection;
            this.CbsTokenProvider = cbsTokenProvider;
            this.RetryPolicy = retryPolicy;
        }

        ReceiveMode ReceiveMode { get; }

        string ClientId { get; }

        public string EntityPath { get; }

        MessagingEntityType EntityType { get; }

        int PrefetchCount { get; }

        ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        RetryPolicy RetryPolicy { get; }

        public Task<IMessageSession> AcceptMessageSessionAsync()
        {
            return this.AcceptMessageSessionAsync(this.ServiceBusConnection.OperationTimeout);
        }

        public Task<IMessageSession> AcceptMessageSessionAsync(TimeSpan serverWaitTime)
        {
            return this.AcceptMessageSessionAsync(null, serverWaitTime);
        }

        public Task<IMessageSession> AcceptMessageSessionAsync(string sessionId)
        {
            return this.AcceptMessageSessionAsync(sessionId, this.ServiceBusConnection.OperationTimeout);
        }

        public async Task<IMessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan serverWaitTime)
        {
            MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStart(
                this.ClientId,
                this.EntityPath,
                this.ReceiveMode,
                this.PrefetchCount,
                sessionId);

            var receiver = new MessageReceiver(
                this.EntityPath,
                this.EntityType,
                this.ReceiveMode,
                this.ServiceBusConnection,
                this.CbsTokenProvider,
                this.RetryPolicy,
                this.PrefetchCount,
                sessionId,
                true);
            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await receiver.GetSessionReceiverLinkAsync(serverWaitTime).ConfigureAwait(false);
                    }, serverWaitTime)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionException(
                    this.ClientId,
                    this.EntityPath,
                    exception);

                await receiver.CloseAsync().ConfigureAwait(false);
                throw AmqpExceptionHelper.GetClientException(exception);
            }

            MessageSession session = new MessageSession(receiver.SessionId, receiver.LockedUntilUtc, receiver, this.RetryPolicy);

            MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStop(
                this.ClientId,
                this.EntityPath,
                session.SessionId);

            return session;
        }
    }
}