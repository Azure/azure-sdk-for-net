// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing blobs with the
    /// <see cref="BlobContainerClient.GetBlobsAsync"/> and
    /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync"/>
    /// operations.
    /// </summary>
    [Flags]
    public enum GetBlobOptions
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="GetBlobOptions"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// Flag specifying that metadata related to any current
        /// or previous copy operation should be included.
        /// </summary>
        CopyOperationStatus = 1,
        /// <summary>
        /// Flag specifying that the blob's metadata should be
        /// included.
        /// </summary>
        Metadata = 2,
        /// <summary>
        /// Flag specifying that the blob's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        /// </summary>
        Snapshots = 4,
        /// <summary>
        /// Flag specifying that blobs for which blocks have
        /// been uploaded, but which have not been committed using
        /// <see cref="Specialized.BlockBlobClient.CommitBlockListAsync"/> should be
        /// included.
        /// </summary>
        UncommittedBlobs = 8,
        /// <summary>
        /// Flag specifying that soft deleted blobs should be
        /// included in the response.
        /// </summary>
        DeletedBlobs = 16
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// GetBlobOptions enum extensions
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the details into ListBlobsIncludeItem values.
        /// </summary>
        /// <returns>ListBlobsIncludeItem values</returns>
        internal static IEnumerable<ListBlobsIncludeItem> AsIncludeItems(this GetBlobOptions options)
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation.
            var items = new List<ListBlobsIncludeItem>();
            if (options.HasFlag(GetBlobOptions.CopyOperationStatus))
            { items.Add(ListBlobsIncludeItem.Copy); }
            if (options.HasFlag(GetBlobOptions.DeletedBlobs))
            { items.Add(ListBlobsIncludeItem.Deleted); }
            if (options.HasFlag(GetBlobOptions.Metadata))
            { items.Add(ListBlobsIncludeItem.Metadata); }
            if (options.HasFlag(GetBlobOptions.Snapshots))
            { items.Add(ListBlobsIncludeItem.Snapshots); }
            if (options.HasFlag(GetBlobOptions.UncommittedBlobs))
            { items.Add(ListBlobsIncludeItem.Uncommittedblobs); }
            return items.Count > 0 ? items : null;
        }
    }
}
