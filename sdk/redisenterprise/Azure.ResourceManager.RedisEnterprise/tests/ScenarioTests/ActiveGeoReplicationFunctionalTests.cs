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
                PublicNetworkAccess = PublicNetworkAccess.Enabled
            };

            var clusterResponse1 = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName1, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse1.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName1, clusterResponse1.Data.Name);
            Assert.AreEqual("Microsoft.Cache/redisEnterprise", clusterResponse1.Data.ResourceType);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse1.Data.Sku.Name);
            Assert.AreEqual(2, clusterResponse1.Data.Sku.Capacity);

            // Create cache in west us
            data = new RedisEnterpriseClusterData(
                AzureLocation.WestUS,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                {
                    Capacity = 2
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                PublicNetworkAccess = PublicNetworkAccess.Enabled
            };

            var clusterResponse2 = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName2, data)).Value;
            Assert.AreEqual(AzureLocation.WestUS, clusterResponse2.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName2, clusterResponse2.Data.Name);
            Assert.AreEqual("Microsoft.Cache/redisEnterprise", clusterResponse2.Data.ResourceType);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse2.Data.Sku.Name);
            Assert.AreEqual(2, clusterResponse2.Data.Sku.Capacity);

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
            Assert.AreEqual(databaseName, databaseResponse1.Data.Name);
            Assert.AreEqual("Microsoft.Cache/redisEnterprise/databases", databaseResponse1.Data.ResourceType);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse1.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse1.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse1.Data.EvictionPolicy);
            Assert.AreEqual(groupNickname, databaseResponse1.Data.GeoReplication.GroupNickname);
            Assert.AreEqual(linkedDatabaseId1, databaseResponse1.Data.GeoReplication.LinkedDatabases[0].Id);
            Assert.AreEqual(RedisEnterpriseDatabaseLinkState.Linked, databaseResponse1.Data.GeoReplication.LinkedDatabases[0].State);

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
            Assert.AreEqual(databaseName, databaseResponse2.Data.Name);
            Assert.AreEqual("Microsoft.Cache/redisEnterprise/databases", databaseResponse2.Data.ResourceType);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse2.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse2.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse2.Data.EvictionPolicy);
            Assert.AreEqual(groupNickname, databaseResponse2.Data.GeoReplication.GroupNickname);
            Assert.AreEqual(2, databaseResponse2.Data.GeoReplication.LinkedDatabases.Count);
            Assert.AreEqual(linkedDatabaseId1, databaseResponse2.Data.GeoReplication.LinkedDatabases[0].Id);
            Assert.AreEqual(RedisEnterpriseDatabaseLinkState.Linked, databaseResponse2.Data.GeoReplication.LinkedDatabases[0].State);
            Assert.AreEqual(linkedDatabaseId2, databaseResponse2.Data.GeoReplication.LinkedDatabases[1].Id);
            Assert.AreEqual(RedisEnterpriseDatabaseLinkState.Linked, databaseResponse2.Data.GeoReplication.LinkedDatabases[1].State);

            // Check if all linked ids can be seen on database 1 as well
            databaseResponse1 = (await databaseCollection1.GetAsync(databaseName)).Value;
            Assert.AreEqual(2, databaseResponse1.Data.GeoReplication.LinkedDatabases.Count);

            // Force unlink database 1 from active geo-replication group
            var content = new ForceUnlinkRedisEnterpriseDatabaseContent(new List<ResourceIdentifier>() { new ResourceIdentifier(linkedDatabaseId1) });
            await databaseResponse2.ForceUnlinkAsync(WaitUntil.Completed, content);

            databaseResponse2 = await databaseResponse2.GetAsync();
            Assert.AreEqual(1, databaseResponse2.Data.GeoReplication.LinkedDatabases.Count);
            Assert.AreEqual(linkedDatabaseId2, databaseResponse2.Data.GeoReplication.LinkedDatabases[0].Id);
            Assert.AreEqual(RedisEnterpriseDatabaseLinkState.Linked, databaseResponse2.Data.GeoReplication.LinkedDatabases[0].State);
        }
    }
}
