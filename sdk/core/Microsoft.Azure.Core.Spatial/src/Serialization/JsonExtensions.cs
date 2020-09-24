// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        /// <summary>
        /// Gets a <see cref="StringComparison"/> given the optional <see cref="JsonSerializerOptions"/>.
        /// The default is <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/> to read <see cref="JsonSerializerOptions.PropertyNameCaseInsensitive"/>.</param>
        /// <returns>
        /// <see cref="StringComparison.OrdinalIgnoreCase"/> if <paramref name="options"/> is non-null and <see cref="JsonSerializerOptions.PropertyNameCaseInsensitive"/> is true;
        /// otherwise, <see cref="StringComparison.Ordinal"/>.</returns>
        public static StringComparison GetStringComparisonOrDefault(
            this JsonSerializerOptions options) =>
            options?.PropertyNameCaseInsensitive ?? false
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;
    }
}
