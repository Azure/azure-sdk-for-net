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

// NOTE: customize the deserialization of the "subscriptions" property.
namespace Azure.ResourceManager.Search.Models
{
    [CodeGenSerialization(nameof(Subscriptions), DeserializationValueHook = nameof(DeserializeIsSubscriptions))]
    public partial class SearchServiceNetworkSecurityPerimeterAccessRuleProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeIsSubscriptions(JsonProperty property, ref IList<WritableSubResource> subscriptions)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerSearchContext.Default));
            }
            subscriptions = array;
        }
    }
}
