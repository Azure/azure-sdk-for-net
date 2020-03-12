// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Contains information about a receiver that has attempted to receive a message from the Azure Service Bus entity.
    /// </summary>
    public class ProcessMessageEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="message"></param>
        /// <param name="receiver"></param>
        /// <param name="cancellationToken"></param>
        internal ProcessMessageEventArgs(ServiceBusReceivedMessage message, ServiceBusReceiver receiver, CancellationToken cancellationToken)
        {
            Message = message;
            Receiver = receiver;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// The received message to be processed. Expected to be <c>null</c> if the receive call has timed out.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// Gets a <see cref="ServiceBusReceiver"/>
        /// </summary>
        public ServiceBusReceiver Receiver { get; }

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        public CancellationToken CancellationToken { get; }
    }
}
