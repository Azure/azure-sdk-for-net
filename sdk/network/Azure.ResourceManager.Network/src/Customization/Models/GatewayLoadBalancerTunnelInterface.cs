// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Gateway load balancer tunnel interface of a load balancer backend address pool. </summary>
    public partial class GatewayLoadBalancerTunnelInterface
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="InterfaceType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use InterfaceType instead.")]
        public GatewayLoadBalancerTunnelInterfaceType? Type
        {
            get => InterfaceType;
            set => InterfaceType = value;
        }
    }
}
