// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing blobs with the
    /// <see cref="BlobContainerClient.GetBlobsAsync"/> and
    /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync"/>
    /// operations.
    /// </summary>
    public struct GetBlobsOptions : IEquatable<GetBlobsOptions>
    {
        // we can get rid of whole type by making prefix and enums parameters to wherever this type is currently used

        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// blobs whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }  // No Prefix header is produced if ""

        // start enum
        /// <summary>
        /// Gets or sets a flag specifing that metadata related to any current
        /// or previous copy operation should be included.
        /// </summary>
        public bool IncludeCopyOperationStatus { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the blob's metadata should be
        /// included.
        /// </summary>
        public bool IncludeMetadata { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the blob's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        /// </summary>
        public bool IncludeSnapshots { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that blobs for which blocks have
        /// been uploaded, but which have not been committed using
        /// <see cref="Specialized.BlockBlobClient.CommitBlockListAsync"/> should be
        /// included.
        /// </summary>
        public bool IncludeUncommittedBlobs { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that soft deleted blobs should be
        /// included in the response.
        /// </summary>
        public bool IncludeDeletedBlobs { get; set; }

        // end enum
        /// <summary>
        /// Convert the details into ListBlobsIncludeItem values.
        /// </summary>
        /// <returns>ListBlobsIncludeItem values</returns>
        internal IEnumerable<ListBlobsIncludeItem> AsIncludeItems()
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation.
            var items = new List<ListBlobsIncludeItem>();
            if (IncludeCopyOperationStatus) { items.Add(ListBlobsIncludeItem.Copy); }
            if (IncludeDeletedBlobs) { items.Add(ListBlobsIncludeItem.Deleted); }
            if (IncludeMetadata) { items.Add(ListBlobsIncludeItem.Metadata); }
            if (IncludeSnapshots) { items.Add(ListBlobsIncludeItem.Snapshots); }
            if (IncludeUncommittedBlobs) { items.Add(ListBlobsIncludeItem.Uncommittedblobs); }
            return items.Count > 0 ? items : null;
        }

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetBlobsOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the GetBlobsOptions.
        /// </summary>
        /// <returns>Hash code for the GetBlobsOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            ((IncludeCopyOperationStatus ? 0b00001 : 0) +
             (IncludeDeletedBlobs ? 0b00010 : 0) +
             (IncludeMetadata ? 0b00100 : 0) +
             (IncludeSnapshots ? 0b01000 : 0) +
             (IncludeUncommittedBlobs ? 0b10000 : 0)) ^
            (Prefix?.GetHashCode() ?? 0);

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetBlobsOptions left, GetBlobsOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetBlobsOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetBlobsOptions left, GetBlobsOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetBlobsOptions other) =>
            IncludeCopyOperationStatus == other.IncludeCopyOperationStatus &&
            IncludeDeletedBlobs == other.IncludeDeletedBlobs &&
            IncludeMetadata == other.IncludeMetadata &&
            IncludeSnapshots == other.IncludeSnapshots &&
            IncludeUncommittedBlobs == other.IncludeUncommittedBlobs &&
            Prefix == other.Prefix;
    }
}
