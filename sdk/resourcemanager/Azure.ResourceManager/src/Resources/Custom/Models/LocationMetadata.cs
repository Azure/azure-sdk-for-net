// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    [CodeGenSerialization(nameof(Longitude), SerializationValueHook = nameof(WriteLongitude), DeserializationValueHook = nameof(ReadLongitude))]
    [CodeGenSerialization(nameof(Latitude), SerializationValueHook = nameof(WriteLatitude), DeserializationValueHook = nameof(ReadLatitude))]
    public partial class LocationMetadata
    {
        /// <summary> The longitude of the location. </summary>
        public double? Longitude { get; }
        /// <summary> The latitude of the location. </summary>
        public double? Latitude { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteLongitude(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Longitude.HasValue)
            {
                writer.WriteStringValue(Longitude.Value.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLongitude(JsonProperty property, ref double? longitude)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            longitude = double.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteLatitude(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Latitude.HasValue)
            {
                writer.WriteStringValue(Latitude.Value.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLatitude(JsonProperty property, ref double? latitude)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            latitude = double.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);
        }
    }
}
