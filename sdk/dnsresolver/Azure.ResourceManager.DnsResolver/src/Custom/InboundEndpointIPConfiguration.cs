// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class InboundEndpointIPConfiguration
    {
        // Justification: keep the shipped WritableSubResource-based constructor overload for
        // backward compatibility. The flattened SubnetId property is now generator-owned.
        /// <summary>
        /// Initializes a new instance of the <see cref="InboundEndpointIPConfiguration"/> class.
        /// </summary>
        /// <param name="subnet">The subnet associated with the inbound endpoint IP configuration.</param>
        public InboundEndpointIPConfiguration(WritableSubResource subnet)
        {
            Argument.AssertNotNull(subnet, nameof(subnet));
            Subnet = new SubResource(subnet.Id);
        }
    }
}
