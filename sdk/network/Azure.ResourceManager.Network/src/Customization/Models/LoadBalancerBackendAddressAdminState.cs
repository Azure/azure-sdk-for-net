// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct LoadBalancerBackendAddressAdminState
    {
        // Shipped in 1.15.0, but not a value in the current service schema.
        /// <summary> Drain. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This state is obsolete and will be removed in a future release", false)]
        public static LoadBalancerBackendAddressAdminState Drain { get; } = new LoadBalancerBackendAddressAdminState("Drain");
    }
}
