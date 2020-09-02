// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;

namespace Azure.Azure.Test
{
    public static class ResourcesManagementTestUtilities
    {
        /// Get a default resource location for a given resource type
        /// <summary>
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static async Task<string> GetResourceLocation(ResourcesManagementClient client, string resourceType)
        {
            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            Response<Provider> provider = await client.Providers.GetAsync(providerName);
            foreach (var resource in provider.Value.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.LastOrDefault();
                }
            }

            return location;
        }

        /// <summary>
        /// Equality comparison for locations returned by resource management
        /// </summary>
        /// <param name="expected">The expected location</param>
        /// <param name="actual">The actual location returned by resource management</param>
        /// <returns>true if the locations are equivalent, otherwise false</returns>
        public static bool LocationsAreEqual(string expected, string actual)
        {
            bool result = string.Equals(expected, actual, System.StringComparison.OrdinalIgnoreCase);
            if (!result && !string.IsNullOrEmpty(expected))
            {
                string normalizedLocation = expected.ToLower().Replace(" ", null);
                result = string.Equals(normalizedLocation, actual, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
