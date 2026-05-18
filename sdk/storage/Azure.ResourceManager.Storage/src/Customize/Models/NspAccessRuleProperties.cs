// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Structural fix: Custom deserialization hook so Subscriptions is read correctly as
// List<SubResource>. Generator deserializes this incorrectly.
// Generator bug: https://github.com/Azure/azure-sdk-for-net/issues/57282
// TODO: Clean up after the generator bug is resolved.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    [CodeGenSerialization(nameof(Subscriptions), DeserializationValueHook = nameof(DeserializeSubscriptionsList))]
    public partial class NspAccessRuleProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeSubscriptionsList(JsonProperty property, ref IReadOnlyList<SubResource> subscriptions)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var list = new List<SubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    list.Add(null);
                }
                else
                {
                    list.Add(ModelReaderWriter.Read<SubResource>(
                        new System.BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())),
                        ModelSerializationExtensions.WireOptions,
                        AzureResourceManagerStorageContext.Default));
                }
            }
            subscriptions = list;
        }
    }
}
