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
        // Justification: the released SDK exposed both this WritableSubResource-based
        // constructor and the top-level SubnetId convenience property directly on the
        // data model. The current generated shape already restores the scalar
        // ResourceIdentifier plumbing, so this partial only preserves those legacy
        // entry points as thin compatibility forwards.
        // TODO: Remove this compatibility shim when issue #58357 is fixed and the mgmt
        // generator preserves WritableSubResource-based ...Id projections automatically.
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

        /// <summary>
        /// Gets or sets the subnet resource identifier.
        /// </summary>
        public ResourceIdentifier SubnetId
        {
            get => Properties is null ? default : Properties.Subnet?.Id;
            set
            {
                if (value is null)
                {
                    if (Properties is not null)
                    {
                        Properties.Subnet = null;
                    }
                    return;
                }

                Properties ??= new OutboundEndpointProperties(value);
                Properties.Subnet = new global::Azure.ResourceManager.DnsResolver.Models.SubResource(value);
            }
        }
    }
}
