// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial struct ContainerNetworkProtocol
    {
        // backward-compat shim: old name was Tcp, new is TCP
        /// <summary> TCP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerNetworkProtocol Tcp { get; } = new ContainerNetworkProtocol("TCP");
        // backward-compat shim: old name was Udp, new is UDP
        /// <summary> UDP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerNetworkProtocol Udp { get; } = new ContainerNetworkProtocol("UDP");
    }
}
