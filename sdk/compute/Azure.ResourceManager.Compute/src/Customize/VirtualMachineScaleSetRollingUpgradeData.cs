// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    // Add serialization and deserialization hooks for Id property to handle the null and empty string cases for issue #45613.
    [CodeGenSerialization(nameof(Id), DeserializationValueHook = nameof(DeserializeId))]
    public partial class VirtualMachineScaleSetRollingUpgradeData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeId(JsonProperty property, ref ResourceIdentifier id)
        {
            if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
            {
                id = null;
            }
            id = new ResourceIdentifier(property.Value.GetString());
        }
    }
}
