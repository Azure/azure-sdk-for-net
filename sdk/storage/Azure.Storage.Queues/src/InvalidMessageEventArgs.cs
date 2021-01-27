// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Contains information about invalid message.
    /// See also <see cref="QueueClientOptions.OnInvalidMessage"/>.
    /// </summary>
    public class InvalidMessageEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="QueueClient"/> that has received invalid message.
        /// </summary>
        public QueueClient QueueClient { get; }

        /// <summary>
        /// Gets the invalid message which can be either <see cref="QueueMessage"/> or <see cref="PeekedMessage"/>.
        /// The body of the message is as received, i.e. no decoding is attempted.
        /// </summary>
        public object Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMessageEventArgs"/>.
        /// </summary>
        /// <param name="queueClient">The <see cref="QueueClient"/> that has received invalid message.</param>
        /// <param name="message">The invalid message.</param>
        /// <param name="runSynchronously">
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
        /// Thrown if <paramref name="queueClient"/> or <paramref name="message"/>
        /// are null.
        /// </exception>
        public InvalidMessageEventArgs(
            QueueClient queueClient,
            QueueMessage message,
            bool runSynchronously,
            CancellationToken cancellationToken)
            : base(runSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(queueClient, nameof(queueClient));
            Argument.AssertNotNull(message, nameof(message));
            QueueClient = queueClient;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMessageEventArgs"/>.
        /// </summary>
        /// <param name="queueClient">The <see cref="QueueClient"/> that has received invalid message.</param>
        /// <param name="message">The invalid message.</param>
        /// <param name="runSynchronously">
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
        /// Thrown if <paramref name="queueClient"/> or <paramref name="message"/>
        /// are null.
        /// </exception>
        public InvalidMessageEventArgs(
            QueueClient queueClient,
            PeekedMessage message,
            bool runSynchronously,
            CancellationToken cancellationToken)
            : base(runSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(queueClient, nameof(queueClient));
            Argument.AssertNotNull(message, nameof(message));
            QueueClient = queueClient;
            Message = message;
        }
    }
}
