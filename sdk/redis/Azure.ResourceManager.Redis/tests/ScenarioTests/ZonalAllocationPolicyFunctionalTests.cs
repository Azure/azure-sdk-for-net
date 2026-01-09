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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Standard));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.BasicOrStandard));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(0));
                Assert.That(responseCreate.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.Automatic));
                Assert.That(responseCreate.Data.Zones, Is.Empty);
            });

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(1));
                Assert.That(responseCreate.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.Automatic));
                Assert.That(responseCreate.Data.Zones, Is.Empty);
            });

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(1));
                Assert.That(responseCreate.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.NoZones));
                Assert.That(responseCreate.Data.Zones, Is.Empty);
            });

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(1));
                Assert.That(responseCreate.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.UserDefined));
                Assert.That(responseCreate.Data.Zones, Is.EqualTo(new List<string> { "1", "2" }));
            });

            await responseCreate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
                Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(1));
                Assert.That(responseCreate.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.NoZones));
                Assert.That(responseCreate.Data.Zones, Is.Empty);
            });

            var patch = new RedisPatch()
            {
                ZonalAllocationPolicy = ZonalAllocationPolicy.Automatic
            };

            var responseUpdate = (await responseCreate.UpdateAsync(WaitUntil.Completed, patch)).Value;
            var response = (await ResourceGroup.GetAllRedis().GetAsync(redisCacheName)).Value;
            Assert.That(response.Data.ZonalAllocationPolicy, Is.EqualTo(ZonalAllocationPolicy.Automatic));

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
