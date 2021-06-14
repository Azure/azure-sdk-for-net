// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.DataMovement
{
    internal static class BlobMovementExtensions
    {
        public static async IAsyncEnumerable<string> GetBlobsByName(this BlobContainerClient client)
        {
            await foreach (Models.BlobItem blob in client.GetBlobsAsync().ConfigureAwait(false))
            {
                yield return blob.Name;
            }
        }

        public static async IAsyncEnumerable<string> GetBlobsByName(this BlobServiceClient client)
        {
            await foreach (Models.BlobContainerItem container in client.GetBlobContainersAsync().ConfigureAwait(false))
            {
                await foreach (Models.BlobItem blob in client.GetBlobContainerClient(container.Name).GetBlobsAsync().ConfigureAwait(false))
                {
                    yield return container.Name + "/" + blob.Name;
                }
            }
        }
    }
}
