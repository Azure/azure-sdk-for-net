// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        // Justification: the pre-migration SDK exposed VirtualNetworkLinkId directly on this
        // wrapper model. The TypeSpec-generated shape now exposes VirtualNetworkLink instead,
        // so this partial preserves the previous convenience property for backward compatibility.
        /// <summary>
        /// Gets the virtual network link resource identifier.
        /// </summary>
        public ResourceIdentifier VirtualNetworkLinkId => VirtualNetworkLink is null ? default : VirtualNetworkLink.Id;
    }
}
