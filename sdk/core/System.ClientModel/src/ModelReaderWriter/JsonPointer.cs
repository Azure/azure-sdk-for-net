// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
internal static partial class JsonPointer
{
    // TODO (pri 3): make sure JSON Pointer escaping works, e.g. "/a~/b"u8 finds property "a/b"

    public static ReadOnlySpan<byte> GetUtf8(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).ValueSpan;

    public static ReadOnlySpan<byte> GetUtf8(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).ValueSpan;

    public static ReadOnlySpan<byte> GetUtf8(this BinaryData json)
        => json.ToMemory().Span.GetUtf8();

    public static ReadOnlySpan<byte> GetUtf8(this ReadOnlySpan<byte> json)
    {
        Utf8JsonReader reader = new(json);
        bool success = reader.Read();
        return reader.ValueSpan;
    }

    public static string? GetString(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetString();

    public static string? GetString(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetString();

    public static string? GetString(this BinaryData json)
        => json.ToMemory().Span.GetString();

    public static string? GetString(this ReadOnlySpan<byte> json)
    {
        Utf8JsonReader reader = new(json);
        bool success = reader.Read();
        return reader.GetString();
    }

    public static int GetInt32(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetInt32();

    public static int? GetNullableInt32(this BinaryData json, ReadOnlySpan<byte> pointer)
    {
        var reader = json.Find(pointer);
        return reader.TokenType == JsonTokenType.Null ? default : reader.GetInt32();
    }

    public static int GetInt32(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetInt32();

    public static int? GetNullableInt32(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        var reader = json.Find(pointer);
        return reader.TokenType == JsonTokenType.Null ? default : reader.GetInt32();
    }

    public static int GetInt32(this BinaryData json)
        => json.ToMemory().Span.GetInt32();

    public static int GetInt32(this ReadOnlySpan<byte> json)
    {
        Utf8JsonReader reader = new(json);
        bool success = reader.Read();
        return reader.GetInt32();
    }

    public static double GetDouble(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetDouble();

    public static double GetDouble(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetDouble();

    public static double GetDouble(this BinaryData json)
        => json.ToMemory().Span.GetDouble();

    public static double GetDouble(this ReadOnlySpan<byte> json)
    {
        Utf8JsonReader reader = new(json);
        bool success = reader.Read();
        return reader.GetDouble();
    }

    public static bool GetBoolean(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetBoolean();

    public static bool GetBoolean(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
        => json.Find(pointer).GetBoolean();

    public static bool GetBoolean(this BinaryData json)
        => json.ToMemory().Span.GetBoolean();

    public static bool GetBoolean(this ReadOnlySpan<byte> json)
    {
        Utf8JsonReader reader = new(json);
        bool success = reader.Read();
        return reader.GetBoolean();
    }

    public static int GetArrayLength(ReadOnlyMemory<byte> memory, ReadOnlySpan<byte> pointer = default)
    {
        var reader = pointer.IsEmpty ? new Utf8JsonReader(memory.Span) : memory.Span.Find(pointer);

        if (pointer.IsEmpty)
        {
            bool success = reader.Read();
            Debug.Assert(success, "JSON must be valid UTF-8 and parseable as JSON");
        }

        if (reader.TokenType != JsonTokenType.StartArray)
            throw new InvalidOperationException("JSON value is not an array");

        int count = 0;
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                count++;
            }
        }
        return count;
    }

    public static string[]? GetStringArray(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.ToMemory().Span.GetStringArray(pointer);

    public static string[]? GetStringArray(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        var reader = json.Find(pointer);
        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<string>();

        var strings = new List<string>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                strings.Add(reader.GetString() ?? string.Empty);
            }
        }
        return strings.ToArray();
    }

    public static string[]? GetStringArray(this BinaryData json)
        => json.ToMemory().Span.GetStringArray();

    public static string[]? GetStringArray(this ReadOnlySpan<byte> json)
    {
        var reader = new Utf8JsonReader(json);
        bool success = reader.Read();
        Debug.Assert(success, "JSON must be valid UTF-8 and parseable as JSON");

        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<string>();

        var strings = new List<string>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                strings.Add(reader.GetString() ?? string.Empty);
            }
        }
        return strings.ToArray();
    }

    public static double[]? GetDoubleArray(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.ToMemory().Span.GetDoubleArray(pointer);

    public static double[]? GetDoubleArray(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        var reader = json.Find(pointer);
        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<double>();

        var doubles = new List<double>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                doubles.Add(reader.GetDouble());
            }
        }
        return doubles.ToArray();
    }

    public static double[]? GetDoubleArray(this BinaryData json)
        => json.ToMemory().Span.GetDoubleArray();

    public static double[]? GetDoubleArray(this ReadOnlySpan<byte> json)
    {
        var reader = new Utf8JsonReader(json);
        bool success = reader.Read();
        Debug.Assert(success, "JSON must be valid UTF-8 and parseable as JSON");

        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<double>();

        var doubles = new List<double>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                doubles.Add(reader.GetDouble());
            }
        }
        return doubles.ToArray();
    }

    public static int[]? GetInt32Array(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.ToMemory().Span.GetInt32Array(pointer);

    public static int[]? GetInt32Array(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        var reader = json.Find(pointer);
        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<int>();

        var ints = new List<int>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                ints.Add(reader.GetInt32());
            }
        }
        return ints.ToArray();
    }

    public static int[]? GetInt32Array(this BinaryData json)
        => json.ToMemory().Span.GetInt32Array();

    public static int[]? GetInt32Array(this ReadOnlySpan<byte> json)
    {
        var reader = new Utf8JsonReader(json);
        bool success = reader.Read();
        Debug.Assert(success, "JSON must be valid UTF-8 and parseable as JSON");

        if (reader.TokenType != JsonTokenType.StartArray)
            return Array.Empty<int>();

        var ints = new List<int>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                ints.Add(reader.GetInt32());
            }
        }
        return ints.ToArray();
    }

    public static Utf8JsonReader Find(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        if (json.Length == 0)
            throw new ArgumentException("JSON document cannot be empty", nameof(json));

        var reader = new Utf8JsonReader(json);
        bool success = reader.Read();
        Debug.Assert(success);

        if (pointer.Length == 0)
        { // return the whole document
            return reader;
        }

        return Find(reader, pointer);
    }

    public static Utf8JsonReader Find(this BinaryData json, ReadOnlySpan<byte> pointer)
        => json.ToMemory().Span.Find(pointer);

    public static Utf8JsonReader Find(Utf8JsonReader reader, ReadOnlySpan<byte> pointer)
    {
        if (pointer.Length == 0)
            return reader;
        if (pointer[0] != (byte)'/')
            throw new ArgumentException("JSON Pointer must start with '/'", nameof(pointer));
        if (pointer.IndexOf((byte)'~') != -1)
            throw new NotImplementedException("JSON Pointer escaping not implemented yet");

        pointer = pointer.Slice(1); // slice off the leading '/'
        int slashIndex = pointer.IndexOf((byte)'/');
        ReadOnlySpan<byte> nextPointerSegment = slashIndex == -1 ? pointer : pointer.Slice(0, slashIndex);
        ReadOnlySpan<byte> remainingPointer = slashIndex == -1 ? ReadOnlySpan<byte>.Empty : pointer.Slice(slashIndex);

        JsonTokenType jsonType = reader.TokenType;
        if (jsonType == JsonTokenType.StartObject)
        {
            reader = FindPropertyValue(reader, nextPointerSegment);
        }
        else if (jsonType == JsonTokenType.StartArray)
        {
            reader = FindArrayItem(reader, nextPointerSegment);
        }
        return Find(reader, remainingPointer);
    }

    public static Utf8JsonReader FindPropertyValue(Utf8JsonReader reader, ReadOnlySpan<byte> propertyName)
    {
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName && reader.ValueTextEquals(propertyName))
            {
                bool success = reader.Read();
                Debug.Assert(success);
                return reader;
            }
        }

#if NET6_0_OR_GREATER
        throw new KeyNotFoundException($"{Encoding.UTF8.GetString(propertyName)} not found in JSON document");
#else
        throw new KeyNotFoundException($"{Encoding.UTF8.GetString(propertyName.ToArray())} not found in JSON document");
#endif
    }

    public static Utf8JsonReader FindArrayItem(Utf8JsonReader reader, ReadOnlySpan<byte> pointer)
    {
        if (!Utf8Parser.TryParse(pointer, out int index, out _))
        {
#if NET6_0_OR_GREATER
            throw new ArgumentException($"Invalid JSON Pointer index: {Encoding.UTF8.GetString(pointer)}");
#else
            throw new ArgumentException($"Invalid JSON Pointer index: {Encoding.UTF8.GetString(pointer.ToArray())}");
#endif
        }

        int current = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                throw new IndexOutOfRangeException();
            }

            // We found an array element (could be an object, array, or primitive value)
            if (current == index)
            {
                return reader;
            }
            current++;

            // Skip the entire value to move to the next array element
            // This handles objects, arrays, and primitive values correctly
            reader.Skip();
        }
#if NET6_0_OR_GREATER
        throw new KeyNotFoundException($"{Encoding.UTF8.GetString(pointer)} not found in JSON document");
#else
        throw new KeyNotFoundException($"{Encoding.UTF8.GetString(pointer.ToArray())} not found in JSON document");
#endif
    }
}
