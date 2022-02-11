// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
// To use ConcurrentQueue, might decide to go with another queue later
using Microsoft.VisualStudio.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
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
    public abstract class StorageTransferManager
    {
        // Not sure if we should keep the jobs that in in progress here
        // private IList<StorageTransferJob> _jobsInProgress;
        // local directory path to put hte memory mapped file of the progress tracking. if we pause or break
        // we will have the information on where to continue from.

        /// <summary>
        /// If set, store the transfer states for each job in the locally at the path specified
        /// </summary>
        private string _transferStateLocalDirectoryPath;

        /// <summary>
        /// If set, store the transfer states for each job in the locally at the path specified
        /// </summary>
        protected internal string TransferStateLocalDirectoryPath => _transferStateLocalDirectoryPath;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions _options;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions Options => _options;

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
        protected StorageTransferManager(StorageTransferManagerOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class and specifying a local directory path to store the transfer state file.
        /// </summary>
        /// <param name="transferStateDirectoryPath">
        /// Optional path to set for the Transfer State File.
        ///
        /// If this file is not set and a transfer is started using
        /// the transfer manager, we will default to storing the file in
        /// %USERPROFILE%\.azstoragedml directory on Windows OS
        /// and $HOME$\.azstoragedml directory on Mac and Linux based OS.
        ///
        /// TODO: this will also hold the the information of all exceptions that
        /// have occured during the transfer state. In the case that too many
        /// exceptions happened during a transfer job and the customer wants
        /// to go through each exception and resolve each one.
        /// </param>
        /// <param name="options"></param>
        protected StorageTransferManager(string transferStateDirectoryPath, StorageTransferManagerOptions options)
            : this(options)
        {
            _transferStateLocalDirectoryPath = transferStateDirectoryPath;
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="jobId"></param>
        public abstract Task PauseTransferJobAsync(string jobId);

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="jobId"></param>
        public abstract Task ResumeTransferJobAsync(string jobId);

        /// <summary>
        /// Resumes transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public abstract Task ResumeAllTransferJobsAsync();

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public abstract Task PauseAllTransferJobsAsync();

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
        public abstract Task CancelAllTransferJobsAsync();

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files.
        /// Removes all logs
        /// </summary>
        public abstract Task CleanAsync();
    }
}
