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
    public class BeginCreateFunctionalTests : TestBase
    {
        [Fact]
        public void BeginCreateFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                var resourceGroupName = TestUtilities.GenerateName("RedisBegin");
                var redisCacheName = TestUtilities.GenerateName("RedisBegin");

                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);
                RedisResource response = _client.Redis.BeginCreate(resourceGroupName, redisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            },
                                            MinimumTlsVersion = TlsVersion.OneFullStopTwo,
                                            ReplicasPerMaster = 2,
                                        });

                Assert.Contains(redisCacheName, response.Id);
                Assert.Equal(redisCacheName, response.Name);
                Assert.Equal(ProvisioningState.Creating, response.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);
                Assert.Equal(TlsVersion.OneFullStopTwo, response.MinimumTlsVersion);
                Assert.Equal(2, response.ReplicasPerMaster);

                Assert.Equal(3, response.Instances.Count);
                for (int i = 0; i < response.Instances.Count; i++)
                {
                    Assert.Equal(15000 + i, response.Instances[i].SslPort);
                    Assert.Null(response.Instances[i].NonSslPort);
                    Assert.Null(response.Instances[i].ShardId);
                    Assert.Null(response.Instances[i].Zone);
                    Assert.Null(response.Instances[i].IsMaster);
                }

                for (int i = 0; i < 60; i++)
                {
                    response = _client.Redis.Get(resourceGroupName, redisCacheName);
                    if (ProvisioningState.Succeeded.Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName);
                _redisCacheManagementHelper.DeleteResourceGroup(resourceGroupName);
            }
        }
    }
}

