﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class QueueServiceClientProvider : StorageClientProvider<QueueServiceClient, QueueClientOptions>
    {
        public QueueServiceClientProvider(IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder)
            : base(configuration, componentFactory, logForwarder) {}

        protected override QueueServiceClient CreateClientFromConnectionString(string connectionString, QueueClientOptions options)
        {
            return new QueueServiceClient(connectionString, options);
        }

        protected override QueueServiceClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, QueueClientOptions options)
        {
            return new QueueServiceClient(endpointUri, tokenCredential, options);
        }
    }
}
