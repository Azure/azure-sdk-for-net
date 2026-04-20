// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverOutboundEndpointData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsResolverOutboundEndpointData(AzureLocation location, WritableSubResource subnet) : base(location)
        {
            Argument.AssertNotNull(subnet, nameof(subnet));
            Subnet = subnet;
        }

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

#pragma warning restore CS1591
