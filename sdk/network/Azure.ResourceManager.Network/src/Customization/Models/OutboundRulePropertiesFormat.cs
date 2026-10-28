// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization(nameof(FrontendIPConfigurations), DeserializationValueHook = nameof(DeserializeFrontendIPConfigurations))]
    internal partial class OutboundRulePropertiesFormat
    {
        private static void DeserializeFrontendIPConfigurations(JsonProperty property, ref IList<WritableSubResource> frontendIPConfigurations)
        {
            frontendIPConfigurations = new ChangeTrackingList<WritableSubResource>();
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                foreach (JsonElement item in property.Value.EnumerateArray())
                {
                    frontendIPConfigurations.Add(item.ValueKind == JsonValueKind.Null
                        ? null
                        : ModelReaderWriter.Read<WritableSubResource>(
                            BinaryData.FromString(item.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default));
                }
            }
        }
    }
}
