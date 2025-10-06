// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Common event arguments for any Storage Transfer Event Handler.
    /// </summary>
    public abstract class TransferEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Transfer id.
        /// </summary>
        public string TransferId { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferEventArgs"/>.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
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
        /// Thrown if <paramref name="transferId"/> is empty or null.
        /// </exception>
        protected TransferEventArgs(
            string transferId,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            TransferId = transferId;
        }
    }
}
