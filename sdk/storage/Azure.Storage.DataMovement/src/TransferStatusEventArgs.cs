// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Event Argument for a change in the Transfer Status
    /// </summary>
    public class TransferStatusEventArgs : TransferEventArgs
    {
        /// <summary>
        /// Gets the <see cref="Storage.DataMovement.TransferStatus"/> of the job.
        /// </summary>
        public TransferStatus TransferStatus { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferStatusEventArgs"/>.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="transferStatus"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public TransferStatusEventArgs(
            string transferId,
            TransferStatus transferStatus,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base (transferId, isRunningSynchronously, cancellationToken)
        {
            TransferStatus = transferStatus;
        }
    }
}
