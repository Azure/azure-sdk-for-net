// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Batch.Models
{
    /// <summary>
    /// Options for a delete blob operation within a batch request.
    /// </summary>
    public class DeleteBlobOptions
    {
        /// <summary>
        /// Specifies options for deleting blob snapshots.
        /// </summary>
        public DeleteSnapshotsOption SnapshotsOption { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// deleting this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Version ID of the blob to delete.
        /// </summary>
        public string VersionID { get; set; }
    }
}
