using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
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
        private TestBase _testBase;

        public RedisCacheManagementHelper(TestBase testBase)
        {
            _client = RedisCacheManagementTestUtilities.GetResourceManagementClient(testBase);
            _testBase = testBase;
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.Cache")
        {
            var reg = _client.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "_client.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("_client.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = _client.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result = _client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = _client.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "_client.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public void TryCreatingCache(string resourceGroupName, string cacheName, string location)
        {
            var redisClient = RedisCacheManagementTestUtilities.GetRedisManagementClient(_testBase);
            RedisCreateOrUpdateResponse createResponse = redisClient.Redis.CreateOrUpdate(resourceGroupName: resourceGroupName, name: cacheName,
                                    parameters: new RedisCreateOrUpdateParameters
                                    {
                                        Location = location,
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

            RedisGetResponse response = redisClient.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
            ThrowIfTrue(!response.Resource.Id.Contains(cacheName), "Cache name not found inside Id.");
            ThrowIfTrue(!response.Resource.Name.Equals(cacheName), string.Format("Cache name is not equal to {0}", cacheName));
            ThrowIfTrue(!response.Resource.Properties.HostName.Contains(cacheName), "Cache name not found inside host name.");

            // wait for maximum 30 minutes for cache to create
            for (int i = 0; i < 60; i++)
            {
                TestUtilities.Wait(new TimeSpan(0, 0, 30));
                RedisGetResponse responseGet = redisClient.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
                if ("succeeded".Equals(responseGet.Resource.Properties.ProvisioningState, StringComparison.InvariantCultureIgnoreCase))
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
