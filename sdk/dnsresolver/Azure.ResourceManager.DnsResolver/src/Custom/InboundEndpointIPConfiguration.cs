// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class InboundEndpointIPConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InboundEndpointIPConfiguration"/> class.
        /// </summary>
        /// <param name="subnet">The subnet associated with the inbound endpoint IP configuration.</param>
        public InboundEndpointIPConfiguration(WritableSubResource subnet)
        {
            Argument.AssertNotNull(subnet, nameof(subnet));
            Subnet = subnet;
        }

        /// <summary>
        /// Gets or sets the subnet resource identifier.
        /// </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet is null ? default : Subnet.Id;
            set
            {
                if (Subnet is null)
                {
                    Subnet = new WritableSubResource();
                }
                Subnet.Id = value;
            }
        }
    }
}
