// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Contains information about job that contained multiple failures
    /// </summary>
    public class DataMovementFailedEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="StorageTransferJob"/> that was performing the Job.
        /// </summary>
        public StorageTransferJob Job { get; }

        /// <summary>
        /// Gets the <see cref="RequestFailedException"/> that was thrown during the job.
        /// </summary>
        public RequestFailedException Exception { get;  }

        /// <summary>
        /// Gets the <see cref="RequestFailedException"/> that has been received and could not be decoded.
        /// The body of the message is as received, i.e. no decoding is attempted.
        /// </summary>
        public RequestFailedException ReceivedMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMovementFailedEventArgs"/>.
        /// </summary>
        /// <param name="job">The <see cref="StorageTransferJob"/> that has received invalid message.</param>
        /// <param name="exception">The <see cref="RequestFailedException"/> thrown during the job</param>
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
        /// Thrown if <paramref name="job"/> is null.
        /// </exception>
        public DataMovementFailedEventArgs(
            StorageTransferJob job,
            RequestFailedException exception,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(job, nameof(Job));
            Job = job;
            Exception = exception;
        }
    }
}
