// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes in which direction signature is being enforced: 0 - OutBound, 1 - InBound, 2 - Any, 3 - Internal, 4 - InternalOutbound, 5 - InternalInbound. </summary>
    [Obsolete("Use FirewallPolicyIdpsSignatureDirection instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FirewallPolicyIDPSSignatureDirection
    {
        /// <summary> 0. </summary>
        _0 = 0,
        /// <summary> 1. </summary>
        _1 = 1,
        /// <summary> 2. </summary>
        _2 = 2,
        /// <summary> 3. </summary>
        _3 = 3,
        /// <summary> 4. </summary>
        _4 = 4,
        /// <summary> 5. </summary>
        _5 = 5
    }
}
