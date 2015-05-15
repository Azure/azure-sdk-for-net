// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that provides custom serialization for resource-based objects.
    /// </summary>
    public class ResourceJsonConverter : JsonConverter
    {
        private const string PropertiesNode = "properties";

        /// <summary>
        /// Returns true if the object being serialized is assignable from the Resource type. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is assignable from the base type. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Resource).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Deserializes an object from a JSON string and flattens out Properties.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (objectType == null)
            {
                throw new ArgumentNullException("objectType");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            JsonSerializer newSerializer = GetSerializerWithoutCurrentConverter(serializer);

            JObject resourceJObject = JObject.Load(reader);
            var resource = resourceJObject.ToObject(objectType, newSerializer);
            JObject propertiesJObject = resourceJObject[PropertiesNode] as JObject;
            if (propertiesJObject != null)
            {
                newSerializer.Populate(propertiesJObject.CreateReader(), resource);
            }
            
            return resource;
        }

        /// <summary>
        /// Serializes an object into a JSON string adding Properties. 
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

            JsonSerializer newSerializer = GetSerializerWithoutCurrentConverter(serializer);

            JObject rootObject = JObject.FromObject(value, newSerializer);
            JObject propertyObject = new JObject();
            rootObject.Add(PropertiesNode, propertyObject);

            PropertyInfo[] propertyInfos = value.GetType().GetProperties()
                .Where(p => typeof(Resource).GetProperty(p.Name) == null).ToArray();
            // Getting all properties that do NOT exist in the Resource object
            foreach (var propertyInfo in propertyInfos.Where(p => p.GetGetMethod() != null))
            {
                // Get property name via reflection or from JsonProperty attribute
                string propertyName = propertyInfo.Name;
                if (propertyInfo.GetCustomAttributes<JsonPropertyAttribute>().Any())
                {
                    propertyName = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
                }

                if (rootObject.Property(propertyName) != null)
                {
                    propertyObject.Add(rootObject.Property(propertyName));
                    rootObject.Property(propertyName).Remove();
                }
            }

            rootObject.WriteTo(writer);
        }

        /// <summary>
        /// Gets a JsonSerializer without current converter.
        /// </summary>
        /// <param name="serializer">JsonSerializer</param>
        /// <returns></returns>
        protected JsonSerializer GetSerializerWithoutCurrentConverter(JsonSerializer serializer)
        {
            JsonSerializer newSerializer = new JsonSerializer();
            PropertyInfo[] properties = typeof(JsonSerializer).GetProperties();
            foreach (var property in properties.Where(p => p.GetSetMethod() != null))
            {
                property.SetValue(newSerializer, property.GetValue(serializer, null), null);
            }
            foreach (var converter in serializer.Converters)
            {
                if (converter != this)
                {
                    newSerializer.Converters.Add(converter);
                }
            }
            return newSerializer;
        }
    }
}