// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization(nameof(Rules), DeserializationValueHook = nameof(DeserializeRules))]
    public partial class ManagedRuleSetRuleGroup
    {
        // The service returns numeric IDs despite the string schema; preserve pre-migration tolerance.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeRules(JsonProperty property, ref IReadOnlyList<string> rules)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<string> array = new List<string>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(item.ValueKind == JsonValueKind.Number ? item.GetRawText() : item.GetString());
            }
            rules = array;
        }
    }
}
