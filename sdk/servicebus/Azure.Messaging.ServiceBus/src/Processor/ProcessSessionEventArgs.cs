// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ProcessSessionEventArgs"/> contain event args related to the session being processed.
    /// </summary>
    public class ProcessSessionEventArgs : EventArgs
    {
        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> instance which will be
        /// cancelled when <see cref="ServiceBusSessionProcessor.StopProcessingAsync"/>
        /// is called, or when the session lock has been lost.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The <see cref="ServiceBusSessionReceiver"/> that will be used for setting and getting session state.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        /// <summary>
        /// The Session Id associated with the session being processed.
        /// </summary>
        public string SessionId => _sessionReceiver.SessionId;

        /// <summary>
        /// Gets the <see cref="DateTimeOffset"/> that the current session is locked until.
        /// </summary>
        public DateTimeOffset SessionLockedUntil => _sessionReceiver.SessionLockedUntil;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        public ProcessSessionEventArgs(
            ServiceBusSessionReceiver receiver,
            CancellationToken cancellationToken)
        {
            _sessionReceiver = receiver;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as byte array.</returns>
        public virtual async Task<byte[]> GetSessionStateAsync(
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.GetSessionStateAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetSessionStateAsync"/>
        /// </summary>
        ///
        /// <param name="sessionState">A byte array of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async Task SetSessionStateAsync(
            byte[] sessionState,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.SetSessionStateAsync(sessionState, cancellationToken).ConfigureAwait(false);
    }
}
