// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Storage Transfer Job Details
    /// </summary>
    public class StorageTransferJobDetails
    {
        /// <summary>
        /// Internal Constructor
        /// </summary>
        protected internal StorageTransferJobDetails() { }

        /// <summary>
        /// Internal Constructor
        /// </summary>
        protected internal StorageTransferJobDetails(
            string jobId,
            StorageJobTransferStatus status,
            DateTimeOffset? jobStartTime)
        {
            JobId = jobId;
            Status = status;
            JobStartTime = jobStartTime;
        }

        /// <summary>
        /// Job Id. Guid.
        /// </summary>
        public string JobId { get; internal set; }

        /// <summary>
        /// Status of the job
        /// </summary>
        public StorageJobTransferStatus Status { get; internal set; }

        /// <summary>
        /// Job start time
        /// </summary>
        public DateTimeOffset? JobStartTime { get; internal set; }
    }
}
