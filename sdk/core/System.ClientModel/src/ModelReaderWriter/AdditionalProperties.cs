// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Internal;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public partial struct AdditionalProperties
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
    /// <param name="rawJson"></param>
    public AdditionalProperties(ReadOnlyMemory<byte> rawJson)
    {
        _rawJson = new(ValueKind.Json, rawJson);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="setter"></param>
    /// <param name="getter"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPropagators(PropagatorSetter setter, PropagatorGetter getter)
    {
        _propagatorSetter = setter;
        _propagatorGetter = getter;
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

#if NET9_0_OR_GREATER
        return _alternateProperties.ContainsKey(jsonPath);
#else
        return _properties.ContainsKey(jsonPath.ToArray());
#endif
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool ContainsStartsWith(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
            return false;

        foreach (var kvp in _properties)
        {
            // TODO: this does not normalize the jsonPath
            if (jsonPath.Length == kvp.Key.Length || kvp.Key.AsSpan().StartsWith(jsonPath))
            {
                return true;
            }
        }

        return false;
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
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, byte[] value)
    {
        SetInternal(jsonPath, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, BinaryData value)
    {
        SetInternal(jsonPath, EncodeValue(value));
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
    /// <param name="json"></param>
    public void Set(ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> json)
    {
        SetInternal(jsonPath, EncodeValue(json));
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

        foreach (var kvp in _properties)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                continue;

            JsonPathReader reader = new(kvp.Key);
            if (!reader.Advance(prefix))
                continue;

            if (reader.Current.TokenType == JsonPathTokenType.PropertySeparator)
                reader.Read();

            WriteEncodedValueAsJson(writer, reader.Current.ValueSpan, kvp.Value);
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

        if (!TryGetValueFromProperties(array, out var value))
            return;

        if (value.Kind == ValueKind.Removed)
            return;

        value.Kind |= ValueKind.Written;
        SetValueOnProperties(array, value);
        writer.WriteRawValue(value.Value.Span.Slice(1, value.Value.Length - 2));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="writer"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Write(Utf8JsonWriter writer)
    {
        if (_properties == null)
            return;

        HashSet<byte[]> arrays = new(JsonPathComparer.Default);
#if NET9_0_OR_GREATER
        HashSet<byte[]>.AlternateLookup<ReadOnlySpan<byte>> alternateArrays = arrays.GetAlternateLookup<ReadOnlySpan<byte>>();
#endif

        foreach (var kvp in _properties)
        {
            if (kvp.Key.IsRoot())
                continue;

            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
            {
                continue;
            }

            var parent = kvp.Key.GetParent();

            if (kvp.Key.IsArrayInsert())
            {
                writer.WritePropertyName(parent.GetPropertyName());
                writer.WriteRawValue(kvp.Value.Value.Span);
                continue;
            }

            if (!parent.IsRoot())
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

        return TryGetValueFromProperties(jsonPath, out var value) && value.Kind == ValueKind.Removed;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool IsRemoved(byte[] jsonPath)
        => IsRemoved(jsonPath.AsSpan());

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public bool ContainsChildOf(ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> property)
    {
        if (_properties == null)
            return false;

        foreach (var kvp in _properties)
        {
            if (kvp.Key.Length <= jsonPath.Length)
                continue;

            JsonPathReader reader = new(kvp.Key);
            if (!reader.Advance(jsonPath))
                continue;

            if (reader.Current.TokenType == JsonPathTokenType.PropertySeparator)
                reader.Read();

            if (reader.Current.ValueSpan.SequenceEqual(property))
            {
                return true;
            }
        }

        return false;
    }
}
