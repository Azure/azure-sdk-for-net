// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Used to define the status of the job when storing the state to the job plan file.
    /// </summary>
    internal enum JobPlanTransferJobStatus
    {
        /// <summary>
        /// ransfer is ready to transfe and not started transfering yet.
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// Transfer started and at least 1 chunk has successfully been transferred.
        /// Used to resume a transfer that started to avoid transferring all chunks thereby improving performance.
        /// </summary>
        Started = 1,

        /// <summary>
        /// Transfer successfuly compelted.
        /// </summary>
        Success = 2,

        /// <summary>
        /// Folder was created, but properties have not been persisted yet. Equivalent to Started, but never intended to be set on anything BUT folders.
        /// </summary>
        FolderCreated = 3,

        /// <summary>
        /// Transfer failed due to some error.
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Transfer failed due to failure while Setting blob tier.
        /// </summary>
        BlobTierFailure = -2,

        /// <summary>
        /// Transfer skipped due to fialure while the entity already exists
        /// </summary>
        SkippedEntityAlreadyExists = -3,

        /// <summary>
        /// Transfer skipped due to blob having snapshots
        /// </summary>
        SkippedBlobHasSnapshots = -4,

        /// <summary>
        /// TierAvailabilityCheckFailure
        /// </summary>
        TierAvailabilityCheckFailure = -5,

        /// <summary>
        /// Cancelled Job
        /// </summary>
        Cancelled = -6,
    }
}
