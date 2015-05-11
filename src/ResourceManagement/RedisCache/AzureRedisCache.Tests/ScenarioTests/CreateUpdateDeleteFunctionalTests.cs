using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class CreateUpdateDeleteFunctionalTests : TestBase, IUseFixture<TestsFixture>
    {
        private TestsFixture fixture;

        public void SetFixture(TestsFixture data)
        {
            fixture = data;
        }

        [Fact]
        public void CreateUpdateDeleteTest()
        {
            TestUtilities.StartTest();
            
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);

            RedisCreateOrUpdateResponse responseCreate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = fixture.Location,
                                        Properties = new RedisProperties
                                        {
                                            RedisVersion = "2.8",
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 0
                                            }
                                        }
                                    });

            Assert.NotNull(responseCreate.RequestId);
            Assert.Contains(fixture.RedisCacheName, responseCreate.Id);
            Assert.Equal(fixture.Location, responseCreate.Location);
            Assert.Equal(fixture.RedisCacheName, responseCreate.Name);
            Assert.Equal("Microsoft.Cache/Redis", responseCreate.Type);
                
            Assert.True("creating".Equals(responseCreate.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
            Assert.Equal(SkuName.Basic, responseCreate.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, responseCreate.Properties.Sku.Family);
            Assert.Equal(0, responseCreate.Properties.Sku.Capacity);
            Assert.Contains("2.8", responseCreate.Properties.RedisVersion);
                        
            Assert.Contains(fixture.RedisCacheName, responseCreate.Properties.HostName);
            Assert.Equal(6379, responseCreate.Properties.Port);
            Assert.Equal(6380, responseCreate.Properties.SslPort);
            Assert.False(responseCreate.Properties.EnableNonSslPort);
            
            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                RedisGetResponse responseGet = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                if ("succeeded".Equals(responseGet.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
            }

            RedisCreateOrUpdateResponse responseUpdate = _client.Redis.CreateOrUpdate(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = fixture.Location,
                                        Properties = new RedisProperties
                                        {
                                            RedisVersion = "2.8",
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Basic,
                                                Family = SkuFamily.C,
                                                Capacity = 0
                                            },
                                            MaxMemoryPolicy = MaxMemoryPolicy.AllKeysLRU,
                                            EnableNonSslPort = true
                                        }
                                    });

            Assert.NotNull(responseUpdate.RequestId);
            Assert.Contains(fixture.RedisCacheName, responseUpdate.Id);
            Assert.Equal(fixture.Location, responseUpdate.Location);
            Assert.Equal(fixture.RedisCacheName, responseUpdate.Name);
            Assert.Equal("Microsoft.Cache/Redis", responseUpdate.Type);

            Assert.Equal(SkuName.Basic, responseUpdate.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, responseUpdate.Properties.Sku.Family);
            Assert.Equal(0, responseUpdate.Properties.Sku.Capacity);
            Assert.Contains("2.8", responseUpdate.Properties.RedisVersion);
            Assert.True(MaxMemoryPolicy.AllKeysLRU.Equals(responseUpdate.Properties.MaxMemoryPolicy.Replace("-", ""), StringComparison.InvariantCultureIgnoreCase));

            Assert.Contains(fixture.RedisCacheName, responseUpdate.Properties.HostName);
            Assert.Equal(6379, responseUpdate.Properties.Port);
            Assert.Equal(6380, responseUpdate.Properties.SslPort);
            Assert.True(responseUpdate.Properties.EnableNonSslPort);

            AzureOperationResponse responseDelete = _client.Redis.Delete(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                
            List<HttpStatusCode> acceptedStatusCodes = new List<HttpStatusCode>();
            acceptedStatusCodes.Add(HttpStatusCode.OK);
            acceptedStatusCodes.Add(HttpStatusCode.Accepted);
            acceptedStatusCodes.Add(HttpStatusCode.NotFound);

            Assert.Contains<HttpStatusCode>(responseDelete.StatusCode, acceptedStatusCodes);
            Assert.NotNull(responseDelete.RequestId);

            TestUtilities.EndTest();
        }
    }
}
