// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    [CodeGenSerialization(nameof(Subscriptions), DeserializationValueHook = nameof(DeserializeSubscriptions))]
    public partial class NetworkSecurityPerimeterAccessRuleProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeSubscriptions(JsonProperty property, ref IList<WritableSubResource> subscriptions, ModelReaderWriterOptions options)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), options, AzureResourceManagerCognitiveServicesContext.Default));
            }
            subscriptions = array;
        }
    }
}
