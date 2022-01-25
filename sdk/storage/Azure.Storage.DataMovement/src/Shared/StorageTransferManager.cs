// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
// To use ConcurrentQueue, might decide to go with another queue later
using Microsoft.VisualStudio.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Azure.Storage.DataMovement.Models;
using System.Collections.Concurrent;

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
        /// To hold the jobs to scan
        /// This is a weird thing to have because we have regular Blob Directory Upload / Download which will
        /// also call the scanner on it's own. Something to think about is whehter or not doing scanning in a separate
        /// part of DMLib instead of scanning right before the job is benefical.
        /// </summary>
        private List<TransferJobInternal> _totalJobs;

        /// <summary>
        /// To hold the jobs to scan
        /// </summary>
        protected internal List<TransferJobInternal> TotalJobs => _totalJobs;

        // Not sure if we should keep the jobs that in in progress here
        // private IList<StorageTransferJob> _jobsInProgress;
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

        /// <summary>
        /// The current state of the StorageTransferMangager
        /// </summary>
        private StorageManagerTransferStatus _managerTransferStatus;

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected internal StorageTransferManager()
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="options">Directory path where transfer state is kept.</param>
        public StorageTransferManager(StorageTransferManagerOptions options)
        {
            _totalJobs = new List<TransferJobInternal>();
            _options = options;
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
        }

        /// <summary>
        /// List all jobs and information
        /// </summary>
        /// <returns></returns>
        public virtual IList<StorageTransferJobDetails> ListJobs()
            //options to grab what kind of information
        {
            return new List<StorageTransferJobDetails>();
        }

        /// <summary>
        /// Returns storage job information if provided jobId
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public virtual StorageTransferJobDetails GetJob(string jobId)
        {
            return new StorageTransferJobDetails();
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public virtual void PauseTransfers()
        {
            _managerTransferStatus = StorageManagerTransferStatus.Pausing;

            foreach (TransferJobInternal job in _totalJobs)
            {
                job.CancellationTokenSource.Cancel(true);
                //TODO: log cancellation of job
                //Call job update transfer status
            }
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
        }

        /// <summary>
        /// Cancel Transfers that are currently being processed.
        /// Removes all transfers that are being processed and waiting
        /// to be performed.
        ///
        /// In cancelling tasks, we are also removing all the transfer state
        /// plan files of all the jobs because we are removing all jobs.
        ///
        /// In order to rerun the job, the customer must readd the job back in.
        /// </summary>
        public virtual void CancelTransfers()
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
            _managerTransferStatus = StorageManagerTransferStatus.Cancelling;
            foreach (TransferJobInternal job in _totalJobs)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.
                job.PlanJobWriter.RemovePlanFile();
            }
        }

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files.
        /// Removes all logs
        /// </summary>
        public virtual void Clean()
        {
            if (_managerTransferStatus == StorageManagerTransferStatus.InProgress)
            {
                // TODO: throw proper exception
                throw new Exception("Please cancel or pause the transfer jobs before cleaning");
            }
            else if (_managerTransferStatus == StorageManagerTransferStatus.Pausing)
            {
                // TODO: throw proper exception
                throw new Exception("Please wait until all transfer jobs have paused");
            }
            else if (_managerTransferStatus == StorageManagerTransferStatus.Cancelling)
            {
                throw new Exception("Please wait until all transfer jobs have cancelled");
            }
            _managerTransferStatus = StorageManagerTransferStatus.Cleaning;
            foreach (TransferJobInternal job in _totalJobs)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.
                job.Logger.removeLogFile();
                job.PlanJobWriter.RemovePlanFile();
            }
        }
    }
}
