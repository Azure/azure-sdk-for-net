// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        /// <summary>
        /// Gets the virtual network link resource identifier.
        /// </summary>
        public ResourceIdentifier VirtualNetworkLinkId => VirtualNetworkLink is null ? default : VirtualNetworkLink.Id;
    }
}
