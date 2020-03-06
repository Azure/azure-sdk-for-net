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
    public class ServiceBusSessionManager
    {
        private readonly TransportReceiver _receiver;

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public string SessionId => _receiver.SessionId;

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until.
        /// </summary>
        public DateTime LockedUntilUtc { get; private set; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        internal ServiceBusRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///
        /// </summary>
        internal ReceiveMode ReceiveMode { get; }

        internal ServiceBusSessionManager(
            TransportReceiver receiver)
        {
            _receiver = receiver;
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
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default) =>
            LockedUntilUtc = await _receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
    }
}
