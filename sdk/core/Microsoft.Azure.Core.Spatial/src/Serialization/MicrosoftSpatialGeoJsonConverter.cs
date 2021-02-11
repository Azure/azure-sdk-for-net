// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Spatial;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Converts between <c>Microsoft.Spatial</c> objects and Geo-JSON.
    /// </summary>
    public class MicrosoftSpatialGeoJsonConverter : JsonConverter<object>
    {
        // TODO: Consider reading and writing more of a GeographicPoint, but for now we only read and write what we support in OData currently.
        private const string CoordinatesPropertyName = "coordinates";
        private const string PointTypeName = "Point";
        private const string TypePropertyName = "type";

        private static readonly JsonEncodedText s_CoordinatesPropertyNameBytes = JsonEncodedText.Encode(CoordinatesPropertyName);
        private static readonly JsonEncodedText s_TypePropertyNameBytes = JsonEncodedText.Encode(TypePropertyName);

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert) =>
            // BUGBUG #15506: Check for all Geography derivatives.
            typeof(GeographyPoint).IsAssignableFrom(typeToConvert);

        /// <inheritdoc/>
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            string type = default;
            double? longitude = default;
            double? latitude = default;

            reader.Expect(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                reader.Expect(JsonTokenType.PropertyName);
                string propertyName = reader.GetString();

                reader.Read();
                if (string.Equals(TypePropertyName, propertyName, StringComparison.Ordinal))
                {
                    reader.Expect(JsonTokenType.String);
                    type = reader.GetString();
                }
                else if (string.Equals(CoordinatesPropertyName, propertyName, StringComparison.Ordinal))
                {
                    reader.Expect(JsonTokenType.StartArray);

                    // Longitude
                    reader.Read();
                    reader.Expect(JsonTokenType.Number);
                    longitude = reader.GetDouble();

                    // Latitude
                    reader.Read();
                    reader.Expect(JsonTokenType.Number);
                    latitude = reader.GetDouble();

                    // Skip the rest.
                    do
                    {
                        reader.Read();
                    } while (reader.TokenType != JsonTokenType.EndArray);
                }
                else
                {
                    reader.Skip();
                }
            }

            if (!string.Equals(PointTypeName, type, StringComparison.Ordinal))
            {
                throw new JsonException($"Deserialization of {nameof(GeographyPoint)} failed. Expected geographic type: '{PointTypeName}'.");
            }

            if (!longitude.HasValue || !latitude.HasValue)
            {
                throw new JsonException($"Deserialization of {nameof(GeographyPoint)} failed. Expected both longitude and latitude.");
            }

            return GeographyPoint.Create(latitude.Value, longitude.Value);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is GeographyPoint point)
            {
                writer.WriteStartObject();
                writer.WriteString(s_TypePropertyNameBytes, PointTypeName);
                writer.WriteStartArray(s_CoordinatesPropertyNameBytes);
                writer.WriteNumberValue(point.Longitude);
                writer.WriteNumberValue(point.Latitude);
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
        }
    }
}
