// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Options that can be specified to modify blob download defaults.
    /// </summary>
    public class DownloadBlobToOptions
    {
        /// <summary>
        /// Creates a new instance of DownloadBlobOptions.
        /// </summary>
        /// <param name="maxChunkSize">The maximum size of chunk to download during the blob download.</param>
        public DownloadBlobToOptions(int maxChunkSize)
        {
            if (maxChunkSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxChunkSize), "Value must be non-zero and positive.");
            }

            MaxChunkSize = maxChunkSize;
        }

        /// <summary>
        /// The size of the blob to download, if known.
        /// </summary>
        public long? BlobSize { get; set; }

        /// <summary>
        /// The maximum size of chunk to download.
        /// </summary>
        public int MaxChunkSize { get; }
    }
}
