// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static class NetworkManagementTestUtilities
    {
        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static async Task<string> GetResourceLocation(ResourcesManagementClient client, string resourceType, FeaturesInfo.Type feature = FeaturesInfo.Type.Default)
        {
            HashSet<string> supportedLocations = null;

            switch (feature)
            {
                case FeaturesInfo.Type.Default:
                    supportedLocations = FeaturesInfo.DefaultLocations;
                    break;
                case FeaturesInfo.Type.All:
                    supportedLocations = FeaturesInfo.AllFeaturesSupportedLocations;
                    break;
                case FeaturesInfo.Type.Ipv6:
                    supportedLocations = FeaturesInfo.Ipv6SupportedLocations;
                    break;
                case FeaturesInfo.Type.MultiCA:
                    supportedLocations = FeaturesInfo.DefaultLocations;
                    break;
            }
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            Response<Provider> provider = await client.Providers.GetAsync(providerName);
            foreach (var resource in provider.Value.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    return resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return null;
        }

        /// <summary>
        /// Get default resource location for a given resource type.
        /// Once all tests are moved away from depreciated version of Resource Manager, this method should be removed
        /// and "using Microsoft.Azure.Management.Resources" should be changed to "using Microsoft.Azure.Management.ResourceManager"
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static async Task<string> GetResourceLocation(ResourcesManagementClient client, ProvidersOperations providersOperations, string resourceType, FeaturesInfo.Type feature = FeaturesInfo.Type.Default)
        {
            HashSet<string> supportedLocations = null;

            switch (feature)
            {
                case FeaturesInfo.Type.Default:
                    supportedLocations = FeaturesInfo.DefaultLocations;
                    break;
                case FeaturesInfo.Type.All:
                    supportedLocations = FeaturesInfo.AllFeaturesSupportedLocations;
                    break;
                case FeaturesInfo.Type.Ipv6:
                    supportedLocations = FeaturesInfo.Ipv6SupportedLocations;
                    break;
                case FeaturesInfo.Type.MultiCA:
                    supportedLocations = FeaturesInfo.DefaultLocations;
                    break;
            }
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            Response<Provider> provider = await providersOperations.GetAsync(providerName);
            foreach (var resource in provider.Value.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    return resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return null;
        }

        /// <summary>
        /// Get randomly generated password
        /// </summary>
        /// <returns>Randomly generated password string</returns>
        public static string GetRandomPassword()
        {
            return "" + Guid.NewGuid().ToString().Replace("-", "@");
        }
    }
}
