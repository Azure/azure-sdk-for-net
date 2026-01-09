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

            Assert.Multiple(() =>
            {
                Assert.That(ncResponse.Data.Name, Is.EqualTo(redisCacheName1));
                Assert.That(ncResponse.Data.Location, Is.EqualTo(AzureLocation.NorthCentralUS));
                Assert.That(ncResponse.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(ncResponse.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
            });

            // Create cache in scus
            parameter = new RedisCreateOrUpdateContent(AzureLocation.SouthCentralUS, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            var scResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName2, parameter)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(scResponse.Data.Name, Is.EqualTo(redisCacheName2));
                Assert.That(scResponse.Data.Location, Is.EqualTo(AzureLocation.SouthCentralUS));
                Assert.That(scResponse.Data.Sku.Name, Is.EqualTo(RedisSkuName.Premium));
                Assert.That(scResponse.Data.Sku.Family, Is.EqualTo(RedisSkuFamily.Premium));
            });

            // Set up replication link
            var linkCollection = ncResponse.GetRedisLinkedServerWithProperties();
            var linkContent = new RedisLinkedServerWithPropertyCreateOrUpdateContent(scResponse.Id, AzureLocation.SouthCentralUS, RedisLinkedServerRole.Secondary);
            var linkServerWithProperties = (await linkCollection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName2, linkContent)).Value;

            Assert.That(linkServerWithProperties.Data.Name, Is.EqualTo(redisCacheName2));
            Assert.That(linkServerWithProperties.Data.LinkedRedisCacheId, Is.EqualTo(scResponse.Id));
            Assert.That(linkServerWithProperties.Data.LinkedRedisCacheLocation, Is.EqualTo(AzureLocation.SouthCentralUS));
            Assert.That(linkServerWithProperties.Data.ServerRole, Is.EqualTo(RedisLinkedServerRole.Secondary));
            Assert.That(string.IsNullOrEmpty(linkServerWithProperties.Data.GeoReplicatedPrimaryHostName), Is.False);
            Assert.That(string.IsNullOrEmpty(linkServerWithProperties.Data.PrimaryHostName), Is.False);

            // test get response from primary
            var primaryLinkProperties = (await linkCollection.GetAsync(redisCacheName2)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(primaryLinkProperties.Data.LinkedRedisCacheId, Is.EqualTo(scResponse.Id));
                Assert.That(primaryLinkProperties.Data.LinkedRedisCacheLocation, Is.EqualTo(AzureLocation.SouthCentralUS));
                Assert.That(primaryLinkProperties.Data.ServerRole, Is.EqualTo(RedisLinkedServerRole.Secondary));
            });

            // test list response from primary
            var allPrimaryLinkProperties = await linkCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allPrimaryLinkProperties, Has.Count.EqualTo(1));

            // test get response from secondary
            var linkCollection2 = scResponse.GetRedisLinkedServerWithProperties();
            var secondaryLinkProperties = (await linkCollection2.GetAsync(redisCacheName1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(secondaryLinkProperties.Data.LinkedRedisCacheId, Is.EqualTo(ncResponse.Id));
                Assert.That(secondaryLinkProperties.Data.LinkedRedisCacheLocation, Is.EqualTo(AzureLocation.NorthCentralUS));
                Assert.That(secondaryLinkProperties.Data.ServerRole, Is.EqualTo(RedisLinkedServerRole.Primary));
            });

            // test list response from secondary
            allPrimaryLinkProperties = await linkCollection2.GetAllAsync().ToEnumerableAsync();
            Assert.That(allPrimaryLinkProperties, Has.Count.EqualTo(1));

            // Delete link on primary
            await primaryLinkProperties.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await linkCollection2.ExistsAsync("redisCacheName1")).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
