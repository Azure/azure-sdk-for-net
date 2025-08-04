// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Internal;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
    /// <param name="rawJson"></param>
    public AdditionalProperties(ReadOnlyMemory<byte> rawJson)
    {
        _rawJson = new(ValueKind.Json, rawJson);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool Contains(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
            return false;

        return _properties.ContainsKey(jsonPath);
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
        Set(jsonPath, NullValue.Instance);
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
    public void Remove(ReadOnlySpan<byte> jsonPath)
    {
        // Special (remove, set null, etc)
        Set(jsonPath, RemovedValue.Instance);
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

        SpanHashSet arrays = new();

        foreach (var kvp in _properties)
        {
            if (kvp.Key.IsRoot())
                continue;

            if (kvp.Value.Kind == ValueKind.Removed)
            {
                continue;
            }

            var parent = kvp.Key.GetParent();

            if (kvp.Value.Kind.HasFlag(ValueKind.ArrayItem))
            {
                var arrayKeySpan = kvp.Key.GetParent();
                if (arrays.Contains(arrayKeySpan))
                {
                    continue;
                }

                if (writer.CurrentDepth > 0)
                {
                    // only write the property name if we are not at the root
                    writer.WritePropertyName(parent.GetPropertyName());
                }
                writer.WriteStartArray();
                foreach (var arrayItem in _properties)
                {
                    if (arrayKeySpan.Length == arrayItem.Key.Length || !arrayItem.Key.AsSpan().StartsWith(arrayKeySpan))
                        continue;

                    if (arrayItem.Value.Kind.HasFlag(ValueKind.Removed) || arrayItem.Key.GetIndexSpan().IsEmpty)
                        continue;

                    writer.WriteRawValue(arrayItem.Value.Value.Span);
                }
                writer.WriteEndArray();

                arrays.Add(arrayKeySpan);
                continue;
            }

            if (!parent.IsRoot())
            {
                JsonPathReader pathReader = new(kvp.Key);
                ReadOnlySpan<byte> firstProperty = pathReader.GetFirstProperty();

                if (Propagated.Contains(firstProperty))
                {
                    continue;
                }

                Propagated.Add(firstProperty);

                AdditionalProperties local = new();
                PropagateTo(ref local, firstProperty);

                writer.WritePropertyName(firstProperty.GetPropertyName());
                writer.WriteStartObject();
                local.Write(writer);
                writer.WriteEndObject();
                continue;
            }

            WriteEncodedValueAsJson(writer, kvp.Key.GetPropertyName(), kvp.Value);
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="target"></param>
    /// <param name="prefix"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PropagateTo(ref AdditionalProperties target, ReadOnlySpan<byte> prefix)
    {
        if (_properties == null)
            return;

        //64 is an arbitrary size but most array names should be small
        Span<byte> arraySpan = stackalloc byte[64];
        arraySpan[0] = (byte)'$';

        foreach (var entry in _properties)
        {
            if (prefix.Length == entry.Key.Length || !entry.Key.AsSpan().StartsWith(prefix))
                continue;

            JsonPathReader pathReader = new(entry.Key);
            ReadOnlySpan<byte> _firstProperty = pathReader.GetFirstProperty();
            if (!_firstProperty.IsEmpty)
            {
                Propagated.Add(_firstProperty);
            }
            var inner = entry.Key.AsSpan().Slice(prefix.Length);
            if (entry.Value.Kind.HasFlag(ValueKind.ArrayItem))
            {
                var indexSpan = entry.Key.GetIndexSpan();
                if (indexSpan.Length == 0)
                {
                    // If the property name is empty, skip it
                    continue;
                }

                if (Utf8Parser.TryParse(indexSpan, out int index, out _))
                {
                    bool useSpan;
                    byte[]? arrayBytes = default;
                    var innerSlice = inner.Slice(0, inner.IndexOf((byte)'['));
                    if (innerSlice.Length + 1 <= arraySpan.Length)
                    {
                        useSpan = true;
                        innerSlice.CopyTo(arraySpan.Slice(1));
                    }
                    else
                    {
                        useSpan = false;
                        arrayBytes = [(byte)'$', .. inner.Slice(0, inner.IndexOf((byte)'['))];
                    }
                    if (target._arrayIndices is null)
                    {
                        target._arrayIndices = new();
                        target._arrayIndices[useSpan ? arraySpan.Slice(0, innerSlice.Length + 1) : arrayBytes] = index;
                    }
                    else
                    {
                        if (!target._arrayIndices.TryGetValue(useSpan ? arraySpan.Slice(0, innerSlice.Length + 1) : arrayBytes, out int existingIndex))
                        {
                            target._arrayIndices[useSpan ? arraySpan.Slice(0, innerSlice.Length + 1) : arrayBytes] = index;
                        }
                        else
                        {
                            target._arrayIndices[useSpan ? arraySpan.Slice(0, innerSlice.Length + 1) : arrayBytes] = Math.Max(index, existingIndex);
                        }
                    }
                }
            }
            target.SetInternal([(byte)'$', .. inner], entry.Value);
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
    /// <param name="array"></param>
    /// <returns></returns>
    public int? GetArrayLength(ReadOnlySpan<byte> array)
    {
        if (_arrayIndices == null || !_arrayIndices.TryGetValue(array, out var index))
        {
            return null;
        }

        return index;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    public bool IsRemoved(byte[] jsonPath)
    {
        if (_properties is null)
            return false;

        return _properties.TryGetValue(jsonPath, out var value) && value.Kind == ValueKind.Removed;
    }
}
