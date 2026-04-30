// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed `ClientIP` typed as System.Net.IPAddress, but the spec
    // models `clientIp: string` so the generator emits `ClientIp` as a string. Spec change
    // can't fix this — TypeSpec has no way to project the wire-format string into a CLR
    // System.Net.IPAddress on the client side; the parse/format bridging must live in C#.
    public partial class NetAppVolumeBreakFileLocksContent
    {
        /// <summary> The client IP address (legacy alias for <see cref="ClientIp"/> typed as <see cref="IPAddress"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ClientIP
        {
            get => string.IsNullOrEmpty(ClientIp) ? null : IPAddress.Parse(ClientIp);
            set => ClientIp = value?.ToString();
        }
    }
}
