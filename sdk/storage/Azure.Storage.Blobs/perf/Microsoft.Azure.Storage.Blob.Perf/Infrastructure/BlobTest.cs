//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.Blob.Perf
{
    public abstract class BlobTest<TOptions> : ContainerTest<TOptions> where TOptions : SizeOptions
    {
        protected CloudBlockBlob CloudBlockBlob { get; private set; }

        public BlobTest(TOptions options) : base(options)
        {
            var blobName = $"Microsoft.Azure.Storage.Blob.Perf.RandomBlobTest-{Guid.NewGuid()}";
            CloudBlockBlob = CloudBlobContainer.GetBlockBlobReference(blobName);
        }
    }
}
