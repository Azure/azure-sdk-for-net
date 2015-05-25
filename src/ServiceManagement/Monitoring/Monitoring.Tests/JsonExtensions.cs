﻿//
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

namespace Monitoring.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Json extensions
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The JSON serialization settings
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> 
            { 
                new TimeSpanConverter(),
                new StringEnumConverter { CamelCaseText = false },
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };

        /// <summary>
        /// Serialize object to the JSON.
        /// </summary>
        /// <param name="obj">The object.</param>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonExtensions.Settings);
        }

        /// <summary>
        /// Deserialize object from the JSON.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">JSON representation of object</param>
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonExtensions.Settings);
        }

        /// <summary>
        /// Deserialize object from the JSON.
        /// </summary>
        /// <param name="json">JSON representation of object</param>
        /// <param name="type">The object type.</param>
        public static object FromJson(this string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, JsonExtensions.Settings);
        }

        /// <summary>
        /// The TimeSpan converter based on ISO 8601 format.
        /// </summary>
        private class TimeSpanConverter : JsonConverter
        {
            /// <summary>
            /// Writes the json.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <param name="value">The value.</param>
            /// <param name="serializer">The serializer.</param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, XmlConvert.ToString((TimeSpan) value));
            }

            /// <summary>
            /// Reads the json.
            /// </summary>
            /// <param name="reader">The reader.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value.</param>
            /// <param name="serializer">The serializer.</param>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                return reader.TokenType != JsonToken.Null
                    ? (object) XmlConvert.ToTimeSpan(serializer.Deserialize<string>(reader))
                    : null;
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof (TimeSpan) || objectType == typeof (TimeSpan?);
            }
        }
    }
}

