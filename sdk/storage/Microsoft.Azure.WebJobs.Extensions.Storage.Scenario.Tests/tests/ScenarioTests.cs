// Copyright (c) Microsoft Corporation. All rights reserved.
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

namespace Microsoft.Azure.WebJobs.Extensions.Storage.ScenarioTests
{
    public class ScenarioTests
    {
        private const string ContainerName = "container-scenariotests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private const string OutputBlobName = "blob.out";
        private const string OutputBlobPath = ContainerName + "/" + OutputBlobName;
        private const string QueueName = "queue-scenariotests";
        private BlobServiceClient blobServiceClient;
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
            // make sure our system containers are present
            blobServiceClient.GetBlobContainerClient("azure-webjobs-hosts").CreateIfNotExists();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
        }

        [Test]
        public async Task BlobTriggerToQueueTriggerToBlob_WritesFinalBlob()
        {
            // Arrange
            var container = await CreateContainerAsync(blobServiceClient, ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await inputBlob.UploadTextAsync("15");

            // Act
            await RunTriggerAsync<object>(typeof(BlobTriggerToQueueTriggerToBlobProgram),
                (s) => BlobTriggerToQueueTriggerToBlobProgram.TaskSource = s);

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string content = await outputBlob.DownloadTextAsync();
            Assert.AreEqual("16", content);
        }

        private static async Task<BlobContainerClient> CreateContainerAsync(BlobServiceClient blobServiceClient, string containerName)
        {
            var container = blobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b =>
            {
                b.Services.AddAzureClients(builder =>
                {
                    builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport());
                });
                b.AddAzureStorageQueues();
                b.AddAzureStorageBlobs();
            }, programType, setTaskSource,
            settings: new Dictionary<string, string>() {
                // This takes precedence over env variables.
                { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
            });
        }

        private class BlobTriggerToQueueTriggerToBlobProgram
        {
            private const string CommittedQueueName = "committed";

            public static TaskCompletionSource<object> TaskSource { get; set; }

            public static void StepOne([BlobTrigger(BlobPath)] TextReader input, [Queue(QueueName)] out Payload output)
            {
                string content = input.ReadToEnd();
                int value = int.Parse(content);
                output = new Payload
                {
                    Value = value + 1,
                    Output = OutputBlobName
                };
            }

            public static void StepTwo([QueueTrigger(QueueName)] Payload input, int value,
                [Blob(ContainerName + "/{Output}")] TextWriter output, [Queue(CommittedQueueName)] out string committed)
            {
                Assert.AreEqual(input.Value, value);
                output.Write(value);
                committed = string.Empty;
            }

            public static void StepThree([QueueTrigger(CommittedQueueName)] string ignore)
            {
                TaskSource.TrySetResult(null);
            }
        }

        private class Payload
        {
            public int Value { get; set; }

            public string Output { get; set; }
        }
    }
}
