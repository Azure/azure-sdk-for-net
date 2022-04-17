// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
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

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages { get; } = new();

        /// <summary>
        /// The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods for the args.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        private readonly SessionReceiverManager _manager;

        private bool _callbackCompleted;

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
            CancellationToken cancellationToken) : this(message, manager: null, cancellationToken)
        {
            _sessionReceiver = receiver;
        }

        internal ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            SessionReceiverManager manager,
            CancellationToken cancellationToken)
        {
            Message = message;
            Messages[message] = default;
            _manager = manager;
            _sessionReceiver = (ServiceBusSessionReceiver) _manager?.Receiver;
            CancellationToken = cancellationToken;
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
            // manager will be null if instance created using the public constructor which is exposed for testing purposes
            _manager?.CancelSession();

        ///<inheritdoc cref="ServiceBusSessionReceiver.RenewSessionLockAsync(CancellationToken)"/>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage"/> from the entity using <see cref="ServiceBusReceiveMode"/> mode
        /// configured in <see cref="ServiceBusSessionProcessorOptions.ReceiveMode"/>, which defaults to PeekLock mode.
        /// This method doesn't guarantee to return exact `maxMessages` messages, even if there are `maxMessages` messages available in the queue or topic.
        /// Messages received using this method are subject to the behavior defined in <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/>.
        /// </summary>
        ///
        /// <param name="maxMessages">The maximum number of messages that will be received.</param>
        /// <param name="maxWaitTime">An optional <see cref="TimeSpan"/> specifying the maximum time to wait for the first message before returning an empty list if no messages are available.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>List of messages received. Returns an empty list if no message is found.</returns>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int maxMessages,
            TimeSpan? maxWaitTime = default,
            CancellationToken cancellationToken = default)
        {
            ValidateCallbackInScope();
            IReadOnlyList<ServiceBusReceivedMessage> messages = await _sessionReceiver.ReceiveMessagesAsync(maxMessages, maxWaitTime, cancellationToken).ConfigureAwait(false);
            return TrackMessagesAsReceived(messages);
        }

        /// <summary>
        /// Receives a <see cref="IList{ServiceBusReceivedMessage}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// Messages received using this method are subject to the behavior defined in <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/>.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        ///
        /// <returns>Messages identified by sequence number are returned.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        /// <exception cref="ServiceBusException">
        ///   The specified sequence number does not correspond to a message that has been deferred.
        ///   The <see cref="ServiceBusException.Reason" /> will be set to <see cref="ServiceBusFailureReason.MessageNotFound"/> in this case.
        /// </exception>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            ValidateCallbackInScope();
            IReadOnlyList<ServiceBusReceivedMessage> messages = await _sessionReceiver.ReceiveDeferredMessagesAsync(sequenceNumbers, cancellationToken).ConfigureAwait(false);
            return TrackMessagesAsReceived(messages);
        }

        private IReadOnlyList<ServiceBusReceivedMessage> TrackMessagesAsReceived(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            foreach (ServiceBusReceivedMessage message in messages)
            {
                Messages[message] = default;
            }

            return messages;
        }

        internal void EndExecutionScope()
        {
            _callbackCompleted = true;
        }

        private void ValidateCallbackInScope()
        {
            if (_callbackCompleted)
            {
                throw new InvalidOperationException(
                    "Messages cannot be received using the 'ProcessSessionMessageEventArgs' after the 'ProcessSessionMessageAsync' event handler has returned.");
            }
        }
    }
}
