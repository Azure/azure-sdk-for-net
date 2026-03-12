// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(EffectiveOutboundIPs), DeserializationValueHook = nameof(DeserializeEffectiveOutboundIPs))]
    public partial class ManagedClusterNatGatewayProfile
    {
        /// <summary> The effective outbound IP resources of the cluster NAT gateway. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }     // Make the EffectiveOutboundIPs as IList for backward compatibility.

        /// <summary> The desired number of outbound IPs created/managed by Azure. Allowed values must be in the range of 1 to 16 (inclusive). The default value is 1. </summary>
        [WirePath("managedOutboundIPProfile.count")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ManagedOutboundIPCount
        {
            get => ManagedOutboundIPProfile is null ? default : ManagedOutboundIPProfile.Count;
            set
            {
                if (ManagedOutboundIPProfile is null)
                    ManagedOutboundIPProfile = new ManagedClusterManagedOutboundIPProfile();
                ManagedOutboundIPProfile.Count = value;
            }
        }

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
