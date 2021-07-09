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
        // This is a weird thing to have because we have regular Blob Directory Upload / Download which will
        // also call the scanner on it's own. Something to think about is whehter or not doing scanning in a separate
        // part of DMLib instead of scanning right before the job is benefical.
        private AsyncQueue<StorageTransferJob> _toScanQueue;
        // To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        // authentication from the original job and for updating the jobs for progress tracking
        private AsyncQueue<StorageTransferJob> _jobsToProcess;
        // Not sure if we should keep the jobs that in in progress here
        // private IList<StorageTransferJob> _jobsInProgress;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.
        private string _progressLogDirectoryPath;

        internal StorageTransferOptions _transferOptions;
        /// <summary>
        /// StorageTransferOptions
        /// </summary>
        public StorageTransferOptions TransferOptions => _transferOptions;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="progressLogDirectoryPath">Specify directory path to log file to continue from.</param>
        /// <param name="transferOptions">Transfer options basket.</param>
        public StorageTransferManager(string progressLogDirectoryPath = default, StorageTransferOptions transferOptions = default)
        {
            _toScanQueue = new AsyncQueue<StorageTransferJob>();
            _jobsToProcess = new AsyncQueue<StorageTransferJob>();
            _progressLogDirectoryPath = progressLogDirectoryPath;
            _transferOptions = transferOptions;
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>//
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleUploadJobAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            string sourceLocalPath,
            BlobClient destinationClient,
            StorageTransferOptions transferOptions = default,
            BlobUploadOptions uploadOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobTransferJob transferJob = new BlobTransferJob(sourceLocalPath, destinationClient, transferOptions, uploadOptions, progressTracker, token);
            _jobsToProcess.Enqueue(transferJob);

            // TODO: remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        /// TODO: remove suppresion
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleDownloadJobAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            BlobClient sourceClient,
            string destinationLocalPath,
            StorageTransferOptions transferOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobTransferJob transferJob = new BlobTransferJob(sourceClient, destinationLocalPath, transferOptions, progressTracker, token);
            _jobsToProcess.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add upload job to perform.
        /// </summary>
        /// TODO: remove suppression
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleUploadDirectoryJobAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            string sourceLocalPath,
            BlobDirectoryClient destinationClient,
            StorageTransferOptions transferOptions = default,
            BlobUploadOptions uploadOptions = default,
            IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobDirectoryTransferJob transferJob = new BlobDirectoryTransferJob(sourceLocalPath, destinationClient, transferOptions, uploadOptions, progressTracker, token);
            _toScanQueue.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// TODO: Replace generated docs
        /// </summary>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task StartTransferAsync(CancellationToken token = default)
        {
            JobScheduler jobScheduler = new JobScheduler(_transferOptions);
            List<Task> tasks = new List<Task>();

            while (!_jobsToProcess.IsEmpty)
            {
                StorageTransferJob job = await _jobsToProcess.DequeueAsync(token).ConfigureAwait(false);
                Task task = Task.Factory.StartNew(async () =>
                {
                    await job.CreateTransferTaskAsync().ConfigureAwait(false);
                }, token, default, jobScheduler);

                tasks.Add(task);
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);
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
