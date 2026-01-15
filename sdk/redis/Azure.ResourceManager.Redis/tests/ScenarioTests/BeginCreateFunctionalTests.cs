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
    public class BeginCreateFunctionalTests : RedisManagementTestBase
    {
        public BeginCreateFunctionalTests(bool isAsync)
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
        public async Task BeginCreateFunctionalTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisBegin");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1)) {
                MinimumTlsVersion = RedisTlsVersion.Tls1_2,
                ReplicasPerMaster = 2,
                RedisVersion = "latest",
                RedisConfiguration = new RedisCommonConfiguration()
                {
                    MaxMemoryPolicy = "allkeys-lru",
                    AdditionalProperties = { { "maxmemory-reserved", BinaryData.FromString("210") } }
                }
            };
            var response = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            Assert.That(response.Data.Name, Is.EqualTo(redisCacheName));
            Assert.That(response.Data.RedisConfiguration.MaxMemoryDelta, Is.EqualTo("642"));
            Assert.That(response.Data.RedisConfiguration.MaxMemoryReserved, Is.EqualTo("642"));
            Assert.That(response.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
            Assert.That(response.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
            Assert.That(response.Data.MinimumTlsVersion, Is.EqualTo(RedisTlsVersion.Tls1_2));
            Assert.That(response.Data.ReplicasPerMaster, Is.EqualTo(2));
            Assert.That(response.Data.RedisVersion.Split('.')[0], Is.EqualTo("6"));// 6 is the current 'latest' version. Will change in the future.

            Assert.That(response.Data.Instances.Count, Is.EqualTo(3));
            for (int i = 0; i < response.Data.Instances.Count; i++)
            {
                Assert.That(response.Data.Instances[i].SslPort, Is.EqualTo(15000 + i));
                Assert.IsNull(response.Data.Instances[i].NonSslPort);
                Assert.That(response.Data.Instances[i].ShardId, Is.EqualTo(0));
                Assert.IsNull(response.Data.Instances[i].Zone);
            }

            await response.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
