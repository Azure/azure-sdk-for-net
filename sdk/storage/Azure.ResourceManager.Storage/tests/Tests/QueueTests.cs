// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class QueueTests:StorageTestBase
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private QueueServiceContainer queueServiceContainer;
        private QueueService queueService;
        private StorageQueueContainer storageQueueContainer;
        public QueueTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task CreateStorageAccountAndGetQueueContainer()
        {
            resourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            storageAccount = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            queueServiceContainer = storageAccount.GetQueueServices();
            queueService = await queueServiceContainer.GetAsync("default");
            storageQueueContainer = queueService.GetStorageQueues();
        }
        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (resourceGroup != null)
            {
                var storageAccountContainer = resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                resourceGroup = null;
                storageAccount = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageQueue()
        {
            //create storage queue
            string storageQueueName = Recording.GenerateAssetName("testqueue");
            StorageQueue queue1 = (await storageQueueContainer.CreateOrUpdateAsync(storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //validate if successfully created
            StorageQueue queue2 = await storageQueueContainer.GetAsync(storageQueueName);
            AssertStorageQueueEqual(queue1, queue2);
            Assert.IsTrue(await storageQueueContainer.CheckIfExistsAsync(storageQueueName));
            Assert.IsFalse(await storageQueueContainer.CheckIfExistsAsync(storageQueueName + "1"));
            StorageQueueData queueData = queue2.Data;
            Assert.IsEmpty(queueData.Metadata);

            //delete storage queue
            await queue1.DeleteAsync();

            //validate if successfully deleted
            Assert.IsFalse(await storageQueueContainer.CheckIfExistsAsync(storageQueueName));
            StorageQueue queue3 = await storageQueueContainer.GetIfExistsAsync(storageQueueName);
            Assert.IsNull(queue3);
        }
        [Test]
        [RecordedTest]
        public async Task GetAllStorageQueues()
        {
            //create two blob containers
            string queueName1 = Recording.GenerateAssetName("testqueue1");
            string queueName2 = Recording.GenerateAssetName("testqueue2");
            StorageQueue queue1 = (await storageQueueContainer.CreateOrUpdateAsync(queueName1, new StorageQueueData())).Value;
            StorageQueue queue2 = (await storageQueueContainer.CreateOrUpdateAsync(queueName2, new StorageQueueData())).Value;

            //validate if there are two queues
            StorageQueue queue3 = null;
            StorageQueue queue4 = null;
            int count = 0;
            await foreach (StorageQueue queue in storageQueueContainer.GetAllAsync())
            {
                count++;
                if (queue.Id.Name == queueName1)
                    queue3 = queue;
                if (queue.Id.Name == queueName2)
                    queue4 = queue;
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(queue3);
            Assert.IsNotNull(queue4);
        }
        [Test]
        [RecordedTest]
        public async Task UpdateStorageQueue()
        {
            //create storage queue
            string storageQueueName = Recording.GenerateAssetName("testqueue");
            StorageQueue queue1 = (await storageQueueContainer.CreateOrUpdateAsync(storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //update queue's meta data
            StorageQueueData queueData = new StorageQueueData();
            queueData.Metadata.Add("key1", "value1");
            queueData.Metadata.Add("key2", "value2");
            StorageQueue queue2=await queue1.UpdateAsync(queueData);
            //validate
            Assert.NotNull(queue2);
            Assert.NotNull(queue2.Data.Metadata);
            Assert.AreEqual(queue2.Data.Metadata["key1"], "value1");
            Assert.AreEqual(queue2.Data.Metadata["key2"], "value2");
        }
    }
}
