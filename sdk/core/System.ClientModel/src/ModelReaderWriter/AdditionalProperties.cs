// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public partial struct AdditionalProperties
{
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
        // TODO: can set support json pointer?
        // System.String
        Set(name, (object)value);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public string GetString(ReadOnlySpan<byte> jsonPointer)
    {
        // TODO: all these methods should take JSON pointer, not just property names

        // Check if this is a JSON pointer (contains '/')
        int slashIndex = jsonPointer.IndexOf((byte)'/');
        if (slashIndex >= 0)
        {
            // This is a JSON pointer - extract the base property name
            ReadOnlySpan<byte> baseName = jsonPointer.Slice(0, slashIndex);
            ReadOnlySpan<byte> pointer = jsonPointer.Slice(slashIndex);

            // Get the encoded value for the base property
            byte[] baseEncodedValue = GetEncodedValue(baseName);
            if (baseEncodedValue.Length == 0 || (ValueKind)baseEncodedValue[0] != ValueKind.Json)
                ThrowPropertyNotFoundException(jsonPointer);

            // Extract JSON bytes (skip the first byte which is the kind)
            byte[] jsonBytes = baseEncodedValue.AsSpan(1).ToArray();

            // Use JsonPointer to navigate to the specific element
            return JsonPointer.GetString(jsonBytes, pointer) ?? string.Empty;
        }

        // Direct property access
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
        return JsonSerializer.Deserialize<string>(jsonString) ?? string.Empty;
    }

    // Helper method to get raw encoded value bytes
    private byte[] GetEncodedValue(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
        {
            return Array.Empty<byte>();
        }

        byte[] nameBytes = name.ToArray();
        if (!_properties.TryGetValue(nameBytes, out byte[]? encodedValue))
        {
            return Array.Empty<byte>();
        }

        return encodedValue!;
    }

    private bool TryGetValueFromSard<T>(ReadOnlySpan<byte> name, out T? value)
    {
        value = default;

        if (_serializedAdditionalRawData == null)
            return false;

#if NET6_0_OR_GREATER
        string nameString = Encoding.UTF8.GetString(name);
#else
        string nameString = Encoding.UTF8.GetString(name.ToArray());
#endif
        if (_serializedAdditionalRawData.TryGetValue(nameString, out BinaryData? data))
        {
            value = data.ToObjectFromJson<T>();
            return true;
        }

        return false;
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
        Set(name, (object)value);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPointer"></param>
    /// <returns></returns>
    public int GetInt32(ReadOnlySpan<byte> jsonPointer)
    {
        // Check if this is a JSON pointer (contains '/')
        int slashIndex = jsonPointer.IndexOf((byte)'/');
        if (slashIndex >= 0)
        {
            // This is a JSON pointer - extract the base property name
            ReadOnlySpan<byte> baseName = jsonPointer.Slice(0, slashIndex);
            ReadOnlySpan<byte> pointer = jsonPointer.Slice(slashIndex);

            // Get the encoded value for the base property
            byte[] baseEncodedValue = GetEncodedValue(baseName);
            if (baseEncodedValue.Length == 0 || (ValueKind)baseEncodedValue[0] != ValueKind.Json)
                ThrowPropertyNotFoundException(jsonPointer);

            // Extract JSON bytes (skip the first byte which is the kind)
            byte[] jsonBytes = baseEncodedValue.AsSpan(1).ToArray();

            // Use JsonPointer to navigate to the specific element
            return JsonPointer.GetInt32(jsonBytes, pointer);
        }

        // Direct property access
        byte[] encodedValue = GetEncodedValue(jsonPointer);
        if (encodedValue.Length == 0 || (ValueKind)encodedValue[0] != ValueKind.Int32)
        {
            if (TryGetValueFromSard<int>(jsonPointer, out int value))
            {
                return value;
            }
            ThrowPropertyNotFoundException(jsonPointer);
        }

        // Parse JSON number representation (skip the first byte which is the kind)
        ReadOnlySpan<byte> valueBytes = encodedValue.AsSpan(1);
#if NET6_0_OR_GREATER
        string jsonNumber = Encoding.UTF8.GetString(valueBytes);
#else
        string jsonNumber = Encoding.UTF8.GetString(valueBytes.ToArray());
#endif
        return int.Parse(jsonNumber);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="name"></param>
    /// <param name="json"></param>
    public void Set(ReadOnlySpan<byte> name, ReadOnlySpan<byte> json)
    {
        // TODO: can set support json pointer?
        // JSON Object
        byte[] jsonBytes = json.ToArray();
        Set(name, (object)jsonBytes);
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
        Set(name, (object)value);
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
