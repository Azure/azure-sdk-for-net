// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
        }

        [Fact]
        public void GetTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                RedisResource response = _client.Redis.Get(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                Assert.Contains(fixture.RedisCacheName, response.Id);
                Assert.Equal(fixture.RedisCacheName, response.Name);

                Assert.Equal("succeeded", response.ProvisioningState, ignoreCase: true);
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
            using (var context = MockContext.Start(this.GetType()))
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

                        Assert.Equal("succeeded", response.ProvisioningState, ignoreCase: true);
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
            using (var context = MockContext.Start(this.GetType()))
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

                        Assert.Equal("succeeded", response.ProvisioningState, ignoreCase: true);
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
            using (var context = MockContext.Start(this.GetType()))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                var response = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);
                Assert.NotNull(response.PrimaryKey);
                Assert.NotNull(response.SecondaryKey);
            }
        }

        [Fact]
        public void RegenerateKeyTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                var beforeRegenerateResponse = _client.Redis.ListKeys(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName);

                var afterRegenerateResponse = _client.Redis.RegenerateKey(resourceGroupName: fixture.ResourceGroupName, name: fixture.RedisCacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = RedisKeyType.Primary });
                Assert.NotEqual(beforeRegenerateResponse.PrimaryKey, afterRegenerateResponse.PrimaryKey);
                Assert.Equal(beforeRegenerateResponse.SecondaryKey, afterRegenerateResponse.SecondaryKey);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(AzureRedisCache.Tests.GetListKeysFunctionalTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}

