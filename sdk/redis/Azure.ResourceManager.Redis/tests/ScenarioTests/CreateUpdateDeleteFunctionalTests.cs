// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class CreateUpdateDeleteFunctionalTests : RedisManagementTestBase
    {
        public CreateUpdateDeleteFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisCollection Collection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetAllRedis();
        }

        [Test]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisBegin");
            var storageSubscriptionId = "7c4785eb-d3cf-4349-b811-8d756312d1ff";
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Basic, RedisSkuFamily.BasicOrStandard, 0));

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Basic, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.BasicOrStandard, responseCreate.Data.Sku.Family);
            Assert.AreEqual(0, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(6379, responseCreate.Data.Port);
            Assert.AreEqual(6380, responseCreate.Data.SslPort);
            Assert.IsFalse(responseCreate.Data.EnableNonSslPort);

            var patch = new RedisPatch()
            {
                RedisConfiguration = new RedisCommonConfiguration()
                {
                    MaxMemoryPolicy = "allkeys-lru",
                    PreferredDataPersistenceAuthMethod = "ManagedIdentity",
                    StorageSubscriptionId = storageSubscriptionId
                },
                EnableNonSslPort = true
            };

            var responseUpdate = (await responseCreate.UpdateAsync(WaitUntil.Completed,patch)).Value;

            Assert.AreEqual(DefaultLocation, responseUpdate.Data.Location);
            Assert.AreEqual(redisCacheName, responseUpdate.Data.Name);
            Assert.AreEqual(RedisSkuName.Basic, responseUpdate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.BasicOrStandard, responseUpdate.Data.Sku.Family);
            Assert.AreEqual(0, responseUpdate.Data.Sku.Capacity);
            Assert.AreEqual("allkeys-lru", responseUpdate.Data.RedisConfiguration.MaxMemoryPolicy);
            Assert.AreEqual(6379, responseUpdate.Data.Port);
            Assert.AreEqual(6380, responseUpdate.Data.SslPort);
            Assert.IsTrue(responseUpdate.Data.EnableNonSslPort);
            Assert.AreEqual(storageSubscriptionId, responseUpdate.Data.RedisConfiguration.StorageSubscriptionId);

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
