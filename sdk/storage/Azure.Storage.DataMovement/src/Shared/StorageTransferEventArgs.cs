// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Event Argument for any Storage Transfer Event Handler.
    /// </summary>
    public class StorageTransferEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Job Id.
        /// </summary>
        public string JobId { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTransferEventArgs"/>.
        /// </summary>
        /// <param name="jobId"></param>
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
        /// Thrown if <paramref name="jobId"/> is empty or null.
        /// </exception>
        public StorageTransferEventArgs(
            string jobId,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            JobId = jobId;
        }
    }
}
