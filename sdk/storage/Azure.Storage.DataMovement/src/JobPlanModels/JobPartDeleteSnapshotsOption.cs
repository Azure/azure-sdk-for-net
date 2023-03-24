// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Required if the blob has associated snapshots. Specify one of the following two options:
    /// include: Delete the base blob and all of its snapshots.
    /// only: Delete only the blob's snapshots and not the blob itself
    /// </summary>
    internal enum JobPartDeleteSnapshotsOption
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,

        /// <summary>
        /// include
        /// </summary>
        IncludeSnapshots = 1,

        /// <summary>
        /// only
        /// </summary>
        OnlySnapshots = 2,
    }
}
