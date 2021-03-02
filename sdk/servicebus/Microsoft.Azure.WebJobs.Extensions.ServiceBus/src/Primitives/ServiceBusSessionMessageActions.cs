// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Represents the set of actions that can be performed on a session
    /// and a message received from a <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public class ServiceBusSessionMessageActions : ServiceBusMessageActions
    {
        private readonly ProcessSessionMessageEventArgs _eventArgs;
        private readonly ServiceBusSessionReceiver _receiver;

        internal ServiceBusSessionMessageActions(ProcessSessionMessageEventArgs eventArgs) : base(eventArgs)
        {
            _eventArgs = eventArgs;
        }

        internal ServiceBusSessionMessageActions(ServiceBusSessionReceiver receiver) : base(receiver)
        {
            _receiver = receiver;
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
