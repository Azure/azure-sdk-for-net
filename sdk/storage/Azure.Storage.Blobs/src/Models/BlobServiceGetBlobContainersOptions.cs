// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for BlobServiceClient.GetBlobContainers.
    /// </summary>
    public class BlobServiceGetBlobContainersOptions
    {
        /// <summary>
        /// Specifies trait options for shaping the blob containers.
        /// </summary>
        public BlobContainerTraits Traits { get; set; }

        /// <summary>
        /// Specifies state options for shaping the blob containers.
        /// </summary>
        public BlobContainerStates States { get; set; }

        /// <summary>
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified <c>prefix</c>.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
