// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job
    /// </summary>
    public enum StorageTransferStatus
    {
        /// <summary>
        /// The Job has been queued up but has not yet begun any transfers.
        /// </summary>
        Queued = 0,

        /// <summary>
        /// The Job has started, but has not yet completed.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Paused jobs. When transfer is paused (e.g. see <see cref="TransferManager.TryPauseTransferAsync(string)"/>) during the transfer
        /// this will be the value.
        ///
        /// This status is a resumable state, only
        /// transfers that failed will be retried when <see cref="TransferManager.StartTransferAsync(StorageResource, StorageResource, Models.SingleTransferOptions)"/>
        /// with the respective transfer id to resume.
        /// </summary>
        Paused = 2,

        /// <summary>
        /// The Job has completed.
        /// </summary>
        Completed = 3,
    };
}
