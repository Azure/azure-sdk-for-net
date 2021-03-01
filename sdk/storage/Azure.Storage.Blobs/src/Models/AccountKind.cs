// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Identifies the account kind.
    /// </summary>
    public enum AccountKind
    {
        /// <summary>
        /// Storage
        /// </summary>
        Storage,

        /// <summary>
        /// BlobStorage
        /// </summary>
        BlobStorage,

        /// <summary>
        /// StorageV2
        /// </summary>
        StorageV2,

        /// <summary>
        /// FileStorage
        /// </summary>
        FileStorage,

        /// <summary>
        /// BlockBlobStorage
        /// </summary>
        BlockBlobStorage
    }
}
