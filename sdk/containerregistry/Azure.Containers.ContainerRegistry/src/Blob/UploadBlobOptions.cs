// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
            if (maxChunkSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxChunkSize), "Value must be non-zero and positive.");
            }

            MaxChunkSize = maxChunkSize;
        }

        /// <summary>
        /// The maximum size of chunk to upload.
        /// </summary>
        public int MaxChunkSize { get; }
    }
}
