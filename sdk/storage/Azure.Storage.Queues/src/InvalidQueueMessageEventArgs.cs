// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Contains information about invalid message.
    /// See also <see cref="QueueClient.InvalidQueueMessageAsync"/>.
    /// </summary>
    public class InvalidQueueMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="QueueClient"/> that has received invalid message.
        /// </summary>
        public QueueClient Sender { get; }

        /// <summary>
        /// Gets the invalid message which can be either <see cref="QueueMessage"/> or <see cref="PeekedMessage"/>.
        /// The body of the message is as received, i.e. no decoding is attempted.
        /// </summary>
        public object Message { get; }

        /// <summary>
        /// A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidQueueMessageEventArgs"/>.
        /// </summary>
        /// <param name="sender">The <see cref="QueueClient"/> that has received invalid message.</param>
        /// <param name="message">The invalid message</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public InvalidQueueMessageEventArgs(QueueClient sender, QueueMessage message, CancellationToken cancellationToken)
        {
            Sender = sender;
            Message = message;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidQueueMessageEventArgs"/>.
        /// </summary>
        /// <param name="sender">The <see cref="QueueClient"/> that has received invalid message.</param>
        /// <param name="message">The invalid message</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public InvalidQueueMessageEventArgs(QueueClient sender, PeekedMessage message, CancellationToken cancellationToken)
        {
            Sender = sender;
            Message = message;
            CancellationToken = cancellationToken;
        }
    }
}
