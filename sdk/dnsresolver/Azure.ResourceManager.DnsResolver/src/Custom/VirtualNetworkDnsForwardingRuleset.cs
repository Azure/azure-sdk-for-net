// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Suppress generated string-typed property to provide ResourceIdentifier version for backward compat.
    [CodeGenSuppress("VirtualNetworkLinkId")]
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        /// <summary> The reference to the virtual network link. </summary>
        public ResourceIdentifier VirtualNetworkLinkId
        {
            get => Properties?.VirtualNetworkLinkId != null ? new ResourceIdentifier(Properties.VirtualNetworkLinkId) : null;
        }
    }
}
