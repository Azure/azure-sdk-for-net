// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for VPN client parameters. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release", false)]
    public partial class VpnClientParameters : VpnClientContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnClientParameters"/>. </summary>
        public VpnClientParameters()
        {
        }
    }
}
