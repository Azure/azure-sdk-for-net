// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Network Fabric Controller services. </summary>
    public partial class NetworkFabricControllerServices
    {
        /// <summary> The IPv4 address spaces. </summary>
        public IReadOnlyList<string> IPv4AddressSpaces => (IReadOnlyList<string>)Ipv4AddressSpaces;

        /// <summary> The IPv6 address spaces. </summary>
        public IReadOnlyList<string> IPv6AddressSpaces => (IReadOnlyList<string>)Ipv6AddressSpaces;
    }
}
