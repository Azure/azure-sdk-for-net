// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

    private ReadOnlyMemory<byte> GetValue(ReadOnlySpan<byte> jsonPath)
    {
        if (TryGetValue(jsonPath, out var value))
        {
            return value;
        }
        ThrowPropertyNotFoundException(jsonPath);
        return ReadOnlyMemory<byte>.Empty;
    }

    private bool TryGetValue(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value)
    {
        value = ReadOnlyMemory<byte>.Empty;
        EncodedValue encodedValue;

        // if root is overridden we should not propagate.
        if (jsonPath.SequenceEqual("$"u8))
        {
            if (_properties is not null && _properties.TryGetValue(jsonPath, out encodedValue))
            {
                if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    value = GetCombinedArray(jsonPath, encodedValue);
                }
                else
                {
                    value = encodedValue.Value;
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
                value = encodedValue.Value.GetJson(jsonPath);
                return true;
            }
            return false;
        }

        if (_properties.TryGetValue(jsonPath, out encodedValue))
        {
            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                value = GetCombinedArray(jsonPath, encodedValue);
            }
            else
            {
                value = encodedValue.Value;
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
            value = parentValue.Value.GetJson(childPath);
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
                value = encodedValue.Value.GetJson(childPath);
                return true;
            }

            // see if the requested index exist in root first
            // collect adjust indexes in a new path as I go
            Span<byte> adjustJsonPath = stackalloc byte[jsonPath.Length];
            jsonPath.CopyTo(adjustJsonPath);
            int adjustLength = jsonPath.Length;
            while (!arrayPath.IsEmpty)
            {
                if (TryGetArrayItemFromRoot(arrayPath, reader, out var indexRequested, out var length, out var arrayItem))
                {
                    GetSubPath(arrayPath, jsonPath, ref childPath);
                    value = arrayItem.GetJson(childPath);
                    return true;
                }
                Utf8Formatter.TryFormat(indexRequested - length, adjustJsonPath.Slice(reader.Current.TokenStartIndex), out int bytesWritten);
                int shift = reader.Current.ValueSpan.Length - bytesWritten;
                if (shift > 0)
                {
                    adjustJsonPath.Slice(reader.Current.TokenStartIndex + reader.Current.ValueSpan.Length + 1)
                        .CopyTo(adjustJsonPath.Slice(reader.Current.TokenStartIndex + bytesWritten + 1));
                    adjustLength -= shift;
                }

                arrayPath = reader.GetNextArray();
            }

            GetSubPath(parentPath, adjustJsonPath.Slice(0, adjustLength), ref childPath);
            value = encodedValue.Value.GetJson(childPath);
            return true;
        }

        return false;
    }

    private bool TryGetArrayItemFromRoot(ReadOnlySpan<byte> jsonPath, JsonPathReader reader, out int indexRequested, out int length, out ReadOnlyMemory<byte> arrayItem)
    {
        length = 0;
        indexRequested = 0;
        arrayItem = ReadOnlyMemory<byte>.Empty;

        if (!Utf8Parser.TryParse(jsonPath.GetIndexSpan(), out indexRequested, out _))
            return false;

        if (!TryGetRootJson(out var rootJson))
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

    private ReadOnlyMemory<byte> GetCombinedArray(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (!TryGetRootJson(out var rootJson, jsonPath.IsRoot()))
            return encodedValue.Value;

        if (!rootJson.TryGetJson(jsonPath, out var existingArray))
            return encodedValue.Value;

        return new ReadOnlyMemory<byte>([.. existingArray.Slice(0, existingArray.Length - 1).Span, .. ","u8, .. encodedValue.Value.Slice(1).Span]);
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

        Span<byte> childPath = stackalloc byte[jsonPath.Length];
        var parentPath = jsonPath;
        var nextPath = jsonPath;
        EncodedValue currentValue = EncodedValue.Empty;
        if (_properties is not null)
        {
            while (true)
            {
                if (_properties.TryGetValue(parentPath, out currentValue))
                {
                    GetSubPath(parentPath, jsonPath, ref childPath);
                    _properties.Set(parentPath, new(currentValue.Kind, ModifyJson(currentValue, childPath, encodedValue)));
                    return;
                }

                if (parentPath.IsRoot())
                    break;

                nextPath = parentPath;
                parentPath = parentPath.GetParent();
            }
        }

        ValueKind kind = ValueKind.Json;

        var jsonParentPath = jsonPath.GetParent();
        if (jsonParentPath.IsRoot())
        {
            // fast path if we are simply adding to root
            nextPath = jsonPath;
            parentPath = jsonParentPath;
        }
        else
        {
            if (_rawJson.Value.IsEmpty)
            {
                if (_properties is null)
                {
                    nextPath = jsonPath.GetFirstProperty();
                    parentPath = "$"u8;
                }
            }
            else
            {
                // since parentPath is not root we need to find how much of jsonPath exists in _rawJson
                // we need to set the key in _properties to that subPath of jsonPath

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

        if (nextPath.IsArrayIndex())
        {
            nextPath = parentPath;
            kind |= ValueKind.ArrayItemAppend;
        }

        if (nextPath.SequenceEqual(jsonPath))
        {
            kind = encodedValue.Kind;
        }

        GetSubPath(nextPath, jsonPath, ref childPath);

        _properties ??= new();
        _properties.Set(nextPath, new(kind, GetNewJson(childPath, encodedValue)));
    }

    private static void GetSubPath(ReadOnlySpan<byte> parentPath, ReadOnlySpan<byte> fullPath, ref Span<byte> subPath)
    {
        if (parentPath.IsRoot())
        {
            fullPath.CopyTo(subPath);
            subPath = subPath.Slice(0, fullPath.Length);
            return;
        }

        var childSlice = fullPath.Slice(parentPath.Length);
        subPath[0] = (byte)'$';
        childSlice.CopyTo(subPath.Slice(1));
        subPath = subPath.Slice(0, childSlice.Length + 1);
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

        ReadOnlyMemory<byte> data = encodedValue.Value;
        ReadOnlySpan<byte> propertyName = pathReader.Current.ValueSpan;

        if (pathReader.Current.TokenType != JsonPathTokenType.End)
        {
            data = GetNonRootNewJson(ref pathReader, jsonPath.GetParent().IsRoot(), jsonPath.IsArrayIndex(), encodedValue);
        }

        if (jsonFound && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
        {
            long endLeft = jsonReader.TokenStartIndex;
            jsonReader.Skip();
            var atEnd = !jsonReader.Read();
            long startRight = atEnd ? jsonReader.BytesConsumed : jsonReader.TokenStartIndex;

            return new ReadOnlyMemory<byte>([.. json.Slice(0, (int)endLeft).Span, .. data.Span, .. json.Slice((int)startRight).Span]);
        }
        else
        {
            return jsonReader.Insert(json, propertyName, data);
        }
    }

    private ReadOnlyMemory<byte> GetNewJson(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (jsonPath.IsRoot())
        {
            // fast path for root
            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                return new([(byte)'[', .. encodedValue.Value.Span, (byte)']']);
            }
            return encodedValue.Value;
        }

        JsonPathReader pathReader = new(jsonPath);

        return GetNonRootNewJson(ref pathReader, jsonPath.GetParent().IsRoot(), jsonPath.IsArrayIndex(), encodedValue);
    }

    private ReadOnlyMemory<byte> GetNonRootNewJson(ref JsonPathReader reader, bool isParentRoot, bool isArrayIndex, EncodedValue encodedValue)
    {
        var arrayWrapper = isParentRoot && isArrayIndex && encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend);

        using var buffer = new UnsafeBufferSequence();
        using var writer = new Utf8JsonWriter(buffer);

        if (arrayWrapper)
        {
            writer.WriteStartArray();
        }

        if (reader.Peek().TokenType == JsonPathTokenType.End)
        {
            writer.WriteRawValue(encodedValue.Value.Span);
        }
        else
        {
            ProjectJson(writer, ref reader, encodedValue, false);
        }

        if (arrayWrapper)
        {
            writer.WriteEndArray();
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
                        writer.WriteRawValue(encodedValue.Value.Span);
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
                            writer.WriteRawValue(encodedValue.Value.Span);
                            writer.WriteEndArray();
                        }
                        else
                        {
                            writer.WriteRawValue(encodedValue.Value.Span);
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
                        writer.WriteRawValue(encodedValue.Value.Span);
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
                        writer.WriteRawValue(encodedValue.Value.Span);
                    }
                    break;
                default:
                    throw new Exception($"Unexpected token type: {pathReader.Current.TokenType}");
            }
        }
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, EncodedValue encodedValue)
    {
        // Helper method to write encoded byte values as JSON

        if (encodedValue.Value.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = encodedValue.Kind & ~ValueKind.ArrayItemAppend;
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
