// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    // Backward-compatibility shim for the pre-migration WritableSubResource constructor.
    public partial class DnsForwardingRulesetVirtualNetworkLinkData
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsForwardingRulesetVirtualNetworkLinkData(WritableSubResource virtualNetwork) : this(virtualNetwork?.Id)
        {
        }
    }
}
