// ------------------------------------------------------------------------------------------------
// <copyright file="NetworkManagementClientExtensions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.Extensions
{
    using System;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;

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
