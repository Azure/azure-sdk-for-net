// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private int _jobId;

        /// <summary>
        /// Get the job id
        /// </summary>
        public int jobId => _jobId;

        private StorageTransferOptions _options;
        /// <summary>
        /// StorageTransferOptions
        /// </summary>
        public StorageTransferOptions Options;

        /// <summary>
        /// Create Storage Transfer Job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="options"></param>
        public StorageTransferJob(int jobId, StorageTransferOptions options = default)
        {
            _jobId = jobId;
            _options = options;
        }
    }
}
