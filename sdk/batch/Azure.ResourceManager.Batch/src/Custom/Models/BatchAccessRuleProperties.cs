// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Batch.Models
{
    // Workaround: The generator emits SubResource.DeserializeSubResource() which is
    // internal to Azure.ResourceManager and inaccessible cross-assembly.
    // Use ModelReaderWriter.Read<SubResource>() via a deserialization hook instead.
    [CodeGenSerialization(nameof(Subscriptions), DeserializationValueHook = nameof(DeserializeSubscriptionsList))]
    public partial class BatchAccessRuleProperties
    {
        private static void DeserializeSubscriptionsList(JsonProperty property, ref IReadOnlyList<SubResource> list)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<SubResource> array = new List<SubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<SubResource>(BinaryData.FromString(item.GetRawText()), null, AzureResourceManagerBatchContext.Default));
            }
            list = array;
        }
    }
}
