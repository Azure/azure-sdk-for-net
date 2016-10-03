// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
            using (var context = MockContext.Start(this.GetType().FullName))
            { 
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                RedisResourceWithAccessKey responseCreate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisCreateOrUpdateParameters
                                        {
                                            Location = fixture.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 0
                                            }
                                        });

                Assert.Contains(fixture.RedisCacheName, responseCreate.Id);
                Assert.Equal(fixture.Location, responseCreate.Location);
                Assert.Equal(fixture.RedisCacheName, responseCreate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseCreate.Type);

                Assert.True("creating".Equals(responseCreate.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Basic, responseCreate.Sku.Name);
                Assert.Equal(SkuFamily.C, responseCreate.Sku.Family);
                Assert.Equal(0, responseCreate.Sku.Capacity);
                
                Assert.Contains(fixture.RedisCacheName, responseCreate.HostName);
                Assert.Equal(6379, responseCreate.Port);
                Assert.Equal(6380, responseCreate.SslPort);
                Assert.False(responseCreate.EnableNonSslPort);
            
                // wait for maximum 30 minutes for cache to create
                for (int i = 0; i < 60; i++)
                {
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                    RedisResource responseGet = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                    if ("succeeded".Equals(responseGet.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
                }

                RedisResourceWithAccessKey responseUpdate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisCreateOrUpdateParameters
                                        {
                                            Location = fixture.Location,
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
                Assert.Equal(fixture.Location, responseUpdate.Location);
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
