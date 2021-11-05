// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class BlobWithContainer<T> where T: BlobBaseClient
    {
        public BlobWithContainer(BlobContainerClient blobContainerClient, T blobClient)
        {
            BlobContainerClient = blobContainerClient;
            BlobClient = blobClient;
        }

        public BlobContainerClient BlobContainerClient { get; }
        public T BlobClient { get; }
    }
}
