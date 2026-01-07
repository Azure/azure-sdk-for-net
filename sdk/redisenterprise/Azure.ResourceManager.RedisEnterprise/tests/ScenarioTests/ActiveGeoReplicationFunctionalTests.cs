// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    public class ActiveGeoReplicationFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public ActiveGeoReplicationFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisEnterpriseClusterCollection Collection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetRedisEnterpriseClusters();
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/30766")]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            var redisEnterpriseCacheName1 = Recording.GenerateAssetName("RedisActiveGeo1");
            var redisEnterpriseCacheName2 = Recording.GenerateAssetName("RedisActiveGeo2");
            string databaseName = "default";
            string groupNickname = Recording.GenerateAssetName("activeGeoTesting");

            // Create cache in east us
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                {
                    Capacity = 2
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse1 = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName1, data)).Value;
            Assert.That(clusterResponse1.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse1.Data.Name, Is.EqualTo(redisEnterpriseCacheName1));
            Assert.That(clusterResponse1.Data.ResourceType, Is.EqualTo("Microsoft.Cache/redisEnterprise"));
            Assert.That(clusterResponse1.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.EnterpriseE10));
            Assert.That(clusterResponse1.Data.Sku.Capacity, Is.EqualTo(2));

            // Create cache in west us
            data = new RedisEnterpriseClusterData(
                AzureLocation.WestUS,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                {
                    Capacity = 2
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse2 = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName2, data)).Value;
            Assert.That(clusterResponse2.Data.Location, Is.EqualTo(AzureLocation.WestUS));
            Assert.That(clusterResponse2.Data.Name, Is.EqualTo(redisEnterpriseCacheName2));
            Assert.That(clusterResponse2.Data.ResourceType, Is.EqualTo("Microsoft.Cache/redisEnterprise"));
            Assert.That(clusterResponse2.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.EnterpriseE10));
            Assert.That(clusterResponse2.Data.Sku.Capacity, Is.EqualTo(2));

            // create db for cluster 1
            string linkedDatabaseId1 = clusterResponse1.Id + "/databases/" + databaseName;
            var databaseCollection1 = clusterResponse1.GetRedisEnterpriseDatabases();
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                GeoReplication = new RedisEnterpriseDatabaseGeoReplication()
                {
                    GroupNickname = groupNickname,
                    LinkedDatabases = { new RedisEnterpriseLinkedDatabase()
                    {
                        Id = new ResourceIdentifier(linkedDatabaseId1)
                    } }
                }
            };
            var databaseResponse1 = (await databaseCollection1.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.That(databaseResponse1.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse1.Data.ResourceType, Is.EqualTo("Microsoft.Cache/redisEnterprise/databases"));
            Assert.That(databaseResponse1.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse1.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.EnterpriseCluster));
            Assert.That(databaseResponse1.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse1.Data.GeoReplication.GroupNickname, Is.EqualTo(groupNickname));
            Assert.That(databaseResponse1.Data.GeoReplication.LinkedDatabases[0].Id, Is.EqualTo(linkedDatabaseId1));
            Assert.That(databaseResponse1.Data.GeoReplication.LinkedDatabases[0].State, Is.EqualTo(RedisEnterpriseDatabaseLinkState.Linked));

            // create db for cluster 2
            string linkedDatabaseId2 = clusterResponse2.Id + "/databases/" + databaseName;
            var databaseCollection2 = clusterResponse2.GetRedisEnterpriseDatabases();
            databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                GeoReplication = new RedisEnterpriseDatabaseGeoReplication()
                {
                    GroupNickname = groupNickname,
                    LinkedDatabases = {
                        new RedisEnterpriseLinkedDatabase()
                        {
                            Id = new ResourceIdentifier(linkedDatabaseId1)
                        },
                        new RedisEnterpriseLinkedDatabase()
                        {
                            Id = new ResourceIdentifier(linkedDatabaseId2)
                        }
                    }
                }
            };
            var databaseResponse2 = (await databaseCollection2.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.That(databaseResponse2.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse2.Data.ResourceType, Is.EqualTo("Microsoft.Cache/redisEnterprise/databases"));
            Assert.That(databaseResponse2.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse2.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.EnterpriseCluster));
            Assert.That(databaseResponse2.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse2.Data.GeoReplication.GroupNickname, Is.EqualTo(groupNickname));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases.Count, Is.EqualTo(2));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[0].Id, Is.EqualTo(linkedDatabaseId1));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[0].State, Is.EqualTo(RedisEnterpriseDatabaseLinkState.Linked));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[1].Id, Is.EqualTo(linkedDatabaseId2));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[1].State, Is.EqualTo(RedisEnterpriseDatabaseLinkState.Linked));

            // Check if all linked ids can be seen on database 1 as well
            databaseResponse1 = (await databaseCollection1.GetAsync(databaseName)).Value;
            Assert.That(databaseResponse1.Data.GeoReplication.LinkedDatabases.Count, Is.EqualTo(2));

            // Force unlink database 1 from active geo-replication group
            var content = new ForceUnlinkRedisEnterpriseDatabaseContent(new List<ResourceIdentifier>() { new ResourceIdentifier(linkedDatabaseId1) });
            await databaseResponse2.ForceUnlinkAsync(WaitUntil.Completed, content);

            databaseResponse2 = await databaseResponse2.GetAsync();
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases.Count, Is.EqualTo(1));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[0].Id, Is.EqualTo(linkedDatabaseId2));
            Assert.That(databaseResponse2.Data.GeoReplication.LinkedDatabases[0].State, Is.EqualTo(RedisEnterpriseDatabaseLinkState.Linked));
        }
    }
}
