// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.DnsResolver.Tests.Extensions
{
    using global::DnsResolver.Tests;
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
    }
}
