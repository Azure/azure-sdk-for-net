// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal static class JsonPathReaderExtensions
{
    public static ReadOnlySpan<byte> GetPropertyName(this Span<byte> jsonPath)
         => GetPropertyName((ReadOnlySpan<byte>)jsonPath);

    public static ReadOnlySpan<byte> GetPropertyName(this byte[] jsonPath)
         => GetPropertyName(jsonPath.AsSpan());

    public static ReadOnlySpan<byte> GetPropertyName(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader reader = new JsonPathReader(jsonPath);
        JsonPathToken lastToken = default;
        while (reader.Read())
        {
            lastToken = reader.Current;
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

    public static bool IsRoot(this ReadOnlySpan<byte> jsonPath)
    {
        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            return false;

        return jsonPath.Length == 1;
    }

    public static byte[] Remove(this byte[] encodedJson, ReadOnlySpan<byte> jsonPath)
    {
        var json = encodedJson.AsSpan(1);

        if (json.IsEmpty)
            throw new ArgumentException("Json was empty", nameof(json));

        if (jsonPath.IsEmpty || jsonPath[0] != (byte)'$')
            throw new ArgumentException("JsonPath must start with '$'", nameof(jsonPath));

        JsonPathReader pathReader = new(jsonPath);
        Utf8JsonReader jsonReader = new(json);
        bool inArray = false;
        while (pathReader.Read())
        {
            switch (pathReader.Current.TokenType)
            {
                case JsonPathTokenType.Root:
                    break;

                case JsonPathTokenType.Property:
                    if (inArray)
                    {
                        int currentIndex = 0;
                        var indexSpan = pathReader.Current.ValueSpan;
                        if (indexSpan[0] == (byte)'-')
                            indexSpan = indexSpan.Slice(1);
                        if (!Utf8Parser.TryParse(indexSpan, out int indexToFind, out _))
                        {
                            throw new ArgumentException("Invalid index in JsonPath", nameof(jsonPath));
                        }

                        while (jsonReader.Read())
                        {
                            if (currentIndex == indexToFind)
                            {
                                long endLeft = jsonReader.TokenStartIndex;
                                jsonReader.Skip();
                                jsonReader.Read();
                                long startRight = jsonReader.TokenStartIndex;

                                return [encodedJson[0], .. json.Slice(0, (int)endLeft), .. json.Slice((int)startRight)];
                            }
                            else
                            {
                                // Skip the value
                                jsonReader.Skip();
                            }
                            currentIndex++;
                        }
                    }
                    else
                    {
                        if (!jsonReader.Read() || jsonReader.TokenType != JsonTokenType.PropertyName ||
                            !jsonReader.ValueSpan.SequenceEqual(pathReader.Current.ValueSpan))
                        {
                            throw new ArgumentException("Property not found in JSON", nameof(jsonPath));
                        }
                    }
                    break;

                case JsonPathTokenType.QuotedString:
                    if (!jsonReader.Read() || jsonReader.TokenType != JsonTokenType.PropertyName ||
                        !jsonReader.ValueSpan.SequenceEqual(pathReader.Current.ValueSpan))
                    {
                        throw new ArgumentException("Property not found in JSON", nameof(jsonPath));
                    }
                    break;

                case JsonPathTokenType.ArrayStart:
                    inArray = true;
                    if (!jsonReader.Read() || jsonReader.TokenType != JsonTokenType.StartArray)
                    {
                        throw new ArgumentException("StartArray not found in JSON", nameof(jsonPath));
                    }
                    break;

                case JsonPathTokenType.ArrayEnd:
                    inArray = false;
                    if (jsonReader.TokenType != JsonTokenType.EndArray)
                    {
                        throw new ArgumentException("EndArray not found in JSON", nameof(jsonPath));
                    }
                    break;

                default:
                    throw new NotSupportedException($"Unsupported token type: {pathReader.Current.TokenType}");
            }
        }
        throw new InvalidOperationException("JsonPath did not lead to a valid removal location in the JSON.");
    }
}
