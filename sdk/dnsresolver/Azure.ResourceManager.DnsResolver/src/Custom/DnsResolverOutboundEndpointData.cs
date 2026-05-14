// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverOutboundEndpointData
    {
        // Justification: keep the shipped WritableSubResource-based constructor overload for
        // backward compatibility. The flattened SubnetId property is now generator-owned.
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsResolverOutboundEndpointData"/> class.
        /// </summary>
        /// <param name="location">The Azure region where the resource exists.</param>
        /// <param name="subnet">The subnet associated with the outbound endpoint.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverOutboundEndpointData(AzureLocation location, WritableSubResource subnet) : base(location)
        {
            Argument.AssertNotNull(subnet, nameof(subnet));
            Properties = new OutboundEndpointProperties(subnet.Id);
        }
    }
}
