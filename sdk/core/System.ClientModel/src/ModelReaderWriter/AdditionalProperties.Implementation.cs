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
    private Dictionary<byte[], EncodedValue>? _properties;
#if NET9_0_OR_GREATER
    private Dictionary<byte[], EncodedValue>.AlternateLookup<ReadOnlySpan<byte>> _alternateProperties;
#endif
    private Dictionary<byte[], int>? _arrayIndices;
#if NET9_0_OR_GREATER
    private Dictionary<byte[], int>.AlternateLookup<ReadOnlySpan<byte>> _alternateArrayIndices;
#endif
    private HashSet<byte[]>? _propagated;
#if NET9_0_OR_GREATER
    private HashSet<byte[]>.AlternateLookup<ReadOnlySpan<byte>> _alternatePropagated;
#endif

    private delegate T? SpanParser<T>(ReadOnlySpan<byte> buffer, ReadOnlySpan<byte> span);

    // Singleton arrays for common values
    private static readonly EncodedValue s_removedValueArray = new(ValueKind.Removed, Array.Empty<byte>());
    private static readonly EncodedValue s_nullValueArray;
    private static readonly EncodedValue s_trueBooleanArray;
    private static readonly EncodedValue s_falseBooleanArray;

    private readonly EncodedValue _rawJson;

    // Static constructor to initialize singleton arrays
    static AdditionalProperties()
    {
        // Initialize null value array
        s_nullValueArray = new(ValueKind.Null, "null"u8.ToArray());
        // Initialize true boolean array
        s_trueBooleanArray = new(ValueKind.BooleanTrue, "true"u8.ToArray());
        // Initialize false boolean array
        s_falseBooleanArray = new(ValueKind.BooleanFalse, "false"u8.ToArray());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool PropagatedContains(ReadOnlySpan<byte> jsonPath)
    {
        if (_propagated == null)
        {
            return false;
        }

#if NET9_0_OR_GREATER
        return _alternatePropagated.Contains(jsonPath);
#else
        return _propagated.Contains(jsonPath.ToArray());
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void PropagatedAdd(ReadOnlySpan<byte> jsonPath)
    {
        if (_propagated == null)
        {
            _propagated = new(JsonPathComparer.Default);
#if NET9_0_OR_GREATER
            _alternatePropagated = _propagated.GetAlternateLookup<ReadOnlySpan<byte>>();
#endif
        }

#if NET9_0_OR_GREATER
        _alternatePropagated.Add(jsonPath);
#else
        _propagated.Add(jsonPath.ToArray());
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryGetValueFromProperties(ReadOnlySpan<byte> jsonPath, out EncodedValue value)
    {
        // This is just to minimize the #if we expect you have done the null check before calling this method
#if NET9_0_OR_GREATER
        return _alternateProperties.TryGetValue(jsonPath, out value);
#else
        return _properties!.TryGetValue(jsonPath.ToArray(), out value);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetValueOnProperties(ReadOnlySpan<byte> jsonPath, EncodedValue value)
    {
        // This is just to minimize the #if we expect you have done the null check before calling this method
#if NET9_0_OR_GREATER
        _alternateProperties[jsonPath] = value;
#else
        _properties![jsonPath.ToArray()] = value;
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryGetValueFromArrayIndicies(ReadOnlySpan<byte> jsonPath, out int value)
    {
        // This is just to minimize the #if we expect you have done the null check before calling this method
#if NET9_0_OR_GREATER
        return _alternateArrayIndices.TryGetValue(jsonPath, out value);
#else
        return _arrayIndices!.TryGetValue(jsonPath.ToArray(), out value);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetValueOnArrayIndicies(ReadOnlySpan<byte> jsonPath, int value)
    {
        // This is just to minimize the #if we expect you have done the null check before calling this method
#if NET9_0_OR_GREATER
        _alternateArrayIndices[jsonPath] = value;
#else
        _arrayIndices![jsonPath.ToArray()] = value;
#endif
    }

    // Helper method to get raw encoded value bytes
    private ReadOnlyMemory<byte> GetValue(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
        {
            if (TryGetParentMatch(jsonPath, true, out var parentPath, out var currentValue))
            {
                if (parentPath.IsRoot())
                {
                    return currentValue.Value.GetJson(jsonPath);
                }
            }
            ThrowPropertyNotFoundException(jsonPath);
        }

        if (jsonPath.IsArrayInsert())
        {
            return CombineAllArrayItems(jsonPath);
        }

        if (!TryGetValueFromProperties(jsonPath, out var encodedValue))
        {
            if (TryGetParentMatch(jsonPath, true, out var parentPath, out var currentValue))
            {
                if (!parentPath.IsRoot())
                {
                    var childSlice = jsonPath.Slice(parentPath.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    return currentValue.Value.GetJson(childPath);
                }
                else
                {
                    return currentValue.Value.GetJson(jsonPath);
                }
            }

            ThrowPropertyNotFoundException(jsonPath);
            return ReadOnlyMemory<byte>.Empty;
        }
        else
        {
            return encodedValue.Value;
        }
    }

    private bool TryGetParentMatch(ReadOnlySpan<byte> jsonPath, bool includeRoot, [NotNullWhen(true)] out ReadOnlySpan<byte> parentPath, out EncodedValue encodedValue)
    {
        parentPath = default;
        encodedValue = EncodedValue.Empty;
        if (_properties == null)
        {
            if (includeRoot && !_rawJson.Value.IsEmpty)
            {
                encodedValue = _rawJson;
                parentPath = "$"u8;
                return true;
            }
            return false;
        }

        parentPath = jsonPath.GetParent();
        while (parentPath.Length > 0)
        {
            if (TryGetValueFromProperties(parentPath, out encodedValue))
            {
                return true;
            }

            parentPath = parentPath.GetParent();

            if (parentPath.IsRoot())
                break;
        }

        if (parentPath.IsRoot() && includeRoot && !_rawJson.Value.IsEmpty)
        {
            encodedValue = _rawJson;
            return true;
        }

        return false;
    }

    private ReadOnlyMemory<byte> CombineAllArrayItems(ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
        {
            return ReadOnlyMemory<byte>.Empty;
        }

        var rootArrayName = jsonPath.Slice(0, jsonPath.Length - 2);
        //is it worth it to calculate the size?
        int size = 0;
        int count = 0;
        foreach (var kvp in _properties)
        {
            if (rootArrayName.Length == kvp.Key.Length || !kvp.Key.AsSpan().StartsWith(rootArrayName))
                continue;

            count++;
            size += kvp.Value.Value.Length;
        }

        if (count == 0)
        {
            //check for the full array entry
            if (TryGetValueFromProperties(jsonPath.GetParent(), out var fullArrayValue))
            {
                return fullArrayValue.Value;
            }
            return ReadOnlyMemory<byte>.Empty;
        }
        else
        {
            //combine all entries that start with the name
            using var memoryStream = new MemoryStream(size + count + 2);
            memoryStream.WriteByte((byte)'[');
            int current = 0;
            foreach (var kvp in _properties)
            {
                if (rootArrayName.Length == kvp.Key.Length || !kvp.Key.AsSpan().StartsWith(rootArrayName))
                    continue;

#if NET6_0_OR_GREATER
                memoryStream.Write(kvp.Value.Value.Span);
#else
                memoryStream.Write(kvp.Value.Value.ToArray(), 0, kvp.Value.Value.Length);
#endif
                if (current++ < count - 1)
                {
                    memoryStream.WriteByte((byte)',');
                }
            }
            memoryStream.WriteByte((byte)']');
            return memoryStream.GetBuffer().AsMemory(0, (int)memoryStream.Length);
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

    private static EncodedValue EncodeValue(bool value)
        => value ? s_trueBooleanArray : s_falseBooleanArray;

    private static EncodedValue EncodeValue(byte[] value)
        => new(ValueKind.Json, value);

    private static EncodedValue EncodeValue(BinaryData value)
    {
        var jsonSpan = value.ToMemory().Span;

        if (jsonSpan.SequenceEqual(s_nullValueArray.Value.Span))
        {
            return s_nullValueArray;
        }

        if (jsonSpan.SequenceEqual(s_falseBooleanArray.Value.Span))
        {
            return s_falseBooleanArray;
        }

        if (jsonSpan.SequenceEqual(s_trueBooleanArray.Value.Span))
        {
            return s_trueBooleanArray;
        }

        return new(ValueKind.Json, value.ToMemory());
    }

    private static EncodedValue EncodeValue(int value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Int32, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode integer value '{value}'.");
    }

    private static EncodedValue EncodeValue(ReadOnlySpan<byte> value)
        => new(ValueKind.Json, value.ToArray());

    private static EncodedValue EncodeValue(string value)
    {
        byte[] bytes = [(byte)'"', .. Encoding.UTF8.GetBytes(value), (byte)'"'];
        return new(ValueKind.Utf8String, bytes);
    }

    // Helper methods to encode objects to byte arrays (similar to PropertyRecord format)
    private static EncodedValue EncodeValue(object value)
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

            default:
                throw new NotSupportedException($"Unsupported value type: {value?.GetType()}");
        }
    }

    // Helper method to decode byte arrays back to objects (for backward compatibility)
    private static object DecodeValue(EncodedValue encodedValue)
    {
        if (encodedValue.Value.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = encodedValue.Kind;
        ReadOnlySpan<byte> valueBytes = encodedValue.Value.Span;

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
                return s_removedValueArray.Value;

            case ValueKind.Null:
                return s_nullValueArray.Value;

            default:
                throw new ArgumentException($"Unknown value kind: {kind}");
        }
    }

    private void SetInternal(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (_properties == null)
        {
            _properties = new(JsonPathComparer.Default);
#if NET9_0_OR_GREATER
            _alternateProperties = _properties.GetAlternateLookup<ReadOnlySpan<byte>>();
#endif
        }

        if (encodedValue.Kind.HasFlag(ValueKind.Removed))
        {
            // if its remove we need to look at parents before inserting
            if (!TryGetValueFromProperties(jsonPath, out var currentValue))
            {
                if (TryGetParentMatch(jsonPath, false, out var parentBytes, out currentValue))
                {
                    var childSlice = jsonPath.Slice(parentBytes.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Value.Remove(childPath);
                    SetValueOnProperties(parentBytes, new(currentValue.Kind, modifiedValue));
                }
                else
                {
                    SetValueOnProperties(jsonPath, encodedValue);
                }
            }
        }
        else
        {
            var indexSpan = jsonPath.GetIndexSpan();
            if (!indexSpan.IsEmpty && !encodedValue.Kind.HasFlag(ValueKind.ArrayItem))
            {
                // Mark as array item
                encodedValue = new(ValueKind.ArrayItem | encodedValue.Kind, encodedValue.Value);
            }

            if (indexSpan.Length == 1 && indexSpan[0] == (byte)'-')
            {
                var arrayName = jsonPath.GetParent();
                // array insert
                if (_arrayIndices == null)
                {
                    _arrayIndices = new(JsonPathComparer.Default);
#if NET9_0_OR_GREATER
                    _alternateArrayIndices = _arrayIndices.GetAlternateLookup<ReadOnlySpan<byte>>();
#endif
                }

                if (!TryGetValueFromArrayIndicies(arrayName, out var usedIndex))
                {
                    usedIndex = 0;
                }
                else
                {
                    usedIndex++;
                }
                SetValueOnArrayIndicies(arrayName, usedIndex);
                _properties[[.. jsonPath.Slice(0, jsonPath.Length - 2), .. Encoding.UTF8.GetBytes(usedIndex.ToString()), (byte)']']] = encodedValue;
            }
            else
            {
                var parent = jsonPath.GetParent();
                if (parent.IsEmpty || parent.IsRoot() || !TryGetValueFromProperties(parent, out var currentValue))
                {
                    SetValueOnProperties(jsonPath, encodedValue);
                }
                else
                {
                    // if we have a parent, we need to modify the parent value
                    var childSlice = jsonPath.Slice(parent.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Value.Replace(childPath, encodedValue.Value);
                    SetValueOnProperties(parent, new(currentValue.Kind, modifiedValue));
                }
            }
        }
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, EncodedValue encodedValue)
    {
        // Helper method to write encoded byte values as JSON

        if (encodedValue.Value.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = encodedValue.Kind & ~ValueKind.ArrayItem;
        ReadOnlySpan<byte> valueBytes = encodedValue.Value.Span;

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
    private void ThrowPropertyNotFoundException(ReadOnlySpan<byte> jsonPath)
    {
        throw new KeyNotFoundException(Encoding.UTF8.GetString(jsonPath.ToArray()));
    }
}
