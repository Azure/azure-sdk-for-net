// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Storage.IntegrationTests
{
    [Trait("SecretsRequired", "true")]
    public class StorageAccountTests
    {
        [Fact]
        public async Task CloudQueueCreate_IfNotExist_CreatesQueue()
        {
            // Arrange
            StorageAccount storageAccount = CreateStorageAccount();
            CloudStorageAccount sdkAccount = storageAccount.SdkObject;
            string queueName = GetQueueName("create-queue");

            // Initialize using the SdkAccount directly.
            CloudQueue sdkQueue = GetQueueReference(sdkAccount, queueName);
            await sdkQueue.DeleteIfExistsAsync();
            Assert.False(await sdkQueue.ExistsAsync());

            try
            {
                // Make sure that using our StorageAccount uses the underlying SdkAccount                
                CloudQueueClient client = storageAccount.CreateCloudQueueClient();
                Assert.NotNull(client); // Guard
                CloudQueue queue = client.GetQueueReference(queueName);
                Assert.NotNull(queue); // Guard

                // Act
                await queue.CreateIfNotExistsAsync(CancellationToken.None);

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

        [Fact]
        public async Task CloudQueueAddMessage_AddsMessage()
        {
            // Arrange
            StorageAccount storageAccount = CreateStorageAccount();
            CloudStorageAccount sdkAccount = storageAccount.SdkObject;
            string queueName = GetQueueName("add-message");

            // Initialize using the SdkAccount directly.
            CloudQueue sdkQueue = GetQueueReference(sdkAccount, queueName);
            await sdkQueue.CreateIfNotExistsAsync();

            try
            {
                string expectedContent = "hello";

                CloudQueueClient client = storageAccount.CreateCloudQueueClient();
                Assert.NotNull(client); // Guard
                CloudQueue queue = client.GetQueueReference(queueName);
                Assert.NotNull(queue); // Guard

                CloudQueueMessage message = new CloudQueueMessage(expectedContent);
                Assert.NotNull(message); // Guard

                // Act
                await queue.AddMessageAsync(message, CancellationToken.None);

                // Assert
                CloudQueueMessage sdkMessage = await sdkQueue.GetMessageAsync();
                Assert.NotNull(sdkMessage);
                Assert.Equal(expectedContent, sdkMessage.AsString);
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
                    c.AddAzureStorage();
                })
                .Build();

            StorageAccount account = host.Services.GetService<StorageAccountProvider>().GetHost();
            Assert.NotNull(account);

            return account;
        }

        private static CloudQueue GetQueueReference(CloudStorageAccount sdkAccount, string queueName)
        {
            CloudQueueClient sdkClient = sdkAccount.CreateCloudQueueClient();
            return sdkClient.GetQueueReference(queueName);
        }

        private static string GetQueueName(string infix)
        {
            return string.Format("test-{0}-{1:N}", infix, Guid.NewGuid());
        }
    }
}