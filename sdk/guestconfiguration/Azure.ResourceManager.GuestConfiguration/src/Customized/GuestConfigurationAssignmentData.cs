// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.GuestConfiguration
{
    [CodeGenSerialization(nameof(SystemData), DeserializationValueHook = nameof(DeserializeSystemDataValue))]
    [CodeGenSerialization(nameof(Location), DeserializationValueHook = nameof(DeserializeLocationValue))]
    public partial class GuestConfigurationAssignmentData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeSystemDataValue(JsonProperty property, ref SystemData systemData)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerGuestConfigurationContext.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeLocationValue(JsonProperty property, ref string location)
        {
            location = property.Value.GetString();
        }
    }
}
