// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job.
    /// </summary>
    public enum StorageTransferStatus
    {
        /// <summary>
        /// Default value.
        /// Equivalent to <see cref="StorageTransferStatus.None"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// The Job has been queued up but has not yet begun any transfers.
        /// Equivalent to <see cref="StorageTransferStatus.Queued"/>.
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The Job has started, but has not yet completed.
        /// Equivalent to <see cref="StorageTransferStatus.InProgress"/>.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The Job has been paused. When transfer is paused (e.g. see <see cref="TransferManager.PauseTransferIfRunningAsync(string, System.Threading.CancellationToken)"/>) during the transfer,
        /// this will be the value.
        ///
        /// This status is a resumable state, only
        /// transfers that failed will be retried when <see cref="TransferManager.StartTransferAsync(StorageResource, StorageResource, Models.TransferOptions)"/>
        /// with the respective transfer ID to resume.
        /// </summary>
        Paused = 3,

        /// <summary>
        /// The Job has completed successfully with no failures or skips.
        /// </summary>
        Completed = 4,

        /// <summary>
        /// The Job has been completed with at least one skipped transfer.
        /// </summary>
        CompletedWithSkippedTransfers = 5,

        /// <summary>
        /// The Job has been completed with at least one failed transfer.
        /// </summary>
        CompletedWithFailedTransfers = 6,

        /// <summary>
        /// A pause was called on the transfer job and is in progress.
        /// </summary>
        PauseInProgress = 7,

        /// <summary>
        /// A pause was called on the transfer job and is in progress.
        /// </summary>
        CancellationInProgress = 8,
    };
}
