// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly string[] TypeNames = new string[]
        {
            GeoJsonConstants.PointTypeName,
            GeoJsonConstants.LineStringTypeName,
            GeoJsonConstants.PolygonTypeName,
            GeoJsonConstants.MultiPointTypeName,
            GeoJsonConstants.MultiLineStringTypeName,
            GeoJsonConstants.MultiPolygonTypeName,
            GeoJsonConstants.GeometryCollectionTypeName
        };

        private static readonly Type[] SupportedTypes = new Type[]
        {
            typeof(GeographyPoint),
            typeof(GeographyLineString),
            typeof(GeographyPolygon),
            typeof(GeographyMultiPoint),
            typeof(GeographyMultiLineString),
            typeof(GeographyMultiPolygon),
            typeof(GeographyCollection),
        };

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            return SupportedTypes.Any(z => typeToConvert.IsAssignableFrom(z));
        }

        /// <inheritdoc/>
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            Geography result = ProcessSingleGeography(ref reader);

            Type resultType = result.GetType();

            if (!typeToConvert.IsAssignableFrom(resultType))
            {
                throw new JsonException($"Deserialization failed. Discovered GeoJson of Type {resultType.Name}, expected {typeToConvert.Name}.");
            }

            return result;
        }

        private Geography ProcessSingleGeography(ref Utf8JsonReader reader)
        {
            string type = null;
            GeoJsonCoordinateReader geoJsonCoordinateReader = null;
            List<Geography> geographies = null;

            reader.Expect(JsonTokenType.StartObject);

            while (reader.SkipComments() && reader.TokenType != JsonTokenType.EndObject)
            {
                reader.Expect(JsonTokenType.PropertyName);

                string propertyName = reader.GetString();

                reader.SkipComments();

                if (string.Equals(GeoJsonConstants.TypePropertyName, propertyName, StringComparison.Ordinal))
                {
                    reader.Expect(JsonTokenType.String);
                    type = reader.GetString();
                }

                else if (string.Equals(GeoJsonConstants.CoordinatesPropertyName, propertyName, StringComparison.Ordinal))
                {
                    geoJsonCoordinateReader = GeoJsonCoordinateReader.Create(ref reader);
                }

                else if (string.Equals(GeoJsonConstants.GeometriesPropertyName, propertyName, StringComparison.Ordinal))
                {
                    geographies = ProcessGeometryCollection(ref reader);
                }

                else
                {
                    reader.Skip();
                }
            }

            if (type == null)
            {
                throw new JsonException($"Deserialization failed. Required GeoJson property '{GeoJsonConstants.TypePropertyName}' not found.");
            }

            if (!TypeNames.Contains(type))
            {
                string valid = TypeNames.FirstOrDefault(z => z.Equals(type, StringComparison.OrdinalIgnoreCase));

                if (valid != null)
                {
                    throw new JsonException($"Deserialization failed. GeoJson property '{GeoJsonConstants.TypePropertyName}' values are case sensitive. Use '{valid}' instead.");
                }

                throw new JsonException($"Deserialization failed. GeoJson property '{GeoJsonConstants.TypePropertyName}' contains an invalid value: {type}.");
            }

            if (geoJsonCoordinateReader != null)
            {
                return geoJsonCoordinateReader.GetGeography(type);
            }

            else if (geographies != null)
            {
                return GeographyFactory.Collection().Create(geographies);
            }

            else
            {
                if (type == GeoJsonConstants.GeometryCollectionTypeName)
                {
                    throw new JsonException($"Deserialization failed. Required GeoJson property '{GeoJsonConstants.GeometriesPropertyName}' not found.");
                }

                else
                {
                    throw new JsonException($"Deserialization failed. Required GeoJson property '{GeoJsonConstants.CoordinatesPropertyName}' not found.");
                }
            }
        }

        private List<Geography> ProcessGeometryCollection(ref Utf8JsonReader reader)
        {
            List<Geography> result = new List<Geography>();

            reader.Expect(JsonTokenType.StartArray);

            while (reader.SkipComments() && reader.TokenType != JsonTokenType.EndArray)
            {
                Geography geography = ProcessSingleGeography(ref reader);

                result.Add(geography);
            }

            return result;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is Geography geography)
            {
                writer.WriteGeography(geography);
            }
        }
    }
}
