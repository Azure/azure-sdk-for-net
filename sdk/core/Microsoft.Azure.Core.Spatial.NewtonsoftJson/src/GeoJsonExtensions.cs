// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Defines extension methods for various JSON.NET types that make it easier to recognize and read Geo-JSON.
    /// </summary>
    internal static class GeoJsonExtensions
    {
        private const string Coordinates = "coordinates";
        private const string Crs = "crs";
        private const string Name = "name";
        private const string Point = "Point";
        private const string Properties = "properties";
        private const string Type = "type";
        private const string WorldGeodeticSystem1984 = "EPSG:4326"; // See https://epsg.io/4326

        private static readonly IEnumerable<string> CrsOnly = new[] { Crs };
        private static readonly IEnumerable<string> NameOnly = new[] { Name };
        private static readonly IEnumerable<string> TypeAndCoordinates = new[] { Type, Coordinates };
        private static readonly IEnumerable<string> TypeAndProperties = new[] { Type, Properties };

        /// <summary>
        /// Reads a Geo-JSON point into a <see cref="GeographyPoint" /> instance, or throws
        /// <see cref="JsonSerializationException" /> if the reader is not positioned on the
        /// beginning of a valid Geo-JSON point.
        /// </summary>
        /// <param name="reader">The JSON reader from which to read a Geo-JSON point.</param>
        /// <returns>A <see cref="GeographyPoint" /> instance.</returns>
        public static GeographyPoint ReadGeoJsonPoint(this JsonReader reader)
        {
            // Check for null first.
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            GeographyPoint result = null;

            reader.ReadObject(
                requiredProperties: TypeAndCoordinates,
                optionalProperties: CrsOnly,
                readProperty: (r, propertyName) =>
                {
                    switch (propertyName)
                    {
                        case Type:
                            r.ExpectAndAdvance(JsonToken.String, Point);
                            break;

                        case Coordinates:
                            result = ReadCoordinates(r);
                            break;

                        case Crs:
                            ReadCrs(r);
                            break;
                    }
                });

            return result;
        }

        /// <summary>
        /// Writes a <see cref="GeographyPoint" /> instance as Geo-JSON format.
        /// </summary>
        /// <param name="writer">The JSON writer to which to write the Geo-JSON point.</param>
        /// <param name="point">The <see cref="GeographyPoint" /> instance to write.</param>
        public static void WriteGeoJsonPoint(this JsonWriter writer, GeographyPoint point)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(Type);
            writer.WriteValue(Point);
            writer.WritePropertyName(Coordinates);
            writer.WriteStartArray();
            writer.WriteValue(point.Longitude);
            writer.WriteValue(point.Latitude);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private static bool IsCrsProperties(JObject possibleProperties) =>
            possibleProperties.IsValid(
                requiredProperties: NameOnly,
                isPropertyValid: property => property.Name == Name && property.Value.IsString(WorldGeodeticSystem1984));

        private static void ReadCrsProperties(JsonReader propertiesReader) =>
            propertiesReader.ReadObjectAndAdvance(
                requiredProperties: NameOnly,
                readProperty: (r, _) => r.ExpectAndAdvance(JsonToken.String, WorldGeodeticSystem1984));

        private static void ReadCrs(JsonReader crsReader) =>
            crsReader.ReadObjectAndAdvance(
                requiredProperties: TypeAndProperties,
                readProperty: (r, propertyName) =>
                {
                    switch (propertyName)
                    {
                        case Type:
                            r.ExpectAndAdvance(JsonToken.String, Name);
                            break;

                        case Properties:
                            ReadCrsProperties(r);
                            break;
                    }
                });

        private static GeographyPoint ReadCoordinates(JsonReader coordinatesReader)
        {
            coordinatesReader.ExpectAndAdvance(JsonToken.StartArray);

            double ReadFloatOrInt()
            {
                switch (coordinatesReader.TokenType)
                {
                    case JsonToken.Integer:
                        return coordinatesReader.ExpectAndAdvance<long>(JsonToken.Integer);

                    // Treat all other cases as Float and let ExpectAndAdvance() handle any errors.
                    default:
                        return coordinatesReader.ExpectAndAdvance<double>(JsonToken.Float);
                }
            }

            double longitude = ReadFloatOrInt();
            double latitude = ReadFloatOrInt();

            // Skip remaining coordinates, e.g. z and m.
            while (coordinatesReader.TokenType != JsonToken.EndArray)
            {
                coordinatesReader.Advance();
            }

            coordinatesReader.ExpectAndAdvance(JsonToken.EndArray);

            return GeographyPoint.Create(latitude, longitude);
        }
    }
}
