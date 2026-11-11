// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobContainerClient.GetProperties(BlobContainerGetPropertiesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobContainerGetPropertiesOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob container's properties.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
