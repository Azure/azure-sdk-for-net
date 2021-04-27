//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class BlobTest<TOptions> : ContainerTest<TOptions> where TOptions : SizeOptions
    {
        protected BlobClient BlobClient { get; private set; }
        protected BlockBlobClient BlockBlobClient { get; private set; }

        public BlobTest(TOptions options) : base(options)
        {
            var blobName = $"Azure.Storage.Blobs.Perf.BlobTest-{Guid.NewGuid()}";

            BlobClient = BlobContainerClient.GetBlobClient(blobName);
            BlockBlobClient = BlobContainerClient.GetBlockBlobClient(blobName);
        }
    }
}
