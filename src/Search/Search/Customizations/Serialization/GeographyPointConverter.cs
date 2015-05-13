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
    internal class GeographyPointConverter : JsonConverter
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

            Expect(reader, JsonToken.PropertyName, "type");
            Expect(reader, JsonToken.String, "Point");
            Expect(reader, JsonToken.PropertyName, "coordinates");
            Expect(reader, JsonToken.StartArray);
            double longitude = Expect<double>(reader, JsonToken.Float);
            double latitude = Expect<double>(reader, JsonToken.Float);
            Expect(reader, JsonToken.EndArray);

            Advance(reader);

            if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("crs"))
            {
                Expect(reader, JsonToken.StartObject);
                Expect(reader, JsonToken.PropertyName, "type");
                Expect(reader, JsonToken.String, "name");
                Expect(reader, JsonToken.PropertyName, "properties");
                Expect(reader, JsonToken.StartObject);
                Expect(reader, JsonToken.PropertyName, "name");
                Expect(reader, JsonToken.String, "EPSG:4326");
                Expect(reader, JsonToken.EndObject);
                Expect(reader, JsonToken.EndObject);
                Advance(reader);
            }
            
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

        private void Expect(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            Expect<object>(reader, expectedToken, expectedValue);
        }

        private TValue Expect<TValue>(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            Advance(reader);
            if (reader.TokenType != expectedToken)
            {
                throw new JsonSerializationException(
                    String.Format("Deserialization failed. Expected token: '{0}'", expectedToken));
            }

            if (expectedValue != null && !reader.Value.Equals(expectedValue))
            {
                string message =
                    String.Format(
                        "Deserialization failed. Expected value: '{0}'. Actual: '{1}'",
                        expectedValue,
                        reader.Value);

                throw new JsonSerializationException(message);
            }

            if (reader.Value != null)
            {
                if (!typeof(TValue).IsAssignableFrom(reader.ValueType))
                {
                    string message =
                        String.Format(
                            "Deserialization failed. Value '{0}' is not of expected type '{1}'.",
                            reader.Value,
                            typeof(TValue));

                    throw new JsonSerializationException(message);
                }

                return (TValue)reader.Value;
            }

            return default(TValue);
        }

        private void Advance(JsonReader reader)
        {
            if (!reader.Read())
            {
                throw new JsonSerializationException("Deserialization failed. Unexpected end of input.");
            }
        }
    }
}
