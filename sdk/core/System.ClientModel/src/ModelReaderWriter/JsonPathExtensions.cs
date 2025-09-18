// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal static class JsonPathExtensions
{
    /// <summary>
    /// Converts JSON path RFC 9535 to JSON Pointer RFC 6901 format.
    /// </summary>
    /// <param name="jsonPath">The JSON path to convert.</param>
    /// <param name="buffer">The buffer to write the JSON pointer into.</param>
    /// <param name="isArrayAppend">True if the jsonPath represents an array append operation.</param>
    public static int ConvertToJsonPointer(this byte[] jsonPath, Span<byte> buffer, bool isArrayAppend = false)
    {
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
                    if (reader.Current.ValueSpan.Length > 0)
                    {
                        EscapePropertyName(reader.Current.ValueSpan, buffer.Slice(bytesWritten), out int escapedLength);
                        bytesWritten += escapedLength;
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

    private static void EscapePropertyName(ReadOnlySpan<byte> propertyName, Span<byte> buffer, out int bytesWritten)
    {
        ReadOnlySpan<byte> local = propertyName;
        int count = 0;
        bytesWritten = 0;
        for (int i = 0; i < propertyName.Length; i++)
        {
            byte c = propertyName[i];
            if (c == (byte)'~')
            {
                local.Slice(0, count).CopyTo(buffer.Slice(bytesWritten));
                local = local.Slice(count + 1);
                bytesWritten += count;
                count = 0;
                "~0"u8.CopyTo(buffer.Slice(bytesWritten));
                bytesWritten += 2;
            }
            else if (c == (byte)'/')
            {
                local.Slice(0, count).CopyTo(buffer.Slice(bytesWritten));
                local = local.Slice(count + 1);
                bytesWritten += count;
                count = 0;
                "~1"u8.CopyTo(buffer.Slice(bytesWritten));
                bytesWritten += 2;
            }
            else
            {
                count++;
            }
        }
        local.Slice(0, count).CopyTo(buffer.Slice(bytesWritten));
        bytesWritten += count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetPropertyName(this byte[] jsonPath)
         => GetPropertyName(jsonPath.AsSpan());

    /// <summary>
    /// Gets the first parent path that is not an array index from the specified JSON path.
    /// For example for the JSON path "$.store.book[0].title", this method will return "$.store.book[0].title".
    /// If the JSON path is "$.store.book[0][1]", this method will return "$.store.book".
    /// </summary>
    /// <param name="jsonPath">The JSON path to process.</param>
    public static ReadOnlySpan<byte> GetFirstNonIndexParent(this byte[] jsonPath)
    {
        int index = 0;
        ReadOnlySpan<byte> newPath = jsonPath.AsSpan();
        while (!newPath.IsRoot())
        {
            if (!newPath.IsArrayIndex(out index))
            {
                break;
            }
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

    /// <summary>
    /// Determines whether the specified JSON path segment represents a valid array index and extracts the index
    /// position if it does.
    /// </summary>
    /// <param name="jsonPath">The JSON path to test.</param>
    /// <param name="indexPosition">The position of the first digit in the index.</param>
    /// <returns>True if the <paramref name="jsonPath"/> is an array index otherwise false.</returns>
    private static bool IsArrayIndex(this ReadOnlySpan<byte> jsonPath, out int indexPosition)
    {
        indexPosition = 0;
        if (jsonPath.Length < 4)
        {
            return false;
        }

        indexPosition = jsonPath.Length - 1;
        if (jsonPath[indexPosition] != (byte)']')
        {
            return false;
        }

        while (--indexPosition >= 0 && jsonPath[indexPosition] != (byte)'[')
        {
            if (!JsonPathReader.IsDigit(jsonPath[indexPosition]))
            {
                return false;
            }
        }

        if (indexPosition < 0 || jsonPath[indexPosition] != (byte)'[')
        {
            return false;
        }

        indexPosition--;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> GetFirstProperty(this ReadOnlySpan<byte> jsonPath)
        => new JsonPathReader(jsonPath).GetFirstProperty();

    /// <summary>
    /// Extracts the first property name from a JSON path slice, ignoring any leading root or array index syntax.
    /// Does not assume we have a full JSON path, just a slice that may start with a property name.
    /// For example, for the JSON path slice ".store.book[0].title", this method will return "store".
    /// </summary>
    /// <param name="slice">The slice of a JSON path to process.</param>
    public static ReadOnlySpan<byte> GetPropertyNameFromSlice(this ReadOnlySpan<byte> slice)
    {
        if (slice.IsEmpty)
        {
            return slice;
        }

        // in case someone does pass in a full path
        if (slice[0] == (byte)'$')
        {
            slice = slice.Slice(1);
        }

        if (slice[0] == (byte)'.')
        {
            slice = slice.Slice(1);
        }

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

    /// <summary>
    /// Gets the property name of the current JSON path.
    /// For example for the JSON path "$.store.book[0].title", this method will return "title".
    /// </summary>
    /// <param name="jsonPath">The JSON path to get the property name from.</param>
    /// <exception cref="ArgumentException">If the <paramref name="jsonPath"/> does not start with '$'.</exception>
    public static ReadOnlySpan<byte> GetPropertyName(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
        {
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));
        }

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

    /// <summary>
    /// Gets the parent JSON path of the specified JSON path.
    /// For example for the JSON path "$.store.book[0].title", this method will return "$.store.book[0]".
    /// </summary>
    /// <param name="jsonPath">The JSON path to get the parent of.</param>
    /// <exception cref="ArgumentException">If the <paramref name="jsonPath"/> does not start with '$'.</exception>
    public static ReadOnlySpan<byte> GetParent(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
        {
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));
        }

        if (jsonPath.Length == 1)
        {
            return jsonPath;
        }

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

    /// <summary>
    /// Gets the index span of the current JSON path if it is an array index.
    /// For example for the JSON path "$.store.book[0]", this method will return "0".
    /// </summary>
    /// <param name="jsonPath">The JSON path to process.</param>
    /// <exception cref="ArgumentException">If the <paramref name="jsonPath"/> does not start with '$'.</exception>
    public static ReadOnlySpan<byte> GetIndexSpan(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
        {
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));
        }

        int index = jsonPath.Length - 1;
        if (jsonPath[index] != (byte)']')
        {
            return Array.Empty<byte>();
        }

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
    public static bool IsRoot(this Span<byte> jsonPath)
        => IsRoot((ReadOnlySpan<byte>)jsonPath);

    /// <summary>
    /// Gets whether or not the specified JSON path represents the root of the JSON document.
    /// </summary>
    /// <param name="jsonPath">The JSON path to test.</param>
    /// <returns>True if <paramref name="jsonPath"/> is the root '$' otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoot(this ReadOnlySpan<byte> jsonPath)
        => "$"u8.SequenceEqual(jsonPath);

    /// <summary>
    /// Removes the JSON value at the specified JSON path from the JSON byte array.
    /// </summary>
    /// <param name="json">The UTF8 json to modify.</param>
    /// <param name="jsonPath">The JSON path to remove.</param>
    /// <returns>The modified JSON excluding the value found at <paramref name="jsonPath"/>.</returns>
    public static byte[] Remove(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsRoot())
        {
            return Array.Empty<byte>();
        }

        Find(json.Span, jsonPath, out Utf8JsonReader jsonReader, out Utf8JsonReader last);

        long endLeft = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        jsonReader.Read();
        long startRight = jsonReader.TokenStartIndex;

        if (jsonReader.TokenType == JsonTokenType.EndObject && !IsFirstProperty(json, jsonPath))
        {
            endLeft = last.BytesConsumed; //remove trailing comma / whitespace
        }

        if (jsonReader.TokenType == JsonTokenType.EndArray && !IsAtFirstIndex(json, jsonReader.TokenStartIndex))
        {
            endLeft = last.BytesConsumed; //remove trailing comma / whitespace
        }

        return [.. json.Slice(0, (int)endLeft).Span, .. json.Slice((int)startRight).Span];
    }

    private static bool IsFirstProperty(ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        Find(json.Span, jsonPath.GetParent(), out var jsonReader);

        if (jsonReader.TokenType != JsonTokenType.StartObject)
        {
            return false;
        }

        jsonReader.Read();

        return jsonReader.TokenType == JsonTokenType.PropertyName &&
               jsonReader.ValueSpan.SequenceEqual(jsonPath.GetPropertyName());
    }

    /// <summary>
    /// Sets the value of the JSON at the specified JSON path to the provided replacement JSON value.
    /// If the <paramref name="jsonPath"/> does not exist in the original JSON, it will be added with the <paramref name="jsonReplacement"/> value.
    /// </summary>
    /// <param name="json">The original UTF8 JSON.</param>
    /// <param name="jsonPath">The JSON path to replace.</param>
    /// <param name="jsonReplacement">The new UTF8 JSON to replace.</param>
    /// <returns>The modified JSON which has the <paramref name="jsonReplacement"/> at the <paramref name="jsonPath"/>.</returns>
    public static byte[] Set(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath, ReadOnlyMemory<byte> jsonReplacement)
    {
        bool found = TryFind(json.Span, jsonPath, out Utf8JsonReader jsonReader);
        return jsonReader.SetCurrentValue(found, jsonPath.GetPropertyName(), json, jsonReplacement);
    }

    /// <summary>
    /// Sets the value of the JSON at the current position of the <paramref name="jsonReader"/> to the provided replacement JSON value.
    /// </summary>
    /// <param name="jsonReader">The <see cref="Utf8JsonReader"/> pointing at the position to insert.</param>
    /// <param name="wasFound">Indicates if the value previously existed and should be replaced.</param>
    /// <param name="propertyName">The name of the property insert.</param>
    /// <param name="json">The original UTF8 JSON.</param>
    /// <param name="jsonReplacement">The new value to insert at the current position.</param>
    /// <returns>The modified JSON which has <paramref name="jsonReplacement"/> inserted at the current position of <paramref name="jsonReader"/>.</returns>
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

            if (jsonReader.TokenType == JsonTokenType.EndObject || jsonReader.TokenType == JsonTokenType.EndArray || endLeft == jsonReader.TokenStartIndex)
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

    /// <summary>
    /// Determines whether or not the specified JSON byte array is wrapped in an array (i.e. starts with '[' and ends with ']').
    /// </summary>
    /// <param name="json">The UTF8 JSON to test.</param>
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
        {
            return json;
        }

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            jsonReader.Read(); // Move to the value after the property name
        }

        int nextIndex = 0;

        Utf8JsonReader jsonReaderCopy = jsonReader;
        if (jsonReaderCopy.SkipToIndex(index, out nextIndex))
        {
            return json;
        }

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

    /// <summary>
    /// Inserts the specified JSON value at the specified array path in the original JSON byte array.
    /// If the array at the specified path does not exist, it will be created and filled with null values up to the specified index.
    /// </summary>
    /// <param name="json">The original UTF8 JSON.</param>
    /// <param name="arrayPath">The JSON path pointing to the array index to be inserted.</param>
    /// <param name="jsonToInsert">The UTF8 JSON to insert.</param>
    /// <returns>The modified JSON with the <paramref name="jsonToInsert"/> inserted at the <paramref name="arrayPath"/>.</returns>
    /// <exception cref="FormatException">If the parent of <paramref name="arrayPath"/> is not an array.</exception>
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
        {
            jsonReader.Read(); // Move to the value after the property name
        }

        if (jsonReader.TokenType != JsonTokenType.StartArray && jsonReader.TokenType != JsonTokenType.Null)
        {
            throw new FormatException($"{Encoding.UTF8.GetString(arrayParent.ToArray())} is not an array.");
        }

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

    /// <summary>
    /// Appends the specified JSON value to the end of the array at the specified array path in the original JSON byte array.
    /// </summary>
    /// <param name="json">The original UTF8 JSON.</param>
    /// <param name="arrayPath">The JSON path to the array.</param>
    /// <param name="jsonToInsert">The UTF8 JSON to insert.</param>
    /// <returns>The modified JSON with the <paramref name="jsonToInsert"/> appended to the end of <paramref name="arrayPath"/>.</returns>
    public static byte[] Append(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> arrayPath, ReadOnlyMemory<byte> jsonToInsert)
    {
        Find(json.Span, arrayPath, out Utf8JsonReader jsonReader);
        return jsonReader.Insert(json, ReadOnlySpan<byte>.Empty, jsonToInsert);
    }

    /// <summary>
    /// Inserts the specified JSON value at the current position of the <paramref name="jsonReader"/> in the original JSON byte array.
    /// </summary>
    /// <param name="jsonReader">The <see cref="Utf8JsonReader"/> pointing at the place to insert.</param>
    /// <param name="json">The original UTF8 JSON.</param>
    /// <param name="propertyName">The property name to insert.</param>
    /// <param name="jsonToInsert">The UTF8 JSON to insert.</param>
    /// <param name="hasPreviousItems">Indicates if the array was originally empty if <paramref name="jsonReader"/> is pointing inside an array.</param>
    /// <returns>The modified JSON with the <paramref name="jsonToInsert"/> inserted at the current position of <paramref name="jsonReader"/>.</returns>
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
            {
                return true;
            }
            if (c != (byte)' ' && c != (byte)'\r' && c != (byte)'\n' && c != (byte)'\t')
            {
                return false;
            }
        }
        return false;
    }

    private static bool IsEmptyObject(ReadOnlyMemory<byte> json, long tokenStartIndex)
    {
        for (int i = (int)tokenStartIndex - 1; i >= 0; i--)
        {
            byte c = json.Span[i];
            if (c == (byte)'{')
            {
                return true;
            }

            if (c != (byte)' ' && c != (byte)'\r' && c != (byte)'\n' && c != (byte)'\t')
            {
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// Tries to get the JSON value at the specified JSON path from the original JSON byte array.
    /// </summary>
    /// <param name="json">The UTF8 JSON to search in.</param>
    /// <param name="jsonPath">The JSON path to find.</param>
    /// <param name="target">The UTF8 JSON value at <paramref name="jsonPath"/> if it exists.</param>
    /// <returns>True if the <paramref name="jsonPath"/> was found in <paramref name="json"/> otherwise false.</returns>
    public static bool TryGetJson(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> target)
    {
        target = ReadOnlyMemory<byte>.Empty;

        if (!TryFind(json.Span, jsonPath, out Utf8JsonReader jsonReader))
        {
            return false;
        }

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            jsonReader.Read(); // Move to the value after the property name
        }

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

    /// <summary>
    /// Gets the JSON value at the specified JSON path from the original JSON byte array.
    /// </summary>
    /// <param name="json">The UTF8 JSON to search in.</param>
    /// <param name="jsonPath">The JSON path to find.</param>
    /// <exception cref="InvalidOperationException">If <paramref name="jsonPath"/> was not found in <paramref name="json"/>.</exception>
    public static ReadOnlyMemory<byte> GetJson(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        if (!TryGetJson(json, jsonPath, out var target))
        {
            throw new InvalidOperationException($"{Encoding.UTF8.GetString(jsonPath.ToArray())} was not found in the JSON structure.");
        }
        return target;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Find(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader)
        => Find(json, jsonPath, out jsonReader, out _);

    private static void Find(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader, out Utf8JsonReader last)
    {
        if (!TryFind(json, jsonPath, out jsonReader, out last))
        {
            throw new InvalidOperationException($"{Encoding.UTF8.GetString(jsonPath.ToArray())} was not found in the JSON structure.");
        }
    }

    private static bool TryFind(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader)
    {
        Utf8JsonReader last = default;
        return TryFind(json, jsonPath, out jsonReader, out last);
    }

    private static bool TryFind(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader, out Utf8JsonReader last)
    {
        jsonReader = default;
        last = default;

        if (json.IsEmpty)
        {
            return jsonPath.IsEmpty;
        }

        jsonReader = new Utf8JsonReader(json);

        return jsonReader.Advance(jsonPath, ref last);
    }

    /// <summary>
    /// Gets the length of the array at the specified JSON path from the original JSON byte array.
    /// </summary>
    /// <param name="jsonReader"><see cref="Utf8JsonReader"/> holding the JSON to read.</param>
    /// <param name="arrayPath">The JSON path to search for.</param>
    /// <exception cref="InvalidOperationException">If <paramref name="arrayPath"/> is not an array or if <paramref name="arrayPath"/> was not found in <paramref name="jsonReader"/>.</exception>
    public static int GetArrayLength(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> arrayPath)
    {
        if (!jsonReader.Advance(arrayPath))
        {
            throw new InvalidOperationException($"{Encoding.UTF8.GetString(arrayPath.ToArray())} was not found in the JSON structure.");
        }

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
        {
            jsonReader.Read(); // Move to the value after the property name
        }

        if (jsonReader.TokenType != JsonTokenType.StartArray)
        {
            throw new InvalidOperationException($"{Encoding.UTF8.GetString(arrayPath.ToArray())} is not an array.");
        }

        int length = 0;
        while (jsonReader.Read() && jsonReader.TokenType != JsonTokenType.EndArray)
        {
            length++;
            jsonReader.Skip();
        }

        return length;
    }

    /// <summary>
    /// Advances the <see cref="Utf8JsonReader"/> to the position specified by the provided JSON path.
    /// </summary>
    /// <param name="jsonReader">The <see cref="Utf8JsonReader"/> to advance.</param>
    /// <param name="jsonPath">The JSON path to advance to.</param>
    /// <param name="last">The last state of <paramref name="jsonReader"/>.</param>
    /// <exception cref="ArgumentException">If <paramref name="jsonPath"/> does not start with '$'.</exception>
    public static bool Advance(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> jsonPath, ref Utf8JsonReader last)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
        {
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));
        }

        JsonPathReader pathReader = new(jsonPath);
        return jsonReader.Advance(ref pathReader, ref last);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Advance(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> jsonPath)
    {
        Utf8JsonReader last = default;
        return jsonReader.Advance(jsonPath, ref last);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Advance(ref this Utf8JsonReader jsonReader, ref JsonPathReader pathReader)
    {
        Utf8JsonReader last = default;
        return jsonReader.Advance(ref pathReader, ref last);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool Read(ref this Utf8JsonReader jsonReader, ref Utf8JsonReader last)
    {
        last = jsonReader;
        return jsonReader.Read();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Skip(ref this Utf8JsonReader jsonReader, ref Utf8JsonReader last)
    {
        last = jsonReader;
        jsonReader.Skip();
    }

    /// <summary>
    /// Advances the <see cref="Utf8JsonReader"/> to the position specified by the provided <see cref="JsonPathReader"/>.
    /// </summary>
    /// <param name="jsonReader">The <see cref="Utf8JsonReader"/> to advance.</param>
    /// <param name="pathReader">The <paramref name="pathReader"/> that holds the JSON path to find.</param>
    /// <param name="last">The previous state of <paramref name="jsonReader"/>.</param>
    public static bool Advance(ref this Utf8JsonReader jsonReader, ref JsonPathReader pathReader, ref Utf8JsonReader last)
    {
        while (pathReader.Read())
        {
            switch (pathReader.Current.TokenType)
            {
                case JsonPathTokenType.Root:
                    if (!jsonReader.Read(ref last))
                    {
                        return false;
                    }
                    break;

                case JsonPathTokenType.Property:
                    if (!SkipToProperty(ref jsonReader, pathReader, ref last))
                    {
                        return false;
                    }
                    break;

                case JsonPathTokenType.ArrayIndex:
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                    {
                        jsonReader.Read(ref last); // Move to the value after the property name
                    }

                    if (jsonReader.TokenType != JsonTokenType.StartArray)
                    {
                        return false;
                    }

                    var indexSpan = pathReader.Current.ValueSpan;
                    if (!Utf8Parser.TryParse(indexSpan, out int indexToFind, out _))
                    {
                        return false;
                    }

                    if (!jsonReader.SkipToIndex(indexToFind, out _, ref last))
                    {
                        return false;
                    }

                    break;

                case JsonPathTokenType.PropertySeparator:
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                    {
                        jsonReader.Read(ref last);
                    }
                    break;

                case JsonPathTokenType.End:
                    return true;

                default:
                    return false;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool SkipToIndex(ref this Utf8JsonReader jsonReader, int indexToFind, out int maxIndex)
    {
        Utf8JsonReader last = default;
        return jsonReader.SkipToIndex(indexToFind, out maxIndex, ref last);
    }

    /// <summary>
    /// Given a <see cref="Utf8JsonReader"/> positioned at the start of an array, skips to the specified index in the array.
    /// </summary>
    /// <param name="jsonReader">The <see cref="Utf8JsonReader"/> pointed at an array.</param>
    /// <param name="indexToFind">The index to skip to.</param>
    /// <param name="maxIndex">The max index found.</param>
    /// <param name="last">The last state of <paramref name="jsonReader"/>.</param>
    /// <returns>Try if the index was found otherwise false.</returns>
    internal static bool SkipToIndex(ref this Utf8JsonReader jsonReader, int indexToFind, out int maxIndex, ref Utf8JsonReader last)
    {
        maxIndex = 0;

        while (jsonReader.Read(ref last))
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
                jsonReader.Skip(ref last);
            }
            maxIndex++;
        }

        return true;
    }

    private static bool SkipToProperty(ref Utf8JsonReader jsonReader, JsonPathReader pathReader, ref Utf8JsonReader last)
    {
        if (jsonReader.TokenType != JsonTokenType.StartObject)
        {
            return false;
        }

        while (jsonReader.Read(ref last))
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
                jsonReader.Skip(ref last);
            }
        }

        return false;
    }
}
