// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using SubResource = Microsoft.Azure.Management.Dns.Models.SubResource;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public static class ResourceGroupHelper
    {
        // DNS resources are in location "global" but resource groups cannot be in that same location
        private const string ResourceLocation = "Central US";

        private static readonly Random RandomGenerator = new Random();

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
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        /// <summary>
        /// Default constructor for management clients,
        ///  using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static DnsManagementClient GetDnsClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<DnsManagementClient>(handlers: handler);
            return client;
        }

        /// <summary>
        /// Default constructor for network clients,
        ///  using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>A netowrk management client, created from the current context (environment variables)</returns>
        public static NetworkManagementClient GetNetworkClient(
            MockContext context,
            RecordedDelegatingHandler handler)
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
                    location = resource.Locations.FirstOrDefault(loca => !string.IsNullOrEmpty(loca));
                }
            }

            return location;
        }

        public static ResourceGroup CreateResourceGroup(
            ResourceManagementClient resourcesClient)
        {
            string resourceGroupName = TestUtilities.GenerateName("hydratestdnsrg");

            var response = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = ResourceLocation
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
                new Zone
                {
                    ZoneType = ZoneType.Public,
                    Location = location,
                    Etag = null
                },
                null,
                null);
        }

        public static Zone CreatePrivateZone(
            DnsManagementClient dnsClient,
            string zoneName,
            string location,
            IList<SubResource> registrationVnets,
            IList<SubResource> resolutionVnets,
            ResourceGroup resourceGroup)
        {
            return dnsClient.Zones.CreateOrUpdate(
                resourceGroup.Name,
                zoneName,
                new Zone
                {
                    ZoneType = ZoneType.Private,
                    Location = location,
                    Etag = null,
                    RegistrationVirtualNetworks = registrationVnets,
                    ResolutionVirtualNetworks = resolutionVnets,
                },
                null,
                null);
        }

        public static VirtualNetwork CreateVirtualNetwork(
            string resourceGroupName,
            NetworkManagementClient networkClient)
        {
            var virtualNetworkName = TestUtilities.GenerateName("hydratestdnsvn");
            var subnetName = TestUtilities.GenerateName("hydratestdnssubnet");

            var vnet = new VirtualNetwork
            {
                AddressSpace = new AddressSpace
                {
                    AddressPrefixes = new List<string>
                    {
                        "10.0.0.0/16"
                    }
                },
                Subnets = new List<Subnet>
                {
                    new Subnet
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0." + RandomGenerator.Next(0, 255) + ".0/24"
                    }
                },
                Location = ResourceLocation
            };

            var putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, virtualNetworkName, vnet);
            Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

            var getVnetResponse = networkClient.VirtualNetworks.Get(resourceGroupName, virtualNetworkName);
            return getVnetResponse;
        }
    }
}