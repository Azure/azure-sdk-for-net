// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobServiceClient.RenameBlobContainer(string, string, BlobServiceRenameBlobContainerOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    internal class BlobServiceRenameBlobContainerOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> that
        /// source container has to meet to proceed with rename.
        /// Note that LeaseId is the only request condition enforced by
        /// this API.
        /// </summary>
        public BlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
