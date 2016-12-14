// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Messaging.Amqp;

    public class AmqpMessageSession : MessageSession
    {
        public AmqpMessageSession(string sessionId, DateTime lockedUntilUtc, MessageReceiver innerMessageReceiver)
            : base(innerMessageReceiver.ReceiveMode, sessionId, lockedUntilUtc, innerMessageReceiver)
        {
        }

        protected override async Task<Stream> OnGetStateAsync()
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

                return sessionState;
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnSetStateAsync(Stream sessionState)
        {
            try
            {
                if (sessionState != null && sessionState.CanSeek && sessionState.Position != 0)
                {
                    throw new InvalidOperationException("CannotSerializeSessionStateWithPartiallyConsumedStream");
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

                await this.InnerMessageReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }

        protected override async Task OnRenewLockAsync()
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
            }
            catch (AmqpException amqpException)
            {
                throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
            }
        }
    }
}