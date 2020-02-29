// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceBusSession
    {
        private readonly TransportConsumer _consumer;

        internal string UserSpecifiedSessionId { get; }

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until.
        /// </summary>
        internal DateTime LockedUntilUtcInternal { get; set; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        internal ServiceBusRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///
        /// </summary>
        internal ReceiveMode ReceiveMode { get; }

        internal ServiceBusSession(
            TransportConsumer consumer,
            string sessionId,
            ReceiveMode receiveMode,
            ServiceBusRetryPolicy retryPolicy)
        {
            _consumer = consumer;
            UserSpecifiedSessionId = sessionId;
            ReceiveMode = receiveMode;
            RetryPolicy = retryPolicy;
        }

        /// <summary>
        /// TODO implement
        /// </summary>
        /// <returns></returns>
        public virtual async Task<byte[]> GetStateAsync(
            CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new byte[4]).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO implement
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task SetStateAsync(byte[] sessionState,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(_consumer.IsClosed, nameof(ServiceBusReceiverClient));

            if (ReceiveMode != ReceiveMode.PeekLock)
            {
                throw new InvalidOperationException(Resources1.OperationNotSupported);
            }

            // MessagingEventSource.Log.RenewSessionLockStart(this.SessionId);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                await RetryPolicy.RunOperation(
                    async (timeout) =>
                    {
                        LockedUntilUtcInternal = await _consumer.RenewSessionLockAsync(
                            UserSpecifiedSessionId,
                            timeout).ConfigureAwait(false);
                    },
                    _consumer.EntityName,
                    _consumer.ConnectionScope,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // MessagingEventSource.Log.RenewSessionLockException(this.SessionId, exception);
                throw exception;
            }
            finally
            {
                // this.diagnosticSource.RenewSessionLockStop(activity, this.SessionId);
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            // MessagingEventSource.Log.MessageRenewLockStop(this.SessionId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<string> GetSessionIdAsync(CancellationToken cancellationToken = default)
        {
            // if the user specified a sessionId we can just return
            // early with that as there is no chance of it changing
            if (UserSpecifiedSessionId != null)
            {
                return UserSpecifiedSessionId;
            }
            else
            {
                return await _consumer.GetSessionIdAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<DateTimeOffset> GetLockedUntilUtcAsync(CancellationToken cancellationToken = default)
        {
            return await _consumer.GetSessionLockedUntilUtcAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
