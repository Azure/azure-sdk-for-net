// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    [CodeGenSerialization(nameof(ApplicationGatewayBackendAddressPools),DeserializationValueHook = nameof(DeserializeApplicationGatewayBackendAddressPools))]
    [CodeGenSerialization(nameof(ApplicationSecurityGroups), DeserializationValueHook = nameof(DeserializeApplicationSecurityGroups))]
    [CodeGenSerialization(nameof(LoadBalancerBackendAddressPools), DeserializationValueHook = nameof(DeserializeLoadBalancerBackendAddressPools))]
    [CodeGenSerialization(nameof(LoadBalancerInboundNatPools), DeserializationValueHook = nameof(DeserializeLoadBalancerInboundNatPools))]
    public partial class ComputeFleetVmssIPConfigurationProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeApplicationGatewayBackendAddressPools(JsonProperty property, ref IList<WritableSubResource> applicationGatewayBackendAddressPools)
        {
            DeserializeWritableSubResourceList(property, ref applicationGatewayBackendAddressPools);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeApplicationSecurityGroups(JsonProperty property, ref IList<WritableSubResource> applicationSecurityGroups)
        {
            DeserializeWritableSubResourceList(property, ref applicationSecurityGroups);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeLoadBalancerBackendAddressPools(JsonProperty property, ref IList<WritableSubResource> loadBalancerBackendAddressPools)
        {
            DeserializeWritableSubResourceList(property, ref loadBalancerBackendAddressPools);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeLoadBalancerInboundNatPools(JsonProperty property, ref IList<WritableSubResource> loadBalancerInboundNatPools)
        {
            DeserializeWritableSubResourceList(property, ref loadBalancerInboundNatPools);
        }

        private static void DeserializeWritableSubResourceList(JsonProperty property, ref IList<WritableSubResource> list)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = [];
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), null, AzureResourceManagerComputeFleetContext.Default));
            }
            list = array;
        }
    }
}
