// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class FakeBlobServiceClientProvider : BlobServiceClientProvider
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FakeBlobServiceClientProvider(BlobServiceClient blobServiceClient)
            : base(null, null, null, null) {
            _blobServiceClient = blobServiceClient;
        }

        public FakeBlobServiceClientProvider(BlobServiceClient blobServiceClient, IConfiguration configuration)
            : base(configuration, null, null, null) {
            _blobServiceClient = blobServiceClient;
        }

        public override BlobServiceClient Get(string name)
        {
            return _blobServiceClient;
        }
    }
}
