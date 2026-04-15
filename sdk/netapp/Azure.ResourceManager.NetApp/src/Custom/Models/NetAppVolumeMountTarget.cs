// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeMountTarget
    {
        /// <summary> The mount target's IPv4 address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress IPAddress => IpAddress;
    }
}
