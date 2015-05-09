using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using ResourceGroups.Tests;

namespace Networks.Tests.Helpers
{
    public static class NetworkManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static NetworkResourceProviderClient GetNetworkResourceProviderClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<NetworkResourceProviderClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            var supportedLocations = new HashSet<string>(new[] { "East US", "West US", "Central US", "West Europe" }, StringComparer.OrdinalIgnoreCase);
            
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.Provider.ResourceTypes)
            {
                if (string.Equals(resource.Name, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    return resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return null;
        }
    }
}