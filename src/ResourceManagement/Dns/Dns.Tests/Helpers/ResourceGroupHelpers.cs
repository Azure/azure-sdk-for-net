// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    using Rest.ClientRuntime.Azure.TestFramework;

    public static class ResourceGroupHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourcesClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(
                handlers: handler);
            return client;
        }

        /// <summary>
        /// Default constructor for management clients,
        ///  using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context
        ///  (environment variables)</returns>
        public static DnsManagementClient GetDnsClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<DnsManagementClient>(
                handlers: handler);
            return client;
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(
            ResourceManagementClient client,
            string resourceType)
        {
            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.ResourceTypes)
            {
                if (string.Equals(
                    resource.ResourceType,
                    parts[1],
                    StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.FirstOrDefault(
                        loca => !string.IsNullOrEmpty(loca));
                }
            }

            return location;
        }

        public static ResourceGroup CreateResourceGroup(
            ResourceManagementClient resourcesClient)
        {
            string resourceGroupName =
                TestUtilities.GenerateName("hydratestdnsrg");

            // DNS resources are in location "global" but resource groups 
            // can't be in that same location
            string location = "Central US";

            Assert.False(
                string.IsNullOrEmpty(location),
                "CSM did not return any valid locations for DNS resources");

            var response = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });

            return response;
        }

        public static Zone CreateZone(
            DnsManagementClient dnsClient,
            string zoneName,
            string location,
            ResourceGroup resourceGroup)
        {
            return dnsClient.Zones.CreateOrUpdate(
                resourceGroup.Name,
                zoneName,
                new Microsoft.Azure.Management.Dns.Models.Zone
                {
                    Location = location,
                    Etag = null
                },
                null,
                null);
        }
    }
}