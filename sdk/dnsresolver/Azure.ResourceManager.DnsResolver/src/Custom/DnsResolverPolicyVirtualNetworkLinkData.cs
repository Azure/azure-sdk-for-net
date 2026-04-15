// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    // Backward-compatibility shim for the pre-migration WritableSubResource constructor.
    public partial class DnsResolverPolicyVirtualNetworkLinkData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverPolicyVirtualNetworkLinkData(AzureLocation location, WritableSubResource virtualNetwork) : this(location, virtualNetwork?.Id)
        {
        }
    }
}

#pragma warning restore CS1591
