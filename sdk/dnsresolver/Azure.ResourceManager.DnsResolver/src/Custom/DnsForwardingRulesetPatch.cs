// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Justification: the generator's default read path for this PATCH model's
    // IList<WritableSubResource> currently emits an invalid call to the internal
    // WritableSubResource.DeserializeWritableSubResource method (CS0117). Keep a
    // property-level deserialization hook until the generator uses the correct
    // per-item read path (ModelReaderWriter.Read<WritableSubResource>(...)).
    // TODO: remove this customization once https://github.com/Azure/azure-sdk-for-net/issues/58426 is fixed.
    [CodeGenSerialization(nameof(DnsResolverOutboundEndpoints), DeserializationValueHook = nameof(DeserializeDnsResolverOutboundEndpoints))]
    public partial class DnsForwardingRulesetPatch
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeDnsResolverOutboundEndpoints(JsonProperty property, ref IList<WritableSubResource> dnsResolverOutboundEndpoints)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (JsonElement item in property.Value.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
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
