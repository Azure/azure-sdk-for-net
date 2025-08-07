// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class UpdateChannelFunctionalTests : RedisManagementTestBase
    {
        public UpdateChannelFunctionalTests(bool isAsync)
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
        public async Task UpdateChannelDefaultCreationTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisUpdateChannel");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Basic, RedisSkuFamily.BasicOrStandard, 0));

            var responseCreate = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.AreEqual(DefaultLocation, responseCreate.Data.Location);
            Assert.AreEqual(redisCacheName, responseCreate.Data.Name);
            Assert.AreEqual(RedisSkuName.Basic, responseCreate.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.BasicOrStandard, responseCreate.Data.Sku.Family);
            Assert.AreEqual(0, responseCreate.Data.Sku.Capacity);
            Assert.AreEqual(6379, responseCreate.Data.Port);
            Assert.AreEqual(6380, responseCreate.Data.SslPort);
            Assert.AreEqual(UpdateChannel.Stable, responseCreate.Data.UpdateChannel);

            var patch = new RedisPatch()
            {
                RedisVersion = "6.0",
                UpdateChannel = UpdateChannel.Preview
            };

            var responseUpdate = (await responseCreate.UpdateAsync(WaitUntil.Completed, patch)).Value;
            var response = (await ResourceGroup.GetAllRedis().GetAsync(redisCacheName)).Value;
            Assert.AreEqual(UpdateChannel.Preview, response.Data.UpdateChannel);

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
