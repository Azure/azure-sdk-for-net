// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DnsResolver.Tests.Extensions
{
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using System;

    internal static class NetworkManagementClientExtensions
    {
        public static VirtualNetwork CreateVirtualNetwork(
            this NetworkManagementClient client,
            string resourceGroupName = null,
            string virtualNetworkName = null,
            string virtualNetworkLocation = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            virtualNetworkName = virtualNetworkName ?? TestDataGenerator.GenerateVirtualNetworkName();

            var virtualNetwork = TestDataGenerator.GenerateVirtualNetwork(location: virtualNetworkLocation);
            return client.VirtualNetworks.CreateOrUpdate(resourceGroupName, virtualNetworkName, virtualNetwork);
        }

        public static Subnet CreateSubnet(
            this NetworkManagementClient client,
            string resourceGroupName = null,
            string virtualNetworkName = null,
            string subnetName = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            subnetName = subnetName ?? TestDataGenerator.GenerateSubnetName();

            var subnet = TestDataGenerator.GenerateSubnet();
            return client.Subnets.CreateOrUpdate(resourceGroupName: resourceGroupName, virtualNetworkName: virtualNetworkName, subnetName: subnetName, subnet);
        }
    }
}
