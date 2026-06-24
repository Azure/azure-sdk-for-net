// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver
{
    public static partial class DnsResolverExtensions
    {
        // Justification: the previous AutoRest-based SDK exposed this ArmClient entry point and
        // a VirtualNetworkDnsResolverResource wrapper. The TypeSpec generator now exposes the same
        // underlying service operations through ResourceGroupResource extension methods instead, so
        // we keep this shim to preserve the released API surface during the MPG migration.
        /// <summary>
        /// Gets an object representing a virtual network resource along with the DNS Resolver operations
        /// that can be performed against that virtual network.
        /// </summary>
        public static VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableDnsResolverArmClient(client).GetVirtualNetworkDnsResolverResource(id);
        }
    }
}
