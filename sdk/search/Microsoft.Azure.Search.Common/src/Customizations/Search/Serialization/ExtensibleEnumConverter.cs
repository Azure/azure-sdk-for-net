// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Serializes and deserializes "extensible enums" to and from JSON. Extensible enums are like enumerations in
    /// that they have well-known values, but they are extensible with new values and the values are based on strings
    /// instead of integers.
    /// </summary>
    public class ExtensibleEnumConverter<T> : JsonConverter
    {
        private readonly Func<string, T> _enumValueFactory;

        /// <summary>
        /// Initializes a new instance of the ExtensibleEnumConverter class.
        /// </summary>
        public ExtensibleEnumConverter()
        {
            bool TakesSingleStringParameter(ConstructorInfo ctor)
            {
                ParameterInfo[] parameters = ctor.GetParameters();
                if (parameters.Length == 1)
                {
                    return parameters[0].ParameterType == typeof(string);
                }

                return false;
            }

            ConstructorInfo fromStringCtor = typeof(T).GetTypeInfo().DeclaredConstructors.FirstOrDefault(TakesSingleStringParameter);

            Throw.IfArgument(
                fromStringCtor == null, 
                typeof(T).Name,
                $"No constructor taking a string parameter could be found for type '{typeof(T)}'.");

            _enumValueFactory = str => (T)fromStringCtor.Invoke(new[] { str });
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

            return _enumValueFactory(reader.Expect<string>(JsonToken.String));
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
