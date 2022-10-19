// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DnsResolver
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.DnsResolver. </summary>
    [CodeGenSuppress("GetDnsResolvers", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolversAsync", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesets", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesetsAsync", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    public static partial class DnsResolverExtensions
    {
        #region VirtualNetworkDnsResolverResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualNetworkDnsResolverResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualNetworkDnsResolverResource.CreateResourceIdentifier" /> to create a <see cref="VirtualNetworkDnsResolverResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualNetworkDnsResolverResource" /> object. </returns>
        public static VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualNetworkDnsResolverResource.ValidateResourceId(id);
                return new VirtualNetworkDnsResolverResource(client, id);
            }
            );
        }
        #endregion
    }
}
