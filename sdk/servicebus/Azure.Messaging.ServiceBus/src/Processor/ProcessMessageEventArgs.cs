// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ProcessMessageEventArgs"/> contain event args that are specific
    /// to the <see cref="ServiceBusReceivedMessage"/> that is being processed.
    /// </summary>
    public class ProcessMessageEventArgs : EventArgs
    {
        /// <summary>
        /// The received message to be processed.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// The processor's <see cref="System.Threading.CancellationToken"/> instance which will be
        /// cancelled when <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The path of the Service Bus entity that the message was received from.
        /// </summary>
        public string EntityPath => _receiver.EntityPath;

        /// <summary>
        /// The identifier of the processor that raised this event.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// The fully qualified Service Bus namespace that the message was received from.
        /// </summary>
        public string FullyQualifiedNamespace => _receiver.FullyQualifiedNamespace;

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages => _receiveActions.Messages;

        private readonly ServiceBusReceiver _receiver;
        private readonly ProcessorReceiveActions _receiveActions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The message to be processed.</param>
        /// <param name="receiver">The receiver instance that can be used to perform message settlement.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProcessMessageEventArgs(ServiceBusReceivedMessage message, ServiceBusReceiver receiver, CancellationToken cancellationToken) :
            this(message, manager: null, cancellationToken)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The message to be processed.</param>
        /// <param name="receiver">The receiver instance that can be used to perform message settlement.</param>
        /// <param name="identifier">The identifier of the processor.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        public ProcessMessageEventArgs(ServiceBusReceivedMessage message, ServiceBusReceiver receiver, string identifier, CancellationToken cancellationToken) :
            this(message, manager: null, identifier, cancellationToken)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The message to be processed.</param>
        /// <param name="manager">The receiver manager for these event args.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ProcessMessageEventArgs(
            ServiceBusReceivedMessage message,
            ReceiverManager manager,
            CancellationToken cancellationToken)
        {
            Message = message;

            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            _receiver = manager?.Receiver;
            CancellationToken = cancellationToken;

            bool autoRenew = manager?.ShouldAutoRenewMessageLock() == true;
            _receiveActions = new ProcessorReceiveActions(message, manager, autoRenew);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The message to be processed.</param>
        /// <param name="manager">The receiver manager for these event args.</param>
        /// <param name="identifier">The identifier of the processor.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
        internal ProcessMessageEventArgs(
            ServiceBusReceivedMessage message,
            ReceiverManager manager,
            string identifier,
            CancellationToken cancellationToken) : this(message, manager, cancellationToken)
        {
            Identifier = identifier;
        }

        ///<inheritdoc cref="ServiceBusReceiver.AbandonMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.AbandonMessageAsync(message, propertiesToModify, cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.CompleteMessageAsync(ServiceBusReceivedMessage, CancellationToken)"/>
        public virtual async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await _receiver.CompleteMessageAsync(
                message,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, string, string, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeadLetterMessageAsync(
                message,
                deadLetterReason,
                deadLetterErrorDescription,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeadLetterMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, string, string, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeadLetterMessageAsync(
                message,
                propertiesToModify,
                deadLetterReason: deadLetterReason,
                deadLetterErrorDescription: deadLetterErrorDescription,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            await _receiver.DeferMessageAsync(
                message,
                propertiesToModify,
                cancellationToken)
            .ConfigureAwait(false);
            message.IsSettled = true;
        }

        ///<inheritdoc cref="ServiceBusReceiver.RenewMessageLockAsync(ServiceBusReceivedMessage, CancellationToken)"/>
        public virtual async Task RenewMessageLockAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            await _receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a <see cref="ProcessorReceiveActions"/> instance which enables receiving additional messages within the scope of the current event.
        /// </summary>
        public virtual ProcessorReceiveActions GetReceiveActions() => _receiveActions;

        internal void EndExecutionScope() => _receiveActions.EndExecutionScope();

        internal async Task CancelMessageLockRenewalAsync() => await _receiveActions.CancelMessageLockRenewalAsync().ConfigureAwait(false);
    }
}
