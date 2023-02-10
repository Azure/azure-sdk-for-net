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
    /// A set of receive-related actions that can be performed from the processor message callback.
    /// </summary>
#pragma warning disable CA1001 // Does not need to be disposable as cancellationTokenSource will always be disposed
    public class ProcessorReceiveActions
#pragma warning restore CA1001
    {
        private bool _callbackCompleted;
        private readonly ReceiverManager _manager;
        private readonly ServiceBusReceiver _receiver;
        private readonly CancellationTokenSource _lockRenewalCancellationSource;
        private readonly ConcurrentDictionary<Task, byte> _renewalTasks = new();
        private readonly bool _autoRenew;

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages { get; } = new();

        /// <summary>
        /// For mocking.
        /// </summary>
        protected ProcessorReceiveActions()
        {
        }

        internal ProcessorReceiveActions(ServiceBusReceivedMessage triggerMessage, ReceiverManager manager, bool autoRenewMessageLocks)
        {
            _manager = manager;

            // manager would be null in scenarios where customers are using the public constructor of the event args for testing purposes.
            _receiver = manager?.Receiver;
            _autoRenew = autoRenewMessageLocks;
            Messages[triggerMessage] = default;

            if (_autoRenew)
            {
                _lockRenewalCancellationSource = new CancellationTokenSource();
                _renewalTasks[_manager.RenewMessageLockAsync(triggerMessage, _lockRenewalCancellationSource)] = default;
            }
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
        /// <seealso cref="ProcessMessageEventArgs.DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
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

        /// <inheritdoc cref="ServiceBusReceiver.PeekMessagesAsync"/>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesAsync(
            int maxMessages,
            long? fromSequenceNumber = default,
            CancellationToken cancellationToken = default)
       {
            ValidateCallbackInScope();

            // Peeked messages are not locked so we don't need to track them for lock renewal or autocompletion, as these options do not apply.
            return await _receiver.PeekMessagesAsync(
                maxMessages: maxMessages,
                fromSequenceNumber: fromSequenceNumber,
                cancellationToken: cancellationToken).ConfigureAwait(false);
       }

        private IReadOnlyList<ServiceBusReceivedMessage> TrackMessagesAsReceived(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            if (_autoRenew)
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

        internal async Task CancelMessageLockRenewalAsync()
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
                if (_manager is SessionReceiverManager)
                {
                    throw new InvalidOperationException(
                        "Messages cannot be received using the 'ProcessSessionMessageEventArgs' after the 'ProcessSessionMessageAsync' event handler has returned.");
                }
                throw new InvalidOperationException(
                    "Messages cannot be received using the 'ProcessMessageEventArgs' after the 'ProcessMessageAsync' event handler has returned.");
            }
        }
    }
}
