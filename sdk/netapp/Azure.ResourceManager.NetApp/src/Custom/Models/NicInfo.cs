// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed `IPAddress` (all-caps); the spec field `ipAddress`
    // generates `IpAddress`. Renaming via @@clientName would break GA callers using
    // `IpAddress` — keep both names by aliasing here.
    public partial class NicInfo
    {
        /// <summary> IP Address (legacy alias for <see cref="IpAddress"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPAddress => IpAddress;
    }
}
