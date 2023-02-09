// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Event Argument for a change in the Transfer Status
    /// </summary>
    public class TransferStatusEventArgs : StorageTransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="Storage.DataMovement.StorageTransferStatus"/> of the job.
        /// </summary>
        public StorageTransferStatus StorageTransferStatus { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferStatusEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="transferStatus"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public TransferStatusEventArgs(
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
