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
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private QueueServiceResource _queueService;
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
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
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
                await foreach (StorageAccountResource account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync(WaitUntil.Completed);
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
            StorageQueueResource queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //validate if successfully created
            StorageQueueResource queue2 = await _storageQueueCollection.GetAsync(storageQueueName);
            AssertStorageQueueEqual(queue1, queue2);
            Assert.IsTrue(await _storageQueueCollection.ExistsAsync(storageQueueName));
            Assert.IsFalse(await _storageQueueCollection.ExistsAsync(storageQueueName + "1"));
            StorageQueueData queueData = queue2.Data;
            Assert.IsEmpty(queueData.Metadata);

            //delete storage queue
            await queue1.DeleteAsync(WaitUntil.Completed);

            //validate if successfully deleted
            Assert.IsFalse(await _storageQueueCollection.ExistsAsync(storageQueueName));
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _storageQueueCollection.GetAsync(storageQueueName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllStorageQueues()
        {
            //create two blob containers
            string queueName1 = Recording.GenerateAssetName("testqueue1");
            string queueName2 = Recording.GenerateAssetName("testqueue2");
            StorageQueueResource queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName1, new StorageQueueData())).Value;
            StorageQueueResource queue2 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName2, new StorageQueueData())).Value;

            //validate if there are two queues
            StorageQueueResource queue3 = null;
            StorageQueueResource queue4 = null;
            int count = 0;
            await foreach (StorageQueueResource queue in _storageQueueCollection.GetAllAsync())
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
            StorageQueueResource queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageQueueName, new StorageQueueData())).Value;
            Assert.IsNotNull(queue1);
            Assert.AreEqual(queue1.Id.Name, storageQueueName);

            //update queue's meta data
            StorageQueueData queueData = new StorageQueueData();
            queueData.Metadata.Add("key1", "value1");
            queueData.Metadata.Add("key2", "value2");
            StorageQueueResource queue2 = await queue1.UpdateAsync(queueData);
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
            _queueService = (await _queueService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //validate
            Assert.AreEqual(_queueService.Data.Cors.CorsRulesValue.Count, 1);
        }
    }
}
