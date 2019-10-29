// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.OperationalInsights;
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

        public static ComputeManagementClient GetComputeManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ComputeManagementClient>(handlers: handler);
            return client;
        }

        public static StorageManagementClient GetStorageManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            return client;
        }

        public static OperationalInsightsManagementClient GetOperationalInsightsManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<OperationalInsightsManagementClient>(handlers: handler);
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

        /// <summary>
        /// Get default resource location for a given resource type.
        /// Once all tests are moved away from depreciated version of Resource Manager, this method should be removed
        /// and "using Microsoft.Azure.Management.Resources" should be changed to "using Microsoft.Azure.Management.ResourceManager"
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(Microsoft.Azure.Management.ResourceManager.ResourceManagementClient client, string resourceType, Network.Tests.Helpers.FeaturesInfo.Type feature = Network.Tests.Helpers.FeaturesInfo.Type.Default)
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
            var provider = Microsoft.Azure.Management.ResourceManager.ProvidersOperationsExtensions.Get(client.Providers, providerName);
            foreach (var resource in provider.ResourceTypes)
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
            return "AzureSDKNetworkTest#" + Guid.NewGuid().ToString().Replace("-", "@");
        }
    }
}