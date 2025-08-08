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

    private PropagatorSetter? _propagatorSetter;
    private PropagatorGetter? _propagatorGetter;

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

    private ReadOnlyMemory<byte> GetValue(ReadOnlySpan<byte> jsonPath)
    {
        if (TryGetValue(jsonPath, out var value))
        {
            return value;
        }
        ThrowPropertyNotFoundException(jsonPath);
        return ReadOnlyMemory<byte>.Empty;
    }

    // Helper method to get raw encoded value bytes
    private bool TryGetValue(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value)
    {
        value = ReadOnlyMemory<byte>.Empty;

        if (jsonPath.SequenceEqual("$"u8))
        {
            return GetRootJson(jsonPath, ref value);
        }

        if (_propagatorGetter is not null && _propagatorGetter(jsonPath, out var childValue))
        {
            value = childValue;
            return true;
        }

        if (_properties == null)
        {
            if (TryGetParentMatch(jsonPath, true, out var parentPath, out var currentValue))
            {
                if (parentPath.IsRoot())
                {
                    value = currentValue.Value.GetJson(jsonPath);
                    return true;
                }
            }
            return false;
        }

        if (!_properties.TryGetValue(jsonPath, out var encodedValue))
        {
            if (TryGetParentMatch(jsonPath, true, out var parentPath, out var currentValue))
            {
                if (parentPath.IsArrayInsert())
                {
                    int openBracketIndex = jsonPath.LastIndexOf((byte)'[');
                    Span<byte> childPath = stackalloc byte[jsonPath.Length - openBracketIndex + 1];
                    childPath[0] = (byte)'$';
                    jsonPath.Slice(openBracketIndex).CopyTo(childPath.Slice(1));
                    value = currentValue.Value.GetJson(childPath);
                    return true;
                }
                if (!parentPath.IsRoot())
                {
                    var childSlice = jsonPath.Slice(parentPath.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    value = currentValue.Value.GetJson(childPath);
                }
                else
                {
                    value = currentValue.Value.GetJson(jsonPath);
                }
                return true;
            }

            ThrowPropertyNotFoundException(jsonPath);
            return false;
        }
        else
        {
            value = encodedValue.Value;
            return true;
        }
    }

    private bool GetRootJson(ReadOnlySpan<byte> jsonPath, ref ReadOnlyMemory<byte> value)
    {
        if (_properties is null)
        {
            if (_rawJson.Value.IsEmpty)
            {
                return false;
            }
            else
            {
                value = _rawJson.Value;
                return true;
            }
        }
        else
        {
            if (_properties.TryGetValue(jsonPath, out var encodedValue))
            {
                value = encodedValue.Value;
                return true;
            }
            else
            {
                return false;
            }
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
            if (_properties.TryGetValue(parentPath, out encodedValue))
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
            if (_properties.TryGetValue(jsonPath.GetParent(), out var fullArrayValue))
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
        if (_propagatorSetter is not null && _propagatorSetter(jsonPath, encodedValue))
            return;

        if (_properties == null)
        {
            _properties = new(JsonPathComparer.Default);
        }

        if (encodedValue.Kind.HasFlag(ValueKind.Removed))
        {
            // if its remove we need to look at parents before inserting
            if (!_properties.TryGetValue(jsonPath, out var currentValue))
            {
                if (TryGetParentMatch(jsonPath, false, out var parentBytes, out currentValue))
                {
                    var childSlice = parentBytes.IsArrayInsert() ? jsonPath.Slice(parentBytes.Length - 3) : jsonPath.Slice(parentBytes.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Value.Remove(childPath);
                    _properties.Set(parentBytes, new(currentValue.Kind, modifiedValue));
                }
                else
                {
                    _properties.Set(jsonPath, encodedValue);
                }
            }
        }
        else
        {
            if (jsonPath.EndsWith("[-]"u8))
            {
                if (_properties.TryGetValue(jsonPath, out var currentValue))
                {
                    byte[] newValue = [.. currentValue.Value.Span.Slice(0, currentValue.Value.Span.Length - 1), (byte)',', .. encodedValue.Value.Span, (byte)']'];
                    _properties.Set(jsonPath, new(currentValue.Kind, newValue));
                }
                else
                {
                    byte[] newValue = [(byte)'[', .. encodedValue.Value.Span, (byte)']'];
                    _properties.Set(jsonPath, new(encodedValue.Kind, newValue));
                }
            }
            else
            {
                if (TryGetParentMatch(jsonPath, false, out var parentBytes, out var currentValue))
                {
                    // if we have a parent, we need to modify the parent value
                    var childSlice = parentBytes.IsArrayInsert() ? jsonPath.Slice(parentBytes.Length - 3) : jsonPath.Slice(parentBytes.Length);
                    Span<byte> childPath = stackalloc byte[childSlice.Length + 1];
                    childPath[0] = (byte)'$';
                    childSlice.CopyTo(childPath.Slice(1));
                    var modifiedValue = currentValue.Value.Set(childPath, encodedValue.Value);
                    _properties.Set(parentBytes, new(currentValue.Kind, modifiedValue));
                }
                else
                {
                    _properties.Set(jsonPath, encodedValue);
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
