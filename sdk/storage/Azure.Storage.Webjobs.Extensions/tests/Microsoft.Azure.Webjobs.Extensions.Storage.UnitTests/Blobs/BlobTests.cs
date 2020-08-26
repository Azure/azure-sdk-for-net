// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;
using Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class BlobTests : IClassFixture<AzuriteFixture>
    {
        private const string TriggerQueueName = "input";
        private const string ContainerName = "container";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;

        private readonly AzuriteFixture azuriteFixture;

        public BlobTests(AzuriteFixture azuriteFixture)
        {
            this.azuriteFixture = azuriteFixture;
        }

        [Fact]
        public async Task Blob_IfBoundToCloudBlockBlob_BindsAndCreatesContainerButNotBlob()
        {
            // Act
            var azuriteAccount = azuriteFixture.GetAccount();
            var account = StorageAccount.NewFromConnectionString(azuriteAccount.ConnectionString);

            var prog = new BindToCloudBlockBlobProgram();
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToCloudBlockBlobProgram>(prog, builder =>
                {
                    builder.AddAzureStorage()
                    .UseStorage(account);
                })
                .Build();

            var jobHost = host.GetJobHost<BindToCloudBlockBlobProgram>();
            await jobHost.CallAsync(nameof(BindToCloudBlockBlobProgram.Run));

            var result = prog.Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(BlobName, result.Name);
            Assert.NotNull(result.Container);
            Assert.Equal(ContainerName, result.Container.Name);
            CloudBlobContainer container = GetContainerReference(account, ContainerName);
            Assert.True(await container.ExistsAsync());
            CloudBlockBlob blob = container.GetBlockBlobReference(BlobName);
            Assert.False(await blob.ExistsAsync());
        }

        [Fact]
        public async Task Blob_IfBoundToTextWriter_CreatesBlob()
        {
            // Arrange
            const string expectedContent = "message";
            var azuriteAccount = azuriteFixture.GetAccount();
            var account = StorageAccount.NewFromConnectionString(azuriteAccount.ConnectionString);
            QueueClient triggerQueue = CreateQueue(account, TriggerQueueName);
            await triggerQueue.SendMessageAsync(expectedContent);

            // Act
            await RunTrigger(account, typeof(BindToTextWriterProgram));

            // Assert
            CloudBlobContainer container = GetContainerReference(account, ContainerName);
            Assert.True(await container.ExistsAsync());
            CloudBlockBlob blob = container.GetBlockBlobReference(BlobName);
            Assert.True(await blob.ExistsAsync());
            string content = blob.DownloadText();
            Assert.Equal(expectedContent, content);
        }

        private static QueueClient CreateQueue(StorageAccount account, string queueName)
        {
            var client = account.CreateQueueServiceClient();
            var queue = client.GetQueueClient(queueName);
            queue.CreateIfNotExists();
            return queue;
        }

        private static CloudBlobContainer GetContainerReference(StorageAccount account, string containerName)
        {
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(ContainerName);
        }

        private static async Task RunTrigger(StorageAccount account, Type programType)
        {
            await FunctionalTest.RunTriggerAsync(account, programType);
        }

        private static async Task<TResult> RunTrigger<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource);
        }

        private class BindToCloudBlockBlobProgram
        {
            public CloudBlockBlob Result { get; set; }

            public void Run(
                [Blob(BlobPath)] CloudBlockBlob blob)
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
