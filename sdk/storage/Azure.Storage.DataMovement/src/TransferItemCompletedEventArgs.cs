// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Event Argument for a change in the Transfer Status
    /// </summary>
    public class TransferItemCompletedEventArgs : DataTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="StorageResourceItem"/> that was the source resource for the transfer.
        /// </summary>
        public StorageResourceItem SourceResource { get; }

        /// <summary>
        /// Gets the <see cref="StorageResourceItem"/> that was the destination resource for the transfer.
        /// </summary>
        public StorageResourceItem DestinationResource { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferItemFailedEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
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
        /// Trhown if <paramref name="transferId"/> is empty or null.
        /// Thrown if <paramref name="sourceResource"/> is empty or null.
        /// Thrown if <paramref name="destinationResource"/> is empty or null.
        /// </exception>
        public TransferItemCompletedEventArgs(
            string transferId,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            Argument.AssertNotNull(sourceResource, nameof(sourceResource));
            Argument.AssertNotNull(destinationResource, nameof(destinationResource));
            SourceResource = sourceResource;
            DestinationResource = destinationResource;
        }
    }
}
