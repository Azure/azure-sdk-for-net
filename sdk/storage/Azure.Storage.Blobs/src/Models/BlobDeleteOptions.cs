// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobBaseClient.DeleteAsync(BlobDeleteOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobDeleteOptions
    {
        /// <summary>
        /// Optional.  Specifies options for deleting blob snapshots.
        /// </summary>
        public DeleteSnapshotsOption? SnapshotsOption { get; set; }

        /// <summary>
        /// Optional.  Specifies options for deleting blob snapshots.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional.  Only applicable when deleting blob snapshots or versions on a
        /// storage accounts with Blob Soft Delete enabled.
        /// If specified, the blob snapshots or version will be permanently deleted.
        /// </summary>
        public BlobDeleteType? DeleteType { get; set; }
    }
}
