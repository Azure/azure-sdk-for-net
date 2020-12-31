﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobTests
    {
        private const string TriggerQueueName = "input-blobtests";
        private const string ContainerName = "container-blobtests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;

        private BlobServiceClient blobServiceClient;
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
            queueServiceClient.GetQueueClient(TriggerQueueName).DeleteIfExists();
        }

        [Test]
        public async Task Blob_IfBoundToCloudBlockBlob_BindsAndCreatesContainerButNotBlob()
        {
            // Act
            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToCloudBlockBlobProgram>(prog, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServices(blobServiceClient, queueServiceClient);
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(BlobName, result.Name);
            Assert.NotNull(result.BlobContainerName);
            Assert.AreEqual(ContainerName, result.BlobContainerName);
            var container = GetContainerReference(blobServiceClient, ContainerName);
            Assert.True(await container.ExistsAsync());
            var blob = container.GetBlockBlobClient(BlobName);
            Assert.False(await blob.ExistsAsync());
        }

        [Test]
        public async Task Blob_IfBoundToBlobClient_BindsAndCreatesContainerButNotBlob()
        {
            // Act
            var prog = new BindToBlobClientProgram();
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToBlobClientProgram>(prog, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServices(blobServiceClient, queueServiceClient);
                })
                .Build();

            var jobHost = host.GetJobHost<BindToBlobClientProgram>();
            await jobHost.CallAsync(nameof(BindToBlobClientProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(BlobName, result.Name);
            Assert.NotNull(result.BlobContainerName);
            Assert.AreEqual(ContainerName, result.BlobContainerName);
            var container = GetContainerReference(blobServiceClient, ContainerName);
            Assert.True(await container.ExistsAsync());
            var blob = container.GetBlockBlobClient(BlobName);
            Assert.False(await blob.ExistsAsync());
        }

        [Test]
        public async Task Blob_IfBoundToTextWriter_CreatesBlob()
        {
            // Arrange
            const string expectedContent = "message";
            QueueClient triggerQueue = CreateQueue(TriggerQueueName);
            await triggerQueue.SendMessageAsync(expectedContent);

            // Act
            await RunTrigger(typeof(BindToTextWriterProgram));

            // Assert
            var container = GetContainerReference(blobServiceClient, ContainerName);
            Assert.True(await container.ExistsAsync());
            var blob = container.GetBlockBlobClient(BlobName);
            Assert.True(await blob.ExistsAsync());
            string content = await blob.DownloadTextAsync();
            Assert.AreEqual(expectedContent, content);
        }

        private QueueClient CreateQueue(string queueName)
        {
            var queue = queueServiceClient.GetQueueClient(queueName);
            queue.CreateIfNotExists();
            return queue;
        }

        private static BlobContainerClient GetContainerReference(BlobServiceClient blobServiceClient, string containerName)
        {
            return blobServiceClient.GetBlobContainerClient(containerName);
        }

        private async Task RunTrigger(Type programType)
        {
            await FunctionalTest.RunTriggerAsync(b => {
                b.Services.AddAzureClients(builder =>
                {
                    builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport());
                });
                b.AddAzureStorageBlobs();
                b.AddAzureStorageQueues();
            }, programType,
            settings: new Dictionary<string, string>() {
                // This takes precedence over env variables.
                { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
            });
        }

        private class BindToCloudBlockBlobProgram
        {
            public BlockBlobClient Result { get; set; }

            public void Run(
                [Blob(BlobPath)] BlockBlobClient blob)
            {
                this.Result = blob;
            }
        }

        private class BindToBlobClientProgram
        {
            public BlobClient Result { get; set; }

            public void Run(
                [Blob(BlobPath)] BlobClient blob)
            {
                this.Result = blob;
            }
        }

        private class BindToTextWriterProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] string message,
                [Blob(BlobPath)] TextWriter blob)
            {
                blob.Write(message);
                blob.Flush();
            }
        }
    }
}
