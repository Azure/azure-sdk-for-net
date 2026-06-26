// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The current mode enforced, 0 - Disabled, 1 - Alert, 2 -Deny. </summary>
    [Obsolete("Use FirewallPolicyIdpsSignatureMode instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FirewallPolicyIDPSSignatureMode
    {
        /// <summary> 0. </summary>
        _0 = 0,
        /// <summary> 1. </summary>
        _1 = 1,
        /// <summary> 2. </summary>
        _2 = 2
    }
}
