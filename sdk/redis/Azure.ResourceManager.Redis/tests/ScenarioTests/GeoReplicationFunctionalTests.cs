// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class GeoReplicationFunctionalTests : RedisManagementTestBase
    {
        public GeoReplicationFunctionalTests(bool isAsync)
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

            var redisCacheName1 = Recording.GenerateAssetName("RedisGeo1");
            var redisCacheName2 = Recording.GenerateAssetName("RedisGeo2");

            // Create cache in ncus
            var parameter = new RedisCreateOrUpdateContent(AzureLocation.NorthCentralUS, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            var ncResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName1, parameter)).Value;

            Assert.AreEqual(redisCacheName1, ncResponse.Data.Name);
            Assert.AreEqual(AzureLocation.NorthCentralUS, ncResponse.Data.Location);
            Assert.AreEqual(RedisSkuName.Premium, ncResponse.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, ncResponse.Data.Sku.Family);

            // Create cache in scus
            parameter = new RedisCreateOrUpdateContent(AzureLocation.SouthCentralUS, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            var scResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName2, parameter)).Value;

            Assert.AreEqual(redisCacheName2, scResponse.Data.Name);
            Assert.AreEqual(AzureLocation.SouthCentralUS, scResponse.Data.Location);
            Assert.AreEqual(RedisSkuName.Premium, scResponse.Data.Sku.Name);
            Assert.AreEqual(RedisSkuFamily.Premium, scResponse.Data.Sku.Family);

            // Set up replication link
            var linkCollection = ncResponse.GetRedisLinkedServerWithProperties();
            var linkContent = new RedisLinkedServerWithPropertyCreateOrUpdateContent(scResponse.Id, AzureLocation.SouthCentralUS, RedisLinkedServerRole.Secondary);
            var linkServerWithProperties = (await linkCollection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName2, linkContent)).Value;

            Assert.AreEqual(redisCacheName2, linkServerWithProperties.Data.Name);
            Assert.AreEqual(scResponse.Id, linkServerWithProperties.Data.LinkedRedisCacheId);
            Assert.AreEqual(AzureLocation.SouthCentralUS, linkServerWithProperties.Data.LinkedRedisCacheLocation);
            Assert.AreEqual(RedisLinkedServerRole.Secondary, linkServerWithProperties.Data.ServerRole);
            Assert.False(string.IsNullOrEmpty(linkServerWithProperties.Data.GeoReplicatedPrimaryHostName));
            Assert.False(string.IsNullOrEmpty(linkServerWithProperties.Data.PrimaryHostName));

            // test get response from primary
            var primaryLinkProperties = (await linkCollection.GetAsync(redisCacheName2)).Value;
            Assert.AreEqual(scResponse.Id, primaryLinkProperties.Data.LinkedRedisCacheId);
            Assert.AreEqual(AzureLocation.SouthCentralUS, primaryLinkProperties.Data.LinkedRedisCacheLocation);
            Assert.AreEqual(RedisLinkedServerRole.Secondary, primaryLinkProperties.Data.ServerRole);

            // test list response from primary
            var allPrimaryLinkProperties = await linkCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(allPrimaryLinkProperties.Count, 1);

            // test get response from secondary
            var linkCollection2 = scResponse.GetRedisLinkedServerWithProperties();
            var secondaryLinkProperties = (await linkCollection2.GetAsync(redisCacheName1)).Value;
            Assert.AreEqual(ncResponse.Id, secondaryLinkProperties.Data.LinkedRedisCacheId);
            Assert.AreEqual(AzureLocation.NorthCentralUS, secondaryLinkProperties.Data.LinkedRedisCacheLocation);
            Assert.AreEqual(RedisLinkedServerRole.Primary, secondaryLinkProperties.Data.ServerRole);

            // test list response from secondary
            allPrimaryLinkProperties = await linkCollection2.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(allPrimaryLinkProperties.Count, 1);

            // Delete link on primary
            await primaryLinkProperties.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await linkCollection2.ExistsAsync("redisCacheName1")).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
