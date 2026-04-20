// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        public ResourceIdentifier VirtualNetworkLinkId => VirtualNetworkLink is null ? default : VirtualNetworkLink.Id;
    }
}

#pragma warning restore CS1591
