// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    // Suppress generated string-typed property/constructor to provide ResourceIdentifier versions for backward compat.
    [CodeGenSuppress("DnsResolverData", typeof(AzureLocation), typeof(string))]
    [CodeGenSuppress("VirtualNetworkId")]
    public partial class DnsResolverData
    {
        /// <summary> Initializes a new instance of <see cref="DnsResolverData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="virtualNetworkId"> The reference to the virtual network. </param>
        public DnsResolverData(AzureLocation location, ResourceIdentifier virtualNetworkId) : base(location)
        {
            Properties = new Models.DnsResolverProperties(virtualNetworkId?.ToString());
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverData(AzureLocation location, WritableSubResource virtualNetwork) : this(location, virtualNetwork?.Id)
        {
        }

        /// <summary> The reference to the virtual network. </summary>
        public ResourceIdentifier VirtualNetworkId
        {
            get => Properties?.VirtualNetworkId != null ? new ResourceIdentifier(Properties.VirtualNetworkId) : null;
            set
            {
                if (Properties is null) Properties = new Models.DnsResolverProperties();
                Properties.VirtualNetworkId = value?.ToString();
            }
        }
    }
}
