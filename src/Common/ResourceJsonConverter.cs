// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that provides custom serialization for resource-based objects.
    /// </summary>
    /// <typeparam name="T">The base type.</typeparam>
    public class ResourceJsonConverter : JsonConverter
    {
        /// <summary>
        /// Returns true if the object being serialized is assignable from the base type. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is assignable from the base type. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Resource).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Throws NotSupportedException.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Serializes an object into a JSON string based on discriminator
        /// field and object name. If JsonObject attribute is available, its value is used instead.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            // Getting contract to determine property bindings
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());

            PropertyInfo[] properties = value.GetType().GetProperties();
            // Getting all properties with public get method
            foreach (var propertyInfo in properties.Where(p => p.GetGetMethod() != null))
            {
                // Get property name via reflection or from JsonProperty attribute
                string propertyName = propertyInfo.Name;
                if (propertyInfo.GetCustomAttributes<JsonPropertyAttribute>().Any())
                {
                    propertyName = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
                }

                // Skipping properties with null value if NullValueHandling is set to Ignore
                if (serializer.NullValueHandling == NullValueHandling.Ignore &&
                    propertyInfo.GetValue(value, null) == null)
                {
                    continue;
                }

                // Skipping properties with JsonIgnore attribute, non-readable, and 
                // ShouldSerialize returning false when set
                if (!contract.Properties[propertyName].Ignored &&
                    contract.Properties[propertyName].Readable &&
                    (contract.Properties[propertyName].ShouldSerialize == null ||
                    contract.Properties[propertyName].ShouldSerialize(propertyInfo.GetValue(value, null))))
                {
                    writer.WritePropertyName(propertyName);
                    serializer.Serialize(
                        writer,
                        propertyInfo.GetValue(value, null));
                }
            }
            writer.WriteEndObject();
        }
    }
#if !NET45
    public static class AttributeExtensions
    {
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo memberInfo) where T : class
        {
            if (memberInfo == null)
            {
                return Enumerable.Empty<T>();
            }
            return memberInfo.GetCustomAttributes(typeof(T), true).Select(a => a as T);
        }

        public static T GetCustomAttribute<T>(this MemberInfo memberInfo) where T : class
        {
            if (memberInfo == null)
            {
                return null;
            }
            return memberInfo.GetCustomAttributes(typeof(T), true).First() as T;
        }
    }
#endif
}