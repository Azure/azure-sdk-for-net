// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// TODO (kasobol-msft).
    /// </summary>
    public class InvalidQueueMessageEventArgs : EventArgs
    {
        /// <summary>
        /// TODO (kasobol-msft).
        /// </summary>
        public QueueClient Sender { get; }

        /// <summary>
        /// TODO (kasobol-msft).
        /// </summary>
        public object Message { get; }

        /// <summary>
        /// TODO (kasobol-msft).
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// TODO (kasobol-msft).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        public InvalidQueueMessageEventArgs(QueueClient sender, object message, CancellationToken cancellationToken)
        {
            Sender = sender;
            Message = message;
            CancellationToken = cancellationToken;
        }
    }
}
