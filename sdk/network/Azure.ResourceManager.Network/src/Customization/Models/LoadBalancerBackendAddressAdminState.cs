// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A list of administrative states which once set can override health probe so that Load Balancer will always forward new connections to backend, or deny new connections and reset existing connections. </summary>
    public readonly partial struct LoadBalancerBackendAddressAdminState : IEquatable<LoadBalancerBackendAddressAdminState>
    {
        private const string DrainValue = "Drain";

        /// <summary> Drain. </summary>
        [Obsolete("This state is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancerBackendAddressAdminState Drain { get; } = new LoadBalancerBackendAddressAdminState(DrainValue);
    }
}
