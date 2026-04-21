// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Justification: the generator's default read path for this PATCH model's
    // IList<WritableSubResource> currently emits an invalid call to a nonexistent
    // WritableSubResource.DeserializeWritableSubResource method. Keep a property-level
    // deserialization hook until the generator uses the correct per-item read path.
    [CodeGenSerialization(nameof(DnsResolverOutboundEndpoints), DeserializationValueHook = nameof(DeserializeDnsResolverOutboundEndpoints))]
    public partial class DnsForwardingRulesetPatch
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeDnsResolverOutboundEndpoints(global::System.Text.Json.JsonProperty property, ref IList<WritableSubResource> dnsResolverOutboundEndpoints)
        {
            if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
            {
                return;
            }

            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (global::System.Text.Json.JsonElement item in property.Value.EnumerateArray())
            {
                if (item.ValueKind == global::System.Text.Json.JsonValueKind.Null)
                {
                    array.Add(null);
                }
                else
                {
                    array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerDnsResolverContext.Default));
                }
            }

            dnsResolverOutboundEndpoints = array;
        }
    }
}
