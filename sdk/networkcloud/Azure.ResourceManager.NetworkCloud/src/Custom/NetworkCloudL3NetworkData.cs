// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudL3NetworkData
    {
        /// <summary> The type of the IP address allocation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAllocationType? IPAllocationType
        {
            get => IpAllocationType;
            set => IpAllocationType = value;
        }

        /// <summary> The IPV4 prefix (CIDR) assigned to this L3 network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPv4ConnectedPrefix
        {
            get => Ipv4ConnectedPrefix;
            set => Ipv4ConnectedPrefix = value;
        }

        /// <summary> The IPV6 prefix (CIDR) assigned to this L3 network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPv6ConnectedPrefix
        {
            get => Ipv6ConnectedPrefix;
            set => Ipv6ConnectedPrefix = value;
        }

        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL3NetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudL3NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l3IsolationDomainId, long vlan)
            : this(location, l3IsolationDomainId, vlan, extendedLocation) { }
    }
}
