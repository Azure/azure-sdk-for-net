// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class RebootFunctionalTests : TestBase
    {
        [Fact]
        public void RebootBothNodesTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();
                var resourceGroupName = TestUtilities.GenerateName("redisCacheRG");
                var redisCacheName = TestUtilities.GenerateName("sunnyprimary");
                var location = "westus";
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, location);
                _client.Redis.Create(resourceGroupName, redisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                // First try to get cache and verify that it is premium cache
                RedisResource response = _client.Redis.Get(resourceGroupName, redisCacheName);
                Assert.Contains(redisCacheName, response.Id);
                Assert.Equal(redisCacheName, response.Name);
                Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);

                RedisRebootParameters rebootParameter = new RedisRebootParameters {
                    RebootType = RebootType.AllNodes
                };
                _client.Redis.ForceReboot(resourceGroupName, redisCacheName, parameters: rebootParameter);
            }
        }
    }
}
