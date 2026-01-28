// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class QueueTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private QueueServiceResource _queueService;
        private StorageQueueCollection _storageQueueCollection;
        public QueueTests(bool async) : base(async)//, RecordedTestMode.Record)
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
            Assert.That(queue1, Is.Not.Null);
            Assert.That(storageQueueName, Is.EqualTo(queue1.Id.Name));

            //validate if successfully created
            StorageQueueResource queue2 = await _storageQueueCollection.GetAsync(storageQueueName);
            AssertStorageQueueEqual(queue1, queue2);
            Assert.That((bool)await _storageQueueCollection.ExistsAsync(storageQueueName), Is.True);
            Assert.That((bool)await _storageQueueCollection.ExistsAsync(storageQueueName + "1"), Is.False);
            StorageQueueData queueData = queue2.Data;
            Assert.That(queueData.Metadata, Is.Empty);

            string queueName2 = Recording.GenerateAssetName("queue2");
            var data = new StorageQueueData()
            {
                Metadata = { { "metadata1", "true" }, { "metadata2", "value2" } }
            };
            queue2 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName2, data)).Value;
            Assert.That(queue2.Data.Metadata.Count, Is.EqualTo(2));
            Assert.That(queue2.Data.Metadata, Is.EqualTo(data.Metadata));

            queue2 = await _storageQueueCollection.GetAsync(queueName2);
            Assert.That(queue2.Data.Metadata.Count, Is.EqualTo(2));
            Assert.That(queue2.Data.Metadata, Is.EqualTo(data.Metadata));

            //delete storage queue
            await queue1.DeleteAsync(WaitUntil.Completed);

            //validate if successfully deleted
            Assert.That((bool)await _storageQueueCollection.ExistsAsync(storageQueueName), Is.False);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _storageQueueCollection.GetAsync(storageQueueName); });
            Assert.That(exception.Status, Is.EqualTo(404));
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
            Assert.That(count, Is.EqualTo(2));
            Assert.That(queue3, Is.Not.Null);
            Assert.That(queue4, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageQueue()
        {
            //create storage queue
            string storageQueueName = Recording.GenerateAssetName("testqueue");
            StorageQueueResource queue1 = (await _storageQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageQueueName, new StorageQueueData())).Value;
            Assert.That(queue1, Is.Not.Null);
            Assert.That(storageQueueName, Is.EqualTo(queue1.Id.Name));

            //update queue's meta data
            StorageQueueData queueData = new StorageQueueData();
            queueData.Metadata.Add("key1", "value1");
            queueData.Metadata.Add("key2", "value2");
            StorageQueueResource queue2 = await queue1.UpdateAsync(queueData);
            //validate
            Assert.That(queue2, Is.Not.Null);
            Assert.That(queue2.Data.Metadata, Is.Not.Null);
            Assert.That(queue2.Data.Metadata["key1"], Is.EqualTo("value1"));
            Assert.That(queue2.Data.Metadata["key2"], Is.EqualTo("value2"));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateQueueService()
        {
            //update cors
            QueueServiceData parameter = new QueueServiceData()
            {
                Cors = new StorageCorsRules()
                {
                    CorsRules =
                    {
                        new StorageCorsRule(
                            allowedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                            allowedMethods: new CorsRuleAllowedMethod[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                            allowedOrigins: new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                            exposedHeaders: new string[] { "x-ms-meta-*" },
                            maxAgeInSeconds: 100),
                        new StorageCorsRule(
                            allowedOrigins: new string[] { "*" },
                            allowedMethods: new CorsRuleAllowedMethod[] {"GET" },
                            maxAgeInSeconds: 2,
                            exposedHeaders: new string[] { "*" },
                            allowedHeaders: new string[] { "*" }
                            )
                    }
                },
            };
            _queueService = (await _queueService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //Validate CORS Rules
            Assert.That(_queueService.Data.Cors.CorsRules.Count, Is.EqualTo(parameter.Cors.CorsRules.Count));
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _queueService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
            }

            _queueService = (await _queueService.GetAsync()).Value;

            //Validate CORS Rules
            Assert.That(_queueService.Data.Cors.CorsRules.Count, Is.EqualTo(parameter.Cors.CorsRules.Count));
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _queueService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
            }
        }
    }
}
