// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    // Suppress generated string-typed property/constructor to provide ResourceIdentifier versions for backward compat.
    [CodeGenSuppress("DnsResolverPolicyVirtualNetworkLinkData", typeof(AzureLocation), typeof(string))]
    [CodeGenSuppress("VirtualNetworkId")]
    public partial class DnsResolverPolicyVirtualNetworkLinkData
    {
        /// <summary> Initializes a new instance of <see cref="DnsResolverPolicyVirtualNetworkLinkData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="virtualNetworkId"> The reference to the virtual network. </param>
        public DnsResolverPolicyVirtualNetworkLinkData(AzureLocation location, ResourceIdentifier virtualNetworkId) : base(location)
        {
            Properties = new Models.DnsResolverPolicyVirtualNetworkLinkProperties(virtualNetworkId);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverPolicyVirtualNetworkLinkData(AzureLocation location, WritableSubResource virtualNetwork) : this(location, virtualNetwork?.Id)
        {
        }

        /// <summary> The reference to the virtual network. </summary>
        public ResourceIdentifier VirtualNetworkId
        {
            get => Properties?.VirtualNetworkId;
            set
            {
                if (Properties is null) Properties = new Models.DnsResolverPolicyVirtualNetworkLinkProperties();
                Properties.VirtualNetworkId = value;
            }
        }
    }
}
