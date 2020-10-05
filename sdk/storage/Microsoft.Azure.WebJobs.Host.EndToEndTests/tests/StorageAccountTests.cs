// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Azure.Storage.Queues;
using System.Linq;
using Azure.Storage.Queues.Models;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Storage.IntegrationTests
{
    public class StorageAccountTests
    {
        [Test]
        [WebJobsLiveOnly]
        public async Task CloudQueueCreate_IfNotExist_CreatesQueue()
        {
            // Arrange
            StorageAccount storageAccount = CreateStorageAccount();
            string queueName = GetQueueName("create-queue");

            // Initialize using the SdkAccount directly.
            var sdkQueue = GetQueueReference(storageAccount, queueName);
            await sdkQueue.DeleteIfExistsAsync();
            Assert.False(await sdkQueue.ExistsAsync());

            try
            {
                // Make sure that using our StorageAccount uses the underlying SdkAccount
                var client = storageAccount.CreateQueueServiceClient();
                Assert.NotNull(client); // Guard
                var queue = client.GetQueueClient(queueName);
                Assert.NotNull(queue); // Guard

                // Act
                await queue.CreateIfNotExistsAsync();

                // Assert
                Assert.True(await sdkQueue.ExistsAsync());
            }
            finally
            {
                if (await sdkQueue.ExistsAsync())
                {
                    await sdkQueue.DeleteAsync();
                }
            }
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task CloudQueueAddMessage_AddsMessage()
        {
            // Arrange
            StorageAccount storageAccount = CreateStorageAccount();
            string queueName = GetQueueName("add-message");

            // Initialize using the SdkAccount directly.
            var sdkQueue = GetQueueReference(storageAccount, queueName);
            await sdkQueue.CreateIfNotExistsAsync();

            try
            {
                string expectedContent = "hello";

                var client = storageAccount.CreateQueueServiceClient();
                Assert.NotNull(client); // Guard
                var queue = client.GetQueueClient(queueName);
                Assert.NotNull(queue); // Guard

                // Act
                await queue.SendMessageAsync(expectedContent);

                // Assert
                QueueMessage sdkMessage = (await sdkQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                Assert.NotNull(sdkMessage);
                Assert.AreEqual(expectedContent, sdkMessage.MessageText);
            }
            finally
            {
                await sdkQueue.DeleteAsync();
            }
        }

        private static StorageAccount CreateStorageAccount()
        {
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(c =>
                {
                    c.AddAzureStorageBlobs().AddAzureStorageQueues();
                })
                .Build();

            StorageAccount account = host.Services.GetService<StorageAccountProvider>().GetHost();
            Assert.NotNull(account);

            return account;
        }

        private static QueueClient GetQueueReference(StorageAccount sdkAccount, string queueName)
        {
            var queueServiceClient = sdkAccount.CreateQueueServiceClient();
            return queueServiceClient.GetQueueClient(queueName);
        }

        private static string GetQueueName(string infix)
        {
            return string.Format("test-{0}-{1:N}", infix, Guid.NewGuid());
        }
    }
}
