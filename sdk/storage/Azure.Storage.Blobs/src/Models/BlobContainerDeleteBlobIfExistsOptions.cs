// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobContainerClient.DeleteBlobIfExists(string, BlobContainerDeleteBlobIfExistsOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobContainerDeleteBlobIfExistsOptions
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
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
