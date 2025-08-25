// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Mocking
{
    public partial class MockableDnsResolverArmClient : ArmResource
    {
        // TO-DO: this is a workaround as we don't support partial resource for TypeSpec input. We should remove this file after we move to MPG.
        /// <summary>
        /// Gets an object representing a <see cref="VirtualNetworkDnsResolverResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualNetworkDnsResolverResource.CreateResourceIdentifier" /> to create a <see cref="VirtualNetworkDnsResolverResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualNetworkDnsResolverResource"/> object. </returns>
        public virtual VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(ResourceIdentifier id)
        {
            VirtualNetworkDnsResolverResource.ValidateResourceId(id);
            return new VirtualNetworkDnsResolverResource(Client, id);
        }
    }
}
