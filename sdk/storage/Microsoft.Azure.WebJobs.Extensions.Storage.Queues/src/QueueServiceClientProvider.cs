// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    internal class QueueServiceClientProvider : StorageClientProvider<QueueServiceClient, QueueClientOptions>
    {
        private readonly QueuesOptions _queuesOptions;

        public QueueServiceClientProvider(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            AzureEventSourceLogForwarder logForwarder,
            IOptions<QueuesOptions> queueOptions)
            : base(configuration, componentFactory, logForwarder)
        {
            _queuesOptions = queueOptions?.Value;
        }

        protected override QueueServiceClient CreateClientFromConnectionString(string connectionString, QueueClientOptions options)
        {
            options.MessageEncoding = _queuesOptions.MessageEncoding;
            return new QueueServiceClient(connectionString, options);
        }

        protected override QueueServiceClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, QueueClientOptions options)
        {
            options.MessageEncoding = _queuesOptions.MessageEncoding;
            return new QueueServiceClient(endpointUri, tokenCredential, options);
        }
    }
}
