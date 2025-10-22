// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    // Custom deserialization hook for handling mixed-type rule arrays.
    // Addresses issue where WAF rule IDs can be either strings or numbers in JSON.
    [CodeGenSerialization(nameof(Rules), DeserializationValueHook = nameof(DeserializeNumberValue))]
    public partial class ManagedRuleSetRuleGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNumberValue(JsonProperty property, ref IReadOnlyList<string> rules)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            rules = [.. property.Value.EnumerateArray()
                .Select(item => item.ValueKind == JsonValueKind.String
                    ? item.GetString()
                    : item.GetInt32().ToString())];
        }
    }
}
