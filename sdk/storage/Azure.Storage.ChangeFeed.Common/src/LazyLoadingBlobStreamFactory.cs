// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class LazyLoadingBlobStreamFactory
    {
        public virtual LazyLoadingBlobStream BuildLazyLoadingBlobStream(BlobClient blobClient, long offset, long blockSize)
            => new LazyLoadingBlobStream(blobClient, offset, blockSize);
    }
}
