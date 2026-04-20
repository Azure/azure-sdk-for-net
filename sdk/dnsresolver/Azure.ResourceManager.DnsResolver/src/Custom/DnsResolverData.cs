// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverData
    {
        // Justification: the released SDK exposed a WritableSubResource-based constructor.
        // The generated model now restores the flattened VirtualNetworkId property directly,
        // so this partial only preserves the legacy constructor overload.
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsResolverData"/> class.
        /// </summary>
        /// <param name="location">The Azure region where the resource exists.</param>
        /// <param name="virtualNetwork">The virtual network associated with the DNS resolver.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverData(AzureLocation location, WritableSubResource virtualNetwork) : base(location)
        {
            Argument.AssertNotNull(virtualNetwork, nameof(virtualNetwork));
            Properties = new DnsResolverProperties(virtualNetwork.Id);
        }
    }
}
