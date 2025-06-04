// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Converter for TimeSpans to/from integer millisecond values in JSON.
/// </summary>
public class TimespanToMillisecondConverter : JsonConverter<TimeSpan?>
{
    /// <summary>
    /// Reads a <see cref="TimeSpan"/> value from JSON.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">The type of the object to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The deserialized <see cref="TimeSpan?"/> value.</returns>
    public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;

            case JsonTokenType.Number:
                return TimeSpan.FromMilliseconds(reader.GetInt32());

            case JsonTokenType.String:
                string? strValue = reader.GetString();
                if (int.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out int milliseconds))
                {
                    return TimeSpan.FromMilliseconds(milliseconds);
                }
                else
                {
                    throw new JsonException("Invalid millisecond value: " + strValue);
                }

            default:
                throw new JsonException($"Don't know how to parse '{reader.TokenType}' as a millisecond value");
        }
    }

    /// <summary>
    /// Writes a <see cref="TimeSpan"/> value to JSON.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The <see cref="TimeSpan"/> value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteNumberValue((int)Math.Ceiling(value.Value.TotalMilliseconds));
        }
    }
}
