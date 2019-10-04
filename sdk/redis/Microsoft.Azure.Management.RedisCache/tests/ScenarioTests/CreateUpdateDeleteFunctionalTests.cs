// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
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
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                var responseCreate = _client.Redis.Create(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 0
                                            }
                                        });

                Assert.Contains(fixture.RedisCacheName, responseCreate.Id);
                Assert.Equal(RedisCacheManagementHelper.Location, responseCreate.Location);
                Assert.Equal(fixture.RedisCacheName, responseCreate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseCreate.Type);

                Assert.Equal("succeeded", responseCreate.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Basic, responseCreate.Sku.Name);
                Assert.Equal(SkuFamily.C, responseCreate.Sku.Family);
                Assert.Equal(0, responseCreate.Sku.Capacity);
                
                Assert.Contains(fixture.RedisCacheName, responseCreate.HostName);
                Assert.Equal(6379, responseCreate.Port);
                Assert.Equal(6380, responseCreate.SslPort);
                Assert.False(responseCreate.EnableNonSslPort);

                var responseUpdate = _client.Redis.Update(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisUpdateParameters
                                        {
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 0
                                            },
                                            RedisConfiguration = new Dictionary<string, string>() {
                                                    {"maxmemory-policy","allkeys-lru"}
                                            },
                                            EnableNonSslPort = true
                                        });

                Assert.Contains(fixture.RedisCacheName, responseUpdate.Id);
                Assert.Equal(RedisCacheManagementHelper.Location, responseUpdate.Location);
                Assert.Equal(fixture.RedisCacheName, responseUpdate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseUpdate.Type);

                Assert.Equal(SkuName.Basic, responseUpdate.Sku.Name);
                Assert.Equal(SkuFamily.C, responseUpdate.Sku.Family);
                Assert.Equal(0, responseUpdate.Sku.Capacity);
                Assert.Equal("allkeys-lru", responseUpdate.RedisConfiguration["maxmemory-policy"]);

                Assert.Contains(fixture.RedisCacheName, responseUpdate.HostName);
                Assert.Equal(6379, responseUpdate.Port);
                Assert.Equal(6380, responseUpdate.SslPort);
                Assert.True(responseUpdate.EnableNonSslPort);

                _client.Redis.Delete(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            }
        }
    }
}

