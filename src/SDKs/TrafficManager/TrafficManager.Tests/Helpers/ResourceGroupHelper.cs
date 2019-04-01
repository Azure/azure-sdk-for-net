// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//

namespace TrafficManager.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources;
    using System.Linq;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public static class ResourceGroupHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            return client;
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            var supportedLocations = new HashSet<string>(new[] { "global", "East Asia", "West US", "North Central US", "North Europe", "West Europe", "South Central US", "East US" }, StringComparer.OrdinalIgnoreCase);

            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return location;
        }

        public const string ResourceGroupLocation = "Central US";

        public static ResourceGroup CreateResourceGroup(this TestBase testBase, MockContext context, string resourceGroupName)
        {
            ResourceManagementClient resourcesClient = ResourceGroupHelper.GetResourceManagementClient(testBase, context);
            

            Assert.False(string.IsNullOrEmpty(ResourceGroupLocation), "CSM did not return any valid locations for DNS resources");

            var response = resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = ResourceGroupLocation
                });

            return response;
        }

        public static void DeleteResourceGroup(this TestBase testBase, MockContext context, string resourceGroupName)
        {
            ResourceManagementClient resourcesClient = ResourceGroupHelper.GetResourceManagementClient(testBase, context);

            resourcesClient.ResourceGroups.Delete(resourceGroupName);
        }
    }
}
