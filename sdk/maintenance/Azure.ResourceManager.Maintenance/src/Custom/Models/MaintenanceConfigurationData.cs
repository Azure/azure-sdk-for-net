// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Maintenance
{
    [CodeGenSerialization(nameof(StartOn), SerializationValueHook = nameof(SerializeStartOn))]
    [CodeGenSerialization(nameof(ExpireOn), SerializationValueHook = nameof(SerializeExpireOn))]
    public partial class MaintenanceConfigurationData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeStartOn(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(StartOn.Value, "yyyy-MM-dd HH:mm");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeExpireOn(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(ExpireOn.Value, "yyyy-MM-dd HH:mm");
        }
    }
}
