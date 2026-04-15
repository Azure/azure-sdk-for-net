// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    // Suppress generated string-typed property/constructor to provide ResourceIdentifier versions for backward compat.
    [CodeGenSuppress("DnsForwardingRulesetVirtualNetworkLinkData", typeof(string))]
    [CodeGenSuppress("VirtualNetworkId")]
    public partial class DnsForwardingRulesetVirtualNetworkLinkData
    {
        /// <summary> Initializes a new instance of <see cref="DnsForwardingRulesetVirtualNetworkLinkData"/>. </summary>
        /// <param name="virtualNetworkId"> The reference to the virtual network. </param>
        public DnsForwardingRulesetVirtualNetworkLinkData(ResourceIdentifier virtualNetworkId)
        {
            Properties = new Models.VirtualNetworkLinkProperties(virtualNetworkId);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsForwardingRulesetVirtualNetworkLinkData(WritableSubResource virtualNetwork) : this(virtualNetwork?.Id)
        {
        }

        /// <summary> The reference to the virtual network. </summary>
        public ResourceIdentifier VirtualNetworkId
        {
            get => Properties?.VirtualNetworkId;
            set
            {
                if (Properties is null) Properties = new Models.VirtualNetworkLinkProperties();
                Properties.VirtualNetworkId = value;
            }
        }
    }
}
