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

namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(EffectiveOutboundIPs), DeserializationValueHook = nameof(DeserializeEffectiveOutboundIPs))]
    public partial class ManagedClusterLoadBalancerProfile
    {
        /// <summary> The effective outbound IP resources of the cluster load balancer. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeEffectiveOutboundIPs(JsonProperty property, ref IList<WritableSubResource> EffectiveOutboundIPs)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    array.Add(null);
                }
                else
                {
                    array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerContainerServiceContext.Default));
                }
            }
            EffectiveOutboundIPs = array;
        }
    }
}
