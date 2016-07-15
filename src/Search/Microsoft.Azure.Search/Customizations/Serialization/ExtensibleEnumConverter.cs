// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Delegate type for a factory method that creates or looks up an ExtensibleEnum instance from a given string.
    /// </summary>
    /// <typeparam name="T">The type of ExtensibleEnum returned.</typeparam>
    /// <param name="name">The enum value to look up or create.</param>
    /// <returns>An instance of type T.</returns>
    public delegate T ExtensibleEnumValueFactory<T>(string name) where T : ExtensibleEnum<T>;

    /// <summary>
    /// Serializes and deserializes "extensible enums" to and from JSON. Extensible enums are like enumerations in
    /// that they have well-known values, but they are extensible with new values and the values are based on strings
    /// instead of integers.
    /// </summary>
    public class ExtensibleEnumConverter<T> : ConverterBase where T : ExtensibleEnum<T>
    {
        private ExtensibleEnumValueFactory<T> _enumValueFactory;

        /// <summary>
        /// Initializes a new instance of the ExtensibleEnumConverter class.
        /// </summary>
        public ExtensibleEnumConverter() : this("Create") { }

        /// <summary>
        /// Initializes a new instance of the ExtensibleEnumConverter class.
        /// </summary>
        /// <param name="factoryMethodName">
        /// The name of a public static method that creates an instance of type T given a string value; Default is
        /// "Create".
        /// </param>
        public ExtensibleEnumConverter(string factoryMethodName)
        {
            Throw.IfArgumentNull(factoryMethodName, "factoryMethodName");

            MethodInfo method = typeof(T).GetTypeInfo().GetDeclaredMethod(factoryMethodName);

            const string MessageFormat =
                "No method named '{0}' could be found that is convertible to ExtensibleEnumValueFactory<{1}>.";

            Throw.IfArgument(
                method == null, 
                "factoryMethodName", 
                String.Format(MessageFormat, factoryMethodName, typeof(T).Name));

            _enumValueFactory = 
                (ExtensibleEnumValueFactory<T>)method.CreateDelegate(typeof(ExtensibleEnumValueFactory<T>));
        }

        /// <summary>
        /// Indicates whether this converter can serialize or deserialize objects of the given type.
        /// </summary>
        /// <param name="objectType">The type to test against.</param>
        /// <returns>true if objectType derives from ExtensibleEnum, false otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <summary>
        /// Deserializes a string into an ExtensibleEnum.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">Ignored by this method.</param>
        /// <param name="existingValue">Ignored by this method.</param>
        /// <param name="serializer">Ignored by this method.</param>
        /// <returns>An instance of type T, or null if the current JSON token is null.</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            // Check for null first.
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            return _enumValueFactory(Expect<string>(reader, JsonToken.String));
        }

        /// <summary>
        /// Serializes an ExtensibleEnum to a JSON string.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">Ignored by this method.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
