// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Microsoft.Spatial;
    using Newtonsoft.Json;

    /// <summary>
    /// Serializes Microsoft.Spatial.GeographyPoint objects to Geo-JSON and vice-versa.
    /// </summary>
    internal class GeographyPointConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(GeographyPoint).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

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

            ExpectAndAdvance(reader, JsonToken.StartObject);
            ExpectAndAdvance(reader, JsonToken.PropertyName, "type");
            ExpectAndAdvance(reader, JsonToken.String, "Point");
            ExpectAndAdvance(reader, JsonToken.PropertyName, "coordinates");
            ExpectAndAdvance(reader, JsonToken.StartArray);
            double longitude = ExpectAndAdvance<double>(reader, JsonToken.Float);
            double latitude = ExpectAndAdvance<double>(reader, JsonToken.Float);
            ExpectAndAdvance(reader, JsonToken.EndArray);

            if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("crs"))
            {
                Advance(reader);
                ExpectAndAdvance(reader, JsonToken.StartObject);
                ExpectAndAdvance(reader, JsonToken.PropertyName, "type");
                ExpectAndAdvance(reader, JsonToken.String, "name");
                ExpectAndAdvance(reader, JsonToken.PropertyName, "properties");
                ExpectAndAdvance(reader, JsonToken.StartObject);
                ExpectAndAdvance(reader, JsonToken.PropertyName, "name");
                ExpectAndAdvance(reader, JsonToken.String, "EPSG:4326");
                ExpectAndAdvance(reader, JsonToken.EndObject);
                ExpectAndAdvance(reader, JsonToken.EndObject);
            }

            Expect(reader, JsonToken.EndObject);
            return GeographyPoint.Create(latitude, longitude);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var point = (GeographyPoint)value;
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue("Point");
            writer.WritePropertyName("coordinates");
            writer.WriteStartArray();
            writer.WriteValue(point.Longitude);
            writer.WriteValue(point.Latitude);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
