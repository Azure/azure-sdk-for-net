// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// Interface used to describe a MessageSession.
    /// </summary>
    public interface IMessageSession : IMessageReceiver
    {
        /// <summary>
        /// Gets the SessionId.
        /// </summary>
        string SessionId { get; }

        /// <summary>
        /// Gets the time that the session is locked until as UTC.
        /// </summary>
        DateTime LockedUntilUtc { get; }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        /// <returns>The asynchronous operation</returns>
        Task<Stream> GetStateAsync();

        /// <summary>
        /// Sets the session state.
        /// </summary>
        /// <param name="sessionState">A <see cref="Stream"/> of session state</param>
        /// <returns>The asynchronous operation</returns>
        Task SetStateAsync(Stream sessionState);

        /// <summary>
        /// Renews the session lock.
        /// </summary>
        /// <returns>The asynchronous operation</returns>
        Task RenewSessionLockAsync();
    }
}