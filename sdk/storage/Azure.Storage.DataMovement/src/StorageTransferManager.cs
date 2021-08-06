// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System.Threading;
using Azure.Storage.Blobs.Models;
using System.Threading.Tasks;
using System.IO;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The <see cref="StorageTransferManager"/> allows you to manipulate
    /// Azure Storage Block Blobs by queueing up upload and download transfer
    /// items, manage those operations, track progress and pause and resume
    /// transfer processes.
    ///
    /// TODO: update description to include page blobs, append blobs, SMB Files
    /// and DataLake Files once added.
    /// </summary>
    public class StorageTransferManager
    {
        // To hold the jobs to scan
        // This is a weird thing to have because we have regular Blob Directory Upload / Download which will
        // also call the scanner on it's own. Something to think about is whehter or not doing scanning in a separate
        // part of DMLib instead of scanning right before the job is benefical.
        //
        // Follow-up to above: Scanning before-hand might be best to separate concerns in different
        // phases of a runtime lifecycle. As it is now the directory UL/DL scans inline; possibly, to
        // have little duplication, we can separate the methods out into several so they can be reused.
        //
        // i.e. DownloadInternal splits into a scanner, a wrapper that scans, and then the wrapper passes
        // scanned items into a deeper download that actually performs/queues these actions. Benefit here is
        // we can take the scan method and call it in a job (maybe new interface method for scanning; to
        // be implemented by classes as needed), store the results in an instance variable, then move the job
        // over to the _jobsToProcess queue. Functionality for "processing" phase would become sending the
        // stored scanned items directly to the deeper download.
        private Queue<StorageTransferJob> _toScanQueue;
        // To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        // authentication from the original job and for updating the jobs for progress tracking
        private Queue<StorageTransferJob> _jobsToProcess;
        // Not sure if we should keep the jobs that in in progress here
        //private IList<StorageTransferJob> _jobsInProgress;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.
        private string _transferStateDirectoryPath;

        // StorageTransferOptions for managing parallelization
        private StorageTransferOptions _transferOptions;

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="transferStateDirectoryPath">Directory path where transfer state is kept.</param>
        public StorageTransferManager(string transferStateDirectoryPath = default, StorageTransferOptions transferOptions = default)
        {
            _toScanQueue = new Queue<StorageTransferJob>();
            _jobsToProcess = new Queue<StorageTransferJob>();
            _transferStateDirectoryPath = transferStateDirectoryPath;
            _transferOptions = transferOptions;
        }

        /// <summary>
        /// Add Blob Upload Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="uploadOptions"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// TODO: remove suppression
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleUploadAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            string sourceLocalPath,
            BlobClient destinationClient,
            BlobUploadOptions uploadOptions = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobUploadTransferJob transferJob = new BlobUploadTransferJob(sourceLocalPath, destinationClient, uploadOptions, token);
            _jobsToProcess.Enqueue(transferJob);

            // TODO: remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add Blob Download Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="transferOptions"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// TODO: remove suppresion
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleDownloadAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            BlobClient sourceClient,
            string destinationLocalPath,
            StorageTransferOptions transferOptions = default,
            //TODO: make options bag to include progress tracker
            //IProgress<StorageTransferStatus> progressTracker,
            // IProgress<StorageTransferStatus> progressTracker = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobDownloadTransferJob transferJob = new BlobDownloadTransferJob(sourceClient, destinationLocalPath, transferOptions, token);
            _jobsToProcess.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add Upload Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="uploadOptions"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// TODO: remove suppression
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleUploadDirectoryAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            string sourceLocalPath,
            BlobDirectoryClient destinationClient,
            BlobDirectoryUploadOptions uploadOptions = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobUploadDirectoryTransferJob transferJob = new BlobUploadDirectoryTransferJob(sourceLocalPath, destinationClient, uploadOptions, token);
            _toScanQueue.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Add Download Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="options"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// TODO: remove suppression
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<StorageTransferResults> ScheduleDownloadDirectoryAsync(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            BlobDirectoryClient sourceClient,
            string destinationLocalPath,
            BlobDirectoryDownloadOptions options = default,
            CancellationToken token = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            BlobDownloadDirectoryTransferJob transferJob = new BlobDownloadDirectoryTransferJob(sourceClient, destinationLocalPath, options, token);
            _toScanQueue.Enqueue(transferJob);

            // TODO; remove stub
            return new StorageTransferResults();
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public async Task StartTransfersAsync()
        {
            int concurrency = _transferOptions.MaximumJobConcurrency.HasValue ?
                _transferOptions.MaximumJobConcurrency.Value :
                5; // Random default, needs to be picked realistically.

            // Throttler notes: the throttler will take into its AddTask method
            // (which maybe should be renamed QueueTask) a Func<Task> to prevent
            // starting until the throttler wants to.
            //
            // To accomodate this, all StorageTransferJobs will provide this through
            // the common GetTransferTask that generates a Func<Task> that wraps the
            // underlying StartTask method, which in turn is implemented (overridden)
            // in each job type.
            //
            // Concerns are how exactly to have everything partiton as the throttler
            // trickles down from the manager through to the operations themselves.
            // Do we use new options in the StorageTransferManager (like the
            // MaximumJobConcurrency) above to handle each level? Do we have the
            // MaximumConcurrency specify a total pool and break that down?
            // How do we resolve conflicts in the latter case? (Most obvious example:
            // 5 jobs, 5 concurrency. This feeds the pool the jobs, which no longer
            // will have space to run their own operations...)
            //
            // How to actually pass this throttler down is also a point of concern.
            // Maybe a new override that takes the throttler in the relevant methods,
            // internal and shared to DMLib? Or a separate options bag?

            TaskThrottler throttler = new TaskThrottler(concurrency);

            while (_jobsToProcess.Count > 0)
            {
                StorageTransferJob job;
                lock (_jobsToProcess)
                {
                    job = _jobsToProcess.Dequeue();
                }
                throttler.AddTask(job.GetTransferTask());
            }
            await throttler.WaitAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public static void PauseTransfers()
        {
        }

        /// <summary>
        /// Cancel Transfers that are currently being processed.
        /// Removes all transfers that are being processed and waiting
        /// to be performed.
        /// </summary>
        public static void CancelTransfers()
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
        }
    }
}
