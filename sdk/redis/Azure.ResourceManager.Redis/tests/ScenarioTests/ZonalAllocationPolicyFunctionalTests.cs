// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class ZonalAllocationPolicyFunctionalTests : RedisManagementTestBase
    {
        public ZonalAllocationPolicyFunctionalTests(bool isAsync)
                    : base(isAsync) // RecordedTestMode.Record)
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
        public async Task AutomaticZonalAllocationStandardCacheCreationTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisZonalAllocationPolicy");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Standard, RedisSkuFamily.BasicOrStandard, 0))
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.Automatic
            };

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Standard, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.BasicOrStandard, responseCreate.Data.Sku.Family);
            Assert.AreEqual(0, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(ZonalAllocationPolicy.Automatic, responseCreate.Data.ZonalAllocationPolicy);
            Assert.IsEmpty(responseCreate.Data.Zones);

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task AutomaticZonalAllocationPremiumCacheCreationTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisZonalAllocationPolicy");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.Automatic
            };

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Premium, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, responseCreate.Data.Sku.Family);
            Assert.AreEqual(1, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(ZonalAllocationPolicy.Automatic, responseCreate.Data.ZonalAllocationPolicy);
            Assert.IsEmpty(responseCreate.Data.Zones);

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task NoZonesZonalAllocationPremiumCacheCreationTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisZonalAllocationPolicy");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.NoZones
            };

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Premium, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, responseCreate.Data.Sku.Family);
            Assert.AreEqual(1, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(ZonalAllocationPolicy.NoZones, responseCreate.Data.ZonalAllocationPolicy);
            Assert.IsEmpty(responseCreate.Data.Zones);

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task UserDefinedZonalAllocationPremiumCacheCreationTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisZonalAllocationPolicy");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                Zones = { "1", "2" },
                ZonalAllocationPolicy = ZonalAllocationPolicy.UserDefined
            };

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Premium, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, responseCreate.Data.Sku.Family);
            Assert.AreEqual(1, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(ZonalAllocationPolicy.UserDefined, responseCreate.Data.ZonalAllocationPolicy);
            Assert.AreEqual(new List<string> { "1", "2" }, responseCreate.Data.Zones);

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task UpdateToAutomaticZonalAllocationPolicyTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisZonalAllocationPolicy");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.NoZones
            };

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Premium, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, responseCreate.Data.Sku.Family);
            Assert.AreEqual(1, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(ZonalAllocationPolicy.NoZones, responseCreate.Data.ZonalAllocationPolicy);
            Assert.IsEmpty(responseCreate.Data.Zones);

            var patch = new RedisPatch()
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.Automatic
            };

            var responseUpdate = (await responseCreate.UpdateAsync(WaitUntil.Completed, patch)).Value;
            var response = (await ResourceGroup.GetAllRedis().GetAsync(redisCacheName)).Value;
            Assert.AreEqual(ZonalAllocationPolicy.Automatic, response.Data.ZonalAllocationPolicy);

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
