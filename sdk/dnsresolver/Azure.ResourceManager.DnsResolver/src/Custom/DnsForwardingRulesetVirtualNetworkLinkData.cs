// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsForwardingRulesetVirtualNetworkLinkData
    {
        // Justification: the released SDK exposed both this WritableSubResource-based
        // constructor and the top-level VirtualNetworkId convenience property directly
        // on the data model. The current generated shape already restores the scalar
        // ResourceIdentifier plumbing, so this partial only preserves those legacy
        // entry points as thin compatibility forwards.
        // TODO: Remove this compatibility shim when issue #58357 is fixed and the mgmt
        // generator preserves WritableSubResource-based ...Id projections automatically.
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsForwardingRulesetVirtualNetworkLinkData"/> class.
        /// </summary>
        /// <param name="virtualNetwork">The virtual network associated with the link.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsForwardingRulesetVirtualNetworkLinkData(WritableSubResource virtualNetwork)
        {
            Argument.AssertNotNull(virtualNetwork, nameof(virtualNetwork));
            Properties = new VirtualNetworkLinkProperties(virtualNetwork.Id);
        }

        /// <summary>
        /// Gets or sets the virtual network resource identifier.
        /// </summary>
        public ResourceIdentifier VirtualNetworkId
        {
            get => Properties is null ? default : Properties.VirtualNetwork?.Id;
            set
            {
                if (value is null)
                {
                    if (Properties is not null)
                    {
                        Properties.VirtualNetwork = null;
                    }
                    return;
                }

                Properties ??= new VirtualNetworkLinkProperties(value);
                Properties.VirtualNetwork = new global::Azure.ResourceManager.DnsResolver.Models.SubResource(value);
            }
        }
    }
}
