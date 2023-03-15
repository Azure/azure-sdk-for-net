// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Options to pass to the DownloadBlobTo method.
    /// </summary>
    public class DownloadBlobToOptions
    {
        private readonly int _maxChunkSize;

        /// <summary>
        /// Creates a new instance of DownloadBlobToOptions.
        /// </summary>
        /// <param name="maxChunkSize">The maximum size of chunk to transfer in a single request.</param>
        public DownloadBlobToOptions(int maxChunkSize)
        {
            _maxChunkSize= maxChunkSize;
        }

        /// <summary>
        /// The maximum size of chunk to transfer in a single request.
        /// </summary>
        public int MaxChunkSize => _maxChunkSize;
    }
}
