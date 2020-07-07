// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Creates LazyLoadingBlobStreams.  Allows us to inject mock
    /// LazyLoadingBlobStreams in the Chunk unit tests.
    /// </summary>
    internal class LazyLoadingBlobStreamFactory
    {
        public virtual LazyLoadingBlobStream BuildLazyLoadingBlobStream(
            BlobClient blobClient,
            long offset,
            long blockSize)
            => new LazyLoadingBlobStream(
                blobClient,
                offset,
                blockSize);
    }
}
