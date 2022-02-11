// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal abstract class BlobTransferJobInternal
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
        /// Plan file writer for hte respective job
        /// </summary>
        internal PlanJobWriter PlanJobWriter { get; set; }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected BlobTransferJobInternal()
        {
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal protected BlobTransferJobInternal(string jobId, string loggerFolderPath = default)
        {
            JobId = jobId;
            string folderPath = String.IsNullOrEmpty(loggerFolderPath) ? Constants.DataMovement.DefaultLogTransferFiles : loggerFolderPath;
            // TODO; get loglevel from StorageTransferManager
            PlanJobWriter = new PlanJobWriter(folderPath, jobId);
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

        public virtual async Task PauseTransferJob()
        {
            CancellationTokenSource.Cancel();
                /* TODO: replace with Azure.Core.Diagnotiscs logger
            await Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer Job has been paused.").ConfigureAwait(false);
                */
            await PlanJobWriter.SetTransferStatus("Job Paused").ConfigureAwait(false);
        }

        public virtual async Task ResumeTransferJob()
        {
            CancellationTokenSource.Cancel();
                /* TODO: replace with Azure.Core.Diagnotiscs logger
            await Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer Job has been resumed.").ConfigureAwait(false);
                */
            await PlanJobWriter.SetTransferStatus("Job Paused").ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the job details
        /// </summary>
        /// <returns></returns>
        public abstract BlobTransferJobProperties GetJobDetails();
    }
}
