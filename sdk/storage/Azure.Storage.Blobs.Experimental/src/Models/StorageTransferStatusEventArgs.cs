// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Storage.Experimental;

namespace Azure.Storage.Blobs.Experimental.Models
{
    /// <summary>
    /// Event Argument for a change in the Transfer Status
    /// </summary>
    public class StorageTransferStatusEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="Storage.Experimental.StorageTransferStatus"/> of the job.
        /// </summary>
        public StorageTransferStatus StorageTransferStatus { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTransferStatusEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="transferStatus"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public StorageTransferStatusEventArgs(
            string transferId,
            StorageTransferStatus transferStatus,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base (transferId, isRunningSynchronously, cancellationToken)
        {
            StorageTransferStatus = transferStatus;
        }
    }
}
