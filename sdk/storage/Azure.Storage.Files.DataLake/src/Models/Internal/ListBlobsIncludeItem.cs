// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The ListBlobsIncludeItem.
    /// </summary>
    internal enum ListBlobsIncludeItem
    {
        /// <summary>
        /// copy.
        /// </summary>
        Copy,

        /// <summary>
        /// deleted.
        /// </summary>
        Deleted,

        /// <summary>
        /// metadata.
        /// </summary>

        Metadata,

        /// <summary>
        /// snapshots.
        /// </summary>
        Snapshots,

        /// <summary>
        /// uncommittedblobs.
        /// </summary>
        Uncommittedblobs,

        /// <summary>
        /// versions.
        /// </summary>
        Versions,

        /// <summary>
        /// tags.
        /// </summary>
        Tags
    }
}
