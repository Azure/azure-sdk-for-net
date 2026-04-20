// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class InboundEndpointIPConfiguration
    {
        // Justification: the released SDK exposed a WritableSubResource-based constructor.
        // The generated model now restores the flattened SubnetId property directly, so
        // this partial only preserves the legacy constructor overload.
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
