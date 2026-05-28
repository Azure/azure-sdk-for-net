// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Internal;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    // Dictionary-based storage using UTF8 byte arrays as keys and encoded byte arrays as values
    private SpanDictionary? _properties;
    private readonly EncodedValue _rawJson;

    private PropagatorSetter? _propagatorSetter;
    private PropagatorGetter? _propagatorGetter;

    private bool TryGetEncodedValueInternal(ReadOnlySpan<byte> jsonPath, out EncodedValue value)
    {
        value = EncodedValue.Empty;
        EncodedValue encodedValue;

        // if root is overridden we should not propagate.
        if (jsonPath.IsRoot())
        {
            return TryGetExactMatch(jsonPath, out value);
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

        if (TryGetExactMatch(jsonPath, out value))
        {
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
            // normalize jsonPath once to avoid multiple Normalize calls in GetMaxSibling
            Span<byte> normalizedJsonPathBuffer = stackalloc byte[jsonPath.Length];
            JsonPathComparer.Default.Normalize(jsonPath, normalizedJsonPathBuffer, out var bytesWritten);
            ReadOnlySpan<byte> normalizedJsonPath = normalizedJsonPathBuffer.Slice(0, bytesWritten);

            // if the jsonPath has arrays I need to check if they exist in the root first then patch
            JsonPathReader reader = new(normalizedJsonPath);
            reader.Advance(parentPath);
            ReadOnlySpan<byte> normalizedArrayPath = reader.GetNextArray();
            if (normalizedArrayPath.IsEmpty)
            {
                // no array in sub path
                GetSubPath(parentPath, normalizedJsonPath, ref childPath);
                value = new(encodedValue.Kind, encodedValue.Value.GetJson(childPath));
                return true;
            }

            // see if the requested index exist in root first
            // collect and adjust indexes in a new path as I go
            // indexes will only get smaller so jsonPath.Length is safe
            Span<byte> adjustedJsonPath = stackalloc byte[normalizedJsonPath.Length];
            normalizedJsonPath.CopyTo(adjustedJsonPath);
            int adjustedLength = normalizedJsonPath.Length;

            while (!normalizedArrayPath.IsEmpty)
            {
                if (TryGetArrayItemFromRoot(normalizedArrayPath, reader, out var indexRequested, out var length, out var arrayItem))
                {
                    GetSubPath(normalizedArrayPath, jsonPath, ref childPath);
                    value = new(ValueKind.Json, GetCombinedArray(jsonPath, arrayItem.GetJson(childPath), EncodedValue.Empty));
                    return true;
                }

                AdjustJsonPath(
                    indexRequested - Math.Max(length, GetMaxSibling(normalizedArrayPath) + 1),
                    reader.Current.ValueSpan.Length,
                    reader.Current.TokenStartIndex,
                    adjustedJsonPath,
                    ref adjustedLength);

                normalizedArrayPath = reader.GetNextArray();
            }

            GetSubPath(parentPath, adjustedJsonPath.Slice(0, adjustedLength), ref childPath);
            value = new(encodedValue.Kind, encodedValue.Value.GetJson(childPath));
            return true;
        }

        return false;
    }

    private readonly int GetMaxSibling(ReadOnlySpan<byte> normalizedArrayPath)
    {
        Debug.Assert(_properties is not null, "GetMaxSibling should only be called when _properties is not null.");

        int maxSibling = -1;
        var normalizedPrefix = normalizedArrayPath.GetParent();

        foreach (var kvp in _properties!)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.ModelOwned))
            {
                continue;
            }

            ReadOnlySpan<byte> keySpan = kvp.Key;
            if (!keySpan.StartsWith(normalizedPrefix))
            {
                continue;
            }

            keySpan = keySpan.Slice(normalizedPrefix.Length);

            if (!keySpan.IsArrayWrapped())
            {
                continue;
            }

            if (Utf8Parser.TryParse(keySpan.Slice(1, keySpan.Length - 2), out int index, out _))
            {
                maxSibling = Math.Max(maxSibling, index);
            }
        }

        return maxSibling;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryGetExactMatch(ReadOnlySpan<byte> jsonPath, out EncodedValue value)
    {
        if (_properties is not null && _properties.TryGetValue(jsonPath, out var currentValue))
        {
            if (currentValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                value = new(currentValue.Kind, GetCombinedArray(jsonPath, currentValue));
            }
            else
            {
                value = currentValue;
            }
            return true;
        }

        value = EncodedValue.Empty;
        return false;
    }

    private static void AdjustJsonPath(int newIndex, int indexLength, int indexStart, Span<byte> buffer, ref int length)
    {
        Utf8Formatter.TryFormat(newIndex, buffer.Slice(indexStart), out var bytesWritten);
        int shift = indexLength - bytesWritten;
        if (shift > 0)
        {
            buffer.Slice(indexStart + indexLength).CopyTo(buffer.Slice(indexStart + bytesWritten));
            length -= shift;
        }
    }

    private bool TryGetArrayItemFromRoot(ReadOnlySpan<byte> jsonPath, JsonPathReader reader, out int indexRequested, out int length, out ReadOnlyMemory<byte> arrayItem)
    {
        length = 0;
        indexRequested = 0;
        arrayItem = ReadOnlyMemory<byte>.Empty;

        if (!Utf8Parser.TryParse(jsonPath.GetIndexSpan(), out indexRequested, out _))
        {
            return false;
        }

        if (!TryGetRootJson(out var rootJson))
        {
            return false;
        }

        Utf8JsonReader jsonReader = new(rootJson.Span);
        if (!jsonReader.Advance(jsonPath.GetParent()))
        {
            return false;
        }

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            jsonReader.Read(); // Move to the value after the property name
        }

        if (jsonReader.TokenType != JsonTokenType.StartArray)
        {
            return false;
        }

        if (!jsonReader.SkipToIndex(indexRequested, out length))
        {
            return false;
        }

        long start = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        long end = jsonReader.BytesConsumed;
        arrayItem = rootJson.Slice((int)start, (int)(end - start));
        return true;
    }

    private ReadOnlyMemory<byte> GetCombinedArray(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        TryGetRootJson(out var rootJson);

        rootJson.TryGetJson(jsonPath, out var existingArray);

        return GetCombinedArray(jsonPath, existingArray, encodedValue);
    }

    private ReadOnlyMemory<byte> GetCombinedArray(ReadOnlySpan<byte> jsonPath, ReadOnlyMemory<byte> existingArray, EncodedValue encodedValue)
    {
        Debug.Assert(_properties is not null, "GetCombinedArray should only be called when _properties is not null.");

        Span<byte> normalizedPrefix = stackalloc byte[jsonPath.Length];
        byte[] childPath = new byte[_properties!.MaxKeyLength];
        JsonPathComparer.Default.Normalize(jsonPath, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

        // find all items in _properties that start with normalizedPrefix and combine them into a single array
        foreach (var kvp in _properties)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.ModelOwned))
            {
                continue;
            }

            ReadOnlySpan<byte> keySpan = kvp.Key;

            if (!keySpan.StartsWith(normalizedPrefix))
            {
                continue;
            }

            if (existingArray.IsEmpty)
            {
                // if the existing array is empty, then we can just use the encoded value directly if it matches the prefix, otherwise we need to wrap it in an array
                existingArray = keySpan.SequenceEqual(normalizedPrefix) ? encodedValue.Value : new([(byte)'[', .. kvp.Value.Value.Span, (byte)']']);
            }
            else
            {
                GetSubPath(normalizedPrefix, kvp.Key, childPath, out int childPathLength);
                ReadOnlySpan<byte> childJsonPath = childPath.AsSpan(0, childPathLength);
                if (childJsonPath.IsArrayIndex())
                {
                    // if the childJsonPath is an array index, we need to insert the value at that index in the existing array
                    existingArray = existingArray.InsertAt(childJsonPath, kvp.Value.Value);
                }
                else
                {
                    // otherwise we can just append the value to the existing array
                    existingArray = existingArray.Append(childJsonPath, kvp.Value.Value.Slice(1, kvp.Value.Value.Length - 2));
                }
            }
        }
        // if existing array is still empty return the original encoded value, otherwise return the combined array
        return existingArray.IsEmpty ? encodedValue.Value : existingArray;
    }

    private bool TryGetRootJson(out ReadOnlyMemory<byte> value)
    {
        value = ReadOnlyMemory<byte>.Empty;

        Debug.Assert(_properties is not null, "TryGetRootJson should only be called when _properties is not null.");

        if (_rawJson.Value.IsEmpty)
        {
            return false;
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
            {
                break;
            }
        }

        if (parentPath.IsRoot() && includeRoot)
        {
            if (_properties.TryGetValue(parentPath, out encodedValue))
            {
                return true;
            }

            if (!_rawJson.Value.IsEmpty)
            {
                encodedValue = _rawJson;
                return true;
            }
        }

        return false;
    }

    private void SetInternal(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
    {
        if (_propagatorSetter is not null && _propagatorSetter(jsonPath, encodedValue))
        {
            return;
        }

        EncodedValue currentValue = EncodedValue.Empty;

        if (_properties is not null && _properties.TryGetValue(jsonPath, out currentValue))
        {
            _properties.Set(jsonPath, new(encodedValue.Kind, ModifyJson(currentValue, "$"u8, encodedValue)));
            return;
        }

        ReadOnlySpan<byte> localPath = jsonPath;
        byte[] adjustedPath = new byte[jsonPath.Length];
        Span<byte> childPath = stackalloc byte[localPath.Length];

        if (!_rawJson.Value.IsEmpty && encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
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
                    int newLength = parsedPath.Length;
                    parsedPath.CopyTo(adjustedPath);
                    AdjustJsonPath(index - length, pathReader.Current.ValueSpan.Length, pathReader.Current.TokenStartIndex, adjustedPath, ref newLength);
                    var remainingPath = jsonPath.Slice(pathReader.Current.TokenStartIndex + 2);
                    remainingPath.CopyTo(adjustedPath.AsSpan(newLength));
                    localPath = adjustedPath.AsSpan(0, newLength + remainingPath.Length);
                }
            }
        }

        var parentPath = localPath.SequenceEqual(jsonPath) ? localPath : localPath.GetParent();
        var nextPath = localPath;

        if (_properties is not null)
        {
            while (true)
            {
                if (_properties.TryGetValue(parentPath, out currentValue))
                {
                    GetSubPath(parentPath, localPath, ref childPath);
                    ValueKind newKind = childPath.IsRoot() ? encodedValue.Kind : currentValue.Kind;
                    _properties.Set(parentPath, new(newKind, ModifyJson(currentValue, childPath, encodedValue)));
                    return;
                }

                if (parentPath.IsRoot())
                {
                    break;
                }

                nextPath = parentPath;
                parentPath = parentPath.GetParent();
            }
        }

        if (encodedValue.Kind == ValueKind.Removed && jsonPath.IsArrayIndex())
        {
            Utf8JsonReader jsonReader = new(_rawJson.Value.Span);
            JsonPathReader pathReader = new(jsonPath);
            if (jsonReader.Advance(ref pathReader))
            {
                _properties ??= new();
                _properties.Set(jsonPath, new(encodedValue.Kind, GetNewJson("$"u8, encodedValue)));
                return;
            }

            // we cannot remove an array index that doesn't exist
            ThrowIndexOutOfRangeException(jsonPath);
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
                if (nextPath.IsArrayIndex() && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    nextPath = parentPath;
                    kind |= ValueKind.ArrayItemAppend;
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
                    if (nextPath.IsArrayIndex() && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
                    {
                        nextPath = parentPath;
                        kind |= ValueKind.ArrayItemAppend;
                    }
                }
            }
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

    private static ReadOnlyMemory<byte> ModifyJson(EncodedValue currentValue, ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
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

        ReadOnlyMemory<byte> data = NeedsQuotes(encodedValue.Kind, jsonPath.IsArrayIndex()) ? new([(byte)'"', .. encodedValue.Value.Span, (byte)'"']) : encodedValue.Value;
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

    private static ReadOnlyMemory<byte> GetNewJson(ReadOnlySpan<byte> jsonPath, EncodedValue encodedValue)
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
                return NeedsQuotes(encodedValue.Kind, true)
                    ? new([(byte)'[', (byte)'"', .. encodedValue.Value.Span, (byte)'"', (byte)']'])
                    : new([(byte)'[', .. encodedValue.Value.Span, (byte)']']);
            }
            return encodedValue.Value;
        }

        JsonPathReader pathReader = new(jsonPath);

        return GetNonRootNewJson(ref pathReader, jsonPath.GetParent().IsRoot(), jsonPath.IsArrayIndex(), encodedValue);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool NeedsQuotes(ValueKind kind, bool isArrayIndex)
    {
        var stringKinds = ValueKind.Utf8String | ValueKind.TimeSpan | ValueKind.Guid | ValueKind.DateTime;
        return (kind & stringKinds) > 0 && (isArrayIndex || kind.HasFlag(ValueKind.ArrayItemAppend));
    }

    private static ReadOnlyMemory<byte> GetNonRootNewJson(ref JsonPathReader reader, bool isParentRoot, bool isArrayIndex, EncodedValue encodedValue)
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

    private static void ProjectJson(Utf8JsonWriter writer, ref JsonPathReader pathReader, EncodedValue encodedValue, bool inArray)
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
                    break;
                default:
                    // we will never reach this since all token types are handled above
                    ThrowInvalidToken(pathReader.Current.TokenType);
                    break;
            }
        }
    }
}
