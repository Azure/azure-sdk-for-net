// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies trait information to be included when listing blobs with the
    /// <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, System.Threading.CancellationToken)"/>
    /// operations.
    /// </summary>
    [Flags]
    public enum BlobTraits
    {
        /// <summary>
        /// Flag specifying only the default information for blobs
        /// should be included.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that metadata related to any current
        /// or previous copy operation should be included.
        /// </summary>
        CopyStatus = 1,

        /// <summary>
        /// Flag specifying that the blob's metadata should be
        /// included.
        /// </summary>
        Metadata = 2,

        /// <summary>
        /// Flag specifying that the blob's tags should be included.
        /// </summary>
        Tags = 4,

        /// <summary>
        /// Flag specifying that the blob's immutibility policy should be included.
        /// </summary>
        ImmutabilityPolicy = 8,

        /// <summary>
        /// Flag specifying that the blob's legal hold should be included.
        /// </summary>
        LegalHold = 16,

        /// <summary>
        /// Flag specifying that all traits should be included.
        /// </summary>
        All = ~None
    }
}
