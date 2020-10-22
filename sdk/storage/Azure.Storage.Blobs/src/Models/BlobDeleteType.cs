// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The type of blob deletion.  Only applicable when deleting blob snapshots or versions on a
    /// storage accounts with Blob Soft Delete enabled.
    /// </summary>
    public enum BlobDeleteType
    {
        /// <summary>
        /// If this option is specified, the blob snapshot or version will be permanently delete.
        /// </summary>
        Permanent
    }
}
