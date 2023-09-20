// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal class MockAppendBlobStorageResource : AppendBlobStorageResource
    {
        public MockAppendBlobStorageResource(
            AppendBlobClient blobClient,
            AppendBlobStorageResourceOptions options = null)
            : base(blobClient, options)
        {
        }

        internal MockAppendBlobStorageResource(
            AppendBlobClient blobClient,
            long? length,
            ETag? etagLock,
            AppendBlobStorageResourceOptions options = default)
            : base(blobClient, length, etagLock, options)
        {
        }

        internal MockAppendBlobStorageResource(
            AppendBlobStorageResource resource)
            : base(resource.BlobClient,
                  resource._length,
                  resource._etagDownloadLock,
                  resource._options)
        {
        }

        public async Task<StorageResourceProperties> MockGetPropertiesAsync(CancellationToken cancellationToken = default)
            => await base.GetPropertiesAsync(cancellationToken);

        public async Task<StorageResourceReadStreamResult> MockReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
            => await base.ReadStreamAsync(position, length, cancellationToken);
    }
}
