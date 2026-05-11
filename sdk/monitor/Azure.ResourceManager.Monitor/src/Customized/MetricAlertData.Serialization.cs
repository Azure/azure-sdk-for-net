// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor
{
    // Issue #52787:
    // Some service responses contain targetResourceType as "" instead of null.
    // The generated code would pass that value to new ResourceType(...), which throws.
    // This hook keeps normal behavior for valid values and ignores null/empty/whitespace values.
    [CodeGenSerialization(nameof(TargetResourceType), DeserializationValueHook = nameof(ReadTargetResourceType))]
    public partial class MetricAlertData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadTargetResourceType(JsonProperty property, ref ResourceType? targetResourceType)
        {
            var value = property.Value.ValueKind == JsonValueKind.Null ? null : property.Value.GetString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                targetResourceType = new ResourceType(value);
            }
        }
    }
}
