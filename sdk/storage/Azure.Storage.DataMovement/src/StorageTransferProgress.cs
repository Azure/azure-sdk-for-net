// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Progress Handler to track how many files and bytes were transferred, along with files that failed or were skipped in transfer.
    /// </summary>
    internal class StorageTransferProgress
    {
        /// <summary>
        /// Number of files that were transferred successfully.
        /// </summary>
        public int CompletedCount { get; internal set; }

        /// <summary>
        /// Number of files that were skipped in transfer due to files already existing in the destination. Files will be skipped if
        /// the overwrite policy is set to not overwrite existing files.
        /// </summary>
        public int SkippedCount { get; internal set; }

        /// <summary>
        /// Number of files that failed to transfer successfully.
        /// </summary>
        public int FailedCount { get; internal set; }

        /// <summary>
        /// Number of files that are currently in progress of being transferred.
        /// </summary>
        public int InProgressCount { get; internal set; }

        /// <summary>
        /// Number of files that are queued up for transfer. This will vary depending when all the files discoverable for the full transfers have been queued.
        /// </summary>
        public int QueuedCount { get; internal set; }
    }
}
