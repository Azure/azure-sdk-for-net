// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
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
    private HashSet<byte[]>? _propagated;

    private delegate T? SpanParser<T>(ReadOnlySpan<byte> buffer, ReadOnlySpan<byte> span);

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

    private HashSet<byte[]> Propagated
    {
        get
        {
            if (_propagated == null)
            {
                _propagated = new HashSet<byte[]>(ByteArrayEqualityComparer.Instance);
            }
            return _propagated;
        }
    }

    // Helper method to get raw encoded value bytes
    private byte[] GetEncodedValue(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
        {
            return Array.Empty<byte>();
        }

        if (jsonPath.IsArrayInsert())
        {
            return CombineAllArrayItems(jsonPath);
        }

        byte[] nameBytes = jsonPath.ToArray();
        if (!_properties.TryGetValue(nameBytes, out byte[]? encodedValue))
        {
            if (TryGetParentMatch(jsonPath, true, out var parentBytes, out var currentValue))
            {
                var childSlice = jsonPath.Slice(parentBytes.Length);
                Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                childPath[0] = (byte)'$';
                childSlice.CopyTo(childPath.Slice(1));
                return [currentValue[0], .. currentValue.GetJson(childPath)];
            }

            return Array.Empty<byte>();
        }

        return encodedValue;
    }

    private bool TryGetParentMatch(ReadOnlySpan<byte> name, bool includeRoot, [NotNullWhen(true)] out byte[]? parentPath, [NotNullWhen(true)] out byte[]? encodedValue)
    {
        parentPath = default;
        encodedValue = null;
        if (_properties == null)
        {
            return false;
        }

        var parent = name.GetParent();
        while (parent.Length > 0)
        {
            parentPath = parent.ToArray();
            if (_properties.TryGetValue(parent.ToArray(), out encodedValue))
                return true;

            parent = parent.GetParent();

            if (parent.IsRoot() && !includeRoot)
                return false;
        }

        return false;
    }

    private byte[] CombineAllArrayItems(ReadOnlySpan<byte> name)
    {
        if (_properties == null)
        {
            return Array.Empty<byte>();
        }

        var rootArrayName = name.Slice(0, name.Length - 2).ToArray();
        //is it worth it to calculate the size?
        int size = 0;
        int count = 0;
        foreach (var kvp in EntriesStartsWith(rootArrayName))
        {
            count++;
            size += kvp.Value.Length;
        }

        if (count == 0)
        {
            //check for the full array entry
            if (_properties.TryGetValue(name.GetParent().ToArray(), out byte[]? fullArrayValue))
            {
                return fullArrayValue;
            }
            return Array.Empty<byte>();
        }
        else
        {
            //combine all entries that start with the name
            using var memoryStream = new MemoryStream(size + count + 2);
            memoryStream.WriteByte((byte)ValueKind.Json);
            memoryStream.WriteByte((byte)'[');
            int current = 0;
            foreach (var kvp in EntriesStartsWith(rootArrayName))
            {
                memoryStream.Write(kvp.Value, 1, kvp.Value.Length - 1);
                if (current++ < count - 1)
                {
                    memoryStream.WriteByte((byte)',');
                }
            }
            memoryStream.WriteByte((byte)']');
            return memoryStream.ToArray();
        }
    }

    private byte[] GetPrimitive(ReadOnlySpan<byte> pointer)
    {
        // Direct property access
        byte[] encodedValue = GetEncodedValue(pointer);
        if (encodedValue.Length == 0)
        {
            ThrowPropertyNotFoundException(pointer);
            return default;
        }
        return encodedValue;
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
    {
        var jsonSpan = value.ToMemory().Span;

        if (jsonSpan.SequenceEqual(s_nullValueArray.AsSpan(1)))
        {
            return s_nullValueArray;
        }

        if (jsonSpan.SequenceEqual(s_falseBooleanArray.AsSpan(1)))
        {
            return s_falseBooleanArray;
        }

        if (jsonSpan.SequenceEqual(s_trueBooleanArray.AsSpan(1)))
        {
            return s_trueBooleanArray;
        }

        return [(byte)ValueKind.Json, .. value.ToMemory().Span];
    }

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

    private void SetInternal(ReadOnlySpan<byte> jsonPath, byte[] encodedValue)
    {
        if (_properties == null)
        {
            _properties = new Dictionary<byte[], byte[]>(ByteArrayEqualityComparer.Instance);
        }

        var nameBytes = jsonPath.ToArray();

        if (((ValueKind)encodedValue[0]).HasFlag(ValueKind.Removed))
        {
            // if its remove we need to look at parents before inserting
            if (!_properties.TryGetValue(nameBytes, out var currentValue))
            {
                if (TryGetParentMatch(jsonPath, false, out var parentBytes, out currentValue))
                {
                    var childSlice = jsonPath.Slice(parentBytes.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Remove(childPath);
                    _properties[parentBytes] = modifiedValue;
                }
                else
                {
                    _properties[nameBytes] = encodedValue;
                }
            }
        }
        else
        {
            var indexSpan = jsonPath.GetIndexSpan();
            if (!indexSpan.IsEmpty)
            {
                encodedValue[0] |= (byte)ValueKind.ArrayItem; // Mark as array item
            }

            if (indexSpan.Length == 1 && indexSpan[0] == (byte)'-')
            {
                var arrayNameBytes = jsonPath.GetParent().ToArray();
                // array insert
                if (_arrayIndices == null)
                {
                    _arrayIndices = new Dictionary<byte[], int>(ByteArrayEqualityComparer.Instance);
                }

                if (!_arrayIndices.TryGetValue(arrayNameBytes, out var usedIndex))
                {
                    usedIndex = 0;
                    _arrayIndices[arrayNameBytes] = usedIndex;
                }
                else
                {
                    usedIndex++;
                    _arrayIndices[arrayNameBytes] = usedIndex;
                }
                _properties[[.. jsonPath.Slice(0, jsonPath.Length - 2), .. Encoding.UTF8.GetBytes(usedIndex.ToString()), (byte)']']] = encodedValue;
            }
            else
            {
                var parent = jsonPath.GetParent();
                if (parent.IsEmpty || parent.IsRoot() || !_properties.TryGetValue(parent.ToArray(), out var currentValue))
                {
                    _properties[jsonPath.ToArray()] = encodedValue;
                }
                else
                {
                    // if we have a parent, we need to modify the parent value
                    var childSlice = jsonPath.Slice(parent.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Replace(childPath, encodedValue);
                    _properties[parent.ToArray()] = modifiedValue;
                }
            }
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

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, byte[] encodedValue)
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private void ThrowPropertyNotFoundException(ReadOnlySpan<byte> name)
    {
        throw new KeyNotFoundException(Encoding.UTF8.GetString(name.ToArray()));
    }
}
