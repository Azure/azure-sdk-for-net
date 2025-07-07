// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> Available tool types for agents named tools. </summary>
    [JsonConverter(typeof(PersistentAgentsNamedToolChoiceTypeConverter))]
    public readonly partial struct PersistentAgentsNamedToolChoiceType
    {
    }

    /// <summary>
    /// Custom JSON converter for PersistentAgentsNamedToolChoiceType.
    /// </summary>
    internal class PersistentAgentsNamedToolChoiceTypeConverter : JsonConverter<PersistentAgentsNamedToolChoiceType>
    {
        /// <summary>
        /// Reads and converts the JSON to PersistentAgentsNamedToolChoiceType.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override PersistentAgentsNamedToolChoiceType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                throw new JsonException("Cannot convert null value to PersistentAgentsNamedToolChoiceType.");
            }

            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Cannot convert token type {reader.TokenType} to PersistentAgentsNamedToolChoiceType.");
            }

            string value = reader.GetString();
            return new PersistentAgentsNamedToolChoiceType(value);
        }

        /// <summary>
        /// Writes a PersistentAgentsNamedToolChoiceType as JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, PersistentAgentsNamedToolChoiceType value, JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStringValue(value.ToString());
        }
    }
}
