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
    internal class GeographyPointConverter : JsonConverter
    {
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

            reader.ExpectAndAdvance(JsonToken.StartObject);
            reader.ExpectAndAdvance(JsonToken.PropertyName, "type");
            reader.ExpectAndAdvance(JsonToken.String, "Point");
            reader.ExpectAndAdvance(JsonToken.PropertyName, "coordinates");
            reader.ExpectAndAdvance(JsonToken.StartArray);
            double longitude = reader.ExpectAndAdvance<double>(JsonToken.Float);
            double latitude = reader.ExpectAndAdvance<double>(JsonToken.Float);
            reader.ExpectAndAdvance(JsonToken.EndArray);

            if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("crs"))
            {
                reader.Advance();
                reader.ExpectAndAdvance(JsonToken.StartObject);
                reader.ExpectAndAdvance(JsonToken.PropertyName, "type");
                reader.ExpectAndAdvance(JsonToken.String, "name");
                reader.ExpectAndAdvance(JsonToken.PropertyName, "properties");
                reader.ExpectAndAdvance(JsonToken.StartObject);
                reader.ExpectAndAdvance(JsonToken.PropertyName, "name");
                reader.ExpectAndAdvance(JsonToken.String, "EPSG:4326");
                reader.ExpectAndAdvance(JsonToken.EndObject);
                reader.ExpectAndAdvance(JsonToken.EndObject);
            }

            reader.Expect(JsonToken.EndObject);
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
