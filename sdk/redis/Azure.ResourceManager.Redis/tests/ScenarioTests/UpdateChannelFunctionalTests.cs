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

            Assert.That(responseCreate.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(responseCreate.Data.Name, Is.EqualTo(redisCacheName));
            Assert.That(responseCreate.Data.Sku.Name, Is.EqualTo(RedisSkuName.Basic));
            Assert.That(responseCreate.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.BasicOrStandard));
            Assert.That(responseCreate.Data.Sku.Capacity, Is.EqualTo(0));
            Assert.That(responseCreate.Data.Port, Is.EqualTo(6379));
            Assert.That(responseCreate.Data.SslPort, Is.EqualTo(6380));
            Assert.That(responseCreate.Data.UpdateChannel, Is.EqualTo(UpdateChannel.Stable));

            var patch = new RedisPatch()
            {
                RedisVersion = "6.0",
                UpdateChannel = UpdateChannel.Preview
            };

            var responseUpdate = (await responseCreate.UpdateAsync(WaitUntil.Completed, patch)).Value;
            var response = (await ResourceGroup.GetAllRedis().GetAsync(redisCacheName)).Value;
            Assert.That(response.Data.UpdateChannel, Is.EqualTo(UpdateChannel.Preview));

            await responseUpdate.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
