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
    public abstract class StorageTransferManager
    {
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
            _options = options;
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public abstract void PauseTransfers();

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
        public abstract void CancelTransfers();

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files.
        /// Removes all logs
        /// </summary>
        public abstract void Clean();
    }
}
