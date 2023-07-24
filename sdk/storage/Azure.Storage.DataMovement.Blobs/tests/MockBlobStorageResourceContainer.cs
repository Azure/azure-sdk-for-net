// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

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
