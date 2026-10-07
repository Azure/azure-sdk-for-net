// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StorageMover.Models
{
    // The Storage Mover RP returns "" (empty string) for AgentResourceId on
    // Cloud-to-Cloud jobs (which have no agent), and may return "" for
    // SourceResourceId / TargetResourceId in transient states. The default
    // generated deserializer constructs `new ResourceIdentifier(value)` which
    // throws ArgumentException on empty strings. These deserialization hooks
    // treat "" the same as null so polling JobRun in C2C scenarios succeeds.
    /// <summary> Job run properties. </summary>
    [CodeGenSerialization(nameof(AgentResourceId), DeserializationValueHook = nameof(DeserializeAgentResourceIdValue))]
    [CodeGenSerialization(nameof(SourceResourceId), DeserializationValueHook = nameof(DeserializeSourceResourceIdValue))]
    [CodeGenSerialization(nameof(TargetResourceId), DeserializationValueHook = nameof(DeserializeTargetResourceIdValue))]
    internal partial class JobRunProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeAgentResourceIdValue(JsonProperty property, ref ResourceIdentifier agentResourceId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;
            var propVal = property.Value.GetString();
            if (string.IsNullOrEmpty(propVal))
                return;
            agentResourceId = new ResourceIdentifier(propVal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeSourceResourceIdValue(JsonProperty property, ref ResourceIdentifier sourceResourceId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;
            var propVal = property.Value.GetString();
            if (string.IsNullOrEmpty(propVal))
                return;
            sourceResourceId = new ResourceIdentifier(propVal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTargetResourceIdValue(JsonProperty property, ref ResourceIdentifier targetResourceId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;
            var propVal = property.Value.GetString();
            if (string.IsNullOrEmpty(propVal))
                return;
            targetResourceId = new ResourceIdentifier(propVal);
        }
    }
}
