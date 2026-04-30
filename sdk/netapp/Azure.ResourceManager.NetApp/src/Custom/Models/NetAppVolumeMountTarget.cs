// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed the property as `IPAddress` (all-caps acronym). The spec
    // declares it `ipAddress` so the generator emits `IpAddress`. @@clientName could rename
    // it to "IPAddress" but that would *break* GA users still calling `IpAddress`; keep both
    // by aliasing here.
    public partial class NetAppVolumeMountTarget
    {
        /// <summary> The mount target's IPv4 address (legacy alias for <see cref="IpAddress"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress IPAddress => IpAddress;
    }
}
