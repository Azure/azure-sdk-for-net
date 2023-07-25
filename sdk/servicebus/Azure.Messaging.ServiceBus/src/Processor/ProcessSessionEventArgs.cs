// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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

        private readonly SessionReceiverManager _manager;

        /// <summary>
        /// The Session Id associated with the session being processed.
        /// </summary>
        public string SessionId => _sessionReceiver.SessionId;

        /// <summary>
        /// The identifier of the <see cref="ServiceBusSessionProcessor"/>.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the <see cref="DateTimeOffset"/> that the current session is locked until.
        /// </summary>
        public DateTimeOffset SessionLockedUntil => _sessionReceiver.SessionLockedUntil;

        /// <summary>
        /// The path of the Service Bus entity that the message was received from.
        /// </summary>
        public string EntityPath => _sessionReceiver.EntityPath;

        /// <summary>
        /// The fully qualified Service Bus namespace that the message was received from.
        /// </summary>
        public string FullyQualifiedNamespace => _sessionReceiver.FullyQualifiedNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProcessSessionEventArgs(
            ServiceBusSessionReceiver receiver,
            CancellationToken cancellationToken) : this(manager: null, cancellationToken)
        {
            _sessionReceiver = receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="identifier">The identifier of the processor.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        public ProcessSessionEventArgs(
            ServiceBusSessionReceiver receiver,
            string identifier,
            CancellationToken cancellationToken) : this(receiver, cancellationToken)
        {
            Identifier = identifier;
        }

        internal ProcessSessionEventArgs(
            SessionReceiverManager manager,
            CancellationToken cancellationToken)
        {
            _manager = manager;

            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            _sessionReceiver = (ServiceBusSessionReceiver) _manager?.Receiver;
            CancellationToken = cancellationToken;
        }

        internal ProcessSessionEventArgs(
            SessionReceiverManager manager,
            string identifier,
            CancellationToken cancellationToken) : this(manager, cancellationToken)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as <see cref="BinaryData"/>.</returns>
        public virtual async Task<BinaryData> GetSessionStateAsync(
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.GetSessionStateAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetSessionStateAsync"/>
        /// </summary>
        ///
        /// <param name="sessionState">A <see cref="BinaryData"/> of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async Task SetSessionStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.SetSessionStateAsync(sessionState, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Releases the session that is being processed. No receives will be initiated for the session and the
        /// session will be closed.
        /// The session may end up being reopened for processing immediately after closing if there are messages remaining in the session (
        /// This depends on what other session messages may be in the queue or subscription).
        /// </summary>
        public virtual void ReleaseSession() =>
            // manager will be null if instance created using the public constructor which is exposed for testing purposes
            // This will be awaited when closing the receiver.
            _ = _manager?.CancelAsync();

        ///<inheritdoc cref="ServiceBusSessionReceiver.RenewSessionLockAsync(CancellationToken)"/>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
