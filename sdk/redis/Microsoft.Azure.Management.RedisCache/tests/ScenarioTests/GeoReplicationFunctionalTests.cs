// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class GeoReplicationFunctionalTests : TestBase
    {
        [Fact]
        public void GeoReplicationFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var resourceGroupName = TestUtilities.GenerateName("RedisGeo");
                var redisCacheName1 = TestUtilities.GenerateName("RedisGeo1");
                var redisCacheName2 = TestUtilities.GenerateName("RedisGeo2");

                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);

                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                // Create cache in ncus
                RedisResource ncResponse = _client.Redis.BeginCreate(resourceGroupName, redisCacheName1,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                Assert.Contains(redisCacheName1, ncResponse.Id);
                Assert.Equal(redisCacheName1, ncResponse.Name);
                Assert.Equal("creating", ncResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, ncResponse.Sku.Name);
                Assert.Equal(SkuFamily.P, ncResponse.Sku.Family);

                // Create cache in scus
                RedisResource scResponse = _client.Redis.BeginCreate(resourceGroupName, redisCacheName2,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.SecondaryLocation,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                Assert.Contains(redisCacheName2, scResponse.Id);
                Assert.Equal(redisCacheName2, scResponse.Name);
                Assert.Equal("creating", scResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, scResponse.Sku.Name);
                Assert.Equal(SkuFamily.P, scResponse.Sku.Family);

                // Wait for both cache creation to comeplete
                for (int i = 0; i < 120; i++)
                {
                    ncResponse = _client.Redis.Get(resourceGroupName, redisCacheName1);
                    scResponse = _client.Redis.Get(resourceGroupName, redisCacheName2);
                    if ("succeeded".Equals(ncResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase) &&
                        "succeeded".Equals(scResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                // Fail if any of 2 cache is not created successfully
                Assert.Equal("succeeded", ncResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal("succeeded", scResponse.ProvisioningState, ignoreCase: true);
                
                // Set up replication link
                RedisLinkedServerWithProperties linkServerWithProperties = _client.LinkedServer.Create(resourceGroupName, redisCacheName1, redisCacheName2, new RedisLinkedServerCreateParameters
                                                    {
                                                        LinkedRedisCacheId = scResponse.Id,
                                                        LinkedRedisCacheLocation = RedisCacheManagementHelper.SecondaryLocation,
                                                        ServerRole = ReplicationRole.Secondary
                                                    });

                Assert.Equal(redisCacheName2, linkServerWithProperties.Name);
                Assert.Equal(scResponse.Id, linkServerWithProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.SecondaryLocation, linkServerWithProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Secondary, linkServerWithProperties.ServerRole);
                Assert.Equal("succeeded", linkServerWithProperties.ProvisioningState, ignoreCase: true);

                // test get response from primary
                RedisLinkedServerWithProperties primaryLinkProperties = _client.LinkedServer.Get(resourceGroupName, redisCacheName1, redisCacheName2);
                Assert.Equal(scResponse.Id, primaryLinkProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.SecondaryLocation, primaryLinkProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Secondary, primaryLinkProperties.ServerRole);

                // test list response from primary
                IPage<RedisLinkedServerWithProperties> allPrimaryLinkProperties = _client.LinkedServer.List(resourceGroupName, redisCacheName1);
                Assert.Single(allPrimaryLinkProperties);
                
                // test get response from secondary
                RedisLinkedServerWithProperties secondaryLinkProperties = _client.LinkedServer.Get(resourceGroupName, redisCacheName2, redisCacheName1);
                Assert.Equal(ncResponse.Id, secondaryLinkProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.Location, secondaryLinkProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Primary, secondaryLinkProperties.ServerRole);

                // test list response from secondary
                IPage<RedisLinkedServerWithProperties> allSecondaryLinkProperties = _client.LinkedServer.List(resourceGroupName, redisCacheName2);
                Assert.Single(allSecondaryLinkProperties);

                // Delete link on primary
                _client.LinkedServer.Delete(resourceGroupName, redisCacheName1, redisCacheName2);

                // links should disappear in 5 min
                IPage<RedisLinkedServerWithProperties> afterDeletePrimaryLinkProperties = null;
                IPage<RedisLinkedServerWithProperties> afterDeleteSecondaryLinkProperties = null;
                for (int i = 0; i < 10; i++)
                {
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                    afterDeletePrimaryLinkProperties = _client.LinkedServer.List(resourceGroupName, redisCacheName1);
                    afterDeleteSecondaryLinkProperties = _client.LinkedServer.List(resourceGroupName, redisCacheName2);
                    if (afterDeletePrimaryLinkProperties.Count() == 0 && afterDeleteSecondaryLinkProperties.Count() == 0) break;
                }
                Assert.NotNull(afterDeletePrimaryLinkProperties);
                Assert.Empty(afterDeletePrimaryLinkProperties);
                Assert.NotNull(afterDeleteSecondaryLinkProperties);
                Assert.Empty(afterDeleteSecondaryLinkProperties);

                // Clean up both caches and delete resource group
                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName1);
                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName2);
                _redisCacheManagementHelper.DeleteResourceGroup(resourceGroupName);
            }
        }
    }
}

