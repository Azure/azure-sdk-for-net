// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobServiceClient.GetProperties(BlobServiceGetPropertiesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobServiceGetPropertiesOptions
    {
        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
