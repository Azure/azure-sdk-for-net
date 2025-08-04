// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal static class JsonPathReaderExtensions
{
    public static string? GetString(this ReadOnlySpan<byte> encodedJson, ReadOnlySpan<byte> jsonPath)
    {
        Find(encodedJson, jsonPath, out Utf8JsonReader reader);

        if (reader.TokenType == JsonTokenType.PropertyName)
            reader.Read();

        return reader.GetString();
    }

    public static int? GetNullableInt32(this ReadOnlySpan<byte> encodedJson, ReadOnlySpan<byte> jsonPath)
    {
        Find(encodedJson, jsonPath, out Utf8JsonReader reader);

        if (reader.TokenType == JsonTokenType.PropertyName)
            reader.Read();

        return reader.TokenType == JsonTokenType.Null ? default : reader.GetInt32();
    }

    public static int GetInt32(this ReadOnlySpan<byte> encodedJson, ReadOnlySpan<byte> jsonPath)
    {
        Find(encodedJson, jsonPath, out Utf8JsonReader reader);

        if (reader.TokenType == JsonTokenType.PropertyName)
            reader.Read();

        return reader.GetInt32();
    }

    public static bool GetBoolean(this ReadOnlySpan<byte> encodedJson, ReadOnlySpan<byte> jsonPath)
    {
        Find(encodedJson, jsonPath, out Utf8JsonReader reader);

        if (reader.TokenType == JsonTokenType.PropertyName)
            reader.Read();

        return reader.GetBoolean();
    }

    public static ReadOnlySpan<byte> GetPropertyName(this byte[] jsonPath)
         => GetPropertyName(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetPropertyName(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader reader = new JsonPathReader(jsonPath);
        JsonPathToken lastToken = default;
        while (reader.Read() && reader.Current.TokenType != JsonPathTokenType.End)
        {
            if (reader.Current.TokenType == JsonPathTokenType.Property || reader.Current.TokenType == JsonPathTokenType.QuotedString)
            {
                lastToken = reader.Current;
            }
        }

        return lastToken.TokenType == JsonPathTokenType.Property || lastToken.TokenType == JsonPathTokenType.QuotedString
            ? lastToken.ValueSpan
            : ReadOnlySpan<byte>.Empty;
    }

    public static ReadOnlySpan<byte> GetParent(this byte[] jsonPath)
        => GetParent(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetParent(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        if (jsonPath.Length == 1)
            return jsonPath;

        for (int i = jsonPath.Length - 1; i >= 1; i--)
        {
            byte c = jsonPath[i];

            if (c == (byte)'[')
            {
                return jsonPath.Slice(0, i);
            }
            else if (c == (byte)'.')
            {
                return jsonPath.Slice(0, i);
            }
        }

        return ReadOnlySpan<byte>.Empty;
    }

    public static bool IsArrayInsert(this ReadOnlySpan<byte> jsonPath)
    {
        var indexSpan = jsonPath.GetIndexSpan();

        return indexSpan.Length == 1 && indexSpan[0] == (byte)'-';
    }

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

    public static bool IsRoot(this byte[] jsonPath)
        => IsRoot(jsonPath.AsSpan());

    public static bool IsRoot(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            return false;

        return jsonPath.Length == 1;
    }

    public static byte[] Remove(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        Find(json.Span, jsonPath, out Utf8JsonReader jsonReader);

        long endLeft = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        jsonReader.Read();
        long startRight = jsonReader.TokenStartIndex;

        return [.. json.Slice(0, (int)endLeft).Span, .. json.Slice((int)startRight).Span];
    }

    public static byte[] Replace(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath, ReadOnlyMemory<byte> jsonReplacement)
    {
        Find(json.Span, jsonPath, out Utf8JsonReader jsonReader);

        long endLeft = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        jsonReader.Read();
        long startRight = jsonReader.TokenStartIndex;

        return [.. json.Slice(0, (int)endLeft).Span, .. jsonReplacement.Span, .. json.Slice((int)startRight).Span];
    }

    public static ReadOnlyMemory<byte> GetJson(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> jsonPath)
    {
        Find(json.Span, jsonPath, out Utf8JsonReader jsonReader);

        if (jsonReader.TokenType == JsonTokenType.PropertyName)
            jsonReader.Read(); // Move to the value after the property name

        long start = jsonReader.TokenStartIndex;
        jsonReader.Skip();
        long end = jsonReader.BytesConsumed;
        return json.Slice((int)start, (int)(end - start));
    }

    public static void Find(ReadOnlySpan<byte> json, ReadOnlySpan<byte> jsonPath, out Utf8JsonReader jsonReader)
    {
        if (json.IsEmpty)
            throw new ArgumentException("Json was empty", nameof(json));

        jsonReader = new Utf8JsonReader(json);

        if (!jsonReader.Advance(jsonPath))
            throw new Exception($"{Encoding.UTF8.GetString(jsonPath.ToArray())} was not found in the JSON structure.");
    }

    public static bool Advance(this Utf8JsonReader jsonReader, string jsonPath)
        => jsonReader.Advance(Encoding.UTF8.GetBytes(jsonPath));

    public static bool Advance(ref this Utf8JsonReader jsonReader, ReadOnlySpan<byte> jsonPath)
    {
        // TODO consider assuming $ to avoid requiring allocations when people slice sub-paths
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader pathReader = new(jsonPath);

        bool inArray = false;
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

                case JsonPathTokenType.QuotedString:
                    //deals with the case of $.x['y']
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                        jsonReader.Read();

                    if (!SkipToProperty(ref jsonReader, pathReader))
                        return false;
                    break;

                case JsonPathTokenType.Property:
                    if (!SkipToProperty(ref jsonReader, pathReader))
                        return false;
                    break;

                case JsonPathTokenType.ArrayStart:
                    inArray = true;
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                        jsonReader.Read();

                    if (jsonReader.TokenType != JsonTokenType.StartArray)
                    {
                        return false;
                    }
                    break;

                case JsonPathTokenType.ArrayEnd:
                    inArray = false;
                    break;

                case JsonPathTokenType.PropertySeparator:
                    if (jsonReader.TokenType != JsonTokenType.StartObject)
                        jsonReader.Read();
                    break;

                case JsonPathTokenType.End:
                    return true;

                case JsonPathTokenType.Number:
                    if (!inArray)
                        return false;

                    int currentIndex = 0;
                    var indexSpan = pathReader.Current.ValueSpan;
                    if (!Utf8Parser.TryParse(indexSpan, out int indexToFind, out _))
                    {
                        return false;
                    }

                    while (jsonReader.Read())
                    {
                        if (currentIndex == indexToFind)
                        {
                            break;
                        }
                        else
                        {
                            // Skip the value
                            jsonReader.Skip();
                        }
                        currentIndex++;
                    }

                    break;

                default:
                    return false;
            }
        }

        return false;
    }

    private static bool SkipToProperty(ref Utf8JsonReader jsonReader, JsonPathReader pathReader)
    {
        if (jsonReader.TokenType != JsonTokenType.StartObject)
        {
            return false;
        }

        while (jsonReader.Read())
        {
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
