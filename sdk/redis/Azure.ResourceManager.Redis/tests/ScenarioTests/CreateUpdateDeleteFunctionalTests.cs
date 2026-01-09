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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Basic));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.BasicOrStandard));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(0));
                Assert.That(responseCreate.Data.Port, Is.EqualTo(6379));
                Assert.That(responseCreate.Data.SslPort, Is.EqualTo(6380));
                Assert.That(responseCreate.Data.EnableNonSslPort, Is.False);
            });

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

            Assert.That(responseUpdate.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(responseUpdate.Data.Name, Is.EqualTo(redisCacheName));
            Assert.That(responseUpdate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Basic));
            Assert.That(responseUpdate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.BasicOrStandard));
            Assert.That(responseUpdate.Data.Sku.Capacity, Is.EqualTo(0));
            Assert.That(responseUpdate.Data.RedisConfiguration.MaxMemoryPolicy, Is.EqualTo("allkeys-lru"));
            Assert.That(responseUpdate.Data.Port, Is.EqualTo(6379));
            Assert.That(responseUpdate.Data.SslPort, Is.EqualTo(6380));
            Assert.That(responseUpdate.Data.EnableNonSslPort, Is.True);
            Assert.That(responseUpdate.Data.RedisConfiguration.StorageSubscriptionId, Is.EqualTo(storageSubscriptionId));

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
