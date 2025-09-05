// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal static class JsonPathReaderExtensions
{
    public static int ConvertToJsonPointer(this byte[] jsonPath, Span<byte> buffer, bool isArrayAppend = false)
    {
        //Converts JSON path RFC 9535 to JSON Pointer RFC 6901 format.
        //TODO: escape ~ to ~0 and / to ~1 in property names
        ReadOnlySpan<byte> jsonPathSpan = jsonPath.AsSpan();
        if (jsonPathSpan.SequenceEqual("$"u8))
        {
            if (isArrayAppend)
            {
                buffer[0] = (byte)'/';
                buffer[1] = (byte)'-';
                return 2;
            }
            else
            {
                buffer[0] = (byte)'/';
                return 1;
            }
        }

        JsonPathReader reader = new JsonPathReader(jsonPathSpan);
        int bytesWritten = 0;

        while (reader.Read())
        {
            switch (reader.Current.TokenType)
            {
                case JsonPathTokenType.Root:
                    if (reader.Peek().TokenType == JsonPathTokenType.End)
                    {
                        buffer[bytesWritten++] = (byte)'/';
                    }
                    break;
                case JsonPathTokenType.Property:
                    buffer[bytesWritten++] = (byte)'/';
                    int propertyLength = reader.Current.ValueSpan.Length;
                    if (propertyLength > 0)
                    {
                        reader.Current.ValueSpan.CopyTo(buffer.Slice(bytesWritten));
                        bytesWritten += propertyLength;
                    }
                    break;
                case JsonPathTokenType.ArrayIndex:
                    buffer[bytesWritten++] = (byte)'/';
                    int indexLength = reader.Current.ValueSpan.Length;
                    if (indexLength > 0)
                    {
                        reader.Current.ValueSpan.CopyTo(buffer.Slice(bytesWritten));
                        bytesWritten += indexLength;
                    }
                    break;
                case JsonPathTokenType.End:
                    break;
            }
        }

        if (isArrayAppend)
        {
            buffer[bytesWritten++] = (byte)'/';
            buffer[bytesWritten++] = (byte)'-';
        }

        return bytesWritten;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetPropertyName(this byte[] jsonPath)
         => GetPropertyName(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetFirstNonIndexParent(this byte[] jsonPath)
    {
        int index = 0;
        ReadOnlySpan<byte> newPath = jsonPath.AsSpan();
        while (!newPath.IsRoot())
        {
            if (!newPath.IsArrayIndex(out index))
                break;
            newPath = newPath.Slice(0, index + 1);
        }

        return newPath;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsArrayIndex(this byte[] jsonPath)
        => IsArrayIndex(jsonPath, out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsArrayIndex(this ReadOnlySpan<byte> jsonPath)
        => IsArrayIndex(jsonPath, out _);

    private static bool IsArrayIndex(this ReadOnlySpan<byte> jsonPath, out int index)
    {
        index = 0;
        if (jsonPath.Length < 4)
            return false;

        index = jsonPath.Length - 1;
        if (jsonPath[index] != (byte)']')
            return false;

        while (--index >= 0 && jsonPath[index] != (byte)'[')
        {
            if (!JsonPathReader.IsDigit(jsonPath[index]))
                return false;
        }

        if (index < 0 || jsonPath[index] != (byte)'[')
            return false;

        index--;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetFirstProperty(this ReadOnlySpan<byte> jsonPath)
        => new JsonPathReader(jsonPath).GetFirstProperty();

    public static ReadOnlySpan<byte> GetPropertyNameFromSlice(this ReadOnlySpan<byte> slice)
    {
        if (slice.IsEmpty)
            return slice;

        // in case someone does pass in a full path
        if (slice[0] == (byte)'$')
            slice = slice.Slice(1);

        if (slice[0] == (byte)'.')
            slice = slice.Slice(1);

        bool indexSyntax = slice[0] == (byte)'[';
        int start = indexSyntax ? 2 : 0;
        // we assume the slice starts at the property name
        for (int i = start; i < slice.Length; i++)
        {
            byte c = slice[i];
            if (c == (byte)'.')
            {
                return slice.Slice(start, i - start);
            }
            if (c == (byte)']' && (indexSyntax ? slice[1] == slice[i - 1] : (slice[i - 1] == (byte)'\'' || slice[i - 1] == (byte)'"')))
            {
                return slice.Slice(start, i - 1 - start);
            }
            if (c == (byte)'[' && !indexSyntax)
            {
                return slice.Slice(start, i);
            }
        }

        return slice.Slice(start);
    }

    public static ReadOnlySpan<byte> GetPropertyName(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader reader = new JsonPathReader(jsonPath);
        JsonPathToken lastToken = default;
        while (reader.Read() && reader.Current.TokenType != JsonPathTokenType.End)
        {
            if (reader.Current.TokenType == JsonPathTokenType.Property)
            {
                lastToken = reader.Current;
            }
        }

        return lastToken.TokenType == JsonPathTokenType.Property
            ? lastToken.ValueSpan
            : ReadOnlySpan<byte>.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetParent(this byte[] jsonPath)
        => GetParent(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetParent(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        if (jsonPath.Length == 1)
            return jsonPath;

        if (jsonPath.IsArrayIndex())
        {
            Span<byte> arrayInsert = stackalloc byte[jsonPath.Length];
            int openBracketIndex = jsonPath.LastIndexOf((byte)'[');
            jsonPath.Slice(0, openBracketIndex).CopyTo(arrayInsert);
            return arrayInsert.Slice(0, openBracketIndex).ToArray();
        }

        bool inBracket = false;
        for (int i = jsonPath.Length - 1; i >= 1; i--)
        {
            byte c = jsonPath[i];

            if (c == (byte)'[')
            {
                return jsonPath.Slice(0, i);
            }
            else if (c == (byte)']')
            {
                inBracket = true;
            }
            else if (c == (byte)'.' && !inBracket)
            {
                return jsonPath.Slice(0, i);
            }
        }

        return ReadOnlySpan<byte>.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetIndexSpan(this byte[] jsonPath)
        => GetIndexSpan(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetIndexSpan(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        int index = jsonPath.Length - 1;
        if (jsonPath[index] != (byte)']')
            return Array.Empty<byte>();

        while (--index >= 0 && jsonPath[index] != (byte)'[')
        {
            //skip to array start
        }

        var indexSpan = jsonPath.Slice(index + 1);
        return indexSpan[0] == (byte)'\'' || indexSpan[0] == (byte)'"'
            ? Array.Empty<byte>()
            : indexSpan.Slice(0, indexSpan.Length - 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoot(this byte[] jsonPath)
        => IsRoot(jsonPath.AsSpan());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoot(this ReadOnlySpan<byte> jsonPath)
        => "$"u8.SequenceEqual(jsonPath);

    public static byte[] Remove(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        Find(json.Span, jsonPath, out Utf8JsonReader jsonReader);

        long endLeft = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        jsonReader.Read();
        long startRight = jsonReader.TokenStartIndex;

        if (jsonReader.TokenType == JsonTokenType.EndObject && !IsFirstProperty(json, jsonPath))
        {
            endLeft--; //remove trailing comma
        }

        return [.. json.Slice(0, (int)endLeft).Span, .. json.Slice((int)startRight).Span];
    }

    private static bool IsFirstProperty(ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        Find(json.Span, jsonPath.GetParent(), out var jsonReader);

        if (jsonReader.TokenType != JsonTokenType.StartObject)
            return false;

        jsonReader.Read();

        return jsonReader.TokenType == JsonTokenType.PropertyName &&
               jsonReader.ValueSpan.SequenceEqual(jsonPath.GetPropertyName());
    }

    public static byte[] Set(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath, ReadOnlyMemory<byte> jsonReplacement)
    {
        bool found = TryFind(json.Span, jsonPath, out Utf8JsonReader jsonReader);
        return jsonReader.SetCurrentValue(found, jsonPath.GetPropertyName(), json, jsonReplacement);
    }

    public static byte[] SetCurrentValue(this Utf8JsonReader jsonReader, bool wasFound, ReadOnlySpan<byte> propertyName, ReadOnlyMemory<byte> json, ReadOnlyMemory<byte> jsonReplacement)
    {
        if (wasFound)
        {
            if (jsonReader.TokenType == JsonTokenType.PropertyName)
            {
                //move to the value
                jsonReader.Read();
            }

            long endLeft = jsonReader.TokenStartIndex;
            jsonReader.Skip();
            var atEnd = !jsonReader.Read();
            long startRight = atEnd ? jsonReader.BytesConsumed : jsonReader.TokenStartIndex;

            if (jsonReader.TokenType == JsonTokenType.EndObject || jsonReader.TokenType == JsonTokenType.EndArray)
            {
                return [.. json.Slice(0, (int)endLeft).Span, .. jsonReplacement.Span, .. json.Slice((int)startRight).Span];
            }
            else
            {
                return [.. json.Slice(0, (int)endLeft).Span, .. jsonReplacement.Span, (byte)',', .. json.Slice((int)startRight).Span];
            }
        }
        else
        {
            return jsonReader.Insert(json, propertyName, jsonReplacement);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsArrayWrapped(this ReadOnlyMemory<byte> json)
        => IsArrayWrapped(json.Span);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsArrayWrapped(this ReadOnlySpan<byte> json)
    {
        return json.Length >= 2 && json[0] == (byte)'[' && json[json.Length - 1] == (byte)']';
    }

    private static ReadOnlyMemory<byte> FillAt(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> arrayPath)
    {
        int parentIndex = 0;
        Utf8Parser.TryParse(arrayPath.GetIndexSpan(), out int index, out _);
        ReadOnlySpan<byte> arrayParent = arrayPath.GetParent();
        bool needsWrap = false;
        if (arrayParent.IsArrayIndex())
        {
            needsWrap = true;
            Utf8Parser.TryParse(arrayParent.GetIndexSpan(), out parentIndex, out _);
            json = FillAt(json, arrayParent);
        }
        ReadOnlySpan<byte> jsonSpan = json.Span;
        Utf8JsonReader jsonReader = new(jsonSpan);
        JsonPathReader pathReader = new(arrayParent);

        if (!jsonReader.Advance(ref pathReader))
            return json;

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        int nextIndex = 0;

        Utf8JsonReader jsonReaderCopy = jsonReader;
        if (jsonReaderCopy.SkipToIndex(index, out nextIndex))
            return json;

        int gap = index - nextIndex;
        byte[] rented = ArrayPool<byte>.Shared.Rent(gap * 5 + 6);
        var rentedSpan = rented.AsSpan();
        int length = 0;

        if (needsWrap)
        {
            rentedSpan[0] = (byte)'[';
            rentedSpan = rentedSpan.Slice(1);
            length++;
        }

        for (int i = 0; i < gap; i++)
        {
            "null,"u8.CopyTo(rentedSpan);
            rentedSpan = rentedSpan.Slice(5);
            length += 5;
        }
        "null"u8.CopyTo(rentedSpan);
        length += 4;

        if (needsWrap)
        {
            rentedSpan = rentedSpan.Slice(4);
            rentedSpan[0] = (byte)']';
            length++;
        }

        ReadOnlyMemory<byte> result;
        if (needsWrap)
        {
            result = jsonReader.SetCurrentValue(true, ReadOnlySpan<byte>.Empty, json, new(rented, 0, length));
        }
        else
        {
            result = jsonReaderCopy.Insert(json, ReadOnlySpan<byte>.Empty, new(rented, 0, length), index > 0);
        }

        ArrayPool<byte>.Shared.Return(rented);
        return result;
    }

    public static byte[] InsertAt(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> arrayPath, ReadOnlyMemory<byte> jsonToInsert)
    {
        int parentIndex = 0;
        Utf8Parser.TryParse(arrayPath.GetIndexSpan(), out int index, out _);
        ReadOnlySpan<byte> arrayParent = arrayPath.GetParent();
        if (arrayParent.IsArrayIndex())
        {
            Utf8Parser.TryParse(arrayParent.GetIndexSpan(), out parentIndex, out _);
            json = FillAt(json, arrayParent);
        }
        ReadOnlySpan<byte> jsonSpan = json.Span;
        Utf8JsonReader jsonReader = new(jsonSpan);
        JsonPathReader pathReader = new(arrayParent);

        ReadOnlyMemory<byte> insert = jsonReader.Advance(ref pathReader) && jsonToInsert.IsArrayWrapped()
            ? jsonToInsert.Slice(1, jsonToInsert.Length - 2)
            : jsonToInsert;

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        if (jsonReader.TokenType != JsonTokenType.StartArray && jsonReader.TokenType != JsonTokenType.Null)
            throw new FormatException($"{Encoding.UTF8.GetString(arrayParent.ToArray())} is not an array.");

        bool needsWrap = jsonReader.TokenType == JsonTokenType.Null;

        int nextIndex = 0;

        if (!needsWrap)
        {
            insert = jsonReader.SkipToIndex(index, out nextIndex) && jsonReader.TokenType != JsonTokenType.Null && jsonToInsert.IsArrayWrapped()
                ? jsonToInsert.Slice(1, jsonToInsert.Length - 2)
                : jsonToInsert;
        }

        if (index > nextIndex)
        {
            int gap = index - nextIndex;
            byte[] rented = ArrayPool<byte>.Shared.Rent(gap * 5);
            var rentedSpan = rented.AsSpan();
            for (int i = 0; i < gap; i++)
            {
                "null,"u8.CopyTo(rentedSpan);
                rentedSpan = rentedSpan.Slice(5);
            }
            insert = needsWrap
                ? new([(byte)'[', .. rented.AsSpan(0, 5 * gap), .. insert.Span, (byte)']'])
                : new([.. rented.AsSpan(0, 5 * gap), .. insert.Span]);
            ArrayPool<byte>.Shared.Return(rented);
        }
        else if (needsWrap)
        {
            insert = new([(byte)'[', .. insert.Span, (byte)']']);
        }

        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return jsonReader.SetCurrentValue(true, ReadOnlySpan<byte>.Empty, json, insert);
        }
        else
        {
            return jsonReader.Insert(json, ReadOnlySpan<byte>.Empty, insert, needsWrap ? parentIndex > 0 : nextIndex > 0);
        }
    }

    public static byte[] Append(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> arrayPath, ReadOnlyMemory<byte> jsonToInsert)
    {
        Find(json.Span, arrayPath, out Utf8JsonReader jsonReader);
        return jsonReader.Insert(json, ReadOnlySpan<byte>.Empty, jsonToInsert);
    }

    internal static byte[] Insert(
        ref this Utf8JsonReader jsonReader,
        ReadOnlyMemory<byte> json,
        ReadOnlySpan<byte> propertyName,
        ReadOnlyMemory<byte> jsonToInsert,
        bool hasPreviousItems = false)
    {
        long endLeft;
        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            //move to the value
            jsonReader.Read();
        }

        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            //skip to the end of the array
            while (jsonReader.Read() && jsonReader.TokenType != JsonTokenType.EndArray)
            {
                hasPreviousItems = true;
                jsonReader.Skip();
            }
        }

        endLeft = jsonReader.TokenStartIndex;
        if (jsonReader.TokenType == JsonTokenType.EndArray)
        {
            if (!hasPreviousItems)
            {
                return
                [
                    .. json.Slice(0, (int)endLeft).Span,
                    .. jsonToInsert.Span,
                    .. json.Slice((int)endLeft).Span
                ];
            }
            else
            {
                return
                [
                    .. json.Slice(0, (int)endLeft).Span,
                    (byte)',',
                    .. jsonToInsert.Span,
                    .. json.Slice((int)endLeft).Span
                ];
            }
        }

        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            //skip to the end of the object
            while (jsonReader.Read() && jsonReader.TokenType != JsonTokenType.EndObject)
            {
                hasPreviousItems = true;
                jsonReader.Skip();
            }
        }
        else if (jsonReader.TokenType == JsonTokenType.EndObject)
        {
            hasPreviousItems = !IsEmptyObject(json, jsonReader.TokenStartIndex);
        }

        endLeft = jsonReader.TokenStartIndex;
        var buffer = ArrayPool<byte>.Shared.Rent(json.Length + propertyName.Length + jsonToInsert.Length + 5);
        var shared = buffer.AsSpan();
        var left = json.Slice(0, (int)endLeft);
        left.Span.CopyTo(shared);
        shared = shared.Slice(left.Length);
        int length = left.Length;

        if (hasPreviousItems && !propertyName.IsEmpty)
        {
            shared[0] = (byte)',';
            shared = shared.Slice(1);
            length++;
        }
        if (!propertyName.IsEmpty)
        {
            shared[0] = (byte)'"';
            propertyName.CopyTo(shared.Slice(1));
            shared = shared.Slice(1 + propertyName.Length);
            "\":"u8.CopyTo(shared);
            shared = shared.Slice(2);
            length += propertyName.Length + 3;
        }

        jsonToInsert.Span.CopyTo(shared);
        shared = shared.Slice(jsonToInsert.Length);
        length += jsonToInsert.Length;

        // if I inserted into an array I need a trailing comma if there are more items to come after this one
        if (propertyName.IsEmpty &&
            jsonReader.TokenType != JsonTokenType.EndArray)
        {
            shared[0] = (byte)',';
            shared = shared.Slice(1);
            length++;
        }

        var right = json.Slice((int)endLeft);
        right.Span.CopyTo(shared);
        shared = shared.Slice(right.Length);
        length += right.Length;

        var result = buffer.AsSpan(0, length).ToArray();
        ArrayPool<byte>.Shared.Return(buffer);
        return result;
    }

    private static bool IsAtFirstIndex(ReadOnlyMemory<byte> json, long tokenStartIndex)
    {
        for (int i = (int)tokenStartIndex - 1; i >= 0; i--)
        {
            byte c = json.Span[i];
            if (c == (byte)'[')
                return true;
            if (c != (byte)' ' && c != (byte)'\r' && c != (byte)'\n' && c != (byte)'\t')
                return false;
        }
        return false;
    }

    private static bool IsEmptyObject(ReadOnlyMemory<byte> json, long tokenStartIndex)
    {
        for (int i = (int)tokenStartIndex - 1; i >= 0; i--)
        {
            byte c = json.Span[i];
            if (c == (byte)'{')
                return true;

            if (c != (byte)' ' && c != (byte)'\r' && c != (byte)'\n' && c != (byte)'\t')
                return false;
        }
        return false;
    }

    public static bool TryGetJson(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> target)
    {
        target = ReadOnlyMemory<byte>.Empty;

        if (!TryFind(json.Span, jsonPath, out Utf8JsonReader jsonReader))
            return false;

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        long start = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        long end = jsonReader.BytesConsumed;
        // drop wrapping quotes for strings
        if (json.Span[(int)start] == (byte)'"' && json.Span[(int)(end - 1)] == (byte)'"')
        {
            start++;
            end--;
        }
        target = json.Slice((int)start, (int)(end - start));
        return true;
    }

    public static ReadOnlyMemory<byte> GetJson(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetJson(json, jsonPath, out var target))
        {
            throw new Exception($"{Encoding.UTF8.GetString(jsonPath.ToArray())} was not found in the JSON structure.");
        }
        return target;
    }

    private static void Find(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader)
    {
        if (!TryFind(json, jsonPath, out jsonReader))
        {
            throw new Exception($"{Encoding.UTF8.GetString(jsonPath.ToArray())} was not found in the JSON structure.");
        }
    }

    private static bool TryFind(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader)
    {
        jsonReader = default;

        if (json.IsEmpty)
            return jsonPath.IsEmpty;

        jsonReader = new Utf8JsonReader(json);

        return jsonReader.Advance(jsonPath);
    }

    public static int GetArrayLength(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> arrayPath)
    {
        if (!jsonReader.Advance(arrayPath))
            throw new Exception($"{Encoding.UTF8.GetString(arrayPath.ToArray())} was not found in the JSON structure.");

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        if (jsonReader.TokenType != JsonTokenType.StartArray)
            throw new Exception($"{Encoding.UTF8.GetString(arrayPath.ToArray())} is not an array.");

        int length = 0;
        while (jsonReader.Read() && jsonReader.TokenType != JsonTokenType.EndArray)
        {
            length++;
            jsonReader.Skip();
        }

        return length;
    }

    public static bool Advance(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader pathReader = new(jsonPath);
        return jsonReader.Advance(ref pathReader);
    }

    public static bool Advance(ref this Utf8JsonReader jsonReader, ref JsonPathReader pathReader)
    {
        while (pathReader.Read())
        {
            switch (pathReader.Current.TokenType)
            {
                case JsonPathTokenType.Root:
                    if (!jsonReader.Read())
                    {
                        return false;
                    }
                    break;

                case JsonPathTokenType.Property:
                    if (!SkipToProperty(ref jsonReader, pathReader))
                        return false;
                    break;

                case JsonPathTokenType.ArrayIndex:
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                        jsonReader.Read(); // Move to the value after the property name

                    if (jsonReader.TokenType != JsonTokenType.StartArray)
                        return false;

                    var indexSpan = pathReader.Current.ValueSpan;
                    if (!Utf8Parser.TryParse(indexSpan, out int indexToFind, out _))
                    {
                        return false;
                    }

                    if (!jsonReader.SkipToIndex(indexToFind, out _))
                        return false;

                    break;

                case JsonPathTokenType.PropertySeparator:
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                        jsonReader.Read();
                    break;

                case JsonPathTokenType.End:
                    return true;

                default:
                    return false;
            }
        }

        return false;
    }

    internal static bool SkipToIndex(ref this Utf8JsonReader jsonReader, int indexToFind, out int maxIndex)
    {
        maxIndex = 0;

        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == JsonTokenType.EndArray)
            {
                return false;
            }

            if (maxIndex == indexToFind)
            {
                break;
            }
            else
            {
                // Skip the value
                jsonReader.Skip();
            }
            maxIndex++;
        }

        return true;
    }

    private static bool SkipToProperty(ref Utf8JsonReader jsonReader, JsonPathReader pathReader)
    {
        if (jsonReader.TokenType != JsonTokenType.StartObject)
        {
            return false;
        }

        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == JsonTokenType.EndObject)
            {
                return false;
            }

            if (jsonReader.TokenType == JsonTokenType.PropertyName &&
                jsonReader.ValueSpan.SequenceEqual(pathReader.Current.ValueSpan))
            {
                return true;
            }
            else
            {
                // Skip the value
                jsonReader.Skip();
            }
        }

        return false;
    }
}
