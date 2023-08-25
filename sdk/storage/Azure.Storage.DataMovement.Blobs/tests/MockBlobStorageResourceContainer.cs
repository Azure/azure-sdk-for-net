// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Azure.Storage.Blobs;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal class MockBlobStorageResourceContainer : BlobStorageResourceContainer
    {
        public MockBlobStorageResourceContainer(
            BlobContainerClient blobContainerClient,
            BlobStorageResourceContainerOptions options = null)
            : base(blobContainerClient, options)
        {
        }

        public async IAsyncEnumerable<StorageResource> MockGetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (StorageResource resource in base.GetStorageResourcesAsync(cancellationToken))
            {
                yield return resource;
            }
        }
    }
}
