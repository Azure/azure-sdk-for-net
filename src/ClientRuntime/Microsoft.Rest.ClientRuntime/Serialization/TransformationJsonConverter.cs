// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that provides serialization for with optional object transformation.
    /// </summary>
    public class TransformationJsonConverter : JsonConverter
    {
        /// <summary>
        /// Returns true if the object being serialized contains JsonTransformationAttribute. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized contains JsonTransformationAttribute. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().GetCustomAttribute(typeof(JsonTransformationAttribute)) != null;
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

            try
            {
                JObject jsonObject = JObject.Load(reader);

                // Update type if there is a polymorphism
                var polymorphicDeserializer = serializer.Converters
                    .FirstOrDefault(c =>
                        c.GetType().GetTypeInfo().IsGenericType &&
                        c.GetType().GetGenericTypeDefinition() == typeof(PolymorphicDeserializeJsonConverter<>) &&
                        c.CanConvert(objectType)) as PolymorphicJsonConverter;
                if (polymorphicDeserializer != null)
                {
                    objectType = PolymorphicJsonConverter.GetDerivedType(objectType,
                        (string) jsonObject[polymorphicDeserializer.Discriminator]) ?? objectType;
                }

                // Initialize appropriate type instance
                var resource = Activator.CreateInstance(objectType);

                // For each property in resource - populate property
                var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
                foreach (JsonProperty property in contract.Properties)
                {
                    JToken propertyValueToken;
                    string[] parentPath;
                    string propertyName = property.GetPropertyName(out parentPath);

                    if (parentPath.Length > 0)
                    {
                        string jsonPath = string.Concat(parentPath.Select(p => $"['{p}']"));
                        propertyValueToken = jsonObject.SelectToken(jsonPath, false);
                        if (propertyValueToken != null)
                        {
                            propertyValueToken = propertyValueToken[propertyName];
                        }
                    }
                    else
                    {
                        propertyValueToken = jsonObject[propertyName];
                    }                  

                    if (propertyValueToken != null && property.Writable)
                    {
                        var propertyValue = propertyValueToken.ToObject(property.PropertyType, serializer);
                        property.ValueProvider.SetValue(resource, propertyValue);
                    }
                }
                return resource;
            }
            catch (JsonException)
            {
                return null;
            }
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

            JObject jsonObject = new JObject();

            // Add discriminator field
            var polymorphicSerializer = serializer.Converters
                .FirstOrDefault(c =>
                    c.GetType().GetTypeInfo().IsGenericType &&
                    c.GetType().GetGenericTypeDefinition() == typeof(PolymorphicSerializeJsonConverter<>) &&
                    c.CanConvert(value.GetType())) as PolymorphicJsonConverter;

            if (polymorphicSerializer != null)
            {
                string typeName = value.GetType().Name;
                if (value.GetType().GetTypeInfo().GetCustomAttributes<JsonObjectAttribute>().Any())
                {
                    typeName = value.GetType().GetTypeInfo().GetCustomAttribute<JsonObjectAttribute>().Id;
                }
                jsonObject.Add(polymorphicSerializer.Discriminator, typeName);
            }

            JsonObjectContract contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            foreach (JsonProperty property in contract.Properties)
            {
                object memberValue = property.ValueProvider.GetValue(value);

                // Skipping properties with null value if NullValueHandling is set to Ignore
                if (serializer.NullValueHandling == NullValueHandling.Ignore &&
                    memberValue == null)
                {
                    continue;
                }

                // Skipping properties with JsonIgnore attribute, non-readable, and 
                // ShouldSerialize returning false when set
                if (!property.Ignored && property.Readable &&
                    (property.ShouldSerialize == null || property.ShouldSerialize(memberValue)))
                {
                    string[] parentPath;
                    string propertyName = property.GetPropertyName(out parentPath);

                    // Build hierarchy if necessary
                    JObject parentObject = jsonObject;
                    for (int i = 0; i < parentPath.Length; i++)
                    {
                        JObject childToken = parentObject[parentPath[i]] as JObject;
                        if (childToken == null)
                        {
                            parentObject[parentPath[i]] = new JObject();
                        }
                        parentObject = parentObject[parentPath[i]] as JObject;
                    }

                    parentObject[propertyName] = JToken.FromObject(memberValue, serializer);
                }
            }

            jsonObject.WriteTo(writer, serializer.Converters.ToArray());
        }
    }
}