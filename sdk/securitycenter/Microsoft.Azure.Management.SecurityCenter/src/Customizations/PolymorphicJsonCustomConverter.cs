// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Management.Security
{
    internal class PolymorphicJsonCustomConverter<T1, T2> : JsonConverter
        where T1 : class
        where T2 : class
    {
        private readonly PolymorphicDeserializeJsonConverter<T1> _firstDeserializeConverter;
        private readonly PolymorphicDeserializeJsonConverter<T2> _secondDeserializeConverter;
        private readonly PolymorphicSerializeJsonConverter<T1> _firstSerializeConverter;
        private readonly PolymorphicSerializeJsonConverter<T2> _secondSerializeConverter;
        private readonly string _secondDiscriminatorField;
        private readonly string _firstDiscriminatorField;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicJsonCustomConverter{T1, T2}"/> class.
        /// </summary>
        /// <param name="firstDiscriminatorField">The field on which to choose first child type.</param>
        /// <param name="secondDiscriminatorField">The field on which to choose second child type.</param>
        internal PolymorphicJsonCustomConverter(string firstDiscriminatorField, string secondDiscriminatorField)
        {
            _firstDiscriminatorField = firstDiscriminatorField;
            _secondDiscriminatorField = secondDiscriminatorField;
            _firstSerializeConverter = new PolymorphicSerializeJsonConverter<T1>(firstDiscriminatorField);
            _secondSerializeConverter = new PolymorphicSerializeJsonConverter<T2>(secondDiscriminatorField);
            _firstDeserializeConverter = new PolymorphicDeserializeJsonConverter<T1>(firstDiscriminatorField);
            _secondDeserializeConverter = new PolymorphicDeserializeJsonConverter<T2>(secondDiscriminatorField);
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
                _firstSerializeConverter.WriteJson(writer, value, serializer);
            }
            else
            {
                _secondSerializeConverter.WriteJson(writer, value, serializer);
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
            JObject item = JObject.Load(reader);
            string typeDiscriminator = (string)item[_firstDiscriminatorField];
            Type derivedType = GetDerivedType(typeof(T1), typeDiscriminator);

            if (derivedType != null && typeof(T1).GetTypeInfo().IsAssignableFrom(derivedType.GetTypeInfo()))
            {
                return _firstDeserializeConverter.ReadJson(new JTokenReader(item), objectType, existingValue, serializer);
            }

            typeDiscriminator = (string)item[_secondDiscriminatorField];
            derivedType = GetDerivedType(typeof(T2), typeDiscriminator);

            if (derivedType != null && typeof(T2).GetTypeInfo().IsAssignableFrom(derivedType.GetTypeInfo()))
            {
                return _secondDeserializeConverter.ReadJson(new JTokenReader(item), objectType, existingValue, serializer);
            }

            return null;
        }

        /// <summary>
        /// Returns type that matches specified name.
        /// </summary>
        /// <param name="baseType">Base type.</param>
        /// <param name="name">Derived type name</param>
        /// <returns></returns>
        internal static Type GetDerivedType(Type baseType, string name)
        {
            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }

            foreach (TypeInfo type in baseType.GetTypeInfo().Assembly.DefinedTypes
                .Where(t => t.Namespace == baseType.Namespace && t != baseType.GetTypeInfo()))
            {
                string typeName = type.Name;
                if (type.GetCustomAttributes<JsonObjectAttribute>().Any())
                {
                    typeName = type.GetCustomAttribute<JsonObjectAttribute>().Id;
                }

                if (typeName != null && typeName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return type.AsType();
                }
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
            bool isFirstCanConvert = _firstDeserializeConverter.CanConvert(objectType);
            bool isSecondCanConvert = _secondDeserializeConverter.CanConvert(objectType);
            return isFirstCanConvert || isSecondCanConvert;
        }
    }
}
