// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using BenchmarkDotNet.Engines;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobTests
    {
        private const string TriggerQueueName = "input-blobtests";
        private const string ConnectionName = "AzureWebJobsStorage";
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
            var host = new HostBuilder()
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
            var host = new HostBuilder()
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

        [Test]
        public async Task Blob_IfBoundToParameterBindingData_CreatesParameterBindingData()
        {
            // Arrange
            string connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        { "ConnectionStrings:AzureWebJobsStorage", connectionString }
                    }).Build();

            var program = new BindToParameterBindingData();
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToParameterBindingData>(program, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServicesWithConfiguration(blobServiceClient, queueServiceClient, configuration);
                })
                .Build();

            var jobHost = host.GetJobHost<BindToParameterBindingData>();

            // Act
            await jobHost.CallAsync(nameof(BindToParameterBindingData.Run));
            ParameterBindingData result = program.Result;

            Assert.NotNull(result);

            var blobData = result?.Content.ToObjectFromJson<Dictionary<string,string>>();

            // Assert
            Assert.True(blobData.TryGetValue("Connection", out var resultConnection));
            Assert.True(blobData.TryGetValue("ContainerName", out var resultContainerName));
            Assert.True(blobData.TryGetValue("BlobName", out var resultBlobName));

            Assert.AreEqual(ConnectionName, resultConnection);
            Assert.AreEqual(ContainerName, resultContainerName);
            Assert.AreEqual(BlobName, resultBlobName);
        }

        [Test]
        public async Task Blob_IfBoundToParameterBindingData_Container_CreatesParameterBindingData()
        {
            // Arrange
            string connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        { "ConnectionStrings:AzureWebJobsStorage", connectionString }
                    }).Build();

            var program = new BindToParameterBindingDataBlobContainer();
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToParameterBindingDataBlobContainer>(program, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServicesWithConfiguration(blobServiceClient, queueServiceClient, configuration);
                })
                .Build();

            var jobHost = host.GetJobHost<BindToParameterBindingDataBlobContainer>();

            // Act
            await jobHost.CallAsync(nameof(BindToParameterBindingDataBlobContainer.Run));
            ParameterBindingData result = program.Result;

            Assert.NotNull(result);

            var blobData = result?.Content.ToObjectFromJson<Dictionary<string, string>>();

            // Assert
            Assert.True(blobData.TryGetValue("Connection", out var resultConnection));
            Assert.True(blobData.TryGetValue("ContainerName", out var resultContainerName));
            Assert.True(blobData.TryGetValue("BlobName", out var resultBlobName));

            Assert.AreEqual(ConnectionName, resultConnection);
            Assert.AreEqual(ContainerName, resultContainerName);
            Assert.IsEmpty(resultBlobName);
        }

        [Test]
        public async Task Blob_IfBoundToParameterBindingDataEnumerable_CreatesParameterBindingDataArray()
        {
            string connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        { "ConnectionStrings:AzureWebJobsStorage", connectionString }
                    }).Build();

            // Arrange
            var program = new BindToParameterBindingDataEnumerable();
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToParameterBindingDataEnumerable>(program, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServicesWithConfiguration(blobServiceClient, queueServiceClient, configuration);
                })
                .Build();

            var container = CreateContainer(blobServiceClient, ContainerName);
            var blobfile = container.GetBlockBlobClient(BlobName);
            await blobfile.UploadTextAsync(string.Empty);

            var jobHost = host.GetJobHost<BindToParameterBindingDataEnumerable>();

            // Act
            await jobHost.CallAsync(nameof(BindToParameterBindingDataEnumerable.Run));
            IEnumerable<ParameterBindingData> result = program.Result;

            Assert.NotNull(result);

            // Assert
            foreach (var blob in result)
            {
                var blobData = blob?.Content.ToObjectFromJson<Dictionary<string,string>>();

                Assert.True(blobData.TryGetValue("Connection", out var resultConnection));
                Assert.True(blobData.TryGetValue("ContainerName", out var resultContainerName));
                Assert.True(blobData.TryGetValue("BlobName", out var resultBlobName));

                Assert.AreEqual(ConnectionName, resultConnection);
                Assert.AreEqual(ContainerName, resultContainerName);
                Assert.AreEqual(BlobName, resultBlobName);
            }
        }

        [Test]
        public async Task Blob_IfBoundToStringArray_CreatesStringArray()
        {
            string connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        { "ConnectionStrings:AzureWebJobsStorage", connectionString }
                    }).Build();

            // Arrange
            var program = new BindToStringArray();
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToStringArray>(program, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServicesWithConfiguration(blobServiceClient, queueServiceClient, configuration);
                })
                .Build();

            var container = CreateContainer(blobServiceClient, ContainerName);
            var blobfile = container.GetBlockBlobClient(BlobName);
            await blobfile.UploadTextAsync("teststring");

            var jobHost = host.GetJobHost<BindToStringArray>();

            // Act
            await jobHost.CallAsync(nameof(BindToStringArray.Run));
            string[] result = program.Result;

            Assert.NotNull(result);

            // Assert
            foreach (var blob in result)
            {
                Assert.AreEqual("teststring", blob);
            }
        }

        [Test]
        public async Task Blob_IfBoundToParameterBindingDataArray_CreatesParameterBindingDataArray()
        {
            string connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        { "ConnectionStrings:AzureWebJobsStorage", connectionString }
                    }).Build();

            // Arrange
            var program = new BindToParameterBindingDataArray();
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToParameterBindingDataArray>(program, builder =>
                {
                    builder.AddAzureStorageBlobs()
                    .UseStorageServicesWithConfiguration(blobServiceClient, queueServiceClient, configuration);
                })
                .Build();

            var container = CreateContainer(blobServiceClient, ContainerName);
            var blobfile = container.GetBlockBlobClient(BlobName);
            await blobfile.UploadTextAsync(string.Empty);

            var jobHost = host.GetJobHost<BindToParameterBindingDataArray>();

            // Act
            await jobHost.CallAsync(nameof(BindToParameterBindingDataArray.Run));
            ParameterBindingData[] result = program.Result;

            Assert.NotNull(result);

            foreach (var blob in result)
            {
                var blobData = blob?.Content.ToObjectFromJson<Dictionary<string,string>>();

                Assert.True(blobData.TryGetValue("Connection", out var resultConnection));
                Assert.True(blobData.TryGetValue("ContainerName", out var resultContainerName));
                Assert.True(blobData.TryGetValue("BlobName", out var resultBlobName));

                Assert.AreEqual(ConnectionName, resultConnection);
                Assert.AreEqual(ContainerName, resultContainerName);
                Assert.AreEqual(BlobName, resultBlobName);
            }
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

        private static BlobContainerClient CreateContainer(BlobServiceClient blobServiceClient, string containerName)
        {
            var container = blobServiceClient.GetBlobContainerClient(containerName);
            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            return container;
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

        private class BindToParameterBindingData
        {
            public ParameterBindingData Result { get; set; }

            public void Run(
                [Blob(BlobPath)] ParameterBindingData blobData)
            {
                this.Result = blobData;
            }
        }

        private class BindToParameterBindingDataBlobContainer
        {
            public ParameterBindingData Result { get; set; }

            public void Run(
                [Blob(ContainerName)] ParameterBindingData blobData)
            {
                this.Result = blobData;
            }
        }

        private class BindToParameterBindingDataEnumerable
        {
            public IEnumerable<ParameterBindingData> Result { get; set; }

            public void Run(
                [Blob(ContainerName)] IEnumerable<ParameterBindingData> blobs)
            {
                this.Result = blobs;
            }
        }

        private class BindToStringArray
        {
            public string[] Result { get; set; }

            public void Run(
                [Blob(ContainerName)] string[] blobs)
            {
                this.Result = blobs;
            }
        }

        private class BindToParameterBindingDataArray
        {
            public ParameterBindingData[] Result { get; set; }

            public void Run(
                [Blob(ContainerName)] ParameterBindingData[] blobs)
            {
                this.Result = blobs;
            }
        }
    }
}
