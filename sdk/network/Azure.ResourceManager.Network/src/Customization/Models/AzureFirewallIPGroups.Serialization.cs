// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    // This is a fix for issue: https://github.com/Azure/azure-sdk-for-net/issues/46767
    [CodeGenSerialization(nameof(ChangeNumber), DeserializationValueHook = nameof(DeserializeNumberValue))]
    public partial class AzureFirewallIPGroups
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNumberValue(JsonProperty property, ref string changeNumber)
        {
            changeNumber = property.Value.ValueKind == JsonValueKind.Number ? property.Value.GetUInt64().ToString() : property.Value.GetString();
        }
    }
}
