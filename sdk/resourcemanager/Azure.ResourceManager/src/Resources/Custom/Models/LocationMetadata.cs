// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        internal void WriteLongitude(Utf8JsonWriter writer)
        {
            if (Longitude != null)
                writer.WriteStringValue(Longitude.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLongitude(JsonProperty property, ref Optional<double> longitude)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            longitude = double.Parse(property.Value.GetString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteLatitude(Utf8JsonWriter writer)
        {
            if (Latitude != null)
                writer.WriteStringValue(Latitude.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLatitude(JsonProperty property, ref Optional<double> latitude)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            latitude = double.Parse(property.Value.GetString());
        }
    }
}
