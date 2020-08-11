// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Automation.Tests.Helpers
{
    public static class ResourceGroupHelper
    {

        public static AutomationClient GetAutomationClient(MockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<AutomationClient>(false, handler);
        }

        public static ResourceManagementClient GetResourcesClient(MockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<ResourceManagementClient>(false, handler);
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            var supportedLocations = new HashSet<string>(new[] { "East Asia", "West US", "North Central US", "North Europe", "West Europe", "South Central US", "East US" }, StringComparer.OrdinalIgnoreCase);

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
    }
}
