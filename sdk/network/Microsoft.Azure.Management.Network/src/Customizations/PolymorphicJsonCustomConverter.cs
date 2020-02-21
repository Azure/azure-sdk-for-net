// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Reflection;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;

    public class PolymorphicJsonCustomConverter<T1, T2> : JsonConverter
        where T1 : class
        where T2 : class
    {
        private PolymorphicDeserializeJsonConverter<T1> firstDeserializeConverter;

        private PolymorphicDeserializeJsonConverter<T2> secondDeserializeConverter;

        private PolymorphicSerializeJsonConverter<T1> firstSerializeConverter;

        private PolymorphicSerializeJsonConverter<T2> secondSerializeConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicJsonCustomConverter{T1, T2}"/> class.
        /// </summary>
        /// <param name="firstDiscriminatorField">The field on which to choose first child type.</param>
        /// <param name="secondDiscriminatorField">The field on which to choose second child type.</param>
        public PolymorphicJsonCustomConverter(string firstDiscriminatorField, string secondDiscriminatorField)
        {
            this.firstSerializeConverter = new PolymorphicSerializeJsonConverter<T1>(firstDiscriminatorField);

            this.secondSerializeConverter = new PolymorphicSerializeJsonConverter<T2>(secondDiscriminatorField);

            this.firstDeserializeConverter = new PolymorphicDeserializeJsonConverter<T1>(firstDiscriminatorField);

            this.secondDeserializeConverter = new PolymorphicDeserializeJsonConverter<T2>(secondDiscriminatorField);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            if (typeof(T1).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
            {
                this.firstSerializeConverter.WriteJson(writer, value, serializer);
            }
            else
            {
                this.secondSerializeConverter.WriteJson(writer, value, serializer);
            }
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (typeof(T1).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
            {
                return this.firstDeserializeConverter.ReadJson(reader, objectType, existingValue, serializer);
            }

            if (typeof(T2).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
            {
                return this.secondDeserializeConverter.ReadJson(reader, objectType, existingValue, serializer);
            }

            return null;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            bool isFirstCanConvert = this.firstDeserializeConverter.CanConvert(objectType);
            bool isSecondCanConvert = this.secondDeserializeConverter.CanConvert(objectType);
            return isFirstCanConvert || isSecondCanConvert;
        }
    }
}