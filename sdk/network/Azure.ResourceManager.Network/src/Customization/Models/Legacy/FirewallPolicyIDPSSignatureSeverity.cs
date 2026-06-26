// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes the severity of signature: 1 - High, 2 - Medium, 3 - Low. </summary>
    [Obsolete("Use FirewallPolicyIdpsSignatureSeverity instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FirewallPolicyIDPSSignatureSeverity
    {
        /// <summary> 1. </summary>
        _1 = 1,
        /// <summary> 2. </summary>
        _2 = 2,
        /// <summary> 3. </summary>
        _3 = 3
    }
}
