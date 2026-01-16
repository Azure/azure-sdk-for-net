// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class GetListKeysFunctionalTests : RedisManagementTestBase
    {
        public GetListKeysFunctionalTests(bool isAsync)
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
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter);

            var listResponse = await Collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResponse.Count, Is.GreaterThanOrEqualTo(1));

            var redis = listResponse.FirstOrDefault();
            Assert.That(redis.Data.Name, Is.EqualTo(redisCacheName));
            Assert.That(redis.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
            Assert.That(redis.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
            Assert.That(redis.Data.Sku.Capacity, Is.EqualTo(1));
            Assert.That(redis.Data.Port, Is.EqualTo(6379));
            Assert.That(redis.Data.SslPort, Is.EqualTo(6380));

            listResponse = await DefaultSubscription.GetAllRedisAsync().ToEnumerableAsync();
            Assert.That(listResponse.Count, Is.GreaterThanOrEqualTo(1));

            redis = listResponse.FirstOrDefault(x => x.Data.Name.Equals(redisCacheName));
            if (redis != null)
            {
                Assert.That(redis.Data.Name, Is.EqualTo(redisCacheName));
                Assert.That(redis.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(redis.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
                Assert.That(redis.Data.Sku.Capacity, Is.EqualTo(1));
                Assert.That(redis.Data.Port, Is.EqualTo(6379));
                Assert.That(redis.Data.SslPort, Is.EqualTo(6380));
            }

            var response = (await redis.GetKeysAsync()).Value;
            Assert.That(response.PrimaryKey, Is.Not.Null);
            Assert.That(response.SecondaryKey, Is.Not.Null);
        }
    }
}
