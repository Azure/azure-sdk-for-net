// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Amqp;
    using Azure.Amqp;
    using Core;
    using Primitives;

    internal class MessageSession : MessageReceiver, IMessageSession
    {
        public MessageSession(
            string entityPath,
            MessagingEntityType? entityType,
            ReceiveMode receiveMode,
            ServiceBusConnection serviceBusConnection,
            ICbsTokenProvider cbsTokenProvider,
            RetryPolicy retryPolicy,
            int prefetchCount = Constants.DefaultClientPrefetchCount,
            string sessionId = null,
            bool isSessionReceiver = false)
            : base(entityPath, entityType, receiveMode, serviceBusConnection, cbsTokenProvider, retryPolicy, prefetchCount, sessionId, isSessionReceiver)
        {
        }

        /// <summary>
        /// Gets the time that the session identified by <see cref="SessionId"/> is locked until for this client.
        /// </summary>
        public DateTime LockedUntilUtc
        {
            get => this.LockedUntilUtcInternal;
            internal set => this.LockedUntilUtcInternal = value;
        }

        /// <summary>
        /// Gets the SessionId.
        /// </summary>
        public string SessionId => this.SessionIdInternal;

        public Task<byte[]> GetStateAsync()
        {
            return this.OnGetStateAsync();
        }

        public Task SetStateAsync(byte[] sessionState)
        {
            return this.OnSetStateAsync(sessionState);
        }

        public Task RenewSessionLockAsync()
        {
            return this.OnRenewSessionLockAsync();
        }

        protected override void OnMessageHandler(MessageHandlerOptions registerHandlerOptions, Func<Message, CancellationToken, Task> callback)
        {
            throw new InvalidOperationException($"{nameof(RegisterMessageHandler)} is not supported for Sessions.");
        }

        protected override Task<DateTime> OnRenewLockAsync(string lockToken)
        {
            throw new InvalidOperationException($"{nameof(RenewLockAsync)} is not supported for Session. Use {nameof(RenewSessionLockAsync)} to renew sessions instead");
        }

        protected async Task<byte[]> OnGetStateAsync()
        {
            try
            {
                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.GetSessionStateOperation, this.OperationTimeout, null);
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                AmqpResponseMessage amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                byte[] sessionState = null;
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    if (amqpResponseMessage.Map[ManagementConstants.Properties.SessionState] != null)
                    {
                        sessionState = amqpResponseMessage.GetValue<ArraySegment<byte>>(ManagementConstants.Properties.SessionState).Array;
                    }
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }

                return sessionState;
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        protected async Task OnSetStateAsync(byte[] sessionState)
        {
            try
            {
                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.SetSessionStateOperation, this.OperationTimeout, null);
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                if (sessionState != null)
                {
                    var value = new ArraySegment<byte>(sessionState);
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = value;
                }
                else
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = null;
                }

                AmqpResponseMessage amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        protected async Task OnRenewSessionLockAsync()
        {
            try
            {
                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.RenewSessionLockOperation, this.OperationTimeout, null);
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionIdInternal;

                AmqpResponseMessage amqpResponseMessage = await this.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    this.LockedUntilUtcInternal = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }
    }
}