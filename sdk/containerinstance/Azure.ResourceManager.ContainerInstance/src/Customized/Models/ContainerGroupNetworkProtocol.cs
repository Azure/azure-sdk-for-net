// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat: old API had Tcp/Udp, new generated code has TCP/UDP

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public readonly partial struct ContainerGroupNetworkProtocol
    {
        /// <summary> TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupNetworkProtocol Tcp { get; } = new ContainerGroupNetworkProtocol(TCPValue);
        /// <summary> UDP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupNetworkProtocol Udp { get; } = new ContainerGroupNetworkProtocol(UDPValue);
    }
}
