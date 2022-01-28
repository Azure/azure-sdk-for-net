// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Stores the information of the Transfer Job.
    /// TODO: better description
    /// </summary>
    internal class TransferJobInternal
    {
        /// <summary>
        /// Job Id in form of a Guid
        /// </summary>
        public string JobId { get; set; }
        /// <summary>
        /// Cancellation Token Source
        ///
        /// Will be initialized when the tasks are running.
        ///
        /// Will be disposed of once all tasks of the job have completed or have been cancelled.
        /// </summary>
        public CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        /// Logger for the respective job
        /// </summary>
        internal TransferJobLogger Logger { get; set; }

        /// <summary>
        /// Plan file writer for hte respective job
        /// </summary>
        internal PlanJobWriter PlanJobWriter { get; set; }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected TransferJobInternal()
        {
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal protected TransferJobInternal(string jobId, string loggerFolderPath = default)
        {
            JobId = jobId;
            string folderPath = String.IsNullOrEmpty(loggerFolderPath) ? Constants.DataMovement.DefaultLogTransferFiles : loggerFolderPath;
            // TODO; get loglevel from StorageTransferManager
            Logger = new TransferJobLogger(folderPath,jobId);
        }

        /// <summary>
        /// Gets the status of the transfer job
        /// </summary>
        /// <returns>StorageTransferStatus with the value of the status of the job</returns>
        public virtual StorageJobTransferStatus GetTransferStatus()
        {
            // TODO: remove stub
            return StorageJobTransferStatus.Completed;
        }
    }
}
