// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class DisposingBlobContainer : IDisposingContainer<BlobContainerClient>
    {
        public BlobContainerClient Container { get; private set; }

        public DisposingBlobContainer(BlobContainerClient client)
        {
            Container = client;
        }

        public async ValueTask DisposeAsync()
        {
            if (Container != null)
            {
                try
                {
                    await Container.DeleteIfExistsAsync();
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
