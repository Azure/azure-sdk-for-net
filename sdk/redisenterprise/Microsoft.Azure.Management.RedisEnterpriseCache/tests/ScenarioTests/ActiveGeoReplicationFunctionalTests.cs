// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AzureRedisEnterpriseCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.RedisEnterprise.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;


namespace AzureRedisEnterpriseCache.Tests
{
    public class ActiveGeoReplicationFunctionalTests : TestBase
    {
        [Fact]
        public void ActiveGeoReplicationFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceGroupName = TestUtilities.GenerateName("RedisActiveGeo");
                var redisEnterpriseCacheName1 = TestUtilities.GenerateName("RedisActiveGeo1");
                var redisEnterpriseCacheName2 = TestUtilities.GenerateName("RedisActiveGeo2");
                string databaseName = "default";
                string groupNickname = TestUtilities.GenerateName("activeGeoTesting");

                var _redisEnterpriseCacheManagementHelper = new RedisEnterpriseCacheManagementHelper(this, context);
                _redisEnterpriseCacheManagementHelper.TryRegisterSubscriptionForResource();
                _redisEnterpriseCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisEnterpriseCacheManagementHelper.Location);
                RedisEnterpriseManagementClient _client = RedisEnterpriseCacheManagementTestUtilities.GetRedisEnterpriseManagementClient(this, context);

                // Create cache in east us
                Cluster clusterResponse1 = _client.RedisEnterprise.BeginCreate(resourceGroupName, redisEnterpriseCacheName1,
                                      parameters: new Cluster
                                      {
                                          Location = RedisEnterpriseCacheManagementHelper.Location,
                                          Sku = new Sku()
                                          {
                                              Name = SkuName.EnterpriseE10,
                                              Capacity = 2
                                          }
                                      });
                Assert.Contains(redisEnterpriseCacheName1, clusterResponse1.Id);
                Assert.Equal(RedisEnterpriseCacheManagementHelper.Location, clusterResponse1.Location);
                Assert.Equal(redisEnterpriseCacheName1, clusterResponse1.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise", clusterResponse1.Type);
                Assert.Equal(ProvisioningState.Creating, clusterResponse1.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Creating, clusterResponse1.ResourceState, ignoreCase: true);
                Assert.Equal(SkuName.EnterpriseE10, clusterResponse1.Sku.Name);
                Assert.Equal(2, clusterResponse1.Sku.Capacity);

                // Create cache in west us
                Cluster clusterResponse2 = _client.RedisEnterprise.BeginCreate(resourceGroupName, redisEnterpriseCacheName2,
                                      parameters: new Cluster
                                      {
                                          Location = RedisEnterpriseCacheManagementHelper.SecondaryLocation,
                                          Sku = new Sku()
                                          {
                                              Name = SkuName.EnterpriseE10,
                                              Capacity = 2
                                          }
                                      });
                Assert.Contains(redisEnterpriseCacheName2, clusterResponse2.Id);
                Assert.Equal(RedisEnterpriseCacheManagementHelper.SecondaryLocation, clusterResponse2.Location);
                Assert.Equal(redisEnterpriseCacheName2, clusterResponse2.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise", clusterResponse2.Type);
                Assert.Equal(ProvisioningState.Creating, clusterResponse2.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Creating, clusterResponse2.ResourceState, ignoreCase: true);
                Assert.Equal(SkuName.EnterpriseE10, clusterResponse2.Sku.Name);
                Assert.Equal(2, clusterResponse2.Sku.Capacity);

                // Wait for both cache creation to complete
                for (int i = 0; i < 120; i++)
                {
                    clusterResponse1 = _client.RedisEnterprise.Get(resourceGroupName, redisEnterpriseCacheName1);
                    clusterResponse2 = _client.RedisEnterprise.Get(resourceGroupName, redisEnterpriseCacheName2);
                    if (ProvisioningState.Succeeded.Equals(clusterResponse1.ProvisioningState, StringComparison.OrdinalIgnoreCase) &&
                        ProvisioningState.Succeeded.Equals(clusterResponse2.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
                Assert.Equal(ResourceState.Running, clusterResponse1.ResourceState, ignoreCase: true);
                Assert.Equal(ResourceState.Running, clusterResponse2.ResourceState, ignoreCase: true);

                // Fail if a cache is not created successfully
                Assert.Equal(ProvisioningState.Succeeded, clusterResponse1.ProvisioningState, ignoreCase: true);
                Assert.Equal(ProvisioningState.Succeeded, clusterResponse2.ProvisioningState, ignoreCase: true);

                // create db for cluster 1
                string linkedDatabaseId1 = clusterResponse1.Id + "/databases/" + databaseName;
                Database databaseResponse1 = _client.Databases.BeginCreate(resourceGroupName, redisEnterpriseCacheName1, databaseName,
                                            parameters: new Database
                                            {
                                                ClientProtocol = Protocol.Encrypted,
                                                ClusteringPolicy = ClusteringPolicy.EnterpriseCluster,
                                                EvictionPolicy = EvictionPolicy.NoEviction,
                                                GeoReplication = new DatabasePropertiesGeoReplication()
                                                {
                                                    GroupNickname = groupNickname,
                                                    LinkedDatabases = new List<LinkedDatabase>() {
                                                        new LinkedDatabase(id: linkedDatabaseId1)
                                                    }
                                                }
                                            });
                Assert.Equal(LinkState.Linking, databaseResponse1.GeoReplication.LinkedDatabases[0].State);

                // Wait up to 30 minutes for database creation to succeed
                for (int i = 0; i < 60; i++)
                {
                    databaseResponse1 = _client.Databases.Get(resourceGroupName, redisEnterpriseCacheName1, databaseName);
                    if (ProvisioningState.Succeeded.Equals(databaseResponse1.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
                Assert.Contains(databaseName, databaseResponse1.Id);
                Assert.Equal(databaseName, databaseResponse1.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", databaseResponse1.Type);
                Assert.Equal(ResourceState.Running, databaseResponse1.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Encrypted, databaseResponse1.ClientProtocol);
                Assert.Equal(ClusteringPolicy.EnterpriseCluster, databaseResponse1.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.NoEviction, databaseResponse1.EvictionPolicy);
                Assert.Equal(groupNickname, databaseResponse1.GeoReplication.GroupNickname);
                Assert.Equal(linkedDatabaseId1, databaseResponse1.GeoReplication.LinkedDatabases[0].Id);
                Assert.Equal(LinkState.Linked, databaseResponse1.GeoReplication.LinkedDatabases[0].State);


                // create db for cluster 2
                string linkedDatabaseId2 = clusterResponse2.Id + "/databases/" + databaseName;
                Database databaseResponse2 = _client.Databases.BeginCreate(resourceGroupName, redisEnterpriseCacheName2, databaseName,
                                            parameters: new Database
                                            {
                                                ClientProtocol = Protocol.Encrypted,
                                                ClusteringPolicy = ClusteringPolicy.EnterpriseCluster,
                                                EvictionPolicy = EvictionPolicy.NoEviction,
                                                GeoReplication = new DatabasePropertiesGeoReplication()
                                                {
                                                    GroupNickname = groupNickname,
                                                    LinkedDatabases = new List<LinkedDatabase>() {
                                                        new LinkedDatabase(id: linkedDatabaseId1),
                                                        new LinkedDatabase(id: linkedDatabaseId2)
                                                    }
                                                }
                                            });
                Assert.Equal(LinkState.Linking, databaseResponse2.GeoReplication.LinkedDatabases[1].State);

                // Wait up to 30 minutes for database creation to succeed
                for (int i = 0; i < 60; i++)
                {
                    databaseResponse2 = _client.Databases.Get(resourceGroupName, redisEnterpriseCacheName2, databaseName);
                    if (ProvisioningState.Succeeded.Equals(databaseResponse2.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
                Assert.Contains(databaseName, databaseResponse2.Id);
                Assert.Equal(databaseName, databaseResponse2.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", databaseResponse2.Type);
                Assert.Equal(ResourceState.Running, databaseResponse2.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Encrypted, databaseResponse2.ClientProtocol);
                Assert.Equal(ClusteringPolicy.EnterpriseCluster, databaseResponse2.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.NoEviction, databaseResponse2.EvictionPolicy);
                Assert.Equal(groupNickname, databaseResponse2.GeoReplication.GroupNickname);
                Assert.Equal(2, databaseResponse2.GeoReplication.LinkedDatabases.Count);
                Assert.Equal(linkedDatabaseId1, databaseResponse2.GeoReplication.LinkedDatabases[0].Id);
                Assert.Equal(LinkState.Linked, databaseResponse2.GeoReplication.LinkedDatabases[0].State);
                Assert.Equal(linkedDatabaseId2, databaseResponse2.GeoReplication.LinkedDatabases[1].Id);
                Assert.Equal(LinkState.Linked, databaseResponse2.GeoReplication.LinkedDatabases[1].State);

                // Check if all linked ids can be seen on database 1 as well
                databaseResponse1 = _client.Databases.Get(resourceGroupName, redisEnterpriseCacheName1, databaseName);
                Assert.Equal(2, databaseResponse1.GeoReplication.LinkedDatabases.Count);

                // Force unlink database 1 from active geo-replication group
                _client.Databases.ForceUnlink(resourceGroupName, redisEnterpriseCacheName2, databaseName, new List<string>() { linkedDatabaseId1 });

                // Wait for 5 min
                for (int i = 0; i < 10; i++)
                {
                    databaseResponse2 = _client.Databases.Get(resourceGroupName, redisEnterpriseCacheName2, databaseName);
                    if (databaseResponse2.GeoReplication.LinkedDatabases.Count.Equals(1))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
                Assert.Equal(1, databaseResponse2.GeoReplication.LinkedDatabases.Count);
                Assert.Equal(linkedDatabaseId2, databaseResponse2.GeoReplication.LinkedDatabases[0].Id);
                Assert.Equal(LinkState.Linked, databaseResponse2.GeoReplication.LinkedDatabases[0].State);

                // Clean up resources
                _client.RedisEnterprise.Delete(resourceGroupName: resourceGroupName, clusterName: redisEnterpriseCacheName1);
                _client.RedisEnterprise.Delete(resourceGroupName: resourceGroupName, clusterName: redisEnterpriseCacheName2);
            }
        }
    }
}