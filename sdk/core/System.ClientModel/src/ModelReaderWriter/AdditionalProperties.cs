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
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Contains(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
            return false;

        return _properties.ContainsKey(name.ToArray());
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Contains(byte[] name)
    {
        if (_properties == null)
            return false;

        return _properties.ContainsKey(name);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool ContainsStartsWith(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
            return false;

        byte[] nameBytes = name.ToArray();
        return _properties.Keys.Any(k => k.AsSpan().StartsWith(nameBytes));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<byte[], byte[]>> EntriesStartsWith(byte[] name)
    {
        if (_properties == null)
            yield break;

        foreach (var kvp in _properties)
        {
            var keySpan = kvp.Key.AsSpan();
            if (keySpan.Length <= name.Length)
                continue;

            if (kvp.Key.AsSpan().StartsWith(name))
            {
                yield return kvp;
            }
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, string value)
    {
        SetInternal(name, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, byte[] value)
    {
        SetInternal(name, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, BinaryData value)
    {
        SetInternal(name, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set<T>(ReadOnlySpan<byte> name, IJsonModel<T> value)
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        SetInternal(name, EncodeValue(reader.ToBinaryData()));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, int value)
    {
        // Int32
        SetInternal(name, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="json"></param>
    public void Set(ReadOnlySpan<byte> name, ReadOnlySpan<byte> json)
    {
        SetInternal(name, EncodeValue(json));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, bool value)
    {
        SetInternal(name, EncodeValue(value));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    [RequiresUnreferencedCode("RequiresUnreferencedCode")]
    [RequiresDynamicCode("RequiresDynamicCode")]
    public void Set(ReadOnlySpan<byte> name, object value)
    {
        if (IsAnonymousType(value))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            SetInternal(name, EncodeValue(JsonSerializer.SerializeToUtf8Bytes(value, options)));
        }
        else
        {
            SetInternal(name, EncodeValue(value));
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    public void SetNull(ReadOnlySpan<byte> jsonPointer)
    {
        Set(jsonPointer, NullValue.Instance);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public string? GetString(ReadOnlySpan<byte> propertyName)
    {
        return GetPrimitive(propertyName, JsonPointer.GetString, ValueKind.NullableUtf8String);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public ReadOnlyMemory<byte> GetStringUtf8(ReadOnlySpan<byte> jsonPointer)
    {
        byte[] encodedValue = GetEncodedValue(jsonPointer);
        if (encodedValue.Length == 0 || (ValueKind)encodedValue[0] != ValueKind.Utf8String)
            ThrowPropertyNotFoundException(jsonPointer);

        // Parse JSON string representation (skip the first byte which is the kind)
        ReadOnlySpan<byte> valueBytes = encodedValue.AsSpan(1);
#if NET6_0_OR_GREATER
        string jsonString = Encoding.UTF8.GetString(valueBytes);
#else
        string jsonString = Encoding.UTF8.GetString(valueBytes.ToArray());
#endif
        string actualString = JsonSerializer.Deserialize<string>(jsonString) ?? string.Empty;

        // Return the actual UTF8 bytes of the string (not the JSON representation)
        return Encoding.UTF8.GetBytes(actualString);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public int? GetNullableInt32(ReadOnlySpan<byte> jsonPointer)
    {
        return GetPrimitive(jsonPointer, JsonPointer.GetNullableInt32, ValueKind.NullableInt32);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public int GetInt32(ReadOnlySpan<byte> jsonPointer)
    {
        return GetPrimitive(jsonPointer, JsonPointer.GetInt32, ValueKind.Int32);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public bool GetBoolean(ReadOnlySpan<byte> jsonPointer)
    {
        return GetPrimitive(jsonPointer, JsonPointer.GetBoolean, ValueKind.Boolean);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public BinaryData GetJson(ReadOnlySpan<byte> jsonPointer)
    {
        byte[] encodedValue = GetEncodedValue(jsonPointer);
        if (encodedValue.Length == 0 || (encodedValue[0] & (byte)ValueKind.Json) == 0)
            ThrowPropertyNotFoundException(jsonPointer);

        // Extract JSON bytes (skip the first byte which is the kind)
        byte[] jsonBytes = encodedValue.AsSpan(1).ToArray();
        return BinaryData.FromBytes(jsonBytes);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    public void Remove(ReadOnlySpan<byte> jsonPointer)
    {
        // Special (remove, set null, etc)
        Set(jsonPointer, RemovedValue.Instance);
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

        HashSet<byte[]> arrays = new HashSet<byte[]>(ByteArrayEqualityComparer.Instance);

        foreach (var kvp in _properties)
        {
            if (kvp.Key.IsRoot())
                continue;

            if (kvp.Value[0] == (byte)ValueKind.Removed)
            {
                continue;
            }

            var parent = kvp.Key.GetParent();

            if ((kvp.Value[0] & (byte)ValueKind.ArrayItem) != 0)
            {
                var keySpan = kvp.Key.AsSpan();

                var arrayKey = keySpan.Slice(0, keySpan.IndexOf((byte)'-')).ToArray();
                if (arrays.Contains(arrayKey))
                {
                    continue;
                }

                writer.WritePropertyName(parent.GetPropertyName());
                writer.WriteStartArray();
                foreach (var arrayItem in EntriesStartsWith(arrayKey))
                {
                    if ((arrayItem.Value[0] & (byte)ValueKind.Removed) > 0 || arrayItem.Key.GetIndexSpan().IsEmpty)
                        continue;

                    writer.WriteRawValue(arrayItem.Value.AsSpan().Slice(1));
                }
                writer.WriteEndArray();

                arrays.Add(arrayKey);
                continue;
            }

            if (!parent.IsRoot())
            {
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
        foreach (var entry in EntriesStartsWith(prefix.ToArray()))
        {
            var inner = entry.Key.AsSpan().Slice(prefix.Length);
            if ((entry.Value[0] & (byte)ValueKind.ArrayItem) > 0)
            {
                var indexSpan = entry.Key.GetIndexSpan();
                if (indexSpan.Length == 0)
                {
                    // If the property name is empty, skip it
                    continue;
                }
                if (indexSpan[0] == (byte)'-')
                    indexSpan = indexSpan.Slice(1);

                if (Utf8Parser.TryParse(indexSpan, out int index, out _))
                {
                    byte[] arrayBytes = [(byte)'$', .. inner.Slice(0, inner.IndexOf((byte)'[') + 2), (byte)']'];
                    if (target._arrayIndices is null)
                    {
                        target._arrayIndices = new Dictionary<byte[], int>(ByteArrayEqualityComparer.Instance);
                        target._arrayIndices[arrayBytes] = index;
                    }
                    else
                    {
                        if (!target._arrayIndices.TryGetValue(arrayBytes, out int existingIndex))
                        {
                            target._arrayIndices[arrayBytes] = index;
                        }
                        else
                        {
                            target._arrayIndices[arrayBytes] = Math.Max(index, existingIndex);
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
        if (_arrayIndices == null || !_arrayIndices.TryGetValue(array.ToArray(), out var index))
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

        return _properties.TryGetValue(jsonPath, out var value) && value[0] == (byte)ValueKind.Removed;
    }
}
