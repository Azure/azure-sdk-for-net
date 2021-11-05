// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Contains information about message that could not be decoded.
    /// See also <see cref="QueueClientOptions.MessageDecodingFailed"/>.
    /// </summary>
    public class QueueMessageDecodingFailedEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="QueueClient"/> that has received message.
        /// </summary>
        public QueueClient Queue { get; }

        /// <summary>
        /// Gets the <see cref="QueueMessage"/> that has been received and could not be decoded.
        /// The body of the message is as received, i.e. no decoding is attempted.
        /// </summary>
        public QueueMessage ReceivedMessage { get; }

        /// <summary>
        /// Gets the <see cref="PeekedMessage"/> that has been peeked and could not be decoded.
        /// The body of the message is as received, i.e. no decoding is attempted.
        /// </summary>
        public PeekedMessage PeekedMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessageDecodingFailedEventArgs"/>.
        /// </summary>
        /// <param name="queueClient">The <see cref="QueueClient"/> that has received invalid message.</param>
        /// <param name="receivedMessage">The received <see cref="QueueMessage"/> message.</param>
        /// <param name="peekedMessage">The peeked <see cref="PeekedMessage"/> message.</param>
        /// <param name="isRunningSynchronously">
        /// A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token related to the original operation that raised
        /// the event.  It's important for your handler to pass this token
        /// along to any asynchronous or long-running synchronous operations
        /// that take a token so cancellation will correctly propagate.  The
        /// default value is <see cref="CancellationToken.None"/>.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="queueClient"/> is null.
        /// </exception>
        public QueueMessageDecodingFailedEventArgs(
            QueueClient queueClient,
            QueueMessage receivedMessage,
            PeekedMessage peekedMessage,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(queueClient, nameof(queueClient));
            Queue = queueClient;
            ReceivedMessage = receivedMessage;
            PeekedMessage = peekedMessage;
        }
    }
}
