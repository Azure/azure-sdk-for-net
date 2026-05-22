// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct Layer4Protocol
    {
        /// <summary> TCP(Transmission Control Protocol) Protocol. </summary>
        public static Layer4Protocol Tcp => TCP;

        /// <summary> UDP(User Datagram Protocol) Protocol. </summary>
        public static Layer4Protocol Udp => UDP;
    }
}
