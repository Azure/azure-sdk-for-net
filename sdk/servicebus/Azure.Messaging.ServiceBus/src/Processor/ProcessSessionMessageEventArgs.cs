// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ProcessSessionMessageEventArgs"/> contain event args that
    /// are specific to the <see cref="ServiceBusReceivedMessage"/> and session that
    /// is being processed.
    /// </summary>
    public class ProcessSessionMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="ServiceBusReceivedMessage"/> to be processed.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// Gets the <see cref="System.Threading.CancellationToken"/> instance which
        /// will be cancelled when <see cref="ServiceBusSessionProcessor.StopProcessingAsync"/>
        /// is called, or when the session lock has been lost, or if <see cref="ReleaseSession"/> is called.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods for the args.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        private readonly SessionReceiverManager _receiverManager;

        /// <summary>
        /// Gets the Session Id associated with the <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        public string SessionId => _sessionReceiver.SessionId;

        /// <summary>
        /// Gets the DateTime that the session corresponding to
        /// the <see cref="ServiceBusReceivedMessage"/> is locked until.
        /// </summary>
        public DateTimeOffset SessionLockedUntil => _sessionReceiver.SessionLockedUntil;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The current <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.</param>
        public ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            ServiceBusSessionReceiver receiver,
            CancellationToken cancellationToken)
        {
            Message = message;
            _sessionReceiver = receiver;
            CancellationToken = cancellationToken;
        }

        internal ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            ServiceBusSessionReceiver receiver,
            SessionReceiverManager receiverManager,
            CancellationToken cancellationToken) : this(message, receiver, cancellationToken)
        {
            _receiverManager = receiverManager;
        }

        /// <inheritdoc cref="ServiceBusSessionReceiver.GetSessionStateAsync(CancellationToken)"/>
        public virtual async Task<BinaryData> GetSessionStateAsync(
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.GetSessionStateAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="ServiceBusSessionReceiver.SetSessionStateAsync(BinaryData, CancellationToken)"/>
        public virtual async Task SetSessionStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.SetSessionStateAsync(sessionState, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="ServiceBusReceiver.AbandonMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.AbandonMessageAsync(message, propertiesToModify, cancellationToken)
                .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <inheritdoc cref="ServiceBusReceiver.CompleteMessageAsync(ServiceBusReceivedMessage, CancellationToken)"/>
        public virtual async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.CompleteMessageAsync(
                message,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, string, string, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.DeadLetterMessageAsync(
                message,
                deadLetterReason,
                deadLetterErrorDescription,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.DeadLetterMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <inheritdoc cref="ServiceBusReceiver.DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.DeferMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        /// Releases the session that is being processed. No new receives will be initiated for the session before the
        /// session is closed. Any already received messages will still be delivered to the user message handler, and in-flight message handlers
        /// will be allowed to complete. Messages will still be completed automatically if <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/>
        /// is <c>true</c>.
        /// The session may end up being reopened for processing immediately after closing if there are messages remaining in the session (
        /// This depends on what other session messages may be in the queue or subscription).
        /// </summary>
        public virtual void ReleaseSession() =>
            _receiverManager.CancelSession();
    }
}
