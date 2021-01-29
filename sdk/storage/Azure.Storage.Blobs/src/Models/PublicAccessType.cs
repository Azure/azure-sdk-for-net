// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies whether data in the container may be accessed publicly and the level of access.
    /// </summary>
    public enum PublicAccessType
    {
        /// <summary>
        /// none
        /// </summary>
        None,

        /// <summary>
        /// container
        /// </summary>
        BlobContainer,

        /// <summary>
        /// blob
        /// </summary>
        Blob
    }
}
