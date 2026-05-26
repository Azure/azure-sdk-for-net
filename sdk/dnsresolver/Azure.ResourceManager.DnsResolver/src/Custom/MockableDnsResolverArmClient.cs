// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Mocking
{
    public partial class MockableDnsResolverArmClient
    {
        // Justification: mocking support is part of the public surface for the old AutoRest API.
        // The TypeSpec generator no longer emits the virtual-network wrapper entry point, so this
        // compatibility method restores the old mocking hook without changing generated code.
        /// <summary>
        /// Gets an object representing a virtual network resource together with the DNS Resolver
        /// operations that can be performed against that virtual network.
        /// </summary>
        public virtual VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(ResourceIdentifier id)
        {
            VirtualNetworkDnsResolverResource.ValidateResourceId(id);
            return new VirtualNetworkDnsResolverResource(Client, id);
        }
    }
}
