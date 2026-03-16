// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class IPAddressPool
    {
        /// <summary> The indicator to determine if the load balancer peers the advertised IP address pools only with the InternalNetwork peers or also the additional, non-InternalNetwork peers as well. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BfdEnabled? OnlyUseHostIPs
        {
            get => OnlyUseHostIps;
            set => OnlyUseHostIps = value;
        }
    }
}
