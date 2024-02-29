// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenSerialization(nameof(AnalysisType), SerializationValueHook = nameof(WriteAnalysisType), DeserializationValueHook = nameof(ReadAnalysisType))]
    public partial class DetectorInfo : IUtf8JsonSerializable, IJsonModel<DetectorInfo>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteAnalysisType(Utf8JsonWriter writer)
        {
            WriteArrayToString(writer, AnalysisType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadAnalysisType(JsonProperty property, ref IReadOnlyList<string> analysisType)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                analysisType = new List<string>() { property.Value.GetString() };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteArrayToString(Utf8JsonWriter writer, IReadOnlyList<string> analysisType)
        {
            writer.WriteStringValue(analysisType.ToString());
        }
    }
}
