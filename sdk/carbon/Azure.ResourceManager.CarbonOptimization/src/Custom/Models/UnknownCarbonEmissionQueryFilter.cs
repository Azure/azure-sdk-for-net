// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CarbonOptimization.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ResourceTypeList), DeserializationValueHook = nameof(DeserializeResourceTypeList))]
    internal partial class UnknownCarbonEmissionQueryFilter : CarbonEmissionQueryFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeResourceTypeList(JsonProperty property, ref IList<ResourceType> resourceTypeList)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<ResourceType> array = new List<ResourceType>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(new ResourceType(item.GetString()));
            }
            resourceTypeList = array;
        }
    }
}
