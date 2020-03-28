// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ProcessSessionMessageEventArgs : EventArgs
    {
        /// <summary>
        /// The received message to be processed.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The session receiver that will be used for all settlement methods for the args.
        /// </summary>
        private readonly ServiceBusSessionReceiver _sessionReceiver;

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public string SessionId => _sessionReceiver.SessionId;

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until.
        /// </summary>
        public DateTimeOffset SessionLockedUntil => _sessionReceiver.SessionLockedUntil;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message"></param>
        /// <param name="receiver"></param>
        /// <param name="cancellationToken"></param>
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
        public virtual async Task<byte[]> GetStateAsync(
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.GetStateAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetStateAsync"/>
        /// </summary>
        ///
        /// <param name="sessionState">A byte array of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async Task SetStateAsync(
            byte[] sessionState,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.SetStateAsync(sessionState, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// <para>
        /// When you get session receiver, the session is locked for this receiver by the service for a duration as specified during the Queue/Subscription creation.
        /// If processing of the session requires longer than this duration, the session-lock needs to be renewed.
        /// For each renewal, it resets the time the session is locked by the LockDuration set on the Entity.
        /// </para>
        /// <para>
        /// Renewal of session renews all the messages in the session as well. Each individual message need not be renewed.
        /// </para>
        /// </remarks>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default) =>
            await _sessionReceiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AbandonAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.AbandonAsync(message, propertiesToModify, cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CompleteAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.CompleteAsync(
                message,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="deadLetterReason"></param>
        /// <param name="deadLetterErrorDescription"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeadLetterAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.DeadLetterAsync(
                message,
                deadLetterReason,
                deadLetterErrorDescription,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeadLetterAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.DeadLetterAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertiesToModify"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeferAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default) =>
            await _sessionReceiver.DeferAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
    }
}
