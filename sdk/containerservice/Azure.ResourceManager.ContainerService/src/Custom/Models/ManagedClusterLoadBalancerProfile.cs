// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(EffectiveOutboundIPs), DeserializationValueHook = nameof(DeserializeEffectiveOutboundIPs))]    // Apply custom deserialization for EffectiveOutboundIPs to handle the case when the property is list of WritableSubResource.
    public partial class ManagedClusterLoadBalancerProfile
    {
        /// <summary> Whether to enable multiple standard load balancers. </summary>
        [WirePath("enableMultipleStandardLoadBalancers")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMultipleStandardLoadBalancers { get => IsMultipleStandardLoadBalancersEnabled; set => IsMultipleStandardLoadBalancersEnabled = value; }

        /// <summary> The effective outbound IP resources of the cluster load balancer. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }  // Make the EffectiveOutboundIPs as IList for backward compatibility.

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
