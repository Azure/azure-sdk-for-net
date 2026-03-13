// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public static partial class ArmDnsResolverModelFactory
    {
        // Backward-compat: old factory method took two ResourceIdentifier params, new takes (ResourceIdentifier, string).
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkDnsForwardingRuleset VirtualNetworkDnsForwardingRuleset(ResourceIdentifier id, ResourceIdentifier virtualNetworkLinkId)
        {
            return VirtualNetworkDnsForwardingRuleset(id: id, virtualNetworkLinkId: virtualNetworkLinkId?.ToString());
        }
    }
}
