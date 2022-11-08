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

            Assert.AreEqual(redisCacheName, response.Data.Name);
            Assert.AreEqual("642", response.Data.RedisConfiguration.MaxMemoryDelta);
            Assert.AreEqual("642", response.Data.RedisConfiguration.MaxMemoryReserved);
            Assert.AreEqual(RedisSkuName.Premium, response.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, response.Data.Sku.Family);
            Assert.AreEqual(RedisTlsVersion.Tls1_2, response.Data.MinimumTlsVersion);
            Assert.AreEqual(2, response.Data.ReplicasPerMaster);
            Assert.AreEqual("6", response.Data.RedisVersion.Split('.')[0]);// 6 is the current 'latest' version. Will change in the future.

            Assert.AreEqual(3, response.Data.Instances.Count);
            for (int i = 0; i < response.Data.Instances.Count; i++)
            {
                Assert.AreEqual(15000 + i, response.Data.Instances[i].SslPort);
                Assert.IsNull(response.Data.Instances[i].NonSslPort);
                Assert.AreEqual(0, response.Data.Instances[i].ShardId);
                Assert.IsNull(response.Data.Instances[i].Zone);
            }

            await response.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await Collection.ExistsAsync(redisCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
