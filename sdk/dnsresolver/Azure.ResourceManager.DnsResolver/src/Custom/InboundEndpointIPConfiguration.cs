// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class InboundEndpointIPConfiguration
    {
        // Justification: the released SDK exposed both this WritableSubResource-based
        // constructor and the top-level SubnetId convenience property directly on the
        // model. The current generated shape already restores the scalar
        // ResourceIdentifier plumbing, so this partial only preserves those legacy
        // entry points as thin compatibility forwards.
        // TODO: Remove this compatibility shim when issue #58357 is fixed and the mgmt
        // generator preserves WritableSubResource-based ...Id projections automatically.
        /// <summary>
        /// Initializes a new instance of the <see cref="InboundEndpointIPConfiguration"/> class.
        /// </summary>
        /// <param name="subnet">The subnet associated with the inbound endpoint IP configuration.</param>
        public InboundEndpointIPConfiguration(WritableSubResource subnet)
        {
            Argument.AssertNotNull(subnet, nameof(subnet));
            Subnet = new SubResource(subnet.Id);
        }

        /// <summary>
        /// Gets or sets the subnet resource identifier.
        /// </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet is null ? default : Subnet.Id;
            set
            {
                if (value is null)
                {
                    Subnet = null;
                    return;
                }
                Subnet = new SubResource(value);
            }
        }
    }
}
