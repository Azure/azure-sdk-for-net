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
