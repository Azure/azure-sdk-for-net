// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat: old API had Tcp/Udp, new generated code has TCP/UDP

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public readonly partial struct ContainerNetworkProtocol
    {
        /// <summary> TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerNetworkProtocol Tcp { get; } = new ContainerNetworkProtocol(TCP.ToString());
        /// <summary> UDP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerNetworkProtocol Udp { get; } = new ContainerNetworkProtocol(UDP.ToString());
    }
}
