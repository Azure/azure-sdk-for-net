// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Buffers.Text;
using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public partial struct JsonPatch
{
    // Dictionary-based storage using UTF8 byte arrays as keys and encoded byte arrays as values
    private SpanDictionary? _properties;

    private PropagatorSetter? _propagatorSetter;
    private PropagatorGetter? _propagatorGetter;
    private PropagatorIsFlattened? _propagatorIsFlattened;

    // Singleton arrays for common values
    private static readonly EncodedValue s_removedValueArray = new(ValueKind.Removed, Array.Empty<byte>());
    private static readonly EncodedValue s_nullValueArray;
    private static readonly EncodedValue s_trueBooleanArray;
    private static readonly EncodedValue s_falseBooleanArray;

    private readonly EncodedValue _rawJson;

    // Static constructor to initialize singleton arrays
    static JsonPatch()
    {
        // Initialize null value array
        s_nullValueArray = new(ValueKind.Null, "null"u8.ToArray());
        // Initialize true boolean array
        s_trueBooleanArray = new(ValueKind.BooleanTrue, "true"u8.ToArray());
        // Initialize false boolean array
        s_falseBooleanArray = new(ValueKind.BooleanFalse, "false"u8.ToArray());
    }

    private ReadOnlyMemory<byte> GetEncodedValue(ReadOnlySpan<byte> jsonPath)
    {
        if (TryGetEncodedValue(jsonPath, out var value))
        {
            return value.Value;
        }
        ThrowPropertyNotFoundException(jsonPath);
        return ReadOnlyMemory<byte>.Empty;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out bool value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out bool result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out byte value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out byte result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out DateTime value, StandardFormat format = default)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out DateTime result, out _, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out DateTimeOffset value, StandardFormat format = default)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out DateTimeOffset result, out _, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out decimal value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out decimal result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out double value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out double result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out float value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out float result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out Guid value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out Guid result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out int value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out int result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out long value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out long result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out sbyte value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out sbyte result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out short value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out short result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out TimeSpan value, StandardFormat format = default)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out TimeSpan result, out _, format.Symbol))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out uint value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out uint result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out ulong value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out ulong result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeValue(EncodedValue encodedValue, out ushort value)
    {
        if (Utf8Parser.TryParse(encodedValue.Value.Span, out ushort result, out _))
        {
            value = result;
            return true;
        }

        value = default;
        return false;
    }

    private bool TryDecodeNullableValue<T>(EncodedValue encodedValue, out T? value, out bool supportedType)
        where T : struct
    {
        value = default;
        supportedType = true;

        if (encodedValue.Value.Span.SequenceEqual(s_nullValueArray.Value.Span))
        {
            return true;
        }

        Type target = typeof(T);
        bool parsed;

        if (target == typeof(bool))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out bool boolValue, out _);
            value = parsed ? (T?)(object)boolValue : null;
            return parsed;
        }
        if (target == typeof(byte))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out byte byteValue, out _);
            value = parsed ? (T?)(object)byteValue : null;
            return parsed;
        }
        if (target == typeof(sbyte))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out sbyte sbyteValue, out _);
            value = parsed ? (T?)(object)sbyteValue : null;
            return parsed;
        }
        if (target == typeof(short))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out short shortValue, out _);
            value = parsed ? (T?)(object)shortValue : null;
            return parsed;
        }
        if (target == typeof(ushort))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out ushort ushortValue, out _);
            value = parsed ? (T?)(object)ushortValue : null;
            return parsed;
        }
        if (target == typeof(int))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out int intValue, out _);
            value = parsed ? (T?)(object)intValue : null;
            return parsed;
        }
        if (target == typeof(uint))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out uint uintValue, out _);
            value = parsed ? (T?)(object)uintValue : null;
            return parsed;
        }
        if (target == typeof(long))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out long longValue, out _);
            value = parsed ? (T?)(object)longValue : null;
            return parsed;
        }
        if (target == typeof(ulong))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out ulong ulongValue, out _);
            value = parsed ? (T?)(object)ulongValue : null;
            return parsed;
        }
        if (target == typeof(float))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out float floatValue, out _);
            value = parsed ? (T?)(object)floatValue : null;
            return parsed;
        }
        if (target == typeof(double))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out double doubleValue, out _);
            value = parsed ? (T?)(object)doubleValue : null;
            return parsed;
        }
        if (target == typeof(decimal))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out decimal decimalValue, out _);
            value = parsed ? (T?)(object)decimalValue : null;
            return parsed;
        }
        if (target == typeof(DateTime))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out DateTime dateTimeValue, out _);
            value = parsed ? (T?)(object)dateTimeValue : null;
            return parsed;
        }
        if (target == typeof(DateTimeOffset))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out DateTimeOffset dateTimeOffsetValue, out _);
            value = parsed ? (T?)(object)dateTimeOffsetValue : null;
            return parsed;
        }
        if (target == typeof(Guid))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out Guid guidValue, out _);
            value = parsed ? (T?)(object)guidValue : null;
            return parsed;
        }
        if (target == typeof(TimeSpan))
        {
            parsed = Utf8Parser.TryParse(encodedValue.Value.Span, out TimeSpan timeSpanValue, out _);
            value = parsed ? (T?)(object)timeSpanValue : null;
            return parsed;
        }

        supportedType = false;
        return false;
    }

    private bool TryGetEncodedValue(ReadOnlySpan<byte> jsonPath, out EncodedValue value)
    {
        value = EncodedValue.Empty;
        EncodedValue encodedValue;

        // if root is overridden we should not propagate.
        if (jsonPath.SequenceEqual("$"u8))
        {
            if (_properties is not null && _properties.TryGetValue(jsonPath, out encodedValue))
            {
                if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    value = new(encodedValue.Kind, GetCombinedArray(jsonPath, encodedValue));
                }
                else
                {
                    value = encodedValue;
                }
                return true;
            }

            return false;
        }

        if (_propagatorGetter is not null && _propagatorGetter(jsonPath, out value))
        {
            return true;
        }

        if (_properties == null)
        {
            if (TryGetParentMatch(jsonPath, true, out _, out encodedValue))
            {
                value = new(encodedValue.Kind, encodedValue.Value.GetJson(jsonPath));
                return true;
            }
            return false;
        }

        if (_properties.TryGetValue(jsonPath, out encodedValue))
        {
            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                value = new(ValueKind.Json, GetCombinedArray(jsonPath, encodedValue));
            }
            else
            {
                value = encodedValue;
            }
            return true;
        }

        Span<byte> childPath = stackalloc byte[jsonPath.Length];

        // if jsonPath is an array index and its direct parent is not an insert skip root merger
        ReadOnlySpan<byte> directParent = jsonPath.GetParent();
        if (jsonPath.IsArrayIndex() && _properties.TryGetValue(directParent, out var parentValue) &&
            !parentValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
        {
            GetSubPath(directParent, jsonPath, ref childPath);
            value = new(parentValue.Kind, parentValue.Value.GetJson(childPath));
            return true;
        }

        if (TryGetParentMatch(jsonPath, true, out var parentPath, out encodedValue))
        {
            // if the jsonPath has arrays I need to check if they exist in the root first then patch

            JsonPathReader reader = new(jsonPath);
            reader.Advance(parentPath);
            ReadOnlySpan<byte> arrayPath = reader.GetNextArray();
            if (arrayPath.IsEmpty)
            {
                // no array in path
                GetSubPath(parentPath, jsonPath, ref childPath);
                value = new(encodedValue.Kind, encodedValue.Value.GetJson(childPath));
                return true;
            }

            // see if the requested index exist in root first
            // collect adjust indexes in a new path as I go
            Span<byte> adjustedJsonPath = stackalloc byte[jsonPath.Length];
            jsonPath.CopyTo(adjustedJsonPath);
            int adjustLength = jsonPath.Length;
            int indexLength = reader.Current.ValueSpan.Length;
            int indexStart = reader.Current.TokenStartIndex;
            int indexRequested = 0;
            ReadOnlySpan<byte> lastArrayPath;

            Span<byte> normalizedPrefixBuffer = stackalloc byte[jsonPath.Length];

            while (!arrayPath.IsEmpty)
            {
                lastArrayPath = arrayPath;
                indexLength = reader.Current.ValueSpan.Length;
                indexStart = reader.Current.TokenStartIndex;

                if (TryGetArrayItemFromRoot(arrayPath, reader, out indexRequested, out var length, out var arrayItem))
                {
                    GetSubPath(arrayPath, jsonPath, ref childPath);
                    value = new(ValueKind.Json, GetCombinedArray(jsonPath, arrayItem.GetJson(childPath), EncodedValue.Empty));
                    return true;
                }

                // subtract by max sibling index $[4]
                int maxSibling = -1;
                JsonPathComparer.Default.Normalize(arrayPath.GetParent(), normalizedPrefixBuffer, out var bytesWritten);
                var normalizedPrefix = normalizedPrefixBuffer.Slice(0, bytesWritten);

                foreach (var kvp in _properties)
                {
                    if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                        continue;

                    ReadOnlySpan<byte> keySpan = kvp.Key;
                    if (!keySpan.StartsWith(normalizedPrefix))
                        continue;

                    keySpan = keySpan.Slice(normalizedPrefix.Length);

                    if (keySpan.Length < 2 || keySpan[0] != (byte)'[' || keySpan[keySpan.Length - 1] != (byte)']')
                        continue;

                    if (Utf8Parser.TryParse(keySpan.Slice(1, keySpan.Length - 2), out int index, out _))
                        maxSibling = Math.Max(maxSibling, index);
                }

                AdjustJsonPath(indexRequested - Math.Max(length, (maxSibling + 1)), ref indexLength, adjustedJsonPath.Slice(indexStart, indexLength), ref adjustLength);

                arrayPath = reader.GetNextArray();
            }

            GetSubPath(parentPath, adjustedJsonPath.Slice(0, adjustLength), ref childPath);
            value = new(encodedValue.Kind, encodedValue.Value.GetJson(childPath));
            return true;
        }

        return false;
    }

    private void AdjustJsonPath(int newIndex, ref int indexLength, Span<byte> buffer, ref int length)
    {
        Utf8Formatter.TryFormat(newIndex, buffer, out var bytesWritten);
        int shift = indexLength - bytesWritten;
        if (shift > 0)
        {
            indexLength = bytesWritten;
            buffer.Slice(indexLength + 1).CopyTo(buffer.Slice(bytesWritten + 1));
            length -= shift;
        }
    }

    private bool TryGetArrayItemFromRoot(ReadOnlySpan<byte> jsonPath, JsonPathReader reader, out int indexRequested, out int length, out ReadOnlyMemory<byte> arrayItem)
    {
        length = 0;
        indexRequested = 0;
        arrayItem = ReadOnlyMemory<byte>.Empty;

        if (!Utf8Parser.TryParse(jsonPath.GetIndexSpan(), out indexRequested, out _))
            return false;

        if (!TryGetRootJson(out var rootJson, true))
            return false;

        Utf8JsonReader jsonReader = new(rootJson.Span);
        if (!jsonReader.Advance(jsonPath.GetParent()))
            return false;

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        if (jsonReader.TokenType != JsonTokenType.StartArray)
            return false;

        if (!jsonReader.SkipToIndex(indexRequested, out length))
            return false;

        long start = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        long end = jsonReader.BytesConsumed;
        arrayItem = rootJson.Slice((int)start, (int)(end - start));
        return true;
    }

    private ReadOnlyMemory<byte> GetCombinedArray(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue, bool onlyRaw = true)
    {
        TryGetRootJson(out var rootJson, onlyRaw);

        rootJson.TryGetJson(jsonPath, out var existingArray);

        return GetCombinedArray(jsonPath, existingArray, encodedValue);
    }

    private ReadOnlyMemory<byte> GetCombinedArray(ReadOnlySpan<byte> jsonPath, ReadOnlyMemory<byte> existingArray, EncodedValue encodedValue)
    {
        if (_properties is not null)
        {
            Span<byte> normalizedPrefix = stackalloc byte[jsonPath.Length];
            byte[] childPath = new byte[_properties.MaxKeyLength];
            JsonPathComparer.Default.Normalize(jsonPath, normalizedPrefix, out int bytesWritten);
            normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

            foreach (var kvp in _properties)
            {
                if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                    continue;

                ReadOnlySpan<byte> keySpan = kvp.Key;

                if (!keySpan.StartsWith(normalizedPrefix))
                    continue;

                if (existingArray.IsEmpty)
                {
                    existingArray = keySpan.SequenceEqual(normalizedPrefix) ? encodedValue.Value : new([(byte)'[', .. kvp.Value.Value.Span, (byte)']']);
                }
                else
                {
                    GetSubPath(normalizedPrefix, kvp.Key, childPath, out int childPathLength);
                    ReadOnlySpan<byte> childJsonPath = childPath.AsSpan(0, childPathLength);
                    if (childJsonPath.IsArrayIndex())
                    {
                        Utf8Parser.TryParse(kvp.Key.GetIndexSpan(), out int index, out _);
                        existingArray = existingArray.InsertAt(childJsonPath, index, kvp.Value.Value);
                    }
                    else
                    {
                        existingArray = existingArray.Append(childJsonPath, kvp.Value.Value.Slice(1, kvp.Value.Value.Length - 2));
                    }
                }
            }
            return existingArray.IsEmpty ? encodedValue.Value : existingArray;
        }
        else
        {
            if (existingArray.IsEmpty)
            {
                return encodedValue.Value;
            }
            return new([.. existingArray.Span.Slice(0, existingArray.Length - 1), (byte)',', .. encodedValue.Value.Span.Slice(1)]);
        }
    }

    private bool TryGetRootJson(out ReadOnlyMemory<byte> value, bool onlyRaw = false)
    {
        value = ReadOnlyMemory<byte>.Empty;

        if (_properties is null && _rawJson.Value.IsEmpty)
            return false;

        if (!onlyRaw && _properties?.TryGetValue("$"u8, out var encodedRoot) == true && (encodedRoot.Kind.HasFlag(ValueKind.ArrayItemAppend) ? _rawJson.Value.IsEmpty : true))
        {
            value = encodedRoot.Value;
            return true;
        }

        value = _rawJson.Value;
        return !value.IsEmpty;
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

        if (parentPath.IsRoot() && includeRoot)
        {
            if (_properties.TryGetValue(parentPath, out encodedValue))
                return true;

            if (!_rawJson.Value.IsEmpty)
            {
                encodedValue = _rawJson;
                return true;
            }
        }

        return false;
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

    #region Encode Value
    private static EncodedValue EncodeValue(bool value)
        => value ? s_trueBooleanArray : s_falseBooleanArray;

    private static EncodedValue EncodeValue(byte value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(DateTime value, StandardFormat format = default)
    {
        Span<byte> buffer = stackalloc byte[64];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
        {
            return new(ValueKind.DateTime, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(DateTimeOffset value, StandardFormat format = default)
    {
        Span<byte> buffer = stackalloc byte[64];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
        {
            return new(ValueKind.DateTime, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(decimal value)
    {
        Span<byte> buffer = stackalloc byte[64];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(double value)
    {
        Span<byte> buffer = stackalloc byte[64];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(Guid value)
    {
        Span<byte> buffer = stackalloc byte[128];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Guid, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(int value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(long value)
    {
        Span<byte> buffer = stackalloc byte[20];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(sbyte value)
    {
        Span<byte> buffer = stackalloc byte[8];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(short value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(TimeSpan value, StandardFormat format = default)
    {
        Span<byte> buffer = stackalloc byte[64];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten, format))
        {
            return new(ValueKind.TimeSpan, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(uint value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(ulong value)
    {
        Span<byte> buffer = stackalloc byte[20];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(ushort value)
    {
        Span<byte> buffer = stackalloc byte[11];
        if (Utf8Formatter.TryFormat(value, buffer, out var bytesWritten))
        {
            return new(ValueKind.Number, buffer.Slice(0, bytesWritten).ToArray());
        }

        // not sure how we could ever get here.
        throw new InvalidOperationException($"Failed to encode value '{value}'.");
    }

    private static EncodedValue EncodeValue(string value)
    {
        return new(ValueKind.Utf8String, Encoding.UTF8.GetBytes(value));
    }

    private static EncodedValue EncodeValue(byte[] value)
    {
        if (TryGetKnownValue(value, out var encodedValue))
        {
            return encodedValue;
        }
        return new(ValueKind.Json, value);
    }

    private static EncodedValue EncodeValue(BinaryData value)
    {
        var rom = value.ToMemory();

        if (TryGetKnownValue(rom.Span, out var encodedValue))
        {
            return encodedValue;
        }

        return new(ValueKind.Json, rom);
    }

    private static EncodedValue EncodeValue(ReadOnlySpan<byte> value)
    {
        if (TryGetKnownValue(value, out var encodedValue))
        {
            return encodedValue;
        }
        return new(ValueKind.Json, value.ToArray());
    }

    private static bool TryGetKnownValue(ReadOnlySpan<byte> jsonSpan, out EncodedValue encodedValue)
    {
        if (jsonSpan.SequenceEqual(s_nullValueArray.Value.Span))
        {
            encodedValue = s_nullValueArray;
            return true;
        }
        if (jsonSpan.SequenceEqual(s_falseBooleanArray.Value.Span))
        {
            encodedValue = s_falseBooleanArray;
            return true;
        }
        if (jsonSpan.SequenceEqual(s_trueBooleanArray.Value.Span))
        {
            encodedValue = s_trueBooleanArray;
            return true;
        }
        encodedValue = EncodedValue.Empty;
        return false;
    }
    #endregion

    private void SetInternal(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (_propagatorSetter is not null && _propagatorSetter(jsonPath, encodedValue))
            return;

        EncodedValue currentValue = EncodedValue.Empty;

        ReadOnlySpan<byte> localPath = jsonPath;
        byte[] adjustedPath = new byte[jsonPath.Length];

        if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend) && !_rawJson.Value.IsEmpty)
        {
            if (_properties is not null && _properties.TryGetValue(jsonPath, out currentValue))
            {
                _properties.Set(jsonPath, new(currentValue.Kind, ModifyJson(currentValue, "$"u8, encodedValue)));
                return;
            }
            else
            {
                Utf8JsonReader jsonReader = new(_rawJson.Value.Span);
                JsonPathReader pathReader = new(jsonPath);
                if (jsonReader.Advance(ref pathReader))
                {
                    _properties ??= new();
                    _properties.Set(jsonPath, new(encodedValue.Kind, GetNewJson("$"u8, encodedValue)));
                    return;
                }

                if (pathReader.Current.TokenType != JsonPathTokenType.End)
                {
                    var parsedPath = pathReader.GetParsedPath();
                    if (parsedPath.IsArrayIndex())
                    {
                        jsonReader = new(_rawJson.Value.Span);
                        int length = jsonReader.GetArrayLength(parsedPath.GetParent());
                        Utf8Parser.TryParse(pathReader.Current.ValueSpan, out int index, out _);
                        int indexLength = pathReader.Current.ValueSpan.Length;
                        int newLength = parsedPath.Length;
                        parsedPath.CopyTo(adjustedPath);
                        AdjustJsonPath(index - length, ref indexLength, adjustedPath.AsSpan(pathReader.Current.TokenStartIndex), ref newLength);
                        var remainingPath = jsonPath.Slice(pathReader.Current.TokenStartIndex + 2);
                        remainingPath.CopyTo(adjustedPath.AsSpan(newLength));
                        localPath = adjustedPath.AsSpan(0, newLength + remainingPath.Length);
                    }
                }
            }
        }

        Span<byte> childPath = stackalloc byte[localPath.Length];
        var parentPath = localPath.SequenceEqual(jsonPath) ? localPath : localPath.GetParent();
        var nextPath = localPath;

        if (_properties is not null)
        {
            while (true)
            {
                if (_properties.TryGetValue(parentPath, out currentValue))
                {
                    GetSubPath(parentPath, localPath, ref childPath);
                    _properties.Set(parentPath, new(currentValue.Kind, ModifyJson(currentValue, childPath, encodedValue)));
                    return;
                }

                if (parentPath.IsRoot())
                    break;

                nextPath = parentPath;
                parentPath = parentPath.GetParent();
            }
        }

        if (encodedValue.Kind == ValueKind.Removed && jsonPath.IsArrayIndex())
        {
            // we cannot remove an array index that doesn't exist
            throw new IndexOutOfRangeException($"Cannot remove non-existing array item at path '{Encoding.UTF8.GetString(jsonPath.ToArray())}'.");
        }

        ValueKind kind = ValueKind.Json;

        var jsonParentPath = localPath.GetParent();
        if (jsonParentPath.IsRoot())
        {
            // fast path if we are simply adding to root
            nextPath = localPath;
            parentPath = jsonParentPath;
        }
        else
        {
            if (_rawJson.Value.IsEmpty)
            {
                if (_properties is null)
                {
                    nextPath = localPath.GetFirstProperty();
                    parentPath = "$"u8;
                }
            }
            else
            {
                // since parentPath is not root we need to find how much of localPath exists in _rawJson
                // we need to set the key in _properties to that subPath of localPath

                JsonPathReader pathReader = new(jsonPath);
                Utf8JsonReader jsonReader = new(_rawJson.Value.Span);
                if (jsonReader.Advance(ref pathReader))
                {
                    nextPath = jsonPath;
                    parentPath = jsonParentPath;
                }
                else
                {
                    nextPath = pathReader.GetParsedPath();
                    parentPath = nextPath.GetParent();
                }
            }
        }

        if (nextPath.IsArrayIndex() && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
        {
            nextPath = parentPath;
            kind |= ValueKind.ArrayItemAppend;
        }

        if (nextPath.SequenceEqual(localPath))
        {
            kind = encodedValue.Kind;
        }

        GetSubPath(nextPath, localPath, ref childPath);

        _properties ??= new();
        _properties.Set(nextPath, new(kind, GetNewJson(childPath, encodedValue)));
    }

    private static void GetSubPath(ReadOnlySpan<byte> parentPath, ReadOnlySpan<byte> fullPath, Span<byte> subPath, out int bytesWritten)
    {
        if (parentPath.IsRoot())
        {
            fullPath.CopyTo(subPath);
            bytesWritten = fullPath.Length;
            return;
        }

        var childSlice = fullPath.Slice(parentPath.Length);
        subPath[0] = (byte)'$';
        childSlice.CopyTo(subPath.Slice(1));
        bytesWritten = childSlice.Length + 1;
    }

    private static void GetSubPath(ReadOnlySpan<byte> parentPath, ReadOnlySpan<byte> fullPath, ref Span<byte> subPath)
    {
        GetSubPath(parentPath, fullPath, subPath, out var bytesWritten);
        subPath = subPath.Slice(0, bytesWritten);
    }

    private ReadOnlyMemory<byte> ModifyJson(EncodedValue currentValue, ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (!currentValue.Kind.HasFlag(ValueKind.Json) && !currentValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
        {
            //we are a primitive so just return the new value
            return encodedValue.Value;
        }

        ReadOnlyMemory<byte> json = currentValue.Value;
        if (encodedValue.Kind == ValueKind.Removed)
        {
            return json.Remove(jsonPath);
        }

        JsonPathReader pathReader = new(jsonPath);
        Utf8JsonReader jsonReader = new(json.Span);

        bool jsonFound = jsonReader.Advance(ref pathReader);

        ReadOnlyMemory<byte> data = NeedsQuotes(encodedValue.Kind) ? new([(byte)'"', .. encodedValue.Value.Span, (byte)'"']) : encodedValue.Value;
        ReadOnlySpan<byte> propertyName = pathReader.Current.ValueSpan;

        int index = 0;
        if (pathReader.Current.TokenType == JsonPathTokenType.ArrayIndex)
        {
            Utf8Parser.TryParse(pathReader.Current.ValueSpan, out index, out _);
        }
        if (pathReader.Current.TokenType != JsonPathTokenType.End || jsonReader.TokenType == JsonTokenType.Null)
        {
            data = GetNonRootNewJson(ref pathReader, jsonPath.GetParent().IsRoot(), jsonPath.IsArrayIndex(), encodedValue);
        }

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            jsonReader.Read();
        }

        if (jsonFound && (jsonReader.TokenType != JsonTokenType.StartArray || !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend)))
        {
            return jsonReader.SetCurrentValue(jsonFound, propertyName, json, data);
        }
        else
        {
            return jsonReader.Insert(json, propertyName, data, index > 0);
        }
    }

    private ReadOnlyMemory<byte> GetNewJson(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (encodedValue.Kind == ValueKind.Removed)
        {
            return encodedValue.Value;
        }

        if (jsonPath.IsRoot())
        {
            // fast path for root
            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                return NeedsQuotes(encodedValue.Kind)
                    ? new([(byte)'[', (byte)'"', .. encodedValue.Value.Span, (byte)'"', (byte)']'])
                    : new([(byte)'[', .. encodedValue.Value.Span, (byte)']']);
            }
            return encodedValue.Value;
        }

        JsonPathReader pathReader = new(jsonPath);

        return GetNonRootNewJson(ref pathReader, jsonPath.GetParent().IsRoot(), jsonPath.IsArrayIndex(), encodedValue);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool NeedsQuotes(ValueKind kind)
    {
        var stringKinds = ValueKind.Utf8String | ValueKind.TimeSpan | ValueKind.Guid | ValueKind.DateTime;
        return (kind & stringKinds) > 0 && kind.HasFlag(ValueKind.ArrayItemAppend);
    }

    private ReadOnlyMemory<byte> GetNonRootNewJson(ref JsonPathReader reader, bool isParentRoot, bool isArrayIndex, EncodedValue encodedValue)
    {
        using var buffer = new UnsafeBufferSequence();
        using var writer = new Utf8JsonWriter(buffer);

        if (reader.Peek().TokenType == JsonPathTokenType.End)
        {
            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                writer.WriteStartArray();
                WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                writer.WriteEndArray();
            }
            else
            {
                WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
            }
        }
        else
        {
            ProjectJson(writer, ref reader, encodedValue, false);
        }

        writer.Flush();
        using var bufferReader = buffer.ExtractReader();
        return bufferReader.ToBinaryData().ToMemory();
    }

    private void ProjectJson(Utf8JsonWriter writer, ref JsonPathReader pathReader, EncodedValue encodedValue, bool inArray)
    {
        while (pathReader.Read())
        {
            switch (pathReader.Current.TokenType)
            {
                case JsonPathTokenType.Root:
                    break;
                case JsonPathTokenType.ArrayIndex:
                    writer.WriteStartArray();
                    Utf8Parser.TryParse(pathReader.Current.ValueSpan, out int index, out _);
                    for (int i = 0; i < index; i++)
                    {
                        writer.WriteNullValue(); // Placeholder for array items
                    }
                    if (pathReader.Peek().TokenType == JsonPathTokenType.End)
                    {
                        if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                        {
                            writer.WriteStartArray();
                            WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                            writer.WriteEndArray();
                        }
                        else
                        {
                            WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                        }
                    }
                    else
                    {
                        ProjectJson(writer, ref pathReader, encodedValue, true);
                    }
                    writer.WriteEndArray();
                    break;
                case JsonPathTokenType.Property:
                    if (!inArray)
                    {
                        writer.WritePropertyName(pathReader.Current.ValueSpan);
                    }
                    if (pathReader.Peek().TokenType == JsonPathTokenType.End)
                    {
                        if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                        {
                            writer.WriteStartArray();
                            WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                            writer.WriteEndArray();
                        }
                        else
                        {
                            WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                        }
                    }
                    else
                    {
                        ProjectJson(writer, ref pathReader, encodedValue, false);
                    }
                    break;
                case JsonPathTokenType.PropertySeparator:
                    writer.WriteStartObject();
                    if (pathReader.Peek().TokenType == JsonPathTokenType.End)
                    {
                        WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                    }
                    else
                    {
                        ProjectJson(writer, ref pathReader, encodedValue, false);
                    }
                    writer.WriteEndObject();
                    break;
                case JsonPathTokenType.End:
                    if (writer.BytesPending == 0 && writer.BytesCommitted == 0)
                    {
                        WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, encodedValue);
                    }
                    break;
                default:
                    throw new Exception($"Unexpected token type: {pathReader.Current.TokenType}");
            }
        }
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, EncodedValue encodedValue)
    {
        if (encodedValue.Value.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = encodedValue.Kind & ~ValueKind.ArrayItemAppend;
        ReadOnlySpan<byte> valueBytes = encodedValue.Value.Span;

        if (!propertyName.IsEmpty)
            writer.WritePropertyName(propertyName);

        switch (kind)
        {
            case ValueKind.Number:
                // valueBytes contains JSON number representation
                writer.WriteRawValue(valueBytes);
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

            case ValueKind.Utf8String:
            case ValueKind.TimeSpan:
            case ValueKind.Guid:
            case ValueKind.DateTime:
                writer.WriteStringValue(valueBytes);
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
