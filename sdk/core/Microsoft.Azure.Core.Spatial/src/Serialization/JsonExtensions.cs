// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Extension methods for System.Text.Json.
    /// </summary>
    internal static class JsonExtensions
    {
        /// <summary>
        /// Asserts that the current token of the <see cref="Utf8JsonReader"/> matches the <paramref name="expectedTokenType"/>.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to assert.</param>
        /// <param name="expectedTokenType">The expected <see cref="JsonTokenType"/> of the current token.</param>
        /// <exception cref="JsonException">The current token did not match the <paramref name="expectedTokenType"/>.</exception>
        public static void Expect(
            in this Utf8JsonReader reader,
            JsonTokenType expectedTokenType)
        {
            if (reader.TokenType != expectedTokenType)
            {
                throw new JsonException($"Deserialization failed. Expected token: '{expectedTokenType}'.");
            }
        }
    }
}
