// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsResolverData"/> class.
        /// </summary>
        /// <param name="location">The Azure region where the resource exists.</param>
        /// <param name="virtualNetwork">The virtual network associated with the DNS resolver.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverData(AzureLocation location, WritableSubResource virtualNetwork) : base(location)
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
