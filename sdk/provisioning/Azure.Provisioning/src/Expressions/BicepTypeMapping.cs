// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Xml;
using Azure.Core;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Collect the primary logic for mapping .NET types to Bicep types in one place.
/// </summary>
internal static class BicepTypeMapping
{
    /// <summary>
    /// Map standard Azure types into Bicep primitive type names like bool,
    /// int, string, object, or array.  More complex types are not supported.
    /// </summary>
    /// <param name="type">A .NET type.</param>
    /// <returns>A corresponding Bicep type name or null.</returns>
    public static string? GetBicepTypeName(Type type) =>
        type == typeof(bool) ? "bool" :
        type == typeof(int) ? "int" :
        type == typeof(long) ? "int" :
        type == typeof(string) ? "string" :
        type == typeof(object) ? "object" :
        type == typeof(Uri) ? "string" :
        type == typeof(DateTimeOffset) ? "string" :
        type == typeof(TimeSpan) ? "string" :
        type == typeof(Guid) ? "string" :
        type == typeof(IPAddress) ? "string" :
        type == typeof(ETag) ? "string" :
        type == typeof(ResourceIdentifier) ? "string" :
        type == typeof(ResourceType) ? "string" :
        type == typeof(AzureLocation) ? "string" :
        typeof(Enum).IsAssignableFrom(type) ? "string" :
        typeof(System.Collections.IDictionary).IsAssignableFrom(type) ? "object" :
        typeof(System.Collections.IEnumerable).IsAssignableFrom(type) ? "array" :
        null;

    /// <summary>
    /// Convert a .NET object into a literal Bicep string.
    /// </summary>
    /// <param name="value">The .NET value.</param>
    /// <param name="format">Optional format.</param>
    /// <returns>The corresponding Bicep literal string.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when we cannot convert a value to a literal Bicep string.
    /// </exception>
    public static string ToLiteralString(object value, string? format) =>
        value switch
        {
            bool b => b.ToString(),
            int i => i.ToString(),
            long i => i.ToString(),
            float f => f.ToString(CultureInfo.InvariantCulture),
            double d => d.ToString(CultureInfo.InvariantCulture),
            string s => s,
            Uri u => u.AbsoluteUri,
            DateTimeOffset d => d.ToString("o"),
            TimeSpan t when format == "P" => XmlConvert.ToString(t),
            TimeSpan t => t.ToString(),
            Guid g => g.ToString(),
            IPAddress a => a.ToString(),
            ETag e => e.ToString(),
            ResourceIdentifier i => i.ToString(),
            AzureLocation azureLocation => azureLocation.ToString(),
            ResourceType rt => rt.ToString(),
            Enum e => GetEnumValue(e),
            // Other extensible enums like AzureLocation (AzureLocation has been handled above)
            // TODO: Can we either tag or special case all that we care about because ValueType is too broad
            ValueType ee => ee.ToString()!,
            _ => throw new InvalidOperationException($"Cannot convert {value} to a literal Bicep string.")
        };

    /// <summary>
    /// Convert a <see cref="BinaryData"/> value into a Bicep expression.
    /// </summary>
    /// <param name="value">The <see cref="BinaryData"/> value.</param>
    /// <param name="format">An optional format that controls literal serialization.</param>
    /// <returns>The corresponding Bicep expression.</returns>
    public static BicepExpression ToBicep(BinaryData value, string? format)
    {
        if (format == "base64")
        {
            return BicepSyntax.Value(Convert.ToBase64String(value.ToArray()));
        }

        ReadOnlySpan<byte> json = value.ToMemory().Span;
        Utf8JsonReader reader = new(json);
        BicepExpression expression = ReadJsonValue(ref reader, json);
        if (reader.Read())
        {
            throw CreateJsonException($"Unexpected JSON token {reader.TokenType} after the top-level value.", json, reader.TokenStartIndex);
        }
        return expression;
    }

    private static BicepExpression ReadJsonValue(ref Utf8JsonReader reader, ReadOnlySpan<byte> json)
    {
        if (!reader.Read())
        {
            throw CreateJsonException("Expected a JSON value.", json, reader.BytesConsumed);
        }
        return ToBicep(ref reader, json);
    }

    private static BicepExpression ToBicep(ref Utf8JsonReader reader, ReadOnlySpan<byte> json) =>
        reader.TokenType switch
        {
            JsonTokenType.StartObject => new ObjectExpression(ReadObjectProperties(ref reader, json)),
            JsonTokenType.StartArray => BicepSyntax.Array(ReadArrayValues(ref reader, json)),
            JsonTokenType.String => BicepSyntax.Value(reader.GetString()!),
            JsonTokenType.Number => ToBicepNumber(ref reader),
            JsonTokenType.True => BicepSyntax.Value(true),
            JsonTokenType.False => BicepSyntax.Value(false),
            JsonTokenType.Null => BicepSyntax.Null(),
            _ => throw CreateJsonException($"Unexpected JSON token {reader.TokenType}.", json, reader.TokenStartIndex)
        };

    private static PropertyExpression[] ReadObjectProperties(ref Utf8JsonReader reader, ReadOnlySpan<byte> json)
    {
        List<PropertyExpression> properties = [];
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return [.. properties];
            }
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw CreateJsonException($"Expected JSON property name token but found {reader.TokenType}.", json, reader.TokenStartIndex);
            }

            string propertyName = reader.GetString()!;
            properties.Add(new PropertyExpression(propertyName, ReadJsonValue(ref reader, json)));
        }
        throw CreateJsonException("Expected end of JSON object.", json, reader.BytesConsumed);
    }

    private static BicepExpression[] ReadArrayValues(ref Utf8JsonReader reader, ReadOnlySpan<byte> json)
    {
        List<BicepExpression> values = [];
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return [.. values];
            }

            values.Add(ToBicep(ref reader, json));
        }
        throw CreateJsonException("Expected end of JSON array.", json, reader.BytesConsumed);
    }

    private static BicepExpression ToBicepNumber(ref Utf8JsonReader reader)
    {
        if (reader.TryGetInt32(out int intValue))
        {
            return BicepSyntax.Value(intValue);
        }
        if (reader.TryGetInt64(out long longValue))
        {
            return BicepSyntax.Value(longValue);
        }
        if (reader.TryGetDouble(out double doubleValue) &&
            !double.IsNaN(doubleValue) &&
            !double.IsInfinity(doubleValue))
        {
            return BicepSyntax.Value(doubleValue);
        }

        return BicepFunction.ParseJson(BicepSyntax.Value(GetRawTokenText(ref reader))).Compile();
    }

    private static string GetRawTokenText(ref Utf8JsonReader reader)
    {
        byte[] tokenBytes = reader.HasValueSequence ?
            reader.ValueSequence.ToArray() :
            reader.ValueSpan.ToArray();
        return Encoding.UTF8.GetString(tokenBytes);
    }

    private static JsonException CreateJsonException(string message, ReadOnlySpan<byte> json, long bytePosition)
    {
        (long lineNumber, long bytePositionInLine) = GetJsonPosition(json, bytePosition);
        return new JsonException($"{message} LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine} | BytePosition: {bytePosition}.");
    }

    private static (long LineNumber, long BytePositionInLine) GetJsonPosition(ReadOnlySpan<byte> json, long bytePosition)
    {
        long lineNumber = 0;
        long bytePositionInLine = 0;
        long end = Math.Min(bytePosition, json.Length);

        for (int i = 0; i < end; i++)
        {
            if (json[i] == (byte)'\n')
            {
                lineNumber++;
                bytePositionInLine = 0;
            }
            else
            {
                bytePositionInLine++;
            }
        }

        return (lineNumber, bytePositionInLine);
    }

    /// <summary>
    /// Get the value of an enum.  This is either the name of the enum value or
    /// optionally overridden by a DataMember attribute when the wire value
    /// is different from the .NET name.
    /// </summary>
    /// <param name="value">An enum value.</param>
    /// <returns>The enum value's string representation.</returns>
    private static string GetEnumValue(Enum value)
    {
        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            DataMemberAttribute? member = type.GetField(name)?.GetCustomAttribute<DataMemberAttribute>();
            return member?.Name ?? value.ToString();
        }
        return value.ToString();
    }
}
