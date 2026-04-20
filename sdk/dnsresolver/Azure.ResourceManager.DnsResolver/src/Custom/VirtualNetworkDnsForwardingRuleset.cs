// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        // Justification: the released SDK exposed VirtualNetworkLinkId directly on this
        // wrapper model. The generated shape keeps the nested Properties bag, so this
        // partial preserves the previous convenience property for backward compatibility.
        // TODO: Remove this compatibility shim when issue #58357 is fixed and the mgmt
        // generator preserves WritableSubResource-based ...Id projections automatically.
        /// <summary>
        /// Gets the virtual network link resource identifier.
        /// </summary>
        public ResourceIdentifier VirtualNetworkLinkId => Properties is null ? default : Properties.VirtualNetworkLinkId;
    }
}
