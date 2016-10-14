// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Rest.Azure
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
            return typeof(IResource).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
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
                JObject resourceJObject = JObject.Load(reader);
                // Flatten resource
                JObject propertiesJObject = resourceJObject[PropertiesNode] as JObject;

                // Update type if there is a polymorphism
                var polymorphicDeserializer = serializer.Converters
                    .FirstOrDefault(c =>
                        c.GetType().GetTypeInfo().IsGenericType &&
                        c.GetType().GetGenericTypeDefinition() == typeof(PolymorphicDeserializeJsonConverter<>) &&
                        c.CanConvert(objectType)) as PolymorphicJsonConverter;
                if (polymorphicDeserializer != null)
                {
                    objectType = PolymorphicJsonConverter.GetDerivedType(objectType,
                        (string) resourceJObject[polymorphicDeserializer.Discriminator]) ?? objectType;
                }

                // Initialize appropriate type instance
                var resource = Activator.CreateInstance(objectType);

                // For each property in resource - populate property
                var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
                foreach (JsonProperty property in contract.Properties)
                {
                    JToken propertyValueToken = resourceJObject[property.PropertyName];
                    if (propertyValueToken == null &&
                        propertiesJObject != null &&
                        property.PropertyName.StartsWith("properties.", StringComparison.OrdinalIgnoreCase))
                    {
                        propertyValueToken = propertiesJObject[property.PropertyName.Substring("properties.".Length)];
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

            // If generic resource - serialize as-is
            if (value.GetType().GetTypeInfo().DeclaredProperties.Any(p => p.Name == "Properties" && p.PropertyType == typeof(object)))
            {
                GetSerializerWithoutCurrentConverter(serializer).Serialize(writer, value);
                return;
            }

            // Add discriminator field
            writer.WriteStartObject();
            
            // If there is polymorphism - add polymorphic property
            var polymorphicSerializer = serializer.Converters
                .FirstOrDefault(c =>
                    c.GetType().GetTypeInfo().IsGenericType && 
                    c.GetType().GetGenericTypeDefinition() == typeof(PolymorphicSerializeJsonConverter<>) &&
                    c.CanConvert(value.GetType())) as PolymorphicJsonConverter;

            if (polymorphicSerializer != null)
            {
                writer.WritePropertyName(polymorphicSerializer.Discriminator);
                string typeName = value.GetType().Name;
                if (value.GetType().GetTypeInfo().GetCustomAttributes<JsonObjectAttribute>().Any())
                {
                    typeName = value.GetType().GetTypeInfo().GetCustomAttribute<JsonObjectAttribute>().Id;
                }
                writer.WriteValue(typeName);
            }
                      
            // Go over each property that is in resource and write to stream
            JsonConverterHelper.SerializeProperties(writer, value, serializer, 
                p => !p.PropertyName.StartsWith("properties.", StringComparison.OrdinalIgnoreCase));

            // If there is a need to add properties element - add it
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            if (contract.Properties.Any(p =>
                p.PropertyName.StartsWith("properties.", StringComparison.OrdinalIgnoreCase) &&
                  (p.ValueProvider.GetValue(value) != null || 
                  serializer.NullValueHandling == NullValueHandling.Include)))
            {
                writer.WritePropertyName(PropertiesNode);
                writer.WriteStartObject();
                JsonConverterHelper.SerializeProperties(writer, value, serializer,
                    p => p.PropertyName.StartsWith("properties.", StringComparison.OrdinalIgnoreCase));
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Gets a JsonSerializer without current converter.
        /// </summary>
        /// <param name="serializer">JsonSerializer</param>
        /// <returns></returns>
        protected JsonSerializer GetSerializerWithoutCurrentConverter(JsonSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            JsonSerializer newSerializer = new JsonSerializer();
            var properties = typeof(JsonSerializer).GetTypeInfo().DeclaredProperties;
            foreach (var property in properties.Where(p => p.SetMethod != null && !p.SetMethod.IsPrivate))
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