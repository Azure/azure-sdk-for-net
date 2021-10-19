// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Provides data for <see cref="StorageTransferStatus"/>
    /// and <see cref="StorageTransferStatus"/> events.
    /// </summary>
    public class PathTransferSuccessEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Gets the <see cref="StorageTransferJob"/> raising the
        /// event.
        /// </summary>
        public StorageTransferJob Job { get; }

        /// <summary>
        /// Gets the <see cref="Response{T}"/> of the job
        /// </summary>
        public Response Response { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathTransferSuccessEventArgs"/>
        /// class.
        /// </summary>
        /// <param name="job">
        /// The <see cref="StorageTransferJob"/> raising the event.
        /// </param>
        /// <param name="response">
        /// The <see cref="Response{T}"/> that was added, sent,
        /// completed, or failed.
        /// </param>
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
        /// Thrown if <paramref name="job"/> or <paramref name="response"/>
        /// are null.
        /// </exception>
        public PathTransferSuccessEventArgs(
            StorageTransferJob job,
            Response response,
            bool isRunningSynchronously,
            CancellationToken cancellationToken = default)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(job, nameof(job));
            Argument.AssertNotNull(response, nameof(response));
            Job = job;
            Response = response;
        }
    }
}
