// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverPolicyVirtualNetworkLinkData
    {
        // Justification: the pre-migration SDK exposed both this constructor and the
        // VirtualNetworkId convenience property directly on the data model. The TypeSpec-
        // generated shape now routes through the VirtualNetwork property on an internal
        // Properties bag, so this partial preserves the previous public API surface.
        // TODO: Remove this compatibility shim when issue #58357 is fixed and the mgmt
        // generator preserves WritableSubResource-based ...Id projections automatically.
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsResolverPolicyVirtualNetworkLinkData"/> class.
        /// </summary>
        /// <param name="location">The Azure region where the resource exists.</param>
        /// <param name="virtualNetwork">The virtual network associated with the link.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverPolicyVirtualNetworkLinkData(AzureLocation location, WritableSubResource virtualNetwork) : base(location)
        {
            Argument.AssertNotNull(virtualNetwork, nameof(virtualNetwork));
            VirtualNetwork = virtualNetwork;
        }

        /// <summary>
        /// Gets or sets the virtual network resource identifier.
        /// </summary>
        public ResourceIdentifier VirtualNetworkId
        {
            get => VirtualNetwork is null ? default : VirtualNetwork.Id;
            set
            {
                if (VirtualNetwork is null)
                {
                    VirtualNetwork = new WritableSubResource();
                }
                VirtualNetwork.Id = value;
            }
        }
    }
}
