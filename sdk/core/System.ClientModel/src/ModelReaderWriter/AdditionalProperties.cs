// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Internal;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public partial struct AdditionalProperties
{
    private delegate T? SpanParser<T>(ReadOnlySpan<byte> buffer, ReadOnlySpan<byte> span);

    // Marker classes for special values
    internal sealed class RemovedValue
    {
        public static readonly RemovedValue Instance = new();
        private RemovedValue() { }
        public override string ToString() => "<removed>";
    }

    internal sealed class NullValue
    {
        public static readonly NullValue Instance = new();
        private NullValue() { }
        public override string ToString() => "null";
    }

    // Helper method to write objects as JSON
    private static void WriteObjectAsJson(Utf8JsonWriter writer, string propertyName, object value)
    {
        // Skip removed properties during serialization
        if (value is RemovedValue)
            return;

        ReadOnlySpan<byte> nameBytes = System.Text.Encoding.UTF8.GetBytes(propertyName);

        switch (value)
        {
            case string s:
                writer.WriteString(nameBytes, s);
                break;
            case int i:
                writer.WriteNumber(nameBytes, i);
                break;
            case bool b:
                writer.WriteBoolean(nameBytes, b);
                break;
            case byte[] jsonBytes:
                writer.WritePropertyName(nameBytes);
                writer.WriteRawValue(jsonBytes);
                break;
            case NullValue:
                writer.WriteNull(nameBytes);
                break;
            default:
                throw new NotSupportedException($"Unsupported value type: {value?.GetType()}");
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Contains(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
            return false;
        byte[] nameBytes = name.ToArray();
        return _properties.ContainsKey(nameBytes);
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

    private T? GetPrimitive<T>(ReadOnlySpan<byte> propertyName, SpanParser<T?> parser, ValueKind expectedKind)
    {
        if (TryGetFromPointer(propertyName, parser, default, out T? result))
        {
            return result;
        }

        // Direct property access
        byte[] encodedValue = GetEncodedValue(propertyName);
        if (encodedValue.Length == 0)
        {
            ThrowPropertyNotFoundException(propertyName);
            return default;
        }
        else
        {
            ValueKind kind = (ValueKind)encodedValue[0];
            if (kind == ValueKind.Null && expectedKind.HasFlag(ValueKind.Null))
            {
                return default;
            }
            else
            {
                return JsonSerializer.Deserialize<T>(encodedValue.AsSpan(1));
            }
        }
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

    // Helper method to get raw encoded value bytes
    private byte[] GetEncodedValue(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
        {
            return Array.Empty<byte>();
        }

        byte[] nameBytes = name.ToArray();
        int lastSlashIndex = name.LastIndexOf((byte)'/');
        if (lastSlashIndex > 0)
        {
            ReadOnlySpan<byte> remaining = name.Slice(lastSlashIndex + 1);
            if (remaining.Length == 1 && remaining[0] == (byte)'-')
            {
                //is it worth it to calculate the size?
                int size = 0;
                int count = 0;
                foreach (var kvp in EntriesStartsWith(nameBytes))
                {
                    count++;
                    size += kvp.Value.Length;
                }

                //combine all entries that start with the name
                using var memoryStream = new MemoryStream(size + count);
                memoryStream.WriteByte((byte)ValueKind.Json);
                int current = 0;
                foreach (var kvp in EntriesStartsWith(nameBytes))
                {
                    memoryStream.Write(kvp.Value, 1, kvp.Value.Length - 1);
                    if (current++ < count - 1)
                    {
                        memoryStream.WriteByte((byte)',');
                    }
                }
                return memoryStream.ToArray();
            }
            else if (Utf8Parser.TryParse(remaining, out int index, out _))
            {
                return EntriesStartsWith(name.Slice(0, lastSlashIndex).ToArray()).Skip(index).Take(1).First().Value;
            }
        }

        if (!_properties.TryGetValue(nameBytes, out byte[]? encodedValue))
        {
            return Array.Empty<byte>();
        }

        return encodedValue;
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
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Set(ReadOnlySpan<byte> name, int value)
    {
        // Int32
        SetInternal(name, EncodeValue(value));
    }

    private bool TryGetFromPointer<T>(ReadOnlySpan<byte> name, SpanParser<T> parser, T defaultValue, out T? result)
    {
        // Check if this is a JSON pointer (contains '/')
        result = default;
        int slashIndex = name.IndexOf((byte)'/');
        if (slashIndex >= 0)
        {
            // This is a JSON pointer - extract the base property name
            ReadOnlySpan<byte> baseName = name.Slice(0, slashIndex);
            ReadOnlySpan<byte> pointer = name.Slice(slashIndex);

            // Get the encoded value for the base property
            byte[] baseEncodedValue = GetEncodedValue(baseName);
            if (baseEncodedValue.Length == 0 || (ValueKind)baseEncodedValue[0] != ValueKind.Json)
            {
                return false;
            }

            // Use JsonPointer to navigate to the specific element
            result = parser(baseEncodedValue.AsSpan(1), pointer) ?? defaultValue;
            return true;
        }

        return false;
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
    /// <param name="name"></param>
    /// <param name="json"></param>
    public void Set(ReadOnlySpan<byte> name, ReadOnlySpan<byte> json)
    {
        SetInternal(name, EncodeValue(json));
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public BinaryData GetJson(ReadOnlySpan<byte> jsonPointer)
    {
        byte[] encodedValue = GetEncodedValue(jsonPointer);
        if (encodedValue.Length == 0 || (ValueKind)encodedValue[0] != ValueKind.Json)
            ThrowPropertyNotFoundException(jsonPointer);

        // Extract JSON bytes (skip the first byte which is the kind)
        byte[] jsonBytes = encodedValue.AsSpan(1).ToArray();
        return BinaryData.FromBytes(jsonBytes);
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
    /// <param name="jsonPointer"></param>
    public void Remove(ReadOnlySpan<byte> jsonPointer)
    {
        // Special (remove, set null, etc)
        Set(jsonPointer, RemovedValue.Instance);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    public void SetNull(ReadOnlySpan<byte> jsonPointer)
    {
        Set(jsonPointer, NullValue.Instance);
    }
}
