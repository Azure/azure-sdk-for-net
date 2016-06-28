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
using Microsoft.Rest.Azure;
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
    public class GetListKeysFunctionalTests : TestBase, IClassFixture<TestsFixtureWithCacheCreate>
    {
        private TestsFixtureWithCacheCreate fixture;

        public GetListKeysFunctionalTests(TestsFixtureWithCacheCreate data)
        {
            fixture = data;
        }

        [Fact]
        public void GetTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                RedisResource response = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                Assert.Contains(fixture.RedisCacheName, response.Id);
                Assert.Equal(fixture.RedisCacheName, response.Name);

                Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(SkuName.Basic, response.Sku.Name);
                Assert.Equal(SkuFamily.C, response.Sku.Family);
                Assert.Equal(0, response.Sku.Capacity);
                
                Assert.Contains(fixture.RedisCacheName, response.HostName);
                Assert.Equal(6379, response.Port);
                Assert.Equal(6380, response.SslPort);
            }
        }

        [Fact]
        public void ListTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                IPage<RedisResource> listResponse = _client.Redis.ListByResourceGroup(resourceGroupName: fixture.ResourceGroupName);

                Assert.True(listResponse.Count() >= 1);

                bool found = false;
                foreach (RedisResource response in listResponse)
                {
                    if (response.Id.Contains(fixture.RedisCacheName))
                    {
                        found = true;
                        Assert.Contains(fixture.RedisCacheName, response.Id);
                        Assert.Equal(fixture.RedisCacheName, response.Name);

                        Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                        Assert.Equal(SkuName.Basic, response.Sku.Name);
                        Assert.Equal(SkuFamily.C, response.Sku.Family);
                        Assert.Equal(0, response.Sku.Capacity);
                        
                        Assert.Contains(fixture.RedisCacheName, response.HostName);
                        Assert.Equal(6379, response.Port);
                        Assert.Equal(6380, response.SslPort);
                    }
                }
                Assert.True(found, "Cache created by fixture is not found.");
            }
        }

        [Fact]
        public void ListWithoutResourceGroupTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                IPage<RedisResource> listResponse = _client.Redis.List();

                Assert.True(listResponse.Count() >= 1);

                bool found = false;
                foreach (RedisResource response in listResponse)
                {
                    if (response.Id.Contains(fixture.RedisCacheName))
                    {
                        found = true;
                        Assert.Contains(fixture.RedisCacheName, response.Id);
                        Assert.Equal(fixture.RedisCacheName, response.Name);

                        Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
                        Assert.Equal(SkuName.Basic, response.Sku.Name);
                        Assert.Equal(SkuFamily.C, response.Sku.Family);
                        Assert.Equal(0, response.Sku.Capacity);
                        
                        Assert.Contains(fixture.RedisCacheName, response.HostName);
                        Assert.Equal(6379, response.Port);
                        Assert.Equal(6380, response.SslPort);
                    }
                }
                Assert.True(found, "Cache created by fixture is not found.");
            }
        }

        [Fact]
        public void ListKeysTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                RedisListKeysResult response = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                Assert.NotNull(response.PrimaryKey);
                Assert.NotNull(response.SecondaryKey);
            }
        }

        [Fact]
        public void RegenerateKeyTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                RedisListKeysResult beforeRegenerateResponse = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);

                RedisListKeysResult afterRegenerateResponse = _client.Redis.RegenerateKey(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary });
                Assert.NotEqual(beforeRegenerateResponse.PrimaryKey, afterRegenerateResponse.PrimaryKey);
                Assert.Equal(beforeRegenerateResponse.SecondaryKey, afterRegenerateResponse.SecondaryKey);
            }
        }
    }
}
