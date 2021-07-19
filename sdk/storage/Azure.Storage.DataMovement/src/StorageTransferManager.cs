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
        private AsyncQueue<StorageTransferJob> _toScanQueue;
        // To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        // authentication from the original job and for updating the jobs for progress tracking
        private AsyncQueue<StorageTransferJob> _jobsToProcess;
        // Not sure if we should keep the jobs that in in progress here
        //private IList<StorageTransferJob> _jobsInProgress;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.
        private string _transferStateDirectoryPath;

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="transferStateDirectoryPath">Directory path where transfer state is kept.</param>
        public StorageTransferManager(string transferStateDirectoryPath = default)
        {
            _toScanQueue = new AsyncQueue<StorageTransferJob>();
            _jobsToProcess = new AsyncQueue<StorageTransferJob>();
            _transferStateDirectoryPath = transferStateDirectoryPath;
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
