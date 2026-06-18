// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the BackendAddressPoolResource type. </summary>
    public partial class BackendAddressPoolResource
    {
        /// <summary> Invokes the GetInboundNatRulePortMappingsLoadBalancerAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<BackendAddressInboundNatRulePortMappings>> GetInboundNatRulePortMappingsLoadBalancerAsync(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetInboundNatRulePortMappingsLoadBalancer compatibility operation. </summary>
        public virtual ArmOperation<BackendAddressInboundNatRulePortMappings> GetInboundNatRulePortMappingsLoadBalancer(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
