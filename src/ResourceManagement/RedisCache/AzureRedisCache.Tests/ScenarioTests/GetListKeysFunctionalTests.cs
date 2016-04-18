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
    public class GetListKeysFunctionalTests : TestBase, IUseFixture<TestsFixtureWithCacheCreate>
    {
        private TestsFixtureWithCacheCreate fixture;

        public void SetFixture(TestsFixtureWithCacheCreate data)
        {
            fixture = data;
        }

        [Fact]
        public void GetTest()
        {
            TestUtilities.StartTest();
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);
            RedisGetResponse response = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            Assert.NotNull(response.RequestId);
            Assert.Contains(fixture.RedisCacheName, response.Resource.Id);
            Assert.Equal(fixture.RedisCacheName, response.Resource.Name);

            Assert.True("succeeded".Equals(response.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
            Assert.Equal(SkuName.Basic, response.Resource.Properties.Sku.Name);
            Assert.Equal(SkuFamily.C, response.Resource.Properties.Sku.Family);
            Assert.Equal(0, response.Resource.Properties.Sku.Capacity);

            Assert.Contains(fixture.RedisCacheName, response.Resource.Properties.HostName);
            Assert.Equal(6379, response.Resource.Properties.Port);
            Assert.Equal(6380, response.Resource.Properties.SslPort);
            TestUtilities.EndTest();
        }

        [Fact]
        public void ListTest()
        {
            TestUtilities.StartTest();
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);
            RedisListResponse listResponse = _client.Redis.List(resourceGroupName: fixture.ResourceGroupName);

            Assert.NotNull(listResponse.RequestId);
            Assert.True(listResponse.Value.Count >= 1);

            bool found = false;
            foreach (RedisResource response in listResponse.Value)
            {
                if (response.Id.Contains(fixture.RedisCacheName))
                {
                    found = true;
                    Assert.Contains(fixture.RedisCacheName, response.Id);
                    Assert.Equal(fixture.RedisCacheName, response.Name);

                    Assert.True("succeeded".Equals(response.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
                    Assert.Equal(SkuName.Basic, response.Properties.Sku.Name);
                    Assert.Equal(SkuFamily.C, response.Properties.Sku.Family);
                    Assert.Equal(0, response.Properties.Sku.Capacity);
                    
                    Assert.Contains(fixture.RedisCacheName, response.Properties.HostName);
                    Assert.Equal(6379, response.Properties.Port);
                    Assert.Equal(6380, response.Properties.SslPort);
                }
            }
            Assert.True(found, "Cache created by fixture is not found.");
            TestUtilities.EndTest();
        }

        [Fact]
        public void ListWithoutResourceGroupTest()
        {
            TestUtilities.StartTest();
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);
            RedisListResponse listResponse = _client.Redis.List(null);

            Assert.NotNull(listResponse.RequestId);
            Assert.True(listResponse.Value.Count >= 1);

            bool found = false;
            foreach (RedisResource response in listResponse.Value)
            {
                if (response.Id.Contains(fixture.RedisCacheName))
                {
                    found = true;
                    Assert.Contains(fixture.RedisCacheName, response.Id);
                    Assert.Equal(fixture.RedisCacheName, response.Name);

                    Assert.True("succeeded".Equals(response.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase));
                    Assert.Equal(SkuName.Basic, response.Properties.Sku.Name);
                    Assert.Equal(SkuFamily.C, response.Properties.Sku.Family);
                    Assert.Equal(0, response.Properties.Sku.Capacity);
                    
                    Assert.Contains(fixture.RedisCacheName, response.Properties.HostName);
                    Assert.Equal(6379, response.Properties.Port);
                    Assert.Equal(6380, response.Properties.SslPort);
                }
            }
            Assert.True(found, "Cache created by fixture is not found.");
            TestUtilities.EndTest(); 
        }

        [Fact]
        public void ListKeysTest()
        {
            TestUtilities.StartTest();
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);
            RedisListKeysResponse response = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            Assert.NotNull(response.PrimaryKey);
            Assert.NotNull(response.SecondaryKey);
            TestUtilities.EndTest(); 
        }

        [Fact]
        public void RegenerateKeyTest()
        {
            TestUtilities.StartTest();
            var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this);

            RedisListKeysResponse beforeRegenerateResponse = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);

            AzureOperationResponse response = _client.Redis.RegenerateKey(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary });
            Assert.NotNull(response.RequestId);

            RedisListKeysResponse afterRegenerateResponse = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
            Assert.NotEqual(beforeRegenerateResponse.PrimaryKey, afterRegenerateResponse.PrimaryKey);
            Assert.Equal(beforeRegenerateResponse.SecondaryKey, afterRegenerateResponse.SecondaryKey);
            TestUtilities.EndTest(); 
        }
    }
}
