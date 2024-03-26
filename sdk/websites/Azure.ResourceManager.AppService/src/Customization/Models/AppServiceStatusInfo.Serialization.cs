// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenSerialization(nameof(StatusId), SerializationValueHook = nameof(WriteStatusId), DeserializationValueHook = nameof(ReadStatusId))]
    public partial class AppServiceStatusInfo : IUtf8JsonSerializable, IJsonModel<AppServiceStatusInfo>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteStatusId(Utf8JsonWriter writer)
        {
            WriteEnumToInt(writer, StatusId);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadStatusId(JsonProperty property, ref DetectorInsightStatus? statusId)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                statusId = (DetectorInsightStatus)property.Value.GetInt32();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteEnumToInt(Utf8JsonWriter writer, DetectorInsightStatus? value)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}
