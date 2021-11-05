// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Search.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Defines extension methods for various JSON.NET types that make it easier to implement a custom JsonConverter.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type. Optionally asserts
        /// that the value of the token matches a given expected value. If any of the assertions fail, this method
        /// throws a JsonSerializationException. Otherwise, this method attempts to advance the JSON reader to the
        /// next position.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValues">Optional; The expected possible values of the current JSON token.</param>
        public static void ExpectAndAdvance(
            this JsonReader reader, 
            JsonToken expectedToken, 
            params object[] expectedValues) => ExpectAndAdvance<object>(reader, expectedToken, expectedValues);

        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type and retrieves the
        /// value of the token, if any. Optionally asserts that the value of the token matches a given expected
        /// value. If any of the assertions fail, this method throws a JsonSerializationException. Otherwise, this
        /// method attempts to advance the JSON reader to the next position.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the value of the current JSON token.</typeparam>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValues">Optional; The expected possible values of the current JSON token.</param>
        /// <returns>
        /// The value of the JSON token before advancing the reader, or default(TValue) if the token has no value.
        /// </returns>
        public static TValue ExpectAndAdvance<TValue>(
            this JsonReader reader, 
            JsonToken expectedToken, 
            params object[] expectedValues)
        {
            TValue result = Expect<TValue>(reader, expectedToken, expectedValues);
            Advance(reader);
            return result;
        }

        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type. Optionally asserts
        /// that the value of the token matches a given expected value. If any of the assertions fail, this method
        /// throws a JsonSerializationException.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValues">Optional; The expected possible values of the current JSON token.</param>
        public static void Expect(this JsonReader reader, JsonToken expectedToken, params object[] expectedValues) =>
            Expect<object>(reader, expectedToken, expectedValues);

        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type and retrieves the
        /// value of the token, if any. Optionally asserts that the value of the token matches a given expected
        /// value. If any of the assertions fail, this method throws a JsonSerializationException.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the value of the current JSON token.</typeparam>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValues">Optional; The expected possible values of the current JSON token.</param>
        /// <returns>
        /// The value of the current JSON token, or default(TValue) if the current token has no value.
        /// </returns>
        public static TValue Expect<TValue>(
            this JsonReader reader, 
            JsonToken expectedToken, 
            params object[] expectedValues)
        {
            Throw.IfArgumentNull(reader, nameof(reader));

            if (reader.TokenType != expectedToken)
            {
                throw new JsonSerializationException(
                    string.Format("Deserialization failed. Expected token: '{0}'", expectedToken));
            }

            if (expectedValues != null && expectedValues.Length > 0 &&
                (reader.Value == null || !Array.Exists(expectedValues, v => reader.Value.Equals(v))))
            {
                string message =
                    string.Format(
                        "Deserialization failed. Expected value(s): '{0}'. Actual: '{1}'",
                        string.Join(", ", expectedValues),
                        reader.Value);

                throw new JsonSerializationException(message);
            }

            var result = default(TValue);

            if (reader.Value != null)
            {
                if (!typeof(TValue).GetTypeInfo().IsAssignableFrom(reader.ValueType.GetTypeInfo()))
                {
                    string message =
                        string.Format(
                            "Deserialization failed. Value '{0}' is not of expected type '{1}'.",
                            reader.Value,
                            typeof(TValue));

                    throw new JsonSerializationException(message);
                }

                result = (TValue)reader.Value;
            }

            return result;
        }

        /// <summary>
        /// Advances the given JSON reader, or throws a JsonSerializationException if it cannot be advanced.
        /// </summary>
        /// <param name="reader">The JSON reader to advance.</param>
        public static void Advance(this JsonReader reader)
        {
            Throw.IfArgumentNull(reader, nameof(reader));

            if (!reader.Read())
            {
                throw new JsonSerializationException("Deserialization failed. Unexpected end of input.");
            }
        }

        /// <summary>
        /// Reads the properties of JSON objects, enforcing the presence of required properties and ignoring the order of properties.
        /// </summary>
        /// <param name="reader">The JSON reader to use to read an object.</param>
        /// <param name="requiredProperties">
        /// The names of all JSON properties that are expected to be present in the parsed object.
        /// </param>
        /// <param name="readProperty">
        /// A callback that reads a property value with the given name from the given <see cref="JsonReader" />. It must
        /// advance the reader to the name of the next property, or the end of the object if there are no more properties to read.
        /// </param>
        /// <remarks>
        /// This method will leave the reader positioned on the end of the object.
        /// </remarks>
        public static void ReadObject(
            this JsonReader reader, 
            IEnumerable<string> requiredProperties, 
            Action<JsonReader, string> readProperty) =>
            reader.ReadObject(requiredProperties, Enumerable.Empty<string>(), readProperty);

        /// <summary>
        /// Reads the properties of JSON objects, enforcing the presence of required properties and ignoring the order of properties,
        /// and then advances the given reader to the next token after the end of the object.
        /// </summary>
        /// <param name="reader">The JSON reader to use to read an object.</param>
        /// <param name="requiredProperties">
        /// The names of all JSON properties that are expected to be present in the parsed object.
        /// </param>
        /// <param name="readProperty">
        /// A callback that reads a property value with the given name from the given <see cref="JsonReader" />. It must
        /// advance the reader to the name of the next property, or the end of the object if there are no more properties to read.
        /// </param>
        /// <remarks>
        /// This method will advance the reader to the next position after the end of the object.
        /// </remarks>
        public static void ReadObjectAndAdvance(
            this JsonReader reader, 
            IEnumerable<string> requiredProperties, 
            Action<JsonReader, string> readProperty)
        {
            reader.ReadObject(requiredProperties, readProperty);
            reader.Advance();
        }

        /// <summary>
        /// Reads the properties of JSON objects, enforcing the presence of required properties and ignoring the order of properties.
        /// </summary>
        /// <param name="reader">The JSON reader to use to read an object.</param>
        /// <param name="requiredProperties">
        /// The names of all JSON properties that are expected to be present in the parsed object.
        /// </param>
        /// <param name="optionalProperties">
        /// The names of JSON properties besides the required properties that may be present in the parsed object.
        /// </param>
        /// <param name="readProperty">
        /// A callback that reads a property value with the given name from the given <see cref="JsonReader" />. It must
        /// advance the reader to the name of the next property, or the end of the object if there are no more properties to read.
        /// </param>
        /// <remarks>
        /// This method will leave the reader positioned on the end of the object.
        /// </remarks>
        public static void ReadObject(
            this JsonReader reader, 
            IEnumerable<string> requiredProperties,
            IEnumerable<string> optionalProperties,
            Action<JsonReader, string> readProperty)
        {
            Throw.IfArgumentNull(requiredProperties, nameof(requiredProperties));
            Throw.IfArgumentNull(optionalProperties, nameof(optionalProperties));
            Throw.IfArgumentNull(readProperty, nameof(readProperty));

            // ExpectAndAdvance validates that reader is not null.
            reader.ExpectAndAdvance(JsonToken.StartObject);

            string[] allPropertyNames = requiredProperties.Concat(optionalProperties).ToArray();
            var processedProperties = new HashSet<string>();

            while (reader.TokenType != JsonToken.EndObject)
            {
                string propertyName = reader.ExpectAndAdvance<string>(JsonToken.PropertyName, allPropertyNames);
                readProperty(reader, propertyName);
                processedProperties.Add(propertyName);
            }

            foreach (var propertyName in requiredProperties)
            {
                if (!processedProperties.Contains(propertyName))
                {
                    throw new JsonSerializationException(
                        string.Format("Deserialization failed. Could not find required '{0}' property.", propertyName));
                }
            }
        }

        /// <summary>
        /// Indicates whether or not the given JSON token matches the expected string.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <param name="expectedValue">The expected string value.</param>
        /// <returns><c>true</c> if the given JSON token matches the expected string, <c>false</c> otherwise.</returns>
        public static bool IsString(this JToken token, string expectedValue) =>
            token?.Type == JTokenType.String && token?.Value<string>() == expectedValue;

        /// <summary>
        /// Indicates whether or not the given JSON token is a numeric literal.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <returns><c>true</c> if the given JSON token represents a number, <c>false</c> otherwise.</returns>
        public static bool IsNumber(this JToken token) => token?.Type == JTokenType.Float || token?.Type == JTokenType.Integer;

        /// <summary>
        /// Validates the properties of the given JSON object, enforcing the presence of required properties and ignoring
        /// the order of properties.
        /// </summary>
        /// <param name="obj">The JSON object to validate.</param>
        /// <param name="requiredProperties">
        /// The names of all JSON properties that are expected to be present in the given object.
        /// </param>
        /// <param name="isPropertyValid">
        /// A predicate that determines whether the name and value of given <see cref="JProperty" /> are valid.
        /// </param>
        /// <returns>
        /// <c>true</c> if all properties of the given JSON object pass the given validation function and all required properties exist,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool IsValid(this JObject obj, IEnumerable<string> requiredProperties, Func<JProperty, bool> isPropertyValid)
        {
            Throw.IfArgumentNull(obj, nameof(obj));
            Throw.IfArgumentNull(requiredProperties, nameof(requiredProperties));
            Throw.IfArgumentNull(isPropertyValid, nameof(isPropertyValid));

            var processedProperties = new HashSet<string>();

            foreach (JProperty property in obj.Properties())
            {
                if (isPropertyValid(property))
                {
                    processedProperties.Add(property.Name);
                }
                else
                {
                    return false;
                }
            }

            return requiredProperties.All(p => processedProperties.Contains(p));
        }
    }
}
