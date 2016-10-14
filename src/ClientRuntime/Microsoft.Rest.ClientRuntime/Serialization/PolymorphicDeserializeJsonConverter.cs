// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that handles deserialization for polymorphic objects
    /// based on discriminator field.
    /// </summary>
    /// <typeparam name="T">The base type.</typeparam>
    public class PolymorphicDeserializeJsonConverter<T> : PolymorphicJsonConverter where T : class
    {
        /// <summary>
        /// Initializes an instance of the PolymorphicDeserializeJsonConverter.
        /// </summary>
        /// <param name="discriminatorField">The JSON field used as a discriminator</param>
        public PolymorphicDeserializeJsonConverter(string discriminatorField)
        {
            if (discriminatorField == null)
            {
                throw new ArgumentNullException("discriminatorField");
            }
            Discriminator = discriminatorField;
        }

        /// <summary>
        /// Returns false.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true if the object being deserialized is the base type. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being deserialized is the base type. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof (T) == objectType;
        }

        /// <summary>
        /// Reads a JSON field and deserializes into an appropriate object based on discriminator
        /// field and object name. If JsonObject attribute is available, its value is used instead.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject item = JObject.Load(reader);
                string typeDiscriminator = (string) item[Discriminator];
                Type derivedType = GetDerivedType(typeof (T), typeDiscriminator);
                if (derivedType != null)
                {
                    return item.ToObject(derivedType, serializer);
                }
                return item.ToObject(objectType);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Throws NotSupportedException.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}