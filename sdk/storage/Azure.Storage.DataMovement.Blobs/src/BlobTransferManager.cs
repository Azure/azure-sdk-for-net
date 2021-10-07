// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The <see cref="BlobTransferManager"/> allows you to manipulate
    /// Azure Storage Block Blobs by queueing up upload and download transfer
    /// items, manage those operations, track progress and pause and resume
    /// transfer processes.
    ///
    /// TODO: update description to include page blobs, append blobs, SMB Files
    /// and DataLake Files once added.
    /// </summary>
    public class BlobTransferManager : StorageTransferManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobTransferManager"/>
        /// class for mocking.
        /// </summary>
        protected BlobTransferManager()
        {
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
            BlobVirtualDirectoryClient destinationClient,
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
            BlobVirtualDirectoryClient sourceClient,
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
    }
}
