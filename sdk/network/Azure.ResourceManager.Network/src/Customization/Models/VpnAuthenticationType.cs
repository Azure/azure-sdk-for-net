// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> VPN authentication types enabled for the virtual network gateway. </summary>
    public readonly partial struct VpnAuthenticationType : IEquatable<VpnAuthenticationType>
    {
        /// <summary> AAD. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public static VpnAuthenticationType AAD { get; } = new VpnAuthenticationType(AadValue);
    }
}
