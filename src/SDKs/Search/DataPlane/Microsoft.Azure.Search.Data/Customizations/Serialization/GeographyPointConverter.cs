// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Reflection;
using Microsoft.Spatial;
using Newtonsoft.Json;

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

        public override bool CanConvert(Type objectType) =>
            typeof(GeographyPoint).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            // Check for null first.
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            GeographyPoint result = null;

            void ReadCoordinatesProperty(JsonReader coordinatesReader)
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
                result = GeographyPoint.Create(latitude, longitude);
            }

            void ReadCrsProperty(JsonReader crsReader)
            {
                void ReadPropertiesProperty(JsonReader propertiesReader) =>
                    propertiesReader.ReadObjectAndAdvance(
                        requiredProperties: new[] { Name },
                        readProperty: (r, _) => r.ExpectAndAdvance(JsonToken.String, "EPSG:4326"));

                crsReader.ReadObjectAndAdvance(
                    requiredProperties: new[] { Type, Properties },
                    readProperty: (r, propertyName) =>
                    {
                        switch (propertyName)
                        {
                            case Type:
                                r.ExpectAndAdvance(JsonToken.String, Name);
                                break;

                            case Properties:
                                ReadPropertiesProperty(r);
                                break;
                        }
                    });
            }

            reader.ReadObject(
                requiredProperties: new[] { Type, Coordinates },
                optionalProperties: new[] { Crs },
                readProperty: (r, propertyName) =>
                {
                    switch (propertyName)
                    {
                        case Type:
                            r.ExpectAndAdvance(JsonToken.String, Point);
                            break;

                        case Coordinates:
                            ReadCoordinatesProperty(r);
                            break;

                        case Crs:
                            ReadCrsProperty(r);
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
    }
}
