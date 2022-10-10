// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Specifies states to be used to determine the blobs that will be included
    /// when using the <see cref="StorageResourceContainer.ListStorageResources(ListStorageResourceOptions, CancellationToken)"/>.
    /// operations.
    /// </summary>
    [Flags]
    public enum StorageResourceListStates
    {
        /// <summary>
        /// Default flag specifying that no flags are set in.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the blob's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        ///
        /// Applies for blobs only.
        /// </summary>
        Snapshots = 1,

        /// <summary>
        /// Flag specifying that blobs for which blocks have
        /// been uploaded, but which have not been committed.
        ///
        /// Applies for blobs only.
        /// </summary>
        Uncommitted = 2,

        /// <summary>
        /// Flag specifying that soft deleted blobs should be
        /// included in the response.
        ///
        /// Applies for blobs only.
        /// </summary>
        Deleted = 4,

        /// <summary>
        /// Flag specifying that the blob's version should be
        /// included.  Versions are listed from oldest to newest.
        ///
        /// Applies for blobs only.
        /// </summary>
        Version = 8,

        /// <summary>
        /// Flag specifying to list blobs that were deleted with
        /// versioning enabled.
        ///
        /// Applies for blobs only.
        /// </summary>
        DeletedWithVersions = 16,

        /// <summary>
        /// Flag specifying that blobs of all states should be included.
        /// </summary>
        All = ~None
    }
}
