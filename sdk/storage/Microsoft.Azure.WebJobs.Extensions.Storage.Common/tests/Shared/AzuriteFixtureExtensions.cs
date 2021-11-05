// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Test.Shared;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public static class AzuriteFixtureExtensions
    {
        public static BlobServiceClient GetBlobServiceClient(this AzuriteFixture azuriteFixture)
        {
            var transport = azuriteFixture.GetTransport();
            return new BlobServiceClient(azuriteFixture.GetAzureAccount().ConnectionString, new BlobClientOptions()
            {
                Transport = transport
            });
        }

        public static QueueServiceClient GetQueueServiceClient(this AzuriteFixture azuriteFixture, QueueClientOptions queueClientOptions = default)
        {
            if (queueClientOptions == default)
            {
                queueClientOptions = new QueueClientOptions()
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                };
            }

            queueClientOptions.Transport = azuriteFixture.GetTransport();
            return new QueueServiceClient(azuriteFixture.GetAzureAccount().ConnectionString, queueClientOptions);
        }
    }
}