// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Converts between <c>Microsoft.Spatial</c> objects and Geo-JSON.
    /// </summary>
    public class NewtonsoftJsonMicrosoftSpatialGeoJsonConverter : JsonConverter
    {
        private static readonly string[] TypeNames = new string[]
        {
            GeoJsonConstants.PointTypeName,
            GeoJsonConstants.LineStringTypeName,
            GeoJsonConstants.PolygonTypeName,
            GeoJsonConstants.MultiPointTypeName,
            GeoJsonConstants.MultiLineStringTypeName,
            GeoJsonConstants.MultiPolygonTypeName,
            GeoJsonConstants.GeometryCollectionTypeName,
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
        public override bool CanConvert(Type objectType) =>
            SupportedTypes.Any(z => z.IsAssignableFrom(objectType));

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            Geography result = ProcessSingleGeography(reader);

            Type resultType = result.GetType();

            if (!objectType.IsAssignableFrom(resultType))
            {
                throw new JsonSerializationException($"Deserialization failed: Discovered GeoJson of type '{resultType.Name}', expected '{objectType.Name}'.");
            }

            return result;
        }

        /// <summary>
        /// Some GeoJson documents define a single geography, e.g. Point and MultiPolygon. GeometryCollection on the other
        /// hand contains a list of Geographies specified not in the coordinates property, but in the geometries property.
        /// This methodwill be called at the top level by Read(), and in the case of a GeometryCollection, once for every
        /// entry in its geometries array.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="JsonSerializationException"></exception>
        private Geography ProcessSingleGeography(JsonReader reader)
        {
            string type = null;
            GeoJsonCoordinateReader geoJsonCoordinateReader = null;
            List<Geography> geographies = null;

            reader.Expect(JsonToken.StartObject);

            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                string propertyName = reader.Expect<string>(JsonToken.PropertyName);

                reader.Read();

                if (string.Equals(GeoJsonConstants.TypePropertyName, propertyName, StringComparison.Ordinal))
                {
                    type = reader.Expect<string>(JsonToken.String);
                }

                else if (string.Equals(GeoJsonConstants.CoordinatesPropertyName, propertyName, StringComparison.Ordinal))
                {
                    geoJsonCoordinateReader = GeoJsonCoordinateReader.Create(reader);
                }

                else if (string.Equals(GeoJsonConstants.GeometriesPropertyName, propertyName, StringComparison.Ordinal))
                {
                    geographies = ProcessGeometryCollection(reader);
                }

                else
                {
                    reader.Skip();
                }
            }

            if (type == null)
            {
                throw new JsonSerializationException($"Deserialization failed: Required GeoJson property '{GeoJsonConstants.TypePropertyName}' not found.");
            }

            if (!TypeNames.Contains(type))
            {
                string valid = TypeNames.FirstOrDefault(z => z.Equals(type, StringComparison.OrdinalIgnoreCase));

                if (valid != null)
                {
                    throw new JsonSerializationException($"Deserialization failed: GeoJson property '{GeoJsonConstants.TypePropertyName}' values are case sensitive. Use '{valid}' instead.");
                }

                throw new JsonSerializationException($"Deserialization failed: GeoJson property '{GeoJsonConstants.TypePropertyName}' contains an invalid value: '{type}'.");
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
                    throw new JsonSerializationException($"Deserialization failed: Required GeoJson property '{GeoJsonConstants.GeometriesPropertyName}' not found.");
                }

                else
                {
                    throw new JsonSerializationException($"Deserialization failed: Required GeoJson property '{GeoJsonConstants.CoordinatesPropertyName}' not found.");
                }
            }
        }

        /// <summary>
        /// Called when a GeometryCollection is either the top level type, or when a GeometryCollection has been nested inside
        /// another GeometryCollection (which is legal, but apparently discouraged.)
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the beginning of the geometries array.</param>
        /// <returns>The list of Geographies which were extracted.</returns>
        private List<Geography> ProcessGeometryCollection(JsonReader reader)
        {
            List<Geography> result = new List<Geography>();

            reader.Expect(JsonToken.StartArray);

            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
            {
                Geography geography = ProcessSingleGeography(reader);

                result.Add(geography);
            }

            return result;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Geography geography)
            {
                writer.WriteGeography(geography);
            }
        }
    }
}
