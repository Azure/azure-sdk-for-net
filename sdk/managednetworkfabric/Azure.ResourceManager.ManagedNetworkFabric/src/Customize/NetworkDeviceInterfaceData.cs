// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkDeviceInterfaceData
    {
        /// <summary> IPv4Address of the interface. </summary>
        public IPAddress IPv4Address => IPAddress.TryParse(Ipv4Address, out IPAddress address) ? address : null;

        /// <summary> IPv6Address of the interface. </summary>
        public string IPv6Address => Ipv6Address;
    }
}
