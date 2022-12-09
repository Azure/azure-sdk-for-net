// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the type of storage resource type
    /// </summary>
    public enum StorageResourceType
    {
        /// <summary>
        /// Local File
        /// </summary>
        LocalFile = 0,

        /// <summary>
        /// Block Blob
        /// </summary>
        BlockBlob = 1,

        /// <summary>
        /// Page Blob
        /// </summary>
        PageBlob = 2,

        /// <summary>
        /// Append Blob
        /// </summary>
        AppendBlob = 3,
    }
}
