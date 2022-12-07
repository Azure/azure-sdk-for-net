// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the StorageTransferManager.
    /// </summary>
    internal enum StorageManagerTransferStatus
    {
        /// <summary>
        /// No Jobs are in progress
        /// </summary>
        Idle,

        /// <summary>
        /// Jobs are in progress
        /// </summary>
        InProgress,

        /// <summary>
        /// In progress of pausing transfers. Which means we have received the
        /// command to PauseTransfers but we have not stopped all the running Tasks yet.
        ///
        /// During this time we are writing to the plan files to keep track of the progress
        /// and waiting for the Tasks in flight to exit properly. Also updating all log files
        /// as well.
        ///
        /// In this state no other transfers can be resumed until all the jobs have been
        /// paused, finished or cancelled.
        /// </summary>
        Pausing,

        /// <summary>
        /// In progress of cancelling transfers. Which means that we received the cancel command
        /// but we have not stopped all the transfers and tasks running.
        ///
        /// During this time we are deleting all the plan files and updating the log files properly.
        ///
        /// In this state no other transfers can be resumed until all the jobs have been
        /// paused, finished or cancelled.
        /// </summary>
        Cancelling,

        /// <summary>
        /// In progress of cleaning up all the plan and log files. In this state no transfers can
        /// occur.
        ///
        /// In this state no other jobs can be kicked off.
        /// </summary>
        Cleaning
    };
}
