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
        [Theory]
        // TODO: enable synchronous testing of geo replication methods.
        // An issue with the HTTP test recorder not recording LRO calls
        // is causing a 'Unable to find a matching HTTP request for URL' error.
        // This works when running in 'Record' mode just not in 'Playback' mode.
        //[InlineData(false)]
        [InlineData(true)]
        public void GeoReplicationFunctionalTest(bool async)
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
                Assert.Equal(ProvisioningState.Creating, ncResponse.ProvisioningState, ignoreCase: true);
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
                Assert.Equal(ProvisioningState.Creating, scResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, scResponse.Sku.Name);
                Assert.Equal(SkuFamily.P, scResponse.Sku.Family);

                // Wait for both cache creation to comeplete
                for (int i = 0; i < 120; i++)
                {
                    ncResponse = _client.Redis.Get(resourceGroupName, redisCacheName1);
                    scResponse = _client.Redis.Get(resourceGroupName, redisCacheName2);
                    if (ProvisioningState.Succeeded.Equals(ncResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase) &&
                        ProvisioningState.Succeeded.Equals(scResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                // Fail if any of 2 cache is not created successfully
                Assert.Equal(ProvisioningState.Succeeded, ncResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(ProvisioningState.Succeeded, scResponse.ProvisioningState, ignoreCase: true);

                RedisLinkedServerCreateParameters redisLinkedServerCreateParameters = new RedisLinkedServerCreateParameters
                {
                    LinkedRedisCacheId = scResponse.Id,
                    LinkedRedisCacheLocation = RedisCacheManagementHelper.SecondaryLocation,
                    ServerRole = ReplicationRole.Secondary
                };
                // Set up replication link asynchronously or synchronously 
                RedisLinkedServerWithProperties linkedServerWithProperties = null;
                if (async)
                {
                    linkedServerWithProperties = _client.LinkedServer.BeginCreate(resourceGroupName, redisCacheName1, redisCacheName2, redisLinkedServerCreateParameters);
                }
                else
                {
                    linkedServerWithProperties = _client.LinkedServer.Create(resourceGroupName, redisCacheName1, redisCacheName2, redisLinkedServerCreateParameters);
                    // When created synchronously, linking should be complete after create call
                    Assert.Equal(ProvisioningState.Succeeded, linkedServerWithProperties.ProvisioningState, ignoreCase: true);
                }
                // When created asynchronously, linking should complete in a couple minutes
                for (int i = 0; i < 120; i++)
                {
                    linkedServerWithProperties = _client.LinkedServer.Get(resourceGroupName, redisCacheName1, redisCacheName2);
                    if (linkedServerWithProperties.ProvisioningState.Equals(ProvisioningState.Succeeded, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                Assert.Equal(ProvisioningState.Succeeded, linkedServerWithProperties.ProvisioningState, ignoreCase: true);
                Assert.Equal(redisCacheName2, linkedServerWithProperties.Name);
                Assert.Equal(scResponse.Id, linkedServerWithProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.SecondaryLocation, linkedServerWithProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Secondary, linkedServerWithProperties.ServerRole);
                Assert.False(string.IsNullOrEmpty(linkedServerWithProperties.GeoReplicatedPrimaryHostName));

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
                if (async)
                {
                    _client.LinkedServer.BeginDelete(resourceGroupName, redisCacheName1, redisCacheName2);
                }
                else
                {
                    _client.LinkedServer.Delete(resourceGroupName, redisCacheName1, redisCacheName2);
                    // When deleted synchronously, link should be deleted after delete call 
                    Assert.Empty(_client.LinkedServer.List(resourceGroupName, redisCacheName1));
                }

                // When deleted synchronously, links should disappear in 5 min
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

