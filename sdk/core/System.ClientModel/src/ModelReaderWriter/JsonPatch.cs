// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Internal;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
[Experimental("SCM0001")]
public partial struct JsonPatch
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate bool PropagatorSetter(ReadOnlySpan<byte> jsonPath, EncodedValue value);

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate bool PropagatorGetter(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value);

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate bool PropagatorIsFlattened(ReadOnlySpan<byte> jsonPath);

    /// <summary>
    /// .
    /// </summary>
    /// <param name="rawJson"></param>
    public JsonPatch(ReadOnlyMemory<byte> rawJson)
    {
        _rawJson = new(ValueKind.Json, rawJson);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="setter"></param>
    /// <param name="getter"></param>
    /// <param name="isFlattened"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPropagators(PropagatorSetter setter, PropagatorGetter getter, PropagatorIsFlattened isFlattened)
    {
        _propagatorSetter = setter;
        _propagatorGetter = getter;
        _propagatorIsFlattened = isFlattened;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
            return false;

        // if someone called Append on an array, we don't want to consider that as "contains" for the array path
        // since the entire array wasn't set it was just one item appended to it.
        return _properties.TryGetValue(jsonPath, out var value) && !value.Kind.HasFlag(ValueKind.ArrayItemAppend);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, string value)
    {
        SetInternal(jsonPath, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="utf8Json"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, byte[] utf8Json)
    {
        SetInternal(jsonPath, EncodeValue(utf8Json));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="utf8Json"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, BinaryData utf8Json)
    {
        SetInternal(jsonPath, EncodeValue(utf8Json));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Set<T>(ReadOnlySpan<byte> jsonPath, IJsonModel<T> value)
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        SetInternal(jsonPath, EncodeValue(reader.ToBinaryData()));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, int value)
    {
        // Int32
        SetInternal(jsonPath, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="utf8Json"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> utf8Json)
    {
        SetInternal(jsonPath, EncodeValue(utf8Json));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, bool value)
    {
        SetInternal(jsonPath, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Set(ReadOnlySpan<byte> jsonPath, EncodedValue value)
    {
        SetInternal(jsonPath, value);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    [RequiresUnreferencedCode("RequiresUnreferencedCode")]
    [RequiresDynamicCode("RequiresDynamicCode")]
    public void Set(ReadOnlySpan<byte> jsonPath, object value)
    {
        if (IsAnonymousType(value))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            SetInternal(jsonPath, EncodeValue(JsonSerializer.SerializeToUtf8Bytes(value, options)));
        }
        else
        {
            SetInternal(jsonPath, EncodeValue(value));
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    public void SetNull(ReadOnlySpan<byte> jsonPath)
    {
        SetInternal(jsonPath, s_nullValueArray);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public string? GetString(ReadOnlySpan<byte> jsonPath)
    {
        var bytes = GetValue(jsonPath);
        if (bytes.Span.SequenceEqual(s_nullValueArray.Value.Span))
            return null;

        var span = bytes.Span;
        if (span[0] == (byte)'"' && span[span.Length - 1] == (byte)'"')
            span = span.Slice(1, span.Length - 2);

#if NET6_0_OR_GREATER
        return Encoding.UTF8.GetString(span);
#else
        return Encoding.UTF8.GetString([.. span]);
#endif
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public int? GetNullableInt32(ReadOnlySpan<byte> jsonPath)
    {
        var bytes = GetValue(jsonPath);
        if (bytes.Span.SequenceEqual(s_nullValueArray.Value.Span))
            return null;

        if (Utf8Parser.TryParse(bytes.Span, out int value, out _))
        {
            return value;
        }
        else
        {
            throw new FormatException("Value was not an int?");
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public int GetInt32(ReadOnlySpan<byte> jsonPath)
    {
        var bytes = GetValue(jsonPath);

        if (Utf8Parser.TryParse(bytes.Span, out int value, out _))
        {
            return value;
        }
        else
        {
            throw new FormatException("Value was not an int");
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool GetBoolean(ReadOnlySpan<byte> jsonPath)
    {
        var bytes = GetValue(jsonPath);

        if (Utf8Parser.TryParse(bytes.Span, out bool value, out _))
        {
            return value;
        }
        else
        {
            throw new FormatException("Value was not an bool");
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public BinaryData GetJson(ReadOnlySpan<byte> jsonPath)
    {
        return new(GetValue(jsonPath));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TryGetJson(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value)
    {
        return TryGetValue(jsonPath, out value);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    public void Remove(ReadOnlySpan<byte> jsonPath)
    {
        // Special (remove, set null, etc)
        SetInternal(jsonPath, s_removedValueArray);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="prefix"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Write(Utf8JsonWriter writer, ReadOnlySpan<byte> prefix)
    {
        if (_properties == null)
            return;

        Span<byte> normalizedPrefix = stackalloc byte[prefix.Length];
        JsonPathComparer.Default.Normalize(prefix, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

        foreach (var kvp in _properties)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                continue;

            ReadOnlySpan<byte> keySpan = kvp.Key;
            if (!keySpan.StartsWith(normalizedPrefix))
                continue;

            keySpan = keySpan.Slice(normalizedPrefix.Length);

            WriteEncodedValueAsJson(writer, keySpan.GetPropertyNameFromSlice(), kvp.Value);
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="array"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void WriteArray(Utf8JsonWriter writer, ReadOnlySpan<byte> array)
    {
        if (_properties == null)
            return;

        if (!_properties.TryGetValue(array, out var value))
            return;

        if (value.Kind == ValueKind.Removed)
            return;

        value.Kind |= ValueKind.Written;
        _properties.Set(array, value);
        writer.WriteRawValue(value.Value.Span.Slice(1, value.Value.Length - 2));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="writer"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Write(Utf8JsonWriter writer)
    {
        bool isWriterEmpty = writer.CurrentDepth == 0 && writer.BytesCommitted == 0 && writer.BytesPending == 0;
        bool isSeeded = !_rawJson.Value.IsEmpty;

        SpanHashSet? arrays = null;

        if (!isSeeded && _properties is null && isWriterEmpty)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
            return;
        }

        if (_properties is null && !isWriterEmpty)
        {
            return;
        }

        // write patches
        if (_properties is not null && (isSeeded ? !isWriterEmpty : true))
        {
            bool writingRoot = !isSeeded && isWriterEmpty && !_properties.TryGetValue("$"u8, out var encodedValue) && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend);
            if (writingRoot)
            {
                writer.WriteStartObject();
            }

            foreach (var kvp in _properties)
            {
                if (_propagatorIsFlattened is not null && _propagatorIsFlattened(kvp.Key))
                    continue;

                if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                {
                    continue;
                }

                if (kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    var firstNonArray = kvp.Key.GetFirstNonIndexParent();
                    if (arrays?.Contains(firstNonArray) == true)
                    {
                        continue;
                    }

                    if (!kvp.Key.IsRoot() && !kvp.Key.IsArrayIndex())
                    {
                        writer.WritePropertyName(kvp.Key.GetPropertyName());
                    }
                    _properties.TryGetValue(firstNonArray, out var existingArrayValue);
                    var rawArray = GetCombinedArray(firstNonArray, existingArrayValue, true);
                    writer.WriteRawValue(rawArray.Span);
                    arrays ??= new();
                    arrays.Add(firstNonArray);
                    continue;
                }

                if (!kvp.Key.GetParent().IsRoot())
                {
                    JsonPathReader pathReader = new(kvp.Key);
                    ReadOnlySpan<byte> firstProperty = pathReader.GetFirstProperty();

                    writer.WritePropertyName(firstProperty.GetPropertyName());
                    writer.WriteStartObject();
                    Write(writer, firstProperty);
                    writer.WriteEndObject();
                    continue;
                }

                WriteEncodedValueAsJson(writer, kvp.Key.GetPropertyName(), kvp.Value);
            }

            if (writingRoot)
            {
                writer.WriteEndObject();
            }
            return;
        }

        Debug.Assert(isSeeded, "Raw JSON should not be empty at this point");
        Debug.Assert(isWriterEmpty, "Writer should be empty at this point");

        if (_properties is null)
        {
            if (!_rawJson.Value.IsEmpty && writer.CurrentDepth == 0 && writer.BytesCommitted == 0 && writer.BytesPending == 0)
            {
                writer.WriteRawValue(_rawJson.Value.Span);
            }
        }
        else
        {
            ReadOnlyMemory<byte> newJson = _rawJson.Value;
            foreach (var kvp in _properties)
            {
                if (kvp.Value.Kind.HasFlag(ValueKind.Removed))
                {
                    newJson = newJson.Remove(kvp.Key);
                }
                else if (kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                        newJson = newJson.Append(kvp.Key, kvp.Value.Value.Slice(1, kvp.Value.Value.Length - 2));
                }
                else
                {
                    if (kvp.Key.IsArrayIndex())
                    {
                        Utf8Parser.TryParse(kvp.Key.GetIndexSpan(), out int index, out _);
                        newJson = newJson.InsertAt(kvp.Key, index, kvp.Value.Value);
                    }
                    else
                    {
                        newJson = newJson.Set(kvp.Key, kvp.Value.Value);
                    }
                }
            }
            writer.WriteRawValue(newJson.Span);
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (_properties == null || _properties.Count == 0)
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        bool first = true;
        foreach (var kvp in _properties)
        {
            if (!first)
                sb.AppendLine(",");
            first = false;
            string propertyName = Encoding.UTF8.GetString(kvp.Key);
            sb.Append(propertyName);
            sb.Append(": ");

            // Decode the encoded value for display
            object decodedValue = DecodeValue(kvp.Value);
            sb.Append(decodedValue.ToString());
        }
        if (_properties.Count > 0)
            sb.AppendLine();
        return sb.ToString();
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool IsRemoved(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties is null)
            return false;

        return _properties.TryGetValue(jsonPath, out var value) && value.Kind == ValueKind.Removed;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="prefix"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public bool ContainsChildOf(ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> property)
    {
        if (_properties == null)
            return false;

        Span<byte> normalizedPrefix = stackalloc byte[prefix.Length];
        JsonPathComparer.Default.Normalize(prefix, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

        foreach (var kvp in _properties)
        {
            ReadOnlySpan<byte> keySpan = kvp.Key;

            if (!keySpan.StartsWith(normalizedPrefix))
                continue;

            if (property.SequenceEqual(keySpan.Slice(normalizedPrefix.Length).GetPropertyNameFromSlice()))
                return true;
        }

        return false;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="utf8Json"></param>
    public void Append(ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> utf8Json)
    {
        var encodedValue = EncodeValue(utf8Json);
        SetInternal(jsonPath, new(encodedValue.Kind | ValueKind.ArrayItemAppend, encodedValue.Value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Append(ReadOnlySpan<byte> jsonPath, string value)
    {
        var encodedValue = EncodeValue(value);
        SetInternal(jsonPath, new(encodedValue.Kind | ValueKind.ArrayItemAppend, encodedValue.Value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Append(ReadOnlySpan<byte> jsonPath, int value)
    {
        var encodedValue = EncodeValue(value);
        SetInternal(jsonPath, new(encodedValue.Kind | ValueKind.ArrayItemAppend, encodedValue.Value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    [RequiresUnreferencedCode("RequiresUnreferencedCode")]
    [RequiresDynamicCode("RequiresDynamicCode")]
    public void Append(ReadOnlySpan<byte> jsonPath, object value)
    {
        EncodedValue encodedValue;
        if (IsAnonymousType(value))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            encodedValue = EncodeValue(JsonSerializer.SerializeToUtf8Bytes(value, options));
        }
        else
        {
            encodedValue = EncodeValue(value);
        }

        SetInternal(jsonPath, new(encodedValue.Kind | ValueKind.ArrayItemAppend, encodedValue.Value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Append<T>(ReadOnlySpan<byte> jsonPath, IJsonModel<T> value)
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        var encodedValue = EncodeValue(reader.ToBinaryData());
        SetInternal(jsonPath, new(encodedValue.Kind | ValueKind.ArrayItemAppend, encodedValue.Value));
    }
}
