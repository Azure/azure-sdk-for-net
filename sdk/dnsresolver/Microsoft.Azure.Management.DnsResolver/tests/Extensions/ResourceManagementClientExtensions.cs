// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;

    internal static class ResourceManagementClientExtensions
    {
        public static ResourceGroup CreateResourceGroup(
            this ResourceManagementClient client,
            string resourceGroupName = null,
            string resourceGroupLocation = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroupName();
            var response = client.ResourceGroups.CreateOrUpdate(resourceGroupName, TestDataGenerator.GenerateResourceGroup(resourceGroupLocation));

            return response;
        }

        public static string GetResourceLocation(this ResourceManagementClient client, string resourceType)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (resourceType == null)
            {
                throw new ArgumentNullException(nameof(resourceType));
            }

            string location = null;

            var parts = resourceType.Split('/');
            var providerName = parts[0];
            var resourceName = parts[1];

            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(resource.ResourceType, resourceName, StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.FirstOrDefault(loc => !string.IsNullOrWhiteSpace(loc));
                }
            }

            return location;
        }

        public static string GetDnsResolverResourceLocation(this ResourceManagementClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return client.GetResourceLocation(Constants.DnsResolverResourceType);
        }
    }
}
