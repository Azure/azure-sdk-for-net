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

    public static byte[] InsertAt(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> arrayPath, int index, ReadOnlyMemory<byte> jsonToInsert)
    {
        ReadOnlySpan<byte> jsonSpan = json.Span;
        Utf8JsonReader jsonReader = new(jsonSpan);
        bool isArrayIndex = arrayPath.IsArrayIndex();
        ReadOnlySpan<byte> arrayPathCopy = arrayPath;
        if (isArrayIndex)
        {
            arrayPathCopy = arrayPathCopy.GetParent();
        }
        JsonPathReader pathReader = new(arrayPathCopy);
        ReadOnlyMemory<byte> insert = jsonReader.Advance(ref pathReader)
            ? jsonToInsert.Slice(1, jsonToInsert.Length - 2)
            : jsonToInsert;

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        if (isArrayIndex)
        {
            insert = jsonReader.SkipToIndex(index, out int nextIndex) && jsonReader.TokenType != JsonTokenType.Null
                ? jsonToInsert.Slice(1, jsonToInsert.Length - 2)
                : jsonToInsert;

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
                insert = new([.. rented.AsSpan(0, 5 * gap), .. insert.Span]);
                ArrayPool<byte>.Shared.Return(rented);
            }
        }
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return jsonReader.SetCurrentValue(true, ReadOnlySpan<byte>.Empty, json, insert);
        }
        else
        {
            return jsonReader.Insert(json, ReadOnlySpan<byte>.Empty, insert, true);
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

        if (jsonReader.TokenType == JsonTokenType.EndArray)
        {
            endLeft = jsonReader.TokenStartIndex;
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

        endLeft = jsonReader.TokenStartIndex;
        return
        [
            .. json.Slice(0, (int)endLeft).Span,
            (byte)',',
            (byte)'"',
            .. propertyName,
            (byte)'"',
            (byte)':',
            .. jsonToInsert.Span,
            .. json.Slice((int)endLeft).Span
        ];
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
