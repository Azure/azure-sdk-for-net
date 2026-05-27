// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct Layer4Protocol
    {
        // The TypeSpec generator does not emit public constants for these service-defined protocol values.
        // Removing these shims would drop the shipped Tcp/Udp members and break callers compiled against the GA SDK.

        /// <summary> TCP(Transmission Control Protocol) Protocol. </summary>
        public static Layer4Protocol Tcp => new Layer4Protocol("TCP");

        /// <summary> UDP(User Datagram Protocol) Protocol. </summary>
        public static Layer4Protocol Udp => new Layer4Protocol("UDP");
    }
}
