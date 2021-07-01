// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Options to delete a share's snapshots.
    /// </summary>
    public enum ShareSnapshotsDeleteOption
    {
        /// <summary>
        /// The share's snapshots that do not have an active lease will be deleted with the share.
        /// </summary>
        Include,

        /// <summary>
        /// All of the share's snapshots, including those with an active lease, will be deleted with the share.
        /// </summary>
        IncludeWithLeased
    }
}
