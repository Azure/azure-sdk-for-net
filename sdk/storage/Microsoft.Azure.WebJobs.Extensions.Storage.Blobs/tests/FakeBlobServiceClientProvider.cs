// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;

namespace Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    internal class FakeBlobServiceClientProvider : BlobServiceClientProvider
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FakeBlobServiceClientProvider(BlobServiceClient blobServiceClient)
            : base(null, null, null) {
            _blobServiceClient = blobServiceClient;
        }

        protected override BlobServiceClient CreateClientFromConnectionString(string connectionString, BlobClientOptions options)
        {
            return _blobServiceClient;
        }

        protected override BlobServiceClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, BlobClientOptions options)
        {
            return _blobServiceClient;
        }

        public override BlobServiceClient Get(string name)
        {
            return _blobServiceClient;
        }
    }
}
