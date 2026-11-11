// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for BlobBaseClient.SetHttpHeaders.
    /// </summary>
    public class BlobSetHttpHeadersOptions
    {
        /// <summary>
        /// Optional. The standard HTTP header system properties to set.
        /// If not specified, existing values will be cleared.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the blob's HTTP headers.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
