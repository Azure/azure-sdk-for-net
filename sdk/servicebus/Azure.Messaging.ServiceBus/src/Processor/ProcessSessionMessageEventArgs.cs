// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Security;
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

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages => _receiveActions.Messages;

        /// <summary>
        /// The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods for the args.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        private readonly SessionReceiverManager _manager;
        private readonly ProcessorReceiveActions _receiveActions;

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
        /// The path of the Service Bus entity that the message was received from.
        /// </summary>
        public string EntityPath => _sessionReceiver.EntityPath;

        /// <summary>
        /// The identifier of the <see cref="ServiceBusSessionProcessor"/>.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// The fully qualified Service Bus namespace that the message was received from.
        /// </summary>
        public string FullyQualifiedNamespace => _sessionReceiver.FullyQualifiedNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The current <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            ServiceBusSessionReceiver receiver,
            CancellationToken cancellationToken) : this(message, manager: null, cancellationToken)
        {
            _sessionReceiver = receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessSessionMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The current <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="receiver">The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods
        /// for the args.</param>
        /// <param name="identifier">The identifier of the processor.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.</param>
        public ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            ServiceBusSessionReceiver receiver,
            string identifier,
            CancellationToken cancellationToken) : this(message, receiver, cancellationToken)
        {
            Identifier = identifier;
        }

        internal ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            SessionReceiverManager manager,
            CancellationToken cancellationToken)
        {
            Message = message;
            _manager = manager;

            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            _sessionReceiver = (ServiceBusSessionReceiver) _manager?.Receiver;
            _receiveActions = new ProcessorReceiveActions(message, manager, false);
            CancellationToken = cancellationToken;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            SessionReceiverManager manager,
            string identifier,
            CancellationToken cancellationToken) : this(message, manager, cancellationToken)
        {
            Identifier = identifier;
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

        /// <inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, string, string, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            Dictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.DeadLetterMessageAsync(
                message,
                propertiesToModify,
                deadLetterReason,
                deadLetterErrorDescription,
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
            // manager will be null if instance created using the public constructor which is exposed for testing purposes
            // This will be awaited when closing the receiver.
            _ = _manager?.CancelAsync();

        ///<inheritdoc cref="ServiceBusSessionReceiver.RenewSessionLockAsync(CancellationToken)"/>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a <see cref="ProcessorReceiveActions"/> instance which enables receiving additional messages within the scope of the current event.
        /// </summary>
        public virtual ProcessorReceiveActions GetReceiveActions() => _receiveActions;

        internal void EndExecutionScope() => _receiveActions.EndExecutionScope();
    }
}
