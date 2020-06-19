// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ProcessSessionMessageEventArgs"/> contain event args that are specific
    /// to the <see cref="ServiceBusReceivedMessage"/> and session that is being processed.
    /// </summary>
    public class ProcessSessionMessageEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="ServiceBusReceivedMessage"/> to be processed.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// The processor's <see cref="System.Threading.CancellationToken"/> instance which will be
        /// cancelled in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The <see cref="ServiceBusSessionReceiver"/> that will be used for all settlement methods for the args.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        /// <summary>
        /// The Session Id associated with the <see cref="ServiceBusReceivedMessage"/>.
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
        internal ProcessSessionMessageEventArgs(
            ServiceBusReceivedMessage message,
            ServiceBusSessionReceiver receiver,
            CancellationToken cancellationToken)
        {
            Message = message;
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

        /// <summary>
        /// Abandons a <see cref="ServiceBusReceivedMessage"/>. This will make the message available again for immediate processing as the lock on the message held by the processor will be released.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public async Task AbandonAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.AbandonMessageAsync(message, propertiesToModify, cancellationToken)
                .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        /// Completes a <see cref="ServiceBusReceivedMessage"/>. This will delete the message from the service.
        /// </summary>
        /// <param name="message">The message to complete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// This operation can only be performed on a message that was received by this receiver
        /// when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public async Task CompleteAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await _sessionReceiver.CompleteMessageAsync(
                message,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the deadletter queue, you can call
        /// <see cref="ServiceBusClient.CreateDeadLetterReceiver(string, ServiceBusReceiverOptions)"/>
        /// or <see cref="ServiceBusClient.CreateDeadLetterReceiver(string, string, ServiceBusReceiverOptions)"/>
        /// to create a receiver for the queue or subscription.
        /// This operation can only be performed when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public async Task DeadLetterAsync(
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

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// In order to receive a message from the deadletter queue, you can call
        /// <see cref="ServiceBusClient.CreateDeadLetterReceiver(string, ServiceBusReceiverOptions)"/>
        /// or <see cref="ServiceBusClient.CreateDeadLetterReceiver(string, string, ServiceBusReceiverOptions)"/>
        /// to create a receiver for the queue or subscription.
        /// This operation can only be performed when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// </remarks>
        public async Task DeadLetterAsync(
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

        /// <summary> Defers the processing for a message.</summary>
        ///
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to defer.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// A lock token can be found in <see cref="ServiceBusReceivedMessage.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="ServiceBusReceivedMessage.SequenceNumber"/>
        /// and receive it using <see cref="ServiceBusReceiver.ReceiveDeferredMessagesAsync(IEnumerable{long}, CancellationToken)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public async Task DeferAsync(
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
    }
}
