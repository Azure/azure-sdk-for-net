// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    [CodeGenSerialization(nameof(SncMode), DeserializationValueHook = nameof(DeserializeBoolValue))]
    public partial class SapTableLinkedService
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeBoolValue(JsonProperty property, ref DataFactoryElement<string> sncMode)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                sncMode = JsonSerializer.Deserialize<DataFactoryElement<string>>($"\"{property.Value.GetRawText()}\"");
            }
        }
    }
}
