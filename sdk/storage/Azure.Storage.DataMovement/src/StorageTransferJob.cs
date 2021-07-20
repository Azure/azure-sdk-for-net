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
    internal abstract class StorageTransferJob
    {
        // TODO: thinking about getting rid of this. In the intro doc we thought about having this
        // in the case that they want to remove jobs from the TransferManager and they wanted to
        // point to it
        /*
        private int _jobId;

        /// <summary>
        /// Get the job id
        /// </summary>
        public int jobId => _jobId;
        */

        /// <summary>
        /// Cancellation Token
        /// </summary>
        public CancellationToken CancellationToken;

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns></returns>
        public virtual Task StartTransferTaskAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Create Storage Transfer Job
        /// </summary>
        protected StorageTransferJob()
        {
        }
    }
}
