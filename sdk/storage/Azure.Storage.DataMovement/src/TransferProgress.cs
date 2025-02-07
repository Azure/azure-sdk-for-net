// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Progress Handler to track how many files and bytes were transferred, along with files that failed or were skipped in transfer.
    /// </summary>
    public class TransferProgress
    {
        internal TransferProgress() { }

        /// <summary>
        /// Number of files that were transferred successfully.
        /// </summary>
        public long CompletedCount { get; internal set; }

        /// <summary>
        /// Number of files that were skipped in transfer due to files already existing in the destination. Files will be skipped if
        /// the overwrite policy is set to not overwrite existing files.
        /// </summary>
        public long SkippedCount { get; internal set; }

        /// <summary>
        /// Number of files that failed to transfer successfully.
        /// </summary>
        public long FailedCount { get; internal set; }

        /// <summary>
        /// Number of files that are currently in progress of being transferred.
        /// </summary>
        public long InProgressCount { get; internal set; }

        /// <summary>
        /// Number of files that are queued up for transfer. This will vary depending when all the files discoverable for the full transfers have been queued.
        /// </summary>
        public long QueuedCount { get; internal set; }

        /// <summary>
        /// Number of bytes transferred across all files.
        /// Only populated if <see cref="TransferProgressHandlerOptions.TrackBytesTransferred"/> is set.
        /// </summary>
        public long? BytesTransferred { get; internal set; }
    }
}
