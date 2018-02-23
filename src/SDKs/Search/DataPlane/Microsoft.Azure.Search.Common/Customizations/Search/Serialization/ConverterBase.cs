// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for custom JsonConverters.
    /// </summary>
    public abstract class ConverterBase : JsonConverter
    {
        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type. Optionally asserts
        /// that the value of the token matches a given expected value. If any of the assertions fail, this method
        /// throws a JsonSerializationException. Otherwise, this method attempts to advance the JSON reader to the
        /// next position.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValue">Optional; The expected value of the current JSON token.</param>
        protected void ExpectAndAdvance(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            ExpectAndAdvance<object>(reader, expectedToken, expectedValue);
        }

        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type and retrieves the value
        /// of the token, if any. Optionally asserts that the value of the token matches a given expected value. If
        /// any of the assertions fail, this method throws a JsonSerializationException. Otherwise, this method
        /// attempts to advance the JSON reader to the next position.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the value of the current JSON token.</typeparam>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValue">Optional; The expected value of the current JSON token.</param>
        /// <returns>
        /// The value of the JSON token before advancing the reader, or default(TValue) if the token has no value.
        /// </returns>
        protected TValue ExpectAndAdvance<TValue>(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            TValue result = Expect<TValue>(reader, expectedToken, expectedValue);
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
        /// <param name="expectedValue">Optional; The expected value of the current JSON token.</param>
        protected void Expect(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            Expect<object>(reader, expectedToken, expectedValue);
        }

        /// <summary>
        /// Asserts that the given JSON reader is positioned on a token with the expected type and retrieves the value
        /// of the token, if any. Optionally asserts that the value of the token matches a given expected value. If
        /// any of the assertions fail, this method throws a JsonSerializationException.
        /// </summary>
        /// <typeparam name="TValue">The expected type of the value of the current JSON token.</typeparam>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="expectedToken">The JSON token on which the reader is expected to be positioned.</param>
        /// <param name="expectedValue">Optional; The expected value of the current JSON token.</param>
        /// <returns>
        /// The value of the current JSON token, or default(TValue) if the current token has no value.
        /// </returns>
        protected TValue Expect<TValue>(JsonReader reader, JsonToken expectedToken, object expectedValue = null)
        {
            if (reader.TokenType != expectedToken)
            {
                throw new JsonSerializationException(
                    String.Format("Deserialization failed. Expected token: '{0}'", expectedToken));
            }

            if (expectedValue != null && (reader.Value == null || !reader.Value.Equals(expectedValue)))
            {
                string message =
                    String.Format(
                        "Deserialization failed. Expected value: '{0}'. Actual: '{1}'",
                        expectedValue,
                        reader.Value);

                throw new JsonSerializationException(message);
            }

            TValue result = default(TValue);

            if (reader.Value != null)
            {
                if (!typeof(TValue).GetTypeInfo().IsAssignableFrom(reader.ValueType.GetTypeInfo()))
                {
                    string message =
                        String.Format(
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
        protected void Advance(JsonReader reader)
        {
            if (!reader.Read())
            {
                throw new JsonSerializationException("Deserialization failed. Unexpected end of input.");
            }
        }
    }
}
