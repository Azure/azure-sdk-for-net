// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
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

        internal ServiceBusSession(
            TransportConsumer consumer,
            string sessionId)
        {
            _consumer = consumer;
            UserSpecifiedSessionId = sessionId;
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
        /// TODO implement
        /// </summary>
        /// <returns></returns>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            // TODO implement
            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<string> GetSessionIdAsync
(CancellationToken cancellationToken = default)
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
