// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
// To use AsyncQueue, might decide to go with another queue later
using Microsoft.VisualStudio.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Azure.Storage.DataMovement.Models;

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
        /// <summary>
        /// TransferItemScheduler
        /// </summary>
        private TransferItemScheduler _scheduler;

        /// <summary>
        /// TransferItemScheduler
        /// </summary>
        protected internal TransferItemScheduler Scheduler => _scheduler;

        /// <summary>
        /// To hold the jobs to scan
        /// This is a weird thing to have because we have regular Blob Directory Upload / Download which will
        /// also call the scanner on it's own. Something to think about is whehter or not doing scanning in a separate
        /// part of DMLib instead of scanning right before the job is benefical.
        /// </summary>
        private AsyncQueue<StorageTransferJob> _toScanQueue;

        /// <summary>
        /// To hold the jobs to scan
        /// </summary>
        protected internal AsyncQueue<StorageTransferJob> ToScanQueue => _toScanQueue;

        /// <summary>
        /// To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        /// authentication from the original job and for updating the jobs for progress tracking
        /// </summary>
        private AsyncQueue<StorageTransferJob> _jobsToProcess;

        /// <summary>
        /// To hold the jobs that have finished scanning and ready to run; This will help with grabbing required
        /// authentication from the original job and for updating the jobs for progress tracking
        /// </summary>
        protected internal AsyncQueue<StorageTransferJob> JobsToProcess => _jobsToProcess;

        // Not sure if we should keep the jobs that in in progress here
        //private IList<StorageTransferJob> _jobsInProgress;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions _options;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions Options => _options;

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="options">Directory path where transfer state is kept.</param>
        public StorageTransferManager(StorageTransferManagerOptions options = default)
        {
            _scheduler = new TransferItemScheduler();
            _toScanQueue = new AsyncQueue<StorageTransferJob>();
            _jobsToProcess = new AsyncQueue<StorageTransferJob>();
            _options = options;
        }

        /// <summary>
        /// List all jobs and information
        /// </summary>
        /// <returns></returns>
        public virtual IList<string> ListJobs()
            //options to grab what kind of information
        {
            return new List<string>() { "foo", "bar" };
        }

        /// <summary>
        /// Returns storage job information if provided jobId
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public virtual StorageTransferJob GetJob(string jobId)
        {
            return new StorageTransferJob(string.IsNullOrEmpty(jobId) ? Guid.NewGuid().ToString() : jobId);
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public virtual void PauseTransfers()
        {
        }

        /// <summary>
        /// Cancel Transfers that are currently being processed.
        /// Removes all transfers that are being processed and waiting
        /// to be performed.
        /// </summary>
        public virtual void CancelTransfers()
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
        }

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files.
        /// Removes all logs
        /// </summary>
        public virtual void Clean()
        {
        }
    }
}
