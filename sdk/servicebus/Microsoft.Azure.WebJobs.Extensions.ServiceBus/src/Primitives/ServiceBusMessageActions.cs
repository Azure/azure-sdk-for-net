// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Represents the set of message actions that can be performed on a <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public class ServiceBusMessageActions
    {
        private readonly ServiceBusReceiver _receiver;
        private readonly ProcessMessageEventArgs _eventArgs;
        private readonly ProcessSessionMessageEventArgs _sessionEventArgs;

        internal ConcurrentDictionary<ServiceBusReceivedMessage, byte> SettledMessages { get; } = new();

        internal ServiceBusMessageActions(ProcessSessionMessageEventArgs sessionEventArgs)
        {
            _sessionEventArgs = sessionEventArgs;
        }

        internal ServiceBusMessageActions(ProcessMessageEventArgs eventArgs)
        {
            _eventArgs = eventArgs;
        }

        internal ServiceBusMessageActions(ServiceBusReceiver receiver)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusMessageActions"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected ServiceBusMessageActions()
        {
        }

        ///<inheritdoc cref="ServiceBusReceiver.AbandonMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task AbandonMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.AbandonMessageAsync(message, propertiesToModify, cancellationToken).ConfigureAwait(false);
            }
            else if (_eventArgs != null)
            {
                await _eventArgs.AbandonMessageAsync(message, propertiesToModify, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await _sessionEventArgs.AbandonMessageAsync(message, propertiesToModify, cancellationToken).ConfigureAwait(false);
            }

            TrackMessageAsSettled(message);
        }

        ///<inheritdoc cref="ServiceBusReceiver.CompleteMessageAsync(ServiceBusReceivedMessage, CancellationToken)"/>
        public virtual async Task CompleteMessageAsync(
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.CompleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else if (_eventArgs != null)
            {
                await _eventArgs.CompleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await _sessionEventArgs.CompleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }

            TrackMessageAsSettled(message);
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, string, string, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            string deadLetterReason,
            string deadLetterErrorDescription = default,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.DeadLetterMessageAsync(
                    message,
                    deadLetterReason,
                    deadLetterErrorDescription,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else if (_eventArgs != null)
            {
                await _eventArgs.DeadLetterMessageAsync(
                    message,
                    deadLetterReason,
                    deadLetterErrorDescription,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else
            {
                await _sessionEventArgs.DeadLetterMessageAsync(
                    message,
                    deadLetterReason,
                    deadLetterErrorDescription,
                    cancellationToken)
                .ConfigureAwait(false);
            }

            TrackMessageAsSettled(message);
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeadLetterMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeadLetterMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.DeadLetterMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else if (_eventArgs != null)
            {
                await _eventArgs.DeadLetterMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else
            {
                await _sessionEventArgs.DeadLetterMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }

            TrackMessageAsSettled(message);
        }

        ///<inheritdoc cref="ServiceBusReceiver.DeferMessageAsync(ServiceBusReceivedMessage, IDictionary{string, object}, CancellationToken)"/>
        public virtual async Task DeferMessageAsync(
            ServiceBusReceivedMessage message,
            IDictionary<string, object> propertiesToModify = default,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.DeferMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else if (_eventArgs != null)
            {
                await _eventArgs.DeferMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
            else
            {
                await _sessionEventArgs.DeferMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }

            TrackMessageAsSettled(message);
        }

        private void TrackMessageAsSettled(ServiceBusReceivedMessage message)
            => SettledMessages[message] = 0;
    }
}
