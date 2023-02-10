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
            Assert.GreaterOrEqual(listResponse.Count, 1);

            var redis = listResponse.FirstOrDefault();
            Assert.AreEqual(redisCacheName, redis.Data.Name);
            Assert.AreEqual(RedisSkuName.Premium, redis.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, redis.Data.Sku.Family);
            Assert.AreEqual(1, redis.Data.Sku.Capacity);
            Assert.AreEqual(6379, redis.Data.Port);
            Assert.AreEqual(6380, redis.Data.SslPort);

            listResponse = await DefaultSubscription.GetAllRedisAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listResponse.Count, 1);

            redis = listResponse.FirstOrDefault(x => x.Data.Name.Equals(redisCacheName));
            if (redis != null)
            {
                Assert.AreEqual(redisCacheName, redis.Data.Name);
                Assert.AreEqual(RedisSkuName.Premium, redis.Data.Sku.Name);
                Assert.AreEqual(RedisSkuFamily.Premium, redis.Data.Sku.Family);
                Assert.AreEqual(1, redis.Data.Sku.Capacity);
                Assert.AreEqual(6379, redis.Data.Port);
                Assert.AreEqual(6380, redis.Data.SslPort);
            }

            var response = (await redis.GetKeysAsync()).Value;
            Assert.NotNull(response.PrimaryKey);
            Assert.NotNull(response.SecondaryKey);

            var afterRegenerateResponse = (await redis.RegenerateKeyAsync(new RedisRegenerateKeyContent(RedisRegenerateKeyType.Primary))).Value;

            // Won't be equal when recording but might be equal in playback as all key values will be set to "Sanitized"
            // Make sure to manually edit session records so tests pass
            Assert.AreNotEqual(response.PrimaryKey, afterRegenerateResponse.PrimaryKey);
            Assert.AreNotEqual(response.SecondaryKey, afterRegenerateResponse.SecondaryKey);
        }
    }
}
