// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class BackendAddressPoolResource
    {
        // Preserve the released names while forwarding to the native operations for the same request path.
        /// <summary> Invokes the GetInboundNatRulePortMappingsLoadBalancerAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use GetInboundNatRulePortMappingsAsync instead.")]
        public virtual Task<ArmOperation<BackendAddressInboundNatRulePortMappings>> GetInboundNatRulePortMappingsLoadBalancerAsync(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken = default)
            => GetInboundNatRulePortMappingsAsync(waitUntil, content, cancellationToken);
        /// <summary> Invokes the GetInboundNatRulePortMappingsLoadBalancer compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use GetInboundNatRulePortMappings instead.")]
        public virtual ArmOperation<BackendAddressInboundNatRulePortMappings> GetInboundNatRulePortMappingsLoadBalancer(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken = default)
            => GetInboundNatRulePortMappings(waitUntil, content, cancellationToken);
    }
}
