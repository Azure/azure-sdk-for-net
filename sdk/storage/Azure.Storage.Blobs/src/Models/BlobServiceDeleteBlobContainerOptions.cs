// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobServiceClient.DeleteBlobContainer(string, BlobServiceDeleteBlobContainerOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobServiceDeleteBlobContainerOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the deletion of this container.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
