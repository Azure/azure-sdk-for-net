// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ApplicationGatewayBackendAddressPools), DeserializationValueHook = nameof(DeserializeApplicationGatewayBackendAddressPools))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(LoadBalancerBackendAddressPools), DeserializationValueHook = nameof(DeserializeLoadBalancerBackendAddressPools))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(LoadBalancerInboundNatPools), DeserializationValueHook = nameof(DeserializeLoadBalancerInboundNatPools))]
    public partial class ServiceFabricManagedClusterIPConfiguration
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeApplicationGatewayBackendAddressPools(JsonProperty property, ref IList<WritableSubResource> applicationGatewayBackendAddressPools)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), null, AzureResourceManagerServiceFabricManagedClustersContext.Default));
            }
            applicationGatewayBackendAddressPools = array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeLoadBalancerBackendAddressPools(JsonProperty property, ref IList<WritableSubResource> loadBalancerBackendAddressPools)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), null, AzureResourceManagerServiceFabricManagedClustersContext.Default));
            }
            loadBalancerBackendAddressPools = array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeLoadBalancerInboundNatPools(JsonProperty property, ref IList<WritableSubResource> loadBalancerInboundNatPools)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), null, AzureResourceManagerServiceFabricManagedClustersContext.Default));
            }
            loadBalancerInboundNatPools = array;
        }
    }
}
