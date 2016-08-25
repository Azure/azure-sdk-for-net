using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using ResourceGroups.Tests;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests.Helpers
{
    public static class NetworkManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static NetworkManagementClient GetNetworkManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<NetworkManagementClient>(handlers: handler);
            return client;
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType, Network.Tests.Helpers.FeaturesInfo.Type feature = Network.Tests.Helpers.FeaturesInfo.Type.Default)
        {
            HashSet<string> supportedLocations = null;

            switch (feature)
            {
                case Network.Tests.Helpers.FeaturesInfo.Type.Default:
                    {
                        supportedLocations = Network.Tests.Helpers.FeaturesInfo.defaultLocations;
                        break;
                    }

                case Network.Tests.Helpers.FeaturesInfo.Type.All:
                    {
                        supportedLocations = Network.Tests.Helpers.FeaturesInfo.allFeaturesSupportedLocations;
                        break;
                    }

                case Network.Tests.Helpers.FeaturesInfo.Type.Ipv6:
                    {
                        supportedLocations = Network.Tests.Helpers.FeaturesInfo.ipv6SupportedLocations;
                        break;
                    }

                case Network.Tests.Helpers.FeaturesInfo.Type.MultiCA:
                    {
                        supportedLocations = Network.Tests.Helpers.FeaturesInfo.defaultLocations;
                        break;
                    }
            }
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    return resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return null;
        }
    }
}