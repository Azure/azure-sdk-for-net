// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    // Backward-compatibility shim for the pre-migration WritableSubResource constructor.
    public partial class DnsForwardingRulesetVirtualNetworkLinkData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsForwardingRulesetVirtualNetworkLinkData(WritableSubResource virtualNetwork) : this(virtualNetwork?.Id)
        {
        }
    }
}

#pragma warning restore CS1591
