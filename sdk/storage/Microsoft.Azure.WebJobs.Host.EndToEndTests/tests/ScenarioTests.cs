// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class ScenarioTests
    {
        private const string ContainerName = "container-scenariotests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private const string OutputBlobName = "blob.out";
        private const string OutputBlobPath = ContainerName + "/" + OutputBlobName;
        private const string QueueName = "queue-scenariotests";
        private StorageAccount account;

        [SetUp]
        public void SetUp()
        {
            account = AzuriteNUnitFixture.Instance.GetAccount();
            account.CreateBlobServiceClient().GetBlobContainerClient(ContainerName).DeleteIfExists();
            // make sure our system containers are present
            account.CreateBlobServiceClient().GetBlobContainerClient("azure-webjobs-hosts").CreateIfNotExists();
            account.CreateQueueServiceClient().GetQueueClient(QueueName).DeleteIfExists();
        }

        [Test]
        public async Task BlobTriggerToQueueTriggerToBlob_WritesFinalBlob()
        {
            // Arrange
            var container = await CreateContainerAsync(account, ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await inputBlob.UploadTextAsync("15");

            // Act
            await RunTriggerAsync<object>(account, typeof(BlobTriggerToQueueTriggerToBlobProgram),
                (s) => BlobTriggerToQueueTriggerToBlobProgram.TaskSource = s);

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string content = await outputBlob.DownloadTextAsync();
            Assert.AreEqual("16", content);
        }

        private static async Task<BlobContainerClient> CreateContainerAsync(StorageAccount account, string containerName)
        {
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource);
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
