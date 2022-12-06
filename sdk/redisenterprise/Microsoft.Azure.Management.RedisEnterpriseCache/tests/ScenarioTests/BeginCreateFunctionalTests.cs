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
    public class BeginCreateFunctionalTests : TestBase
    {
        [Fact]
        public void BeginCreateFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                RedisEnterpriseCacheManagementHelper _redisEnterpriseCacheManagementHelper = new RedisEnterpriseCacheManagementHelper(this, context);
                _redisEnterpriseCacheManagementHelper.TryRegisterSubscriptionForResource();

                string resourceGroupName = TestUtilities.GenerateName("RedisEnterpriseBegin");
                string redisEnterpriseCacheName = TestUtilities.GenerateName("RedisEnterpriseBegin");
                string databaseName = "default";

                RedisEnterpriseManagementClient _client = RedisEnterpriseCacheManagementTestUtilities.GetRedisEnterpriseManagementClient(this, context);
                _redisEnterpriseCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisEnterpriseCacheManagementHelper.Location);
                Cluster clusterResponse = _client.RedisEnterprise.BeginCreate(resourceGroupName, redisEnterpriseCacheName,
                                          parameters: new Cluster
                                          {
                                              Location = RedisEnterpriseCacheManagementHelper.Location,
                                              Sku = new Sku()
                                              {
                                                  Name = SkuName.EnterpriseE10,
                                                  Capacity = 2
                                              },
                                              MinimumTlsVersion = TlsVersion.OneFullStopTwo,
                                              Zones = new List<string> { "1", "2", "3" },
                                          });

                Assert.Contains(redisEnterpriseCacheName, clusterResponse.Id);
                Assert.Equal(RedisEnterpriseCacheManagementHelper.Location, clusterResponse.Location);
                Assert.Equal(redisEnterpriseCacheName, clusterResponse.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise", clusterResponse.Type);
                Assert.Equal(ProvisioningState.Creating, clusterResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Creating, clusterResponse.ResourceState, ignoreCase: true);
                Assert.Equal(SkuName.EnterpriseE10, clusterResponse.Sku.Name);
                Assert.Equal(2, clusterResponse.Sku.Capacity);

                // Wait up to 30 minutes for cluster creation to succeed
                for (int i = 0; i < 60; i++)
                {
                    clusterResponse = _client.RedisEnterprise.Get(resourceGroupName, redisEnterpriseCacheName);
                    if (ProvisioningState.Succeeded.Equals(clusterResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
                Assert.Equal(ResourceState.Running, clusterResponse.ResourceState, ignoreCase: true);
                Assert.Equal(3, clusterResponse.Zones.Count);

                Database databaseResponse = _client.Databases.BeginCreate(resourceGroupName, redisEnterpriseCacheName, databaseName,
                                            parameters: new Database
                                            {
                                                ClientProtocol = Protocol.Encrypted,
                                                ClusteringPolicy = ClusteringPolicy.OSSCluster,
                                                EvictionPolicy = EvictionPolicy.NoEviction,
                                                Persistence = new Persistence()
                                                {
                                                    AofEnabled = true,
                                                    AofFrequency = AofFrequency.OneSecond
                                                },
                                                Modules = new List<Module>()
                                                {
                                                    new Module(name: "RedisBloom", args: "ERROR_RATE 0.01 INITIAL_SIZE 400"),
                                                    new Module(name: "RedisTimeSeries", args: "RETENTION_POLICY 20"),
                                                    new Module(name: "RediSearch")
                                                },
                                            });

                // Wait up to 30 minutes for database creation to succeed
                for (int i = 0; i < 60; i++)
                {
                    databaseResponse = _client.Databases.Get(resourceGroupName, redisEnterpriseCacheName, databaseName);
                    if (ProvisioningState.Succeeded.Equals(databaseResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }

                Assert.Contains(databaseName, databaseResponse.Id);
                Assert.Equal(databaseName, databaseResponse.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", databaseResponse.Type);
                Assert.Equal(ResourceState.Running, databaseResponse.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Encrypted, databaseResponse.ClientProtocol);
                Assert.Equal(ClusteringPolicy.OSSCluster, databaseResponse.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.NoEviction, databaseResponse.EvictionPolicy);
                Assert.Equal(3, databaseResponse.Modules.Count);

                _client.RedisEnterprise.Delete(resourceGroupName: resourceGroupName, clusterName: redisEnterpriseCacheName);
            }
        }
    }
}

