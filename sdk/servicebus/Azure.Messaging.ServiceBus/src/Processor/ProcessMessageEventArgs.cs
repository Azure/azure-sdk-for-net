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
    /// The <see cref="ProcessMessageEventArgs"/> contain event args that are specific
    /// to the <see cref="ServiceBusReceivedMessage"/> that is being processed.
    /// </summary>
#pragma warning disable CA1001 // Does not need to be disposable as cancellationTokenSource will always be disposed
    public class ProcessMessageEventArgs : EventArgs
#pragma warning restore CA1001
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

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages { get; } = new();

        private readonly ConcurrentDictionary<Task, byte> _renewalTasks = new();
        private readonly ServiceBusReceiver _receiver;
        private readonly ReceiverManager _manager;
        private readonly CancellationTokenSource _lockRenewalCancellationSource;
        private bool _callbackCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message">The message to be processed.</param>
        /// <param name="receiver">The receiver instance that can be used to perform message settlement.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </param>
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
            Messages[message] = default;
            _manager = manager;
            _receiver = _manager?.Receiver;
            CancellationToken = cancellationToken;

            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            if (_manager?.ShouldAutoRenewMessageLock() == true)
            {
                _lockRenewalCancellationSource = new CancellationTokenSource();
                _renewalTasks[_manager.RenewMessageLockAsync(message, _lockRenewalCancellationSource)] = default;
            }
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
        /// Receives a list of <see cref="ServiceBusReceivedMessage"/> from the entity using <see cref="ServiceBusReceiveMode"/> mode
        /// configured in <see cref="ServiceBusProcessorOptions.ReceiveMode"/>, which defaults to PeekLock mode.
        /// This method doesn't guarantee to return exact `maxMessages` messages, even if there are `maxMessages` messages available in the queue or topic.
        /// Messages received using this method are subject to the behavior defined in the <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/>
        /// and <see cref="ServiceBusProcessorOptions.MaxAutoLockRenewalDuration"/> properties.
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
            IReadOnlyList<ServiceBusReceivedMessage> messages = await _receiver.ReceiveMessagesAsync(maxMessages, maxWaitTime, cancellationToken).ConfigureAwait(false);
            return TrackMessagesAsReceived(messages);
        }

        /// <summary>
        /// Receives a list of deferred <see cref="ServiceBusReceivedMessage"/> identified by <paramref name="sequenceNumbers"/>.
        /// Messages received using this method are subject to the behavior defined in the <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/>
        /// and <see cref="ServiceBusProcessorOptions.MaxAutoLockRenewalDuration"/> properties.
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
            IReadOnlyList<ServiceBusReceivedMessage> messages = await _receiver.ReceiveDeferredMessagesAsync(sequenceNumbers, cancellationToken).ConfigureAwait(false);
            return TrackMessagesAsReceived(messages);
        }

        private IReadOnlyList<ServiceBusReceivedMessage> TrackMessagesAsReceived(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            // manager would be null in scenarios where customers are using the public constructor for testing purposes.
            if (_manager?.ShouldAutoRenewMessageLock() == true)
            {
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    Messages[message] = default;
                    _renewalTasks[_manager.RenewMessageLockAsync(message, _lockRenewalCancellationSource)] = default;
                }
            }
            else
            {
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    Messages[message] = default;
                }
            }

            return messages;
        }

        internal void EndExecutionScope()
        {
            _callbackCompleted = true;
        }

        internal async Task CancelLockRenewalAsync()
        {
            try
            {
                if (_lockRenewalCancellationSource != null)
                {
                    _lockRenewalCancellationSource.Cancel();
                    _lockRenewalCancellationSource.Dispose();
                    await Task.WhenAll(_renewalTasks.Keys).ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
                // Nothing to do here.  These exceptions are expected.
            }
        }

        private void ValidateCallbackInScope()
        {
            if (Volatile.Read(ref _callbackCompleted))
            {
                throw new InvalidOperationException(
                    "Messages cannot be received using the 'ProcessMessageEventArgs' after the 'ProcessMessageAsync' event handler has returned.");
            }
        }
    }
}