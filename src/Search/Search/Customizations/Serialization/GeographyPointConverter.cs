// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Serializes Microsoft.Spatial.GeographyPoint objects to Geo-JSON and vice-versa.
    /// </summary>
    internal class GeographyPointConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(GeographyPoint).IsAssignableFrom(objectType);
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
