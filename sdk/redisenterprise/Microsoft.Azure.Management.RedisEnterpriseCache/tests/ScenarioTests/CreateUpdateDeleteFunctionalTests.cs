// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisEnterpriseCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.RedisEnterprise.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System;
using Xunit;
using Microsoft.Azure.Management.ResourceManager;

namespace AzureRedisEnterpriseCache.Tests
{
    public class CreateUpdateDeleteFunctionalTests : TestBase, IClassFixture<TestsFixture>
    {
        private TestsFixture fixture;

        public CreateUpdateDeleteFunctionalTests(TestsFixture data)
        {
            fixture = data;
        }
        
        [Fact]
        public void CreateUpdateDeleteTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _client = RedisEnterpriseCacheManagementTestUtilities.GetRedisEnterpriseManagementClient(this, context);

                var responseCreate = _client.RedisEnterprise.Create(resourceGroupName: fixture.ResourceGroupName, clusterName: fixture.RedisEnterpriseCacheName,
                                        parameters: new Cluster
                                        {
                                            Location = RedisEnterpriseCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.EnterpriseFlashF300,
                                                Capacity = 3
                                            },
                                            Zones = new List<string> { "1", "2", "3" },
                                        });

                Assert.Contains(fixture.RedisEnterpriseCacheName, responseCreate.Id);
                Assert.Equal(RedisEnterpriseCacheManagementHelper.Location, responseCreate.Location);
                Assert.Equal(fixture.RedisEnterpriseCacheName, responseCreate.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise", responseCreate.Type);
                Assert.Equal(ProvisioningState.Succeeded, responseCreate.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Running, responseCreate.ResourceState, ignoreCase: true);
                Assert.Equal(SkuName.EnterpriseFlashF300, responseCreate.Sku.Name);
                Assert.Equal(3, responseCreate.Sku.Capacity);
                Assert.Equal(3, responseCreate.Zones.Count);
                Assert.Equal(0, responseCreate.PrivateEndpointConnections.Count);
                Assert.Equal(0, responseCreate.Tags.Count);

                var responseCreateDatabase = _client.Databases.Create(resourceGroupName: fixture.ResourceGroupName, clusterName: fixture.RedisEnterpriseCacheName, databaseName: fixture.DatabaseName,
                                                parameters: new Database
                                                {
                                                    ClientProtocol = Protocol.Plaintext,
                                                    ClusteringPolicy = ClusteringPolicy.EnterpriseCluster,
                                                    EvictionPolicy = EvictionPolicy.VolatileLRU,
                                                });

                Assert.Contains(fixture.DatabaseName, responseCreateDatabase.Id);
                Assert.Equal(fixture.DatabaseName, responseCreateDatabase.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", responseCreateDatabase.Type);
                Assert.Equal(ProvisioningState.Succeeded, responseCreateDatabase.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Running, responseCreateDatabase.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Plaintext, responseCreateDatabase.ClientProtocol);
                Assert.Equal(ClusteringPolicy.EnterpriseCluster, responseCreateDatabase.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.VolatileLRU, responseCreateDatabase.EvictionPolicy);

                // Database update operations are not currently supported
                /*
                var responseUpdateDatabase = _client.Databases.Update(resourceGroupName: fixture.ResourceGroupName, clusterName: fixture.RedisEnterpriseCacheName, databaseName: fixture.DatabaseName,
                                                parameters: new DatabaseUpdate
                                                {
                                                    ClientProtocol = Protocol.Encrypted,
                                                });

                Assert.Contains(fixture.DatabaseName, responseUpdateDatabase.Id);
                Assert.Equal(fixture.DatabaseName, responseUpdateDatabase.Name);
                Assert.Equal("Microsoft.Cache/redisEnterprise/databases", responseUpdateDatabase.Type);
                Assert.Equal(ProvisioningState.Succeeded, responseUpdateDatabase.ProvisioningState, ignoreCase: true);
                Assert.Equal(ResourceState.Running, responseUpdateDatabase.ResourceState, ignoreCase: true);
                Assert.Equal(Protocol.Encrypted, responseUpdateDatabase.ClientProtocol);
                Assert.Equal(ClusteringPolicy.EnterpriseCluster, responseUpdateDatabase.ClusteringPolicy);
                Assert.Equal(EvictionPolicy.VolatileLRU, responseUpdateDatabase.EvictionPolicy);
                */

                _client.RedisEnterprise.Delete(resourceGroupName: fixture.ResourceGroupName, clusterName: fixture.RedisEnterpriseCacheName);
            }
        }
    }
}

