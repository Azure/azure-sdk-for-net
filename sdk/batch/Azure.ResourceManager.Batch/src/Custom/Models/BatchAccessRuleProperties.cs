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

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> Properties of Access Rule. </summary>
    [CodeGenSerialization(nameof(Subscriptions), DeserializationValueHook = nameof(DeserializeSubscriptions))]
    public partial class BatchAccessRuleProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeSubscriptions(JsonProperty property, ref IReadOnlyList<SubResource> subscriptions)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            List<SubResource> array = new List<SubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<SubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), null, AzureResourceManagerBatchContext.Default));
            }
            subscriptions = array;
        }
    }
}
