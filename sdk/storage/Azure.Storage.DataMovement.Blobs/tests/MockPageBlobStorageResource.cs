// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal class MockPageBlobStorageResource : PageBlobStorageResource
    {
        public MockPageBlobStorageResource(
            PageBlobClient blobClient,
            PageBlobStorageResourceOptions options = null)
            : base(blobClient, options)
        {
        }

        internal MockPageBlobStorageResource(
            PageBlobClient blobClient,
            long? length,
            ETag? etagLock,
            PageBlobStorageResourceOptions options = default)
            : base(blobClient, length, etagLock, options)
        {
        }

        internal MockPageBlobStorageResource(
            PageBlobStorageResource resource)
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
