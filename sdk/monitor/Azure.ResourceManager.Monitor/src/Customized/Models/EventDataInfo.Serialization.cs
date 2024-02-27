// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    [CodeGenSerialization(nameof(Level), DeserializationValueHook = nameof(ReadLevel))]
    public partial class EventDataInfo : IUtf8JsonSerializable, IJsonModel<EventDataInfo>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLevel(JsonProperty property, ref Optional<MonitorEventLevel> level)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                level = property.Value.GetInt32().ToString().ToMonitorEventLevel();
            }
        }
    }
}
