// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml;
using Azure.ResourceManager.Insights.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Insights.Tests.Helpers
{
    public static class JsonExtensions
    {
        /// <summary>
        /// The JSON serialization settings
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new TimeSpanConverter(),
                new StringEnumConverter {CamelCaseText = false},
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal},
                new PolymorphicTypeConverter<RuleDataSource>(),
                new PolymorphicTypeConverter<RuleCondition>(),
                new PolymorphicTypeConverter<RuleAction>()
            },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        /// <summary>
        /// Serialize object to the JSON.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>JSON representation of object</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonExtensions.Settings);
        }

        /// <summary>
        /// Deserialize object from the JSON.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">JSON representation of object</param>
        /// <returns>Deserialized object</returns>
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonExtensions.Settings);
        }

        /// <summary>
        /// TimeSpanConverter based on ISO 8601 format
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
                serializer.Serialize(writer, XmlConvert.ToString((TimeSpan)value));
            }

            /// <summary>
            /// Reads the json.
            /// </summary>
            /// <param name="reader">The reader.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value.</param>
            /// <param name="serializer">The serializer.</param>
            /// <returns>Deserialized object</returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                {
                    return null;
                }

                string timeSpanString = serializer.Deserialize<string>(reader);
                TimeSpan timeSpan;
                if (TimeSpan.TryParse(timeSpanString, out timeSpan))
                {
                    return timeSpan;
                }

                return XmlConvert.ToTimeSpan(timeSpanString);
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
            }
        }

        public class PolymorphicTypeConverter<T> : CustomCreationConverter<T>
        {
            public const string ClientNamespace = "Microsoft.Azure.Management.Insights.Models";

            private readonly string[] namespaceMappings;

            /// <summary>
            /// Initializes a new instance of the PolymorphicTypeConverter class.
            /// </summary>
            /// <param name="namespaceMappings">The optional list of namespacing mappings that should convert to this type.</param>
            public PolymorphicTypeConverter(string[] namespaceMappings = null)
            {
                this.namespaceMappings = namespaceMappings ?? new[]{ ClientNamespace };
            }

            /// <summary>
            /// Convert the JSON to object.
            /// </summary>
            /// <param name="reader">Json reader.</param>
            /// <param name="objectType">Object type.</param>
            /// <param name="existingValue">Existing value.</param>
            /// <param name="serializer">Json serializer.</param>
            /// <returns>Created object.</returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Load JObject from stream
                JObject jsonObject = JObject.Load(reader);
                JToken type = jsonObject["odata.type"] ?? jsonObject["$type"];
                if (type != null)
                {
                    string incomingTypeString = this.GetTypeString(type);

                    // This assumes that the concrete classes are in the same assembly as the parent class (we can optimize this later by caching the possible types in the constructor
                    // If the type from the user is invalid, null object will be created which will be detected by the Create method
                    return base.ReadJson(jsonObject.CreateReader(), typeof(T).GetTypeInfo().Assembly.GetType(incomingTypeString), existingValue, serializer);
                }

                return null;
            }

            /// <summary>
            /// Create the object.
            /// </summary>
            /// <param name="objectType">The object type.</param>
            /// <returns>The created object.</returns>
            public override T Create(Type objectType)
            {
                // Check if the object extends T, if objectType is null, the call will return false
                if (typeof(T).IsAssignableFrom(objectType))
                {
                    return (T)Activator.CreateInstance(objectType);
                }

                return default(T);
            }

            private string GetTypeString(JToken type)
            {
                string typeString = type.Value<string>();

                if (this.namespaceMappings != null)
                {
                    foreach (string namespaceMapping in this.namespaceMappings)
                    {
                        if (typeString.StartsWith(namespaceMapping, StringComparison.OrdinalIgnoreCase))
                        {
                            // Use the namespace from typeof(T) and the class name from typeString
                            int lastIndex = typeString.LastIndexOf('.');
                            if (lastIndex >= 0)
                            {
                                typeString = typeof(T).Namespace + typeString.Substring(lastIndex);
                                break;
                            }
                        }
                    }
                }

                return typeString;
            }
        }
    }
}
