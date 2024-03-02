// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSerialization(nameof(Id), DeserializationValueHook = nameof(ReadId))]
    [CodeGenSerialization(nameof(PredefinedPolicies), DeserializationValueHook = nameof(ReadPredefinedPolicies))]
    public partial class ApplicationGatewayAvailableSslOptionsInfo
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadPredefinedPolicies(JsonProperty property, ref IList<WritableSubResource> predefinedPolicies)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                // Wrokaround for issue https://github.com/Azure/azure-sdk-for-net/issues/27102 to ensure the id is a valid ResourceIdentifier
                string val = item.ToString();
                if (val.Contains("resourceGroups//"))
                {
                    val = val.Replace("resourceGroups//", string.Empty);
                }
                array.Add(JsonSerializer.Deserialize<WritableSubResource>(val));
            }
            predefinedPolicies = array;
        }
    }
}
