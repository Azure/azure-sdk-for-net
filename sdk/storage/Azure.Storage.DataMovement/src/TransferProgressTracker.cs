// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Internal class for tracking progress of transfers and reporting back to
    /// user's progress handler.
    /// </summary>
    internal class TransferProgressTracker
    {
        private readonly IProgress<StorageTransferProgress> _progressHandler;

        private long _completedCount = 0;
        private long _skippedCount = 0;
        private long _failedCount = 0;
        private long _inProgressCount = 0;
        private long _queuedCount = 0;

        public TransferProgressTracker(IProgress<StorageTransferProgress> progressHandler)
        {
            _progressHandler = progressHandler;
        }

        /// <summary>
        /// Atomically increments completed files, decrements in-progress files and reports progress.
        /// </summary>
        public void IncrementCompletedFiles()
        {
            Interlocked.Decrement(ref _inProgressCount);
            Interlocked.Increment(ref _completedCount);
            _progressHandler?.Report(GetTransferProgress());
        }

        /// <summary>
        /// Atomically increments skipped files, decrements in-progress files and reports progress.
        /// </summary>
        public void IncrementSkippedFiles()
        {
            Interlocked.Decrement(ref _inProgressCount);
            Interlocked.Increment(ref _skippedCount);
            _progressHandler?.Report(GetTransferProgress());
        }

        /// <summary>
        /// Atomically increments failed files, decrements in-progress files and reports progress.
        /// </summary>
        public void IncrementFailedFiles()
        {
            Interlocked.Decrement(ref _inProgressCount);
            Interlocked.Increment(ref _failedCount);
            _progressHandler?.Report(GetTransferProgress());
        }

        /// <summary>
        /// Atomically increments in-progress files, decrements queued files and reports progress.
        /// </summary>
        public void IncrementInProgressFiles()
        {
            Interlocked.Decrement(ref _queuedCount);
            Interlocked.Increment(ref _inProgressCount);
            _progressHandler?.Report(GetTransferProgress());
        }

        /// <summary>
        /// Atomically increments queued files and reports progress.
        /// </summary>
        public void IncrementQueuedFiles()
        {
            Interlocked.Increment(ref _queuedCount);
            _progressHandler?.Report(GetTransferProgress());
        }

        private StorageTransferProgress GetTransferProgress()
        {
            return new StorageTransferProgress()
            {
                CompletedCount = _completedCount,
                SkippedCount = _skippedCount,
                FailedCount = _failedCount,
                InProgressCount = _inProgressCount,
                QueuedCount = _queuedCount,
            };
        }
    }
}
