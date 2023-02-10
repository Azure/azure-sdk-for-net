// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Represents the set of receive actions that can be taken from within a function invocation.
    /// </summary>
    public class ServiceBusReceiveActions
    {
        private readonly ProcessSessionMessageEventArgs _sessionEventArgs;
        private readonly ProcessMessageEventArgs _eventArgs;
        private readonly ServiceBusReceiver _receiver;
        private bool _callbackCompleted;

        // only populated for batch functions
        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> Messages = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusReceiveActions"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected ServiceBusReceiveActions()
        {
        }

        internal ServiceBusReceiveActions(ProcessSessionMessageEventArgs sessionEventArgs)
        {
            _sessionEventArgs = sessionEventArgs;
        }

        internal ServiceBusReceiveActions(ProcessMessageEventArgs eventArgs)
        {
            _eventArgs = eventArgs;
        }

        internal ServiceBusReceiveActions(ServiceBusReceiver receiver)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Receives a list of <see cref="ServiceBusReceivedMessage"/> from the entity.
        /// This method doesn't guarantee to return exact `maxMessages` messages, even if there are `maxMessages` messages available in the queue or topic.
        /// Messages received using this method are subject to the behavior defined in the <see cref="ServiceBusOptions.AutoCompleteMessages"/>.
        /// When this method is used in a single-dispatch functions, messages received are subject to <see cref="ServiceBusOptions.MaxAutoLockRenewalDuration"/>.
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

            if (_receiver != null)
            {
                // We only need to track these messages as received when using the receiver as opposed to the processor. The processor handles
                // this within the Service Bus SDK.
                return TrackMessagesAsReceived(await _receiver.ReceiveMessagesAsync(maxMessages, maxWaitTime, cancellationToken).ConfigureAwait(false));
            }

            if (_eventArgs != null)
            {
                return await _eventArgs.GetReceiveActions().ReceiveMessagesAsync(maxMessages, maxWaitTime, cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _sessionEventArgs.GetReceiveActions().ReceiveMessagesAsync(maxMessages, maxWaitTime, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a list of deferred <see cref="ServiceBusReceivedMessage"/> identified by <paramref name="sequenceNumbers"/>.
        /// Messages received using this method are subject to the behavior defined in the <see cref="ServiceBusOptions.AutoCompleteMessages"/>.
        /// When this method is used in a single-dispatch functions, messages received are subject to <see cref="ServiceBusOptions.MaxAutoLockRenewalDuration"/>.
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

            if (_receiver != null)
            {
                // We only need to track these messages as received when using the receiver as opposed to the processor. The processor handles
                // this within the Service Bus SDK.
                return TrackMessagesAsReceived(await _receiver.ReceiveDeferredMessagesAsync(sequenceNumbers, cancellationToken).ConfigureAwait(false));
            }

            if (_eventArgs != null)
            {
                return await _eventArgs.GetReceiveActions().ReceiveDeferredMessagesAsync(sequenceNumbers, cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _sessionEventArgs.GetReceiveActions().ReceiveDeferredMessagesAsync(sequenceNumbers, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ServiceBusReceiver.PeekMessagesAsync"/>
        public virtual async Task<IReadOnlyList<ServiceBusReceivedMessage>> PeekMessagesAsync(
            int maxMessages,
            long? fromSequenceNumber = default,
            CancellationToken cancellationToken = default)
        {
            ValidateCallbackInScope();

            if (_receiver != null)
            {
                // Peeked messages are not locked so we don't need to track them for lock renewal or autocompletion, as these options do not apply.
                return await _receiver.PeekMessagesAsync(
                       maxMessages: maxMessages,
                       fromSequenceNumber: fromSequenceNumber,
                       cancellationToken: cancellationToken)
                   .ConfigureAwait(false);
            }

            if (_eventArgs != null)
            {
                return await _eventArgs.GetReceiveActions().PeekMessagesAsync(
                        maxMessages: maxMessages,
                        fromSequenceNumber: fromSequenceNumber,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _sessionEventArgs.GetReceiveActions().PeekMessagesAsync(
                    maxMessages: maxMessages,
                    fromSequenceNumber: fromSequenceNumber,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        private void ValidateCallbackInScope()
        {
            if (Volatile.Read(ref _callbackCompleted))
            {
                throw new InvalidOperationException(
                    "Messages cannot be received using the 'ServiceBusReceiveActions' after the function invocation has completed.");
            }
        }

        internal void EndExecutionScope()
        {
            _callbackCompleted = true;
        }

        private IReadOnlyList<ServiceBusReceivedMessage> TrackMessagesAsReceived(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            foreach (ServiceBusReceivedMessage message in messages)
            {
                Messages[message] = default;
            }

            return messages;
        }
    }
}