// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public partial struct AdditionalProperties
{
    // Dictionary-based storage using UTF8 byte arrays as keys and encoded byte arrays as values
    private Dictionary<byte[], byte[]>? _properties;
    private Dictionary<byte[], int>? _arrayIndices;

    // Value kinds for encoding type information in byte arrays
    [Flags]
    private enum ValueKind : byte
    {
        None = 0,
        Json = 1 << 0,
        Int32 = 1 << 1,
        Utf8String = 1 << 2,
        Removed = 1 << 3,
        Null = 1 << 4,
        BooleanTrue = 1 << 5,
        BooleanFalse = 1 << 6,
        ArrayItem = 1 << 7,
        Boolean = BooleanTrue | BooleanFalse,
        NullableInt32 = Int32 | Null,
        NullableBoolean = Boolean | Null,
        NullableUtf8String = Utf8String | Null,
    }

    // Singleton arrays for common values
    private static readonly byte[] s_removedValueArray = [(byte)ValueKind.Removed];
    private static readonly byte[] s_nullValueArray;
    private static readonly byte[] s_trueBooleanArray;
    private static readonly byte[] s_falseBooleanArray;

    // Static constructor to initialize singleton arrays
    static AdditionalProperties()
    {
        // Initialize null value array
        s_nullValueArray = [(byte)ValueKind.Null, .. "null"u8];
        // Initialize true boolean array
        s_trueBooleanArray = [(byte)ValueKind.BooleanTrue, .. "true"u8];
        // Initialize false boolean array
        s_falseBooleanArray = [(byte)ValueKind.BooleanFalse, .. "false"u8];
    }

    private static bool IsAnonymousType(object obj)
    {
        if (obj == null)
            return false;
        var type = obj.GetType();

        return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
            && type.IsGenericType
            && type.Name.Contains("AnonymousType")
            && (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal))
            && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
    }

    private static byte[] EncodeValue(bool value)
        => value ? s_trueBooleanArray : s_falseBooleanArray;

    private static byte[] EncodeValue(byte[] value)
        => [(byte)ValueKind.Json, .. value];

    private static byte[] EncodeValue(BinaryData value)
        => [(byte)ValueKind.Json, .. value.ToMemory().Span];

    private static byte[] EncodeValue(int value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return [(byte)ValueKind.Int32, .. buffer.Slice(0, bytesWritten)];
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode integer value '{value}'.");
    }

    private static byte[] EncodeValue(ReadOnlySpan<byte> value)
        => [(byte)ValueKind.Json, .. value.ToArray()];

    private static byte[] EncodeValue(string value)
        => [(byte)ValueKind.Utf8String, (byte)'"', .. Encoding.UTF8.GetBytes(value), (byte)'"'];

    // Helper methods to encode objects to byte arrays (similar to PropertyRecord format)
    private static byte[] EncodeValue(object value)
    {
        switch (value)
        {
            case string s:
                return EncodeValue(s);

            case int i:
                return EncodeValue(i);

            case bool b:
                // Use singleton arrays for boolean values
                return EncodeValue(b);

            case byte[] jsonBytes:
                return EncodeValue(jsonBytes);

            case RemovedValue:
                // Use singleton array for removed value
                return s_removedValueArray;

            case NullValue:
                // Use singleton array for null value
                return s_nullValueArray;

            default:
                throw new NotSupportedException($"Unsupported value type: {value?.GetType()}");
        }
    }

    // Helper method to decode byte arrays back to objects (for backward compatibility)
    private static object DecodeValue(ReadOnlySpan<byte> encodedValue)
    {
        if (encodedValue.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = (ValueKind)encodedValue[0];
        ReadOnlySpan<byte> valueBytes = encodedValue.Slice(1);

        switch (kind)
        {
            case ValueKind.Utf8String:
                // Parse JSON string representation using Utf8JsonReader
                Utf8JsonReader reader = new Utf8JsonReader(valueBytes);
                if (reader.Read() && reader.TokenType == JsonTokenType.String)
                {
                    return reader.GetString() ?? string.Empty;
                }
                throw new FormatException("Invalid JSON string format.");

            case ValueKind.Int32:
                // Parse JSON number representation
#if NET6_0_OR_GREATER
                string jsonInt = Encoding.UTF8.GetString(valueBytes);
#else
                string jsonInt = Encoding.UTF8.GetString(valueBytes.ToArray());
#endif
                return int.Parse(jsonInt);

            case ValueKind.BooleanTrue:
            case ValueKind.BooleanFalse:
                // Parse JSON boolean representation
#if NET6_0_OR_GREATER
                string jsonBool = Encoding.UTF8.GetString(valueBytes);
#else
                string jsonBool = Encoding.UTF8.GetString(valueBytes.ToArray());
#endif
                return bool.Parse(jsonBool);

            case ValueKind.Json:
                return valueBytes.ToArray();

            case ValueKind.Removed:
                return RemovedValue.Instance;

            case ValueKind.Null:
                return NullValue.Instance;

            default:
                throw new ArgumentException($"Unknown value kind: {kind}");
        }
    }

    private void SetInternal(ReadOnlySpan<byte> name, byte[] encodedValue)
    {
        if (_properties == null)
        {
            _properties = new Dictionary<byte[], byte[]>(ByteArrayEqualityComparer.Instance);
        }

        if (name.EndsWith("/-"u8))
        {
            if (_arrayIndices == null)
            {
                _arrayIndices = new Dictionary<byte[], int>(ByteArrayEqualityComparer.Instance);
            }

            encodedValue[0] |= (byte)ValueKind.ArrayItem; // Mark as array item
            var arrayNameBytes = name.Slice(0, name.Length - 1).ToArray();
            if ( !_arrayIndices.TryGetValue(arrayNameBytes, out var index))
            {
                index = 0;
                _arrayIndices[arrayNameBytes] = index;
            }
            else
            {
                index++;
                _arrayIndices[arrayNameBytes] = index;
            }
            _properties[[.. arrayNameBytes, .. Encoding.UTF8.GetBytes(index.ToString())]] = encodedValue;
        }
        else
        {
            _properties[name.ToArray()] = encodedValue;
        }
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

    private object Get(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
            ThrowPropertyNotFoundException(name);

        byte[] nameBytes = name.ToArray();
        if (!_properties.TryGetValue(nameBytes, out byte[]? encodedValue))
        {
            ThrowPropertyNotFoundException(name);
        }

        return DecodeValue(encodedValue!);
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
            if ((kvp.Value[0] & (byte)ValueKind.ArrayItem) != 0)
            {
                var keySpan = kvp.Key.AsSpan();
                var slash = keySpan.IndexOf((byte)'/');
                if (keySpan.Slice(slash + 1).IndexOf((byte)'/') >= 0)
                {
                    // skip properties that are multiple layers as those will be propagated to the child objects
                    continue;
                }

                var arrayKey = keySpan.Slice(0, slash + 1).ToArray();
                if (arrays.Contains(arrayKey))
                {
                    continue;
                }

                writer.WritePropertyName(keySpan.Slice(0, slash));
                writer.WriteStartArray();
                foreach (var arrayItem in EntriesStartsWith(arrayKey))
                {
                    writer.WriteRawValue(arrayItem.Value.AsSpan().Slice(1));
                }
                writer.WriteEndArray();

                arrays.Add(arrayKey);
                continue;
            }

            if (kvp.Key.AsSpan().IndexOf((byte)'/') >= 0)
            {
                continue;
            }

            // TODO we are going back and forth from bytes to string and back, which is not efficient.
            string propertyName = Encoding.UTF8.GetString(kvp.Key);
            WriteEncodedValueAsJson(writer, propertyName, kvp.Value);
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="target"></param>
    /// <param name="prefix"></param>
    public void PropagateTo(ref AdditionalProperties target, ReadOnlySpan<byte> prefix)
    {
        foreach (var entry in EntriesStartsWith(prefix.ToArray()))
        {
            var inner = entry.Key.AsSpan().Slice(prefix.Length);
            if ((entry.Value[0] & (byte)ValueKind.ArrayItem) > 0)
            {
                var indexSpan = inner.Slice(inner.LastIndexOf((byte)'/') + 1);
                if (Utf8Parser.TryParse(indexSpan, out int index, out _))
                {
                    if (target._arrayIndices is null)
                    {
                        target._arrayIndices = new Dictionary<byte[], int>(ByteArrayEqualityComparer.Instance);
                        target._arrayIndices[inner.Slice(0, inner.Length - 1).ToArray()] = index;
                    }
                    else
                    {
                        if (!target._arrayIndices.TryGetValue(inner.Slice(0, inner.Length - 1).ToArray(), out int existingIndex))
                        {
                            target._arrayIndices[inner.Slice(0, inner.Length - 1).ToArray()] = index;
                        }
                        else
                        {
                            target._arrayIndices[inner.Slice(0, inner.Length - 1).ToArray()] = Math.Max(index, existingIndex);
                        }
                    }
                }
            }
            target.SetInternal(inner, entry.Value);
        }
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, string propertyName, byte[] encodedValue)
    {
        // Helper method to write encoded byte values as JSON

        if (encodedValue.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = (ValueKind)encodedValue[0];
        ReadOnlySpan<byte> valueBytes = encodedValue.AsSpan(1);

        writer.WritePropertyName(propertyName);

        switch (kind)
        {
            case ValueKind.Utf8String:
                // valueBytes contains JSON string representation, parse and write properly
                writer.WriteRawValue(valueBytes);
                break;

            case ValueKind.Int32:
                // valueBytes contains JSON number representation
#if NET6_0_OR_GREATER
                var temp = Encoding.UTF8.GetString(valueBytes);
#else
                var temp = Encoding.UTF8.GetString(valueBytes.ToArray());
#endif
                if (int.TryParse(temp, out int intValue))
                {
                    writer.WriteNumberValue(intValue);
                }
                else
                {
                    throw new FormatException("Invalid integer format in encoded value.");
                }
                break;

            case ValueKind.BooleanTrue:
            case ValueKind.BooleanFalse:
                // valueBytes contains JSON boolean representation
                writer.WriteBooleanValue(kind == ValueKind.BooleanTrue);
                break;

            case ValueKind.Json:
                // Write raw JSON value
                writer.WriteRawValue(valueBytes, skipInputValidation: true);
                break;

            case ValueKind.Null:
                writer.WriteNullValue();
                break;

            case ValueKind.Removed:
                // Skip removed properties during serialization
                break;

            default:
                throw new NotSupportedException($"Unsupported value kind: {kind}");
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private void ThrowPropertyNotFoundException(ReadOnlySpan<byte> name)
    {
        throw new KeyNotFoundException(Encoding.UTF8.GetString(name.ToArray()));
    }
}
