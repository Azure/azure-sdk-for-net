﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class BlobServiceClientProvider : StorageClientProvider<BlobServiceClient, BlobClientOptions>
    {
        public BlobServiceClientProvider(IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder)
            : base(configuration, componentFactory, logForwarder) {}

        protected override BlobServiceClient CreateClientFromConnectionString(string connectionString, BlobClientOptions options)
        {
            return new BlobServiceClient(connectionString, options);
        }

        protected override BlobServiceClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, BlobClientOptions options)
        {
            return new BlobServiceClient(endpointUri, tokenCredential, options);
        }
    }
}
