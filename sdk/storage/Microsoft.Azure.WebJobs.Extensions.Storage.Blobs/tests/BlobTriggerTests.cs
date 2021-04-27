// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobTriggerTests
    {
        private const string ContainerName = "container-blobtriggertests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private BlobServiceClient blobServiceClient;
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
            // make sure our system containers are present
            CreateContainer(blobServiceClient, "azure-webjobs-hosts");
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudBlob_Binds()
        {
            // Arrange
            var container = CreateContainer(blobServiceClient, ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);

            await blob.UploadTextAsync("ignore");

            // Act
            BlobBaseClient result = await RunTriggerAsync<BlobBaseClient>(typeof(BindToCloudBlobProgram),
                (s) => BindToCloudBlobProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(blob.Uri, result.Uri);
        }

        private class BindToCloudBlobProgram
        {
            public static TaskCompletionSource<BlobBaseClient> TaskSource { get; set; }

            public static void Run([BlobTrigger(BlobPath)] BlobBaseClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Test]
        public async Task BlobTrigger_Binding_Metadata()
        {
            var app = new BindToCloudBlob2Program();
            var activator = new FakeActivator(app);
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToCloudBlob2Program>(b =>
                {
                    b.AddAzureStorageBlobs()
                    .UseStorageServices(blobServiceClient, queueServiceClient);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobActivator>(activator);
                })
                .Build();

            // Set the binding data, and verify it's accessible in the function.
            var container = CreateContainer(blobServiceClient, ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await blob.UploadTextAsync(string.Empty);
            await blob.SetMetadataAsync(new Dictionary<string, string> { { "m1", "v1" } });

            await host.GetJobHost().CallAsync(typeof(BindToCloudBlob2Program).GetMethod(nameof(BindToCloudBlob2Program.Run)), new { blob });

            Assert.True(app.Success);
        }

        private class BindToCloudBlob2Program
        {
            public bool Success;
            public void Run(
                [BlobTrigger(BlobPath)] BlobBaseClient blob,
                [Blob("container/{metadata.m1}")] BlobBaseClient blob1
                )
            {
                Assert.AreEqual("v1", blob1.Name);
                this.Success = true;
            }
        }

        private static BlobContainerClient CreateContainer(BlobServiceClient blobServiceClient, string containerName)
        {
            var container = blobServiceClient.GetBlobContainerClient(containerName);
            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            return container;
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b =>
            {
                b.AddAzureStorageBlobs();
                b.UseStorageServices(blobServiceClient, queueServiceClient);
            }, programType, setTaskSource);
        }
    }
}
