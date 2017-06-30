// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Core;

    internal class MessageSession : MessageReceiver, IMessageSession
    {
        public MessageSession(string sessionId, DateTime lockedUntilUtc, MessageReceiver innerMessageReceiver, RetryPolicy retryPolicy)
            : base(innerMessageReceiver.ReceiveMode, innerMessageReceiver.OperationTimeout, retryPolicy)
        {
            this.SessionId = sessionId;
            this.LockedUntilUtc = lockedUntilUtc;
            this.InnerMessageReceiver = innerMessageReceiver ?? throw Fx.Exception.ArgumentNull(nameof(innerMessageReceiver));
            this.ReceiveMode = innerMessageReceiver.ReceiveMode;
        }

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until. This is only applicable when Sessions are used.
        /// </summary>
        public new DateTime LockedUntilUtc
        {
            get => this.InnerMessageReceiver.LockedUntilUtc;
            set => this.InnerMessageReceiver.LockedUntilUtc = value;
        }

        /// <summary>
        /// Gets the SessionId of the current receiver. This is only applicable when Sessions are used.
        /// </summary>
        public new string SessionId
        {
            get => this.InnerMessageReceiver.SessionId;
            set => this.InnerMessageReceiver.SessionId = value;
        }

        public override string Path
        {
            get { return this.InnerMessageReceiver.Path; }
        }

        protected MessageReceiver InnerMessageReceiver { get; set; }

        protected override async Task OnClosingAsync()
        {
            if (this.InnerMessageReceiver != null)
            {
                await this.InnerMessageReceiver.CloseAsync().ConfigureAwait(false);
            }
        }

        public Task<Stream> GetStateAsync()
        {
            return this.OnGetStateAsync();
        }

        public Task SetStateAsync(Stream sessionState)
        {
            return this.OnSetStateAsync(sessionState);
        }

        public Task RenewSessionLockAsync()
        {
            return this.OnRenewSessionLockAsync();
        }

        protected override Task<IList<Message>> OnReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            return this.InnerMessageReceiver.ReceiveAsync(maxMessageCount, serverWaitTime);
        }

        protected override Task<IList<Message>> OnReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            return this.InnerMessageReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
        }

        protected override Task OnCompleteAsync(IEnumerable<string> lockTokens)
        {
            return this.InnerMessageReceiver.CompleteAsync(lockTokens);
        }

        protected override Task OnAbandonAsync(string lockToken)
        {
            return this.InnerMessageReceiver.AbandonAsync(lockToken);
        }

        protected override Task OnDeferAsync(string lockToken)
        {
            return this.InnerMessageReceiver.DeferAsync(lockToken);
        }

        protected override Task OnDeadLetterAsync(string lockToken)
        {
            return this.InnerMessageReceiver.DeadLetterAsync(lockToken);
        }

        protected override Task<DateTime> OnRenewLockAsync(string lockToken)
        {
            // TODO:  Should throw invalid operation exception?
            return this.InnerMessageReceiver.RenewLockAsync(lockToken);
        }

        protected override Task<IList<Message>> OnPeekAsync(long fromSequenceNumber, int messageCount = 1)
        {
            return this.InnerMessageReceiver.PeekAsync(messageCount);
        }

        protected async Task<Stream> OnGetStateAsync()
        {
            try
            {
                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.GetSessionStateOperation, this.OperationTimeout, null);
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionId;

                AmqpResponseMessage amqpResponseMessage = await this.InnerMessageReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                Stream sessionState = null;
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    if (amqpResponseMessage.Map[ManagementConstants.Properties.SessionState] != null)
                    {
                        sessionState = new BufferListStream(new[] { amqpResponseMessage.GetValue<ArraySegment<byte>>(ManagementConstants.Properties.SessionState) });
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

        protected async Task OnSetStateAsync(Stream sessionState)
        {
            try
            {
                if (sessionState != null && sessionState.CanSeek && sessionState.Position != 0)
                {
                    throw new InvalidOperationException(Resources.CannotSerializeSessionStateWithPartiallyConsumedStream);
                }

                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(ManagementConstants.Operations.SetSessionStateOperation, this.OperationTimeout, null);
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionId;

                if (sessionState != null)
                {
                    BufferListStream buffer = BufferListStream.Create(sessionState, AmqpConstants.SegmentSize);
                    ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = value;
                }
                else
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionState] = null;
                }

                AmqpResponseMessage amqpResponseMessage = await this.InnerMessageReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
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
                amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = this.SessionId;

                AmqpResponseMessage amqpResponseMessage = await this.InnerMessageReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    this.LockedUntilUtc = amqpResponseMessage.GetValue<DateTime>(ManagementConstants.Properties.Expiration);
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