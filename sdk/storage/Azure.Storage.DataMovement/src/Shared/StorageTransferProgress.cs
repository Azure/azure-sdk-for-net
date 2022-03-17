// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Progress Handler to track how many files and bytes were transferred, along with files that failed or were skipped in transfer
    /// </summary>
    public class StorageTransferProgress
    {
        /// <summary>
        /// Number of Files that succeeded in transfer
        /// </summary>
        public int FilesTransferredSuccessfully { get; internal set; }

        /// <summary>
        /// Number of files that were skipped in transfer due to overwrite being set to not overwrite files, but the files exists already
        /// </summary>
        public int FilesTransferredSkipped { get; internal set; }

        /// <summary>
        /// Number of files that failed transferred.
        /// </summary>
        public int FilesTransferredFailed { get; internal set; }

        /// <summary>
        /// Number of files that are currently in progress of being uploaded.
        /// </summary>
        public int FilesCurrentlyTransferring { get; internal set; }

        /// <summary>
        /// Number of files that are queued up for transfer. This will vary depending when all the files discoverable for the full transfers have been queued.
        /// </summary>
        public int FilesQueuedForTransfer { get; internal set; }
    }
}
