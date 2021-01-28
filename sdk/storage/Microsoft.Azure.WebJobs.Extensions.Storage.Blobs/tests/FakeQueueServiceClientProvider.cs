// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class FakeQueueServiceClientProvider : QueueServiceClientProvider
    {
        private readonly QueueServiceClient _queueServiceClient;

        public FakeQueueServiceClientProvider(QueueServiceClient queueServiceClient)
            : base(null, null, null, null)
        {
            _queueServiceClient = queueServiceClient;
        }

        protected override QueueServiceClient CreateClientFromConnectionString(string connectionString, QueueClientOptions options)
        {
            return _queueServiceClient;
        }

        protected override QueueServiceClient CreateClientFromTokenCredential(Uri endpointUri, TokenCredential tokenCredential, QueueClientOptions options)
        {
            return _queueServiceClient;
        }

        public override QueueServiceClient Get(string name)
        {
            return _queueServiceClient;
        }
    }
}
