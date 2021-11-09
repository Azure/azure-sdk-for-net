// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Stores the information of the Transfer Job.
    /// TODO: better description
    /// </summary>
    public abstract class StorageTransferJob
    {

        /// <summary>
        /// Job Id in form of a Guid
        /// </summary>
        public string JobId { get; set; }
        /// <summary>
        /// Cancellation Token
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns></returns>
        public virtual Task StartTransferTaskAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        public StorageTransferJob(string jobId)
        {
            JobId = jobId;
        }
    }
}
