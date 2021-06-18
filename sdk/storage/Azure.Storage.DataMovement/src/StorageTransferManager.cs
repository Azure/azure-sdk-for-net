// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
// To use AsyncQueue, might decide to go with another queue later
using Microsoft.VisualStudio.Threading;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System.Threading;
using Azure.Storage.Blobs.Models;
using System.Threading.Tasks;
using System.IO;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// TransferManager class
    /// </summary>
    public class StorageTransferManager
    {
        // To hold the jobs to scan
        private AsyncQueue<StorageTransferJob> _toScanQueue;
        // To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        // authentication from the original job and for updating the jobs for progress tracking
        private IList<StorageTransferJob> _jobsInProgress;
        // The files that have resulted from a scan and waiting to be performed on (upload/download/copy)
        private AsyncQueue<StorageTransferItem> _transferQueue;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.
        private string _progressLogDirectoryPath;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="progressLogDirectoryPath">Specify directory path to log file to continue from.</param>
        public StorageTransferManager(string progressLogDirectoryPath = default)
        {
            _toScanQueue = new AsyncQueue<StorageTransferJob>();
            _jobsInProgress = new List<StorageTransferJob>();
            _transferQueue = new AsyncQueue<StorageTransferItem>();
            _progressLogDirectoryPath = progressLogDirectoryPath;
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public Task<StorageTransferResults> ScheduleUploadJob(
            Stream stream,
            BlobBaseClient destinationClient,
            BlobUploadOptions options = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token)
        {
            StorageTransferItem transferItem = new BlobTransferItem()
            if (_toScanQueue.Count > 1)
            {
                // Call scanning if required. If the job is just one file, we

            }
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public Task<StorageTransferResults> ScheduleUploadJob(
            Stream stream,
            BlobBaseClient destinationClient,
            BlobUploadOptions options = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token)
        {
            StorageTransferItem transferItem = new StorageTransferItem()
            if (_toScanQueue.Count > 1)
            {
                // Call scanning if required. If the job is just one file, we

            }
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public Task<StorageTransferResults> ScheduleUploadJob(
            Stream stream,
            BlobDirectoryClient destinationClient,
            BlobUploadOptions options = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token)
        {
            StorageTransferItem transferItem = new StorageTransferItem()
            if (_toScanQueue.Count > 1)
            {
                // Call scanning if required. If the job is just one file, we

            }
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public Task<StorageTransferResults> ScheduleDownload Job(
            string localPath,
            BlobBaseClient destinationClient,
            BlobUploadOptions options = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token)
        {
            StorageTransferItem transferItem = new StorageTransferItem()
            if (_toScanQueue.Count > 1)
            {
                // Call scanning if required. If the job is just one file, we

            }
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public Task<StorageTransferResults> ScheduleUploadJob(
            Stream stream,
            BlobBaseClient destinationClient,
            BlobUploadOptions options = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token)
        {
            StorageTransferItem transferItem = new StorageTransferItem()
            if (_toScanQueue.Count > 1)
            {
                // Call scanning if required. If the job is just one file, we

            }
        }

        /// <summary>
        /// Pause transfers.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public static void PauseTransfer()
        {
        }

        /// <summary>
        /// Cancel Transfers
        /// </summary>
        public static void CancelTransfer()
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
        }
    }
}
