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
        private AsyncQueue<StorageTransferJob> _jobsInProgress;
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
            _jobsInProgress = new AsyncQueue<StorageTransferJob>();
            _progressLogDirectoryPath = progressLogDirectoryPath;
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public async Task<StorageTransferResults> ScheduleUploadJobAsync(
            string sourceLocalPath,
            BlobBaseClient destinationClient,
            StorageTransferOptions transferOptions = default,
            BlobUploadOptions uploadOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobTransferJob transferJob = new BlobTransferJob(sourceLocalPath, destinationClient, transferOptions, uploadOptions, progressTracker, token);
            _jobsInProgress.Enqueue(transferJob);

            // TODO: remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public async Task<StorageTransferResults> ScheduleDownloadJobAsync(
            BlobBaseClient sourceClient,
            string destinationLocalPath,
            StorageTransferOptions transferOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobTransferJob transferJob = new BlobTransferJob(sourceClient, destinationLocalPath, transferOptions, progressTracker, token);
            _jobsInProgress.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        public async Task<StorageTransferResults> ScheduleUploadDirectoryJobAsync(
            string sourceLocalPath,
            BlobBaseClient destinationClient,
            StorageTransferOptions transferOptions = default,
            BlobUploadOptions uploadOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobDirectoryTransferJob transferItem = new BlobDirectoryTransferJob(sourceLocalPath, destinationClient, transferOptions, uploadOptions, progressTracker, token);

            // TODO; remove stub
            return Task.FromResult(new StorageTransferResults());
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
