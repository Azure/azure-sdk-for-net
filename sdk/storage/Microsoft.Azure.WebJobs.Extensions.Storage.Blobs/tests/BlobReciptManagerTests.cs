// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    public class BlobReciptManagerTests
    {
        private const string ConnectionName = "AzureWebJobsStorage";
        private const string ContainerName = "container-blobreciptmanagertests";
        private BlobServiceClient blobServiceClient;

        [SetUp]
        public void SetUp()
        {
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
            // make sure our system containers are present
            CreateContainer(blobServiceClient, ContainerName);
        }

        private static BlobContainerClient CreateContainer(BlobServiceClient blobServiceClient, string containerName)
        {
            var container = blobServiceClient.GetBlobContainerClient(containerName);
            container.CreateIfNotExists();
            return container;
        }

        private static BlobContainerClient GetContainerReference(BlobServiceClient blobServiceClient, string containerName)
        {
            return blobServiceClient.GetBlobContainerClient(containerName);
        }

        [Test]
        public async Task TryAcquireLeaseNotLogLeaseConflict()
        {
            // Arrange
            BlobContainerClient container = GetContainerReference(blobServiceClient, ContainerName);
            BlobClient blob = container.GetBlobClient(Guid.NewGuid().ToString());
            await blob.UploadAsync(BinaryData.FromString("Hello world"));

            BlobLeaseClient leaseClient = blob.GetBlobLeaseClient();
            BlobLease lease = await leaseClient.AcquireAsync(BlobLeaseClient.InfiniteLeaseDuration);

            // Act
            var messages = new List<string>();
            using (var listener = new AzureEventSourceListener((e, message) =>
            {
                if (e.EventSource.Name == "Azure-Core")
                {
                    messages.Add(message);
                }
            }, System.Diagnostics.Tracing.EventLevel.Warning))
            {
                await new BlobReceiptManager(blobServiceClient)
                    .TryAcquireLeaseAsync(container.GetBlockBlobClient(blob.Name), CancellationToken.None);
            }

            // Assert
            Assert.IsEmpty(messages);
        }
    }
}
