// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Required if the blob has associated snapshots. Specify one of the following two options:
    /// include: Delete the base blob and all of its snapshots.
    /// only: Delete only the blob's snapshots and not the blob itself
    /// </summary>
    public enum DeleteSnapshotsOption
    {
        /// <summary>
        /// none
        /// </summary>
        None,

        /// <summary>
        /// include
        /// </summary>
        IncludeSnapshots,

        /// <summary>
        /// only
        /// </summary>
        OnlySnapshots
    }
}
