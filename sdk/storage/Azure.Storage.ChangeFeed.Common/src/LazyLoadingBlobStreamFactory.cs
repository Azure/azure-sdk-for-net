// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Factory that creates <see cref="LazyLoadingBlobStream"/> instances for on-demand blob downloading.
    /// </summary>
    internal class LazyLoadingBlobStreamFactory
    {
        /// <summary>
        /// Creates a lazy-loading stream that downloads blob content in blocks on demand.
        /// </summary>
        /// <param name="blobClient">The blob client to download from.</param>
        /// <param name="offset">Starting byte offset within the blob.</param>
        /// <param name="blockSize">Number of bytes to download per request.</param>
        /// <returns>A new <see cref="LazyLoadingBlobStream"/>.</returns>
        public virtual LazyLoadingBlobStream BuildLazyLoadingBlobStream(BlobClient blobClient, long offset, long blockSize)
            => new LazyLoadingBlobStream(blobClient, offset, blockSize);
    }
}
