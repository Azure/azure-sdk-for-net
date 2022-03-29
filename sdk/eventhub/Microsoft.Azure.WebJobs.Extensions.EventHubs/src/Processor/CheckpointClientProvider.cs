// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class CheckpointClientProvider : StorageClientProvider<BlobServiceClient, BlobClientOptions>
    {
        public CheckpointClientProvider(IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder, ILogger<BlobServiceClient> logger)
            : base(configuration, componentFactory, logForwarder, logger) { }

        /// <inheritdoc/>
        protected override string ServiceUriSubDomain => "blob";
    }
}