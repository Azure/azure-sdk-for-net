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
using Azure.Storage;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs.Models;

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
        /// internal job transfer to scan for job sand schedule requests accordingly
        /// </summary>
        internal BlobJobTransferScheduler jobTransferScheduler { get; set; }

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="options">Directory path where transfer state is kept.</param>
        public BlobTransferManager(StorageTransferManagerOptions options = default)
            : base(options)
        {
            jobTransferScheduler = new BlobJobTransferScheduler(options.ConcurrencyForLocalFilesystemListing, options.ConcurrencyForServiceListing);
        }

        /// <summary>
        /// Add Blob Upload Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="uploadOptions"></param>
        /// <returns>A guid of the job id</returns>
        public string ScheduleUpload(
            string sourceLocalPath,
            BlobClient destinationClient,
            BlobUploadOptions uploadOptions = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists

            BlobUploadTransferJob transferJob = new BlobUploadTransferJob(jobId, sourceLocalPath, destinationClient, uploadOptions);
            TotalJobs.Add(transferJob);
            jobTransferScheduler.AddJob(transferJob);

            // TODO: remove stub
            return jobId;
        }

        /// <summary>
        /// Add Blob Download Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string ScheduleDownload(
            BlobClient sourceClient,
            string destinationLocalPath,
            BlobDownloadToOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobDownloadTransferJob transferJob = new BlobDownloadTransferJob(jobId, sourceClient, destinationLocalPath, options);
            TotalJobs.Add(transferJob);
            jobTransferScheduler.AddJob(transferJob);
            return jobId;
        }

        /// <summary>
        /// Add Upload Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="overwrite"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// TODO: remove suppression
        public string ScheduleUploadDirectory(
            string sourceLocalPath,
            BlobVirtualDirectoryClient destinationClient,
            bool overwrite = false,
            BlobDirectoryUploadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobUploadDirectoryTransferJob transferJob = new BlobUploadDirectoryTransferJob(jobId, sourceLocalPath, overwrite, destinationClient, options);
            TotalJobs.Add(transferJob);
            jobTransferScheduler.AddJob(transferJob);
            return jobId;
        }

        /// <summary>
        /// Add Download Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// TODO: remove suppression
        public string ScheduleDownloadDirectory(
            BlobVirtualDirectoryClient sourceClient,
            string destinationLocalPath,
            BlobDirectoryDownloadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobDownloadDirectoryTransferJob transferJob = new BlobDownloadDirectoryTransferJob(jobId, sourceClient, destinationLocalPath, options);
            TotalJobs.Add(transferJob);
            jobTransferScheduler.AddJob(transferJob);

            return jobId;
        }

        /*
        /// <summary>
        /// For those who have existing transfers that were paused
        /// but now want to resume it can do so by passing the file path
        /// to the plan file.
        ///
        /// The file will be read to see where the transfer left off
        /// and continue from there.
        ///
        /// This Job will have the same job id as contained in the job file.
        /// </summary>
        /// <param name="planFilePath"></param>
        /// <returns></returns>
        public string ScheduleJobFromPlanFile(string planFilePath)
        {
            //TODO: stub
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            return jobId;
        }
        */

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public override StorageTransferJob GetJob(string jobId)
        {
            //TODO: change to transfer blob transfer job, or create Storage transfer job to be more generic informaiton
            // this will be more clear in teh champion scenario
            return new StorageTransferJob(string.IsNullOrEmpty(jobId) ? Guid.NewGuid().ToString() : jobId);
        }
    }
}
