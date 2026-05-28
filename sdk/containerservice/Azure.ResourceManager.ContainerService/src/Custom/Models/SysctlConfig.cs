// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class SysctlConfig
    {
        /// <summary> Sysctl setting net.ipv4.tcp_tw_reuse. </summary>
        [WirePath("netIpv4TcpTwReuse")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? NetIPv4TcpTwReuse { get => IsNetIpv4TcpTwReuseEnabled; set => IsNetIpv4TcpTwReuseEnabled = value; }
    }
}
