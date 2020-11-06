// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisEnterpriseCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.RedisEnterprise.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System;
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
                var _redisEnterpriseCacheManagementHelper = new RedisEnterpriseCacheManagementHelper(this, context);
                _redisEnterpriseCacheManagementHelper.TryRegisterSubscriptionForResource();

                var resourceGroupName = TestUtilities.GenerateName("RedisEnterpriseBegin");
                var redisEnterpriseCacheName = TestUtilities.GenerateName("RedisEnterpriseBegin");
                var databaseName = "default";

                var _client = RedisEnterpriseCacheManagementTestUtilities.GetRedisEnterpriseManagementClient(this, context);
                _redisEnterpriseCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisEnterpriseCacheManagementHelper.Location);
                var response = _client.RedisEnterprise.BeginCreate(resourceGroupName, redisEnterpriseCacheName,
                                parameters: new Cluster
                                {
                                    Location = RedisEnterpriseCacheManagementHelper.Location,
                                    Sku = new Sku()
                                    {
                                        Name = SkuName.EnterpriseE10,
                                        Capacity = 2
                                    },
                                    MinimumTlsVersion = "1.2",
                                    Zones = new List<string> { "1", "2", "3" },
                                });

                Assert.Contains(redisEnterpriseCacheName, response.Id);
                Assert.Equal(RedisEnterpriseCacheManagementHelper.Location, response.Location);
                Assert.Equal(redisEnterpriseCacheName, response.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise", response.Type);
                Assert.Equal(ProvisioningState.Creating, response.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Creating, response.ResourceState, ignoreCase: true);
                Assert.Equal(SkuName.EnterpriseE10, response.Sku.Name);
                Assert.Equal(2, response.Sku.Capacity);

                for (int i = 0; i < 60; i++)
                {
                    response = _client.RedisEnterprise.GetMethod(resourceGroupName, redisEnterpriseCacheName);
                    if (ProvisioningState.Succeeded.Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }
                Assert.Equal(ResourceState.Running, response.ResourceState, ignoreCase: true);
                Assert.Equal(3, response.Zones.Count);

                var responseDatabase = _client.Databases.BeginCreate(resourceGroupName, redisEnterpriseCacheName, databaseName,
                                        parameters: new Database
                                        {
                                            ClientProtocol = Protocol.Encrypted,
                                            ClusteringPolicy = ClusteringPolicy.OSSCluster,
                                            EvictionPolicy = EvictionPolicy.NoEviction,
                                            Modules = new List<Module>()
                                            {
                                                new Module(name: "RedisBloom", args: "ERROR_RATE 0.00 INITIAL_SIZE 400"),
                                                new Module(name: "RedisTimeSeries", args: "RETENTION_POLICY 20"),
                                                new Module(name: "RediSearch")
                                            },
                                        });

                Assert.Contains(databaseName, responseDatabase.Id);
                Assert.Equal(databaseName, responseDatabase.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", responseDatabase.Type);
                Assert.Equal(ProvisioningState.Succeeded, responseDatabase.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Running, responseDatabase.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Encrypted, responseDatabase.ClientProtocol);
                Assert.Equal(ClusteringPolicy.OSSCluster, responseDatabase.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.NoEviction, responseDatabase.EvictionPolicy);
                Assert.Equal(3, responseDatabase.Modules.Count);

                _client.RedisEnterprise.Delete(resourceGroupName: resourceGroupName, clusterName: redisEnterpriseCacheName);
            }
        }
    }
}

