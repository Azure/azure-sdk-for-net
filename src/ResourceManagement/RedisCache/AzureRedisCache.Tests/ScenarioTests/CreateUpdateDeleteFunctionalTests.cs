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
                                            Properties = new RedisProperties
                                            {
                                                Sku = new Sku()
                                                {
                                                    Name = SkuName.Basic,
                                                    Family = SkuFamily.C,
                                                    Capacity = 0
                                                }
                                            }
                                        });

                Assert.Contains(fixture.RedisCacheName, responseCreate.Id);
                Assert.Equal(fixture.Location, responseCreate.Location);
                Assert.Equal(fixture.RedisCacheName, responseCreate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseCreate.Type);

                Assert.True("creating".Equals(responseCreate.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Basic, responseCreate.Properties.Sku.Name);
                Assert.Equal(SkuFamily.C, responseCreate.Properties.Sku.Family);
                Assert.Equal(0, responseCreate.Properties.Sku.Capacity);
                
                Assert.Contains(fixture.RedisCacheName, responseCreate.Properties.HostName);
                Assert.Equal(6379, responseCreate.Properties.Port);
                Assert.Equal(6380, responseCreate.Properties.SslPort);
                Assert.False(responseCreate.Properties.EnableNonSslPort);
            
                // wait for maximum 30 minutes for cache to create
                for (int i = 0; i < 60; i++)
                {
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                    RedisResource responseGet = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                    if ("succeeded".Equals(responseGet.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
                }

                RedisResourceWithAccessKey responseUpdate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                        parameters: new RedisCreateOrUpdateParameters
                                        {
                                            Location = fixture.Location,
                                            Properties = new RedisProperties
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
                                            }
                                        });

                Assert.Contains(fixture.RedisCacheName, responseUpdate.Id);
                Assert.Equal(fixture.Location, responseUpdate.Location);
                Assert.Equal(fixture.RedisCacheName, responseUpdate.Name);
                Assert.Equal("Microsoft.Cache/Redis", responseUpdate.Type);

                Assert.Equal(SkuName.Basic, responseUpdate.Properties.Sku.Name);
                Assert.Equal(SkuFamily.C, responseUpdate.Properties.Sku.Family);
                Assert.Equal(0, responseUpdate.Properties.Sku.Capacity);
                Assert.Equal("allkeys-lru", responseUpdate.Properties.RedisConfiguration["maxmemory-policy"]);

                Assert.Contains(fixture.RedisCacheName, responseUpdate.Properties.HostName);
                Assert.Equal(6379, responseUpdate.Properties.Port);
                Assert.Equal(6380, responseUpdate.Properties.SslPort);
                Assert.True(responseUpdate.Properties.EnableNonSslPort);

                _client.Redis.Delete(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            }
        }
    }
}
