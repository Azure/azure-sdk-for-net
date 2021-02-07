// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AzureRedisEnterpriseCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.RedisEnterprise.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace AzureRedisEnterpriseCache.Tests
{
    public class RedisEnterpriseCacheManagementHelper
    {
        public static string Location = "East US";
        public static string SecondaryLocation = "West US";

        private ResourceManagementClient _client;
        private MockContext _context;
        private TestBase _testBase;

        public RedisEnterpriseCacheManagementHelper(TestBase testBase, MockContext context)
        {
            _client = RedisEnterpriseCacheManagementTestUtilities.GetResourceManagementClient(testBase, context);
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
            var redisEnterpriseClient = RedisEnterpriseCacheManagementTestUtilities.GetRedisEnterpriseManagementClient(_testBase, _context);
            var createResponse = redisEnterpriseClient.RedisEnterprise.Create(resourceGroupName: resourceGroupName, clusterName: cacheName,
                                    parameters: new Cluster
                                    {
                                        Location = location,
                                        Sku = new Microsoft.Azure.Management.RedisEnterprise.Models.Sku()
                                        {
                                            Name = SkuName.EnterpriseE20,
                                            Capacity = 2
                                        }
                                    });

            Cluster response = redisEnterpriseClient.RedisEnterprise.GetMethod(resourceGroupName: resourceGroupName, clusterName: cacheName);
            ThrowIfTrue(!response.Id.Contains(cacheName), "Cache name not found inside Id.");
            ThrowIfTrue(!response.Name.Equals(cacheName), string.Format("Cache name is not equal to {0}", cacheName));
            ThrowIfTrue(!response.HostName.Contains(cacheName), "Cache name not found inside host name.");

            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                Cluster responseGet = redisEnterpriseClient.RedisEnterprise.GetMethod(resourceGroupName: resourceGroupName, clusterName: cacheName);
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

