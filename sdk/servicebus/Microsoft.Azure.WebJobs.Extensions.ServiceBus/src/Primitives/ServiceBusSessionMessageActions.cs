// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Represents the set of actions that can be performed on a session
    /// and a message received from a <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public class ServiceBusSessionMessageActions
    {
        private readonly ProcessSessionMessageEventArgs _eventArgs;
        private readonly ServiceBusSessionReceiver _receiver;

        internal ServiceBusSessionMessageActions(ProcessSessionMessageEventArgs eventArgs)
        {
            _eventArgs = eventArgs;
        }

        internal ServiceBusSessionMessageActions(ServiceBusSessionReceiver receiver)
        {
            _receiver = receiver;
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
            else
            {
                await _eventArgs.AbandonMessageAsync(message, propertiesToModify, cancellationToken).ConfigureAwait(false);
            }
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
            else
            {
                await _eventArgs.CompleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
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
            else
            {
                await _eventArgs.DeadLetterMessageAsync(
                    message,
                    deadLetterReason,
                    deadLetterErrorDescription,
                    cancellationToken)
                .ConfigureAwait(false);
            }
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
            else
            {
                await _eventArgs.DeadLetterMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
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
            else
            {
                await _eventArgs.DeferMessageAsync(
                    message,
                    propertiesToModify,
                    cancellationToken)
                .ConfigureAwait(false);
            }
        }

        /// <inheritdoc cref="ServiceBusSessionReceiver.GetSessionStateAsync(CancellationToken)"/>
        public virtual async Task<BinaryData> GetSessionStateAsync(
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                return await _receiver.GetSessionStateAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _eventArgs.GetSessionStateAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc cref="ServiceBusSessionReceiver.SetSessionStateAsync(BinaryData, CancellationToken)"/>
        public virtual async Task SetSessionStateAsync(
            BinaryData sessionState,
            CancellationToken cancellationToken = default)
        {
            if (_receiver != null)
            {
                await _receiver.SetSessionStateAsync(sessionState, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await _eventArgs.SetSessionStateAsync(sessionState, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
