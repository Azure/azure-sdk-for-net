// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ProcessMessageEventArgs : EventArgs
    {

        /// <summary>
        ///
        /// </summary>
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
        ///
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusReceiver Receiver { get; }

        /// <summary>
        ///
        /// </summary>
        public CancellationToken CancellationToken { get; }
    }
}
