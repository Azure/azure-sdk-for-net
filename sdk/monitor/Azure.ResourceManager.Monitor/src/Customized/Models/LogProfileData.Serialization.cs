// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor
{
    [CodeGenSerialization(nameof(Location), DeserializationValueHook = nameof(ReadLocation))]
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(ReadResourceType))]
    public partial class LogProfileData : IUtf8JsonSerializable, IJsonModel<LogProfileData>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLocation(JsonProperty property, ref AzureLocation location)
        {
            // enclosing this deserialization in this if since the service might return null value for this property
            // and we cannot resolve this using a directive since this property is inherited from base type ResourceData
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                location = new AzureLocation(property.Value.GetString());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadResourceType(JsonProperty property, ref ResourceType type)
        {
            // enclosing this deserialization in this if since the service might return null value for this property
            // and we cannot resolve this using a directive since this property is inherited from base type ResourceData
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                type = new ResourceType(property.Value.GetString());
            }
        }
    }
}
