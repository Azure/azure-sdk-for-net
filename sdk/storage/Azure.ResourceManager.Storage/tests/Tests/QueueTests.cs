// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests
{
    public class QueueTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private QueueService _queueService;
        private StorageQueueCollection _storageQueueCollection;
        public QueueTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetQueueCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _queueService = _storageAccount.GetQueueService();
            _queueService = await _queueService.GetAsync();
            _storageQueueCollection = _queueService.GetStorageQueues();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageQueue()
        {
            //create storage queue
            string storageQueueName = Recording.GenerateAssetName("testqueue");
            StorageQueue queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //validate if successfully created
            StorageQueue queue2 = await _storageQueueCollection.GetAsync(storageQueueName);
            AssertStorageQueueEqual(queue1, queue2);
            Assert.IsTrue(await _storageQueueCollection.CheckIfExistsAsync(storageQueueName));
            Assert.IsFalse(await _storageQueueCollection.CheckIfExistsAsync(storageQueueName + "1"));
            StorageQueueData queueData = queue2.Data;
            Assert.IsEmpty(queueData.Metadata);

            //delete storage queue
            await queue1.DeleteAsync();

            //validate if successfully deleted
            Assert.IsFalse(await _storageQueueCollection.CheckIfExistsAsync(storageQueueName));
            StorageQueue queue3 = await _storageQueueCollection.GetIfExistsAsync(storageQueueName);
            Assert.IsNull(queue3);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllStorageQueues()
        {
            //create two blob containers
            string queueName1 = Recording.GenerateAssetName("testqueue1");
            string queueName2 = Recording.GenerateAssetName("testqueue2");
            StorageQueue queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(queueName1, new StorageQueueData())).Value;
            StorageQueue queue2 = (await _storageQueueCollection.CreateOrUpdateAsync(queueName2, new StorageQueueData())).Value;

            //validate if there are two queues
            StorageQueue queue3 = null;
            StorageQueue queue4 = null;
            int count = 0;
            await foreach (StorageQueue queue in _storageQueueCollection.GetAllAsync())
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
            StorageQueue queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //update queue's meta data
            StorageQueueData queueData = new StorageQueueData();
            queueData.Metadata.Add("key1", "value1");
            queueData.Metadata.Add("key2", "value2");
            StorageQueue queue2 = await queue1.UpdateAsync(queueData);
            //validate
            Assert.NotNull(queue2);
            Assert.NotNull(queue2.Data.Metadata);
            Assert.AreEqual(queue2.Data.Metadata["key1"], "value1");
            Assert.AreEqual(queue2.Data.Metadata["key2"], "value2");
        }

        [Test]
        [RecordedTest]
        public async Task UpdateQueueService()
        {
            //update cors
            CorsRules cors = new CorsRules();
            cors.CorsRulesValue.Add(new CorsRule(
                allowedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                 allowedOrigins: new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                exposedHeaders: new string[] { "x-ms-meta-*" },
                maxAgeInSeconds: 100));
            QueueServiceData parameter = new QueueServiceData()
            {
                Cors = cors,
            };
            _queueService = (await _queueService.CreateOrUpdateAsync(parameter)).Value;

            //validate
            Assert.AreEqual(_queueService.Data.Cors.CorsRulesValue.Count, 1);
        }
    }
}
