// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies states to be used to determine the blobs that will be included
    /// when using the <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, System.Threading.CancellationToken)"/>
    /// operations.
    /// </summary>
    [Flags]
    public enum BlobStates
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="BlobStates"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the blob's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        /// </summary>
        Snapshots = 1,

        /// <summary>
        /// Flag specifying that blobs for which blocks have
        /// been uploaded, but which have not been committed using
        /// <see cref="Specialized.BlockBlobClient.CommitBlockListAsync(System.Collections.Generic.IEnumerable{string}, CommitBlockListOptions, System.Threading.CancellationToken)"/> should be
        /// included.
        /// </summary>
        Uncommitted = 2,

        /// <summary>
        /// Flag specifying that soft deleted blobs should be
        /// included in the response.
        /// </summary>
        Deleted = 4,

        /// <summary>
        /// Flag specifying that the blob's version should be
        /// included.  Versions are listed from oldest to newest.
        /// </summary>
        Version = 8,

        /// <summary>
        /// Flag specifying to list blobs that were deleted with
        /// versioning enabled.
        /// </summary>
        DeletedWithVersions = 16,

        /// <summary>
        /// Flag specifying that blobs of all states should be included.
        /// </summary>
        All = ~None
    }
}
