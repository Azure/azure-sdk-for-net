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
        /// An event that is raised when the message lock is lost. This event is only raised for the scope of the Process Message handler,
        /// and only for the message that is delivered to the handler - it is not raised for any additional messages received via the ProcessorReceiveActions.
        /// Once the handler returns, the event will not be raised. There are two cases in which this event can be raised:
        /// <list type="numbered">
        ///     <item>
        ///         <description>When the message lock has expired based on the <see cref="ServiceBusReceivedMessage.LockedUntil"/> property</description>
        ///     </item>
        ///     <item>
        ///         <description>When a non-transient exception occurs while attempting to renew the message lock.</description>
        ///     </item>
        /// </list>
        /// </summary>
        public event Func<MessageLockLostEventArgs, Task> MessageLockLostAsync;

        internal CancellationTokenSource MessageLockLostCancellationSource { get; }

        /// <summary>
        /// The <see cref="System.Threading.CancellationToken"/> instance is cancelled when the lock renewal failed to
        /// renew the lock or the <see cref="ServiceBusProcessorOptions.MaxAutoLockRenewalDuration"/> has elapsed.
        /// </summary>
        /// <remarks>The cancellation token is triggered by comparing <see cref="ServiceBusReceivedMessage.LockedUntil"/>
        /// against <see cref="DateTimeOffset.UtcNow"/> and might be subjected to clock drift.</remarks>
        internal CancellationToken MessageLockCancellationToken { get; }

        internal Exception LockLostException { get; set; }

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
        internal ProcessMessageEventArgs(
            ServiceBusReceivedMessage message,
            ReceiverManager manager,
            CancellationToken cancellationToken)
        {
            Message = message;

            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            _receiver = manager?.Receiver;
            CancellationToken = cancellationToken;

            MessageLockLostCancellationSource = new CancellationTokenSource();
            MessageLockCancellationToken = MessageLockLostCancellationSource.Token;

            MessageLockLostCancellationSource.CancelAfterLockExpired(Message);

            bool autoRenew = manager?.ShouldAutoRenewMessageLock() == true;
            _receiveActions = new ProcessorReceiveActions(this, manager, autoRenew);
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

        /// <summary>
        /// Invokes the message lock lost event handler after a message lock is lost.
        /// This method can be overridden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the lock lost event.</param>
        protected internal virtual Task OnMessageLockLostAsync(MessageLockLostEventArgs args) => MessageLockLostAsync?.Invoke(args) ?? Task.CompletedTask;

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

            // Currently only the trigger message supports cancellation token for LockedUntil.
            if (message == Message)
            {
                MessageLockLostCancellationSource.CancelAfterLockExpired(Message);
            }
        }

        /// <summary>
        /// Gets a <see cref="ProcessorReceiveActions"/> instance which enables receiving additional messages within the scope of the current event.
        /// </summary>
        public virtual ProcessorReceiveActions GetReceiveActions() => _receiveActions;

        internal void EndExecutionScope() => _receiveActions.EndExecutionScope();

        internal async Task CancelMessageLockRenewalAsync()
        {
            try
            {
                await _receiveActions.CancelMessageLockRenewalAsync().ConfigureAwait(false);
            }
            finally
            {
                MessageLockLostCancellationSource.Dispose();
            }
        }

        internal CancellationTokenRegistration RegisterMessageLockLostHandler() =>
            MessageLockCancellationToken.Register(
                () => OnMessageLockLostAsync(new MessageLockLostEventArgs(
                    Message,
                    LockLostException)));
    }
}
