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
        /// </summary>
        None = 0,

        /// <summary>
        /// The Job has been queued up but has not yet begun any transfers.
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The Job has started, but has not yet completed.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The Job has been paused. When transfer is paused (e.g. see <see cref="TransferManager.TryPauseTransferAsync(string)"/>) during the transfer,
        /// this will be the value.
        ///
        /// This status is a resumable state, only
        /// transfers that failed will be retried when <see cref="TransferManager.StartTransferAsync(StorageResource, StorageResource, Models.SingleTransferOptions)"/>
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
    };
}
