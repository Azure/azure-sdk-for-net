// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Serializes Microsoft.Spatial.GeographyPoint objects to Geo-JSON and vice-versa.
    /// </summary>
    internal class GeographyPointConverter : JsonConverter
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

        public override bool CanConvert(Type objectType) =>
            typeof(GeographyPoint).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public static bool IsGeoJson(JObject obj) =>
            obj?.IsValid(
                requiredProperties: TypeAndCoordinates,
                isPropertyValid: property =>
                {
                    switch (property.Name)
                    {
                        case Type:
                            return property.Value.IsString(Point);

                        case Coordinates:
                            return AreCoordinates(property.Value);

                        case Crs:
                            return property.Value is JObject possibleCrs && IsCrs(possibleCrs);

                        default:
                            return false;
                    }
                }) ?? false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var point = (GeographyPoint)value;
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

        private static bool IsCrs(JObject possibleCrs) =>
            possibleCrs.IsValid(
                requiredProperties: TypeAndProperties,
                isPropertyValid: property =>
                {
                    switch (property.Name)
                    {
                        case Type:
                            return property.Value.IsString(Name);

                        case Properties:
                            return property.Value is JObject possibleProperties && IsCrsProperties(possibleProperties);

                        default:
                            return false;
                    }
                });

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

        private static bool AreCoordinates(JToken possibleCoordinates) =>
            possibleCoordinates is JArray array && array.Count == 2 && array[0].IsNumber() && array[1].IsNumber();

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

            coordinatesReader.ExpectAndAdvance(JsonToken.EndArray);
            return GeographyPoint.Create(latitude, longitude);
        }
    }
}
