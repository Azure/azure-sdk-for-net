// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class ScenarioTests
    {
        private const string ContainerName = "container";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private const string OutputBlobName = "blob.out";
        private const string OutputBlobPath = ContainerName + "/" + OutputBlobName;
        private const string QueueName = "queue";

        [Fact]
        public async Task BlobTriggerToQueueTriggerToBlob_WritesFinalBlob()
        {
            // Arrange
            StorageAccount account = await CreateFakeStorageAccountAsync();
            CloudBlobContainer container = await CreateContainerAsync(account, ContainerName);
            CloudBlockBlob inputBlob = container.GetBlockBlobReference(BlobName);
            await inputBlob.UploadTextAsync("15");

            // Act
            await RunTriggerAsync<object>(account, typeof(BlobTriggerToQueueTriggerToBlobProgram),
                (s) => BlobTriggerToQueueTriggerToBlobProgram.TaskSource = s);

            // Assert
            CloudBlockBlob outputBlob = container.GetBlockBlobReference(OutputBlobName);
            string content = outputBlob.DownloadText();
            Assert.Equal("16", content);
        }

        private static async Task<CloudBlobContainer> CreateContainerAsync(StorageAccount account, string containerName)
        {
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        private static async Task<StorageAccount> CreateFakeStorageAccountAsync()
        {
            var account = new FakeStorageAccount();

            // make sure our system containers are present
            var container = await CreateContainerAsync(account, "azure-webjobs-hosts");

            return account;
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
                Assert.Equal(input.Value, value);
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