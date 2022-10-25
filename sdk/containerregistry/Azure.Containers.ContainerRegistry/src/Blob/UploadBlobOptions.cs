// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Options that can be specified to modify blob upload defaults.
    /// </summary>
    public class UploadBlobOptions
    {
        /// <summary>
        /// Creates a new instance of UploadBlobOptions.
        /// </summary>
        /// <param name="maxChunkSize">The maximum size of chunk to upload during the blob upload.</param>
        public UploadBlobOptions(int maxChunkSize)
        {
            MaxChunkSize = maxChunkSize;
        }

        /// <summary>
        /// The maximum size of chunk to upload.
        /// </summary>
        public int MaxChunkSize { get; }
    }
}
