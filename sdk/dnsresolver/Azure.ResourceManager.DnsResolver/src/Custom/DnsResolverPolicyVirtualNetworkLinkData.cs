// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverPolicyVirtualNetworkLinkData
    {
        // Justification: keep the shipped WritableSubResource-based constructor overload for
        // backward compatibility. The flattened VirtualNetworkId property is now generator-owned.
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsResolverPolicyVirtualNetworkLinkData"/> class.
        /// </summary>
        /// <param name="location">The Azure region where the resource exists.</param>
        /// <param name="virtualNetwork">The virtual network associated with the link.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverPolicyVirtualNetworkLinkData(AzureLocation location, WritableSubResource virtualNetwork) : base(location)
        {
            Argument.AssertNotNull(virtualNetwork, nameof(virtualNetwork));
            Properties = new DnsResolverPolicyVirtualNetworkLinkProperties(virtualNetwork.Id);
        }
    }
}
