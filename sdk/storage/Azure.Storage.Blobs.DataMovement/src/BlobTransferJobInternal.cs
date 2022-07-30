// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement
{
    internal abstract class BlobTransferJobInternal
    {
        /// <summary>
        /// Job Id in form of a Guid
        /// </summary>
        public string TransferId { get; set; }

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

        private long _transferStatus;
        /// <summary>
        /// Current status of the job
        /// </summary>
        public StorageTransferStatus TransferStatus
        {
            get
            {
                return (StorageTransferStatus)Interlocked.Read(ref _transferStatus);
            }
            set
            {
                Interlocked.Exchange(ref _transferStatus, (long)value);
            }
        }

        private ErrorHandlingOptions _errorHandling;

        /// <summary>
        /// The error handling options
        /// </summary>
        public ErrorHandlingOptions ErrorHandling => _errorHandling;

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected BlobTransferJobInternal()
        {
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal protected BlobTransferJobInternal(string transferId, string planFolderPath = default, ErrorHandlingOptions errorHandling = ErrorHandlingOptions.PauseOnAllFailures)
        {
            _transferStatus = (long) StorageTransferStatus.Queued;
            TransferId = transferId;
            // TODO; get loglevel from StorageTransferManager
            //PlanJobWriter = new PlanJobWriter(folderPath, transferId);
            TransferStatus = StorageTransferStatus.Queued;
            _errorHandling = errorHandling;
            CancellationTokenSource = new CancellationTokenSource();
            PlanJobWriter = new PlanJobWriter(transferId, planFolderPath);
        }

        /// <summary>
        /// Gets the status of the transfer job
        /// </summary>
        /// <returns>StorageTransferStatus with the value of the status of the job</returns>
        public virtual StorageTransferStatus GetTransferStatus()
        {
            return TransferStatus;
        }

        public virtual void PauseTransferJob()
        {
            PauseTransferJobInternal(false).EnsureCompleted();
        }

        /// <summary>
        /// Gets the status of the transfer job
        /// </summary>
        /// <returns>StorageTransferStatus with the value of the status of the job</returns>
        public virtual async Task PauseTransferJobAsync()
        {
            await PauseTransferJobInternal(true).ConfigureAwait(false);
        }

        internal virtual async Task PauseTransferJobInternal(bool async)
        {
            if ((TransferStatus == StorageTransferStatus.InProgress) ||
                (TransferStatus == StorageTransferStatus.Queued))
            {
                TransferStatus = StorageTransferStatus.Paused;
                CancellationTokenSource.Cancel();
                if (async)
                {
                    await PlanJobWriter.SetTransferStatusAsync("Job Paused").ConfigureAwait(false);
                }
                else
                {
                    PlanJobWriter.SetTransferStatus("Job Paused");
                }
            }
        }

        /// <summary>
        /// Gets the job details
        /// </summary>
        /// <returns></returns>
        public abstract BlobTransferJobProperties GetJobDetails();

        /// <summary>
        /// Resume respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public abstract void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default);

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public abstract IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync();

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job chunks</returns>
        public abstract IAsyncEnumerable<Func<Task>> ProcessPartToChunkAsync();
    }
}
