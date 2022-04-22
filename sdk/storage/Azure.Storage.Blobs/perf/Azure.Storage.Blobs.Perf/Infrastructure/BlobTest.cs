// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class BlobTest<TOptions> : ContainerTest<TOptions> where TOptions : SizeOptions
    {
        protected string BlobName { get; } = $"Azure.Storage.Blobs.Perf.BlobTest-{Guid.NewGuid()}";
        protected BlobClient BlobClient { get; private set; }
        protected BlockBlobClient BlockBlobClient { get; private set; }

        public BlobTest(TOptions options) : base(options)
        {
            BlobClient = BlobContainerClient.GetBlobClient(BlobName);
            BlockBlobClient = BlobContainerClient.GetBlockBlobClient(BlobName);
        }
    }
}
