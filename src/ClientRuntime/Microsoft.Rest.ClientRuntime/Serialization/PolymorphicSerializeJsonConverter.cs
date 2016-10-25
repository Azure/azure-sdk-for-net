// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that handles serialization for polymorphic objects
    /// based on discriminator field.
    /// </summary>
    /// <typeparam name="T">The base type.</typeparam>
    public class PolymorphicSerializeJsonConverter<T> : PolymorphicJsonConverter where T : class
    {
        /// <summary>
        /// Initializes an instance of the PolymorphicSerializeJsonConverter.
        /// </summary>
        /// <param name="discriminatorField">The JSON field used as a discriminator</param>
        public PolymorphicSerializeJsonConverter(string discriminatorField)
        {
            if (discriminatorField == null)
            {
                throw new ArgumentNullException("discriminatorField");
            }
            Discriminator = discriminatorField;
        }

        /// <summary>
        /// Returns true if the object being serialized is assignable from the base type. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is assignable from the base type. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <summary>
        /// Returns false.
        /// </summary>
        public override bool CanRead
        {
            get { return false; }
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

            string typeName = value.GetType().Name;
            if (value.GetType().GetTypeInfo().GetCustomAttributes<JsonObjectAttribute>().Any())
            {
                typeName = value.GetType().GetTypeInfo().GetCustomAttribute<JsonObjectAttribute>().Id;
            }

            // Add discriminator field
            writer.WriteStartObject();
            writer.WritePropertyName(Discriminator);
            writer.WriteValue(typeName);
            JsonConverterHelper.SerializeProperties(writer, value, serializer);
            writer.WriteEndObject();
        }
    }
}