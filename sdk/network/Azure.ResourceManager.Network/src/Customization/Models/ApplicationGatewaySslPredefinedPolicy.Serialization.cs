// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization(nameof(Id), DeserializationValueHook = nameof(ReadId))]
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadId(JsonProperty property, ref ResourceIdentifier id)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            // Wrokaround for issue https://github.com/Azure/azure-sdk-for-net/issues/27102 to ensure the id is a valid ResourceIdentifier
            string val = property.Value.GetString();
            if (val.Contains("resourceGroups//"))
            {
                val = val.Replace("resourceGroups//", string.Empty);
            }
            id = new ResourceIdentifier(val);
        }
    }
}
