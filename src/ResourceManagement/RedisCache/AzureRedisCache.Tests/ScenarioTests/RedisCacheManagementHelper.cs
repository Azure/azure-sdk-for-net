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
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class RedisCacheManagementHelper
    {
        private ResourceManagementClient _client;
        private MockContext _context;
        private TestBase _testBase;

        public RedisCacheManagementHelper(TestBase testBase, MockContext context)
        {
            _client = RedisCacheManagementTestUtilities.GetResourceManagementClient(testBase, context);
            _testBase = testBase;
            _context = context;
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.Cache")
        {
            var reg = _client.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "_client.Providers.Register returned null.");
            
            var resultAfterRegister = _client.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.ResourceTypes[0].Locations == null || resultAfterRegister.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroup result = _client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = _client.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "_client.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public void DeleteResourceGroup(string resourceGroupName)
        {
            _client.ResourceGroups.Delete(resourceGroupName);
        }

        public void TryCreatingCache(string resourceGroupName, string cacheName, string location)
        {
            var redisClient = RedisCacheManagementTestUtilities.GetRedisManagementClient(_testBase, _context);
            RedisResourceWithAccessKey createResponse = redisClient.Redis.CreateOrUpdate(resourceGroupName: resourceGroupName, name: cacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = location,
                                        RedisVersion = "2.8",
                                        Sku = new Sku()
                                        {
                                            Name = SkuName.Basic,
                                            Family = SkuFamily.C,
                                            Capacity = 0
                                        }
                                    });

            RedisResource response = redisClient.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
            ThrowIfTrue(!response.Id.Contains(cacheName), "Cache name not found inside Id.");
            ThrowIfTrue(!response.Name.Equals(cacheName), string.Format("Cache name is not equal to {0}", cacheName));
            ThrowIfTrue(!response.HostName.Contains(cacheName), "Cache name not found inside host name.");

            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                RedisResource responseGet = redisClient.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
                if ("succeeded".Equals(responseGet.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                ThrowIfTrue(i == 60, "Cache is not in succeeded state even after 30 min.");
            }
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            { 
                throw new Exception(message);
            }
        }      
    }
}
