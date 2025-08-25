// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DnsResolver
{
    // TO-DO: this is a workaround as we don't support partial resource for TypeSpec input. We should remove this file after we move to MPG.
    /// <summary> A class to add extension methods to Azure.ResourceManager.DnsResolver. </summary>
    [CodeGenSuppress("GetDnsResolversByVirtualNetworkAsync", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolversByVirtualNetwork", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesetsByVirtualNetworkAsync", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesetsByVirtualNetwork", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolverPoliciesByVirtualNetworkAsync", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolverPoliciesByVirtualNetwork", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    public static partial class DnsResolverExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="VirtualNetworkDnsResolverResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualNetworkDnsResolverResource.CreateResourceIdentifier" /> to create a <see cref="VirtualNetworkDnsResolverResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDnsResolverArmClient.GetVirtualNetworkDnsResolverResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="VirtualNetworkDnsResolverResource"/> object. </returns>
        public static VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableDnsResolverArmClient(client).GetVirtualNetworkDnsResolverResource(id);
        }
    }
}
