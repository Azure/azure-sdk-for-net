// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests.ScenarioTests
{
    public class FlushFunctionalTests : RedisManagementTestBase
    {
        private ResourceGroupResource ResourceGroup { get; set; }
        private RedisCollection Collection { get; set; }
        public FlushFunctionalTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetAllRedis();
        }
        [Test]
        public async Task FlushInvocationTest()
        {
            // Create cache
            await SetCollectionsAsync();
            string redisCacheName = Recording.GenerateAssetName("RedisFlush");
            RedisCreateOrUpdateContent redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Standard, RedisSkuFamily.BasicOrStandard, 1));
            RedisResource redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;
            // Execute flush
            await redisResource.FlushCacheAsync(WaitUntil.Completed);
        }
        [Test]
        public async Task FlushValidationFailureTest()
        {
            // Create cache
            await SetCollectionsAsync();
            string redisCacheName = Recording.GenerateAssetName("RedisFlush");
            RedisCreateOrUpdateContent redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Standard, RedisSkuFamily.BasicOrStandard, 1));
            RedisResource redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;

            // Scale cache so that it doesn't except flush requests
            RedisPatch redisPatch = new RedisPatch()
            {
                Sku = new RedisSku(RedisSkuName.Standard, RedisSkuFamily.BasicOrStandard, 2)
            };
            await redisResource.UpdateAsync(WaitUntil.Started, redisPatch);

            // Validate the flush request throws exception
            Assert.ThrowsAsync<Azure.RequestFailedException>(() => redisResource.FlushCacheAsync(WaitUntil.Completed));
        }
    }
}
