// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests
{
    internal static class JsonElementHelpers
    {
        public static JsonElement FromString(string json)
        {
            return JsonDocument.Parse(json).RootElement;
        }

        public static JsonElement FromStream(Stream stream)
        {
            return JsonDocument.Parse(stream).RootElement;
        }

        public static JsonElement FromObjectAsJson(object obj)
        {
#if NET6_0_OR_GREATER
            return JsonSerializer.SerializeToElement(obj);
#else
            return JsonDocument.Parse(JsonSerializer.Serialize(obj)).RootElement;
#endif
        }

        public static Dictionary<string, object?> ToDictionary(this JsonElement jsonElement)
        {
            return jsonElement.GetObject() as Dictionary<string, object?> ?? new Dictionary<string, object?>();
        }

        public static Dictionary<string, object?> ToDictionaryFromJson2(this BinaryData binaryData)
        {
#if NET6_0_OR_GREATER
            Utf8JsonReader reader = new Utf8JsonReader(binaryData, true, default);
            if (!JsonElement.TryParseValue(ref reader, out var element))
                return new Dictionary<string, object?>();
            return element.Value.GetObject() as Dictionary<string, object?> ?? new Dictionary<string, object?>();
#else
            var element = binaryData.ToObjectFromJson<JsonElement>();
            return element.GetObject() as Dictionary<string, object?> ?? new Dictionary<string, object?>();
#endif
        }

        public static Dictionary<string, object?> ToDictionaryFromJson(this BinaryData binaryData)
        {
            Utf8JsonReader reader = new Utf8JsonReader(binaryData);
            reader.Read();
            Dictionary<string, object?> result = new Dictionary<string, object?>();
            ParseObject(ref reader, result);
            return result;
        }

        private static void ParseObject(ref Utf8JsonReader reader, Dictionary<string, object?> result)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.Comment:
                        break;
                    case JsonTokenType.EndArray:
                        break;
                    case JsonTokenType.EndObject:
                        break;
                    case JsonTokenType.None:
                        break;
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString();
                        if (propertyName is null)
                            throw new InvalidOperationException("Property name was null while parsing json");
                        reader.Read();
                        var value = GetValueKind(ref reader);
                        result.Add(propertyName, value);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid token type found {reader.TokenType}");
                }
            }
        }

        private static void FillList(ref Utf8JsonReader reader, List<object?> list)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    break;

                list.Add(GetValueKind(ref reader));
            }
        }

        private static object? GetValueKind(ref Utf8JsonReader reader)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    return GetNumberValue(ref reader);
                case JsonTokenType.String:
                    return reader.GetString();
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.StartObject:
                    var inner = new Dictionary<string, object?>();
                    ParseObject(ref reader, inner);
                    return inner;
                case JsonTokenType.StartArray:
                    var list = new List<object?>();
                    FillList(ref reader, list);
                    return list;
                default:
                    throw new InvalidOperationException($"Invalid token type found getting value {reader.TokenType}");
            }
        }

        private static object? GetNumberValue(ref Utf8JsonReader reader)
        {
            if (reader.TryGetInt32(out var int32Value))
            {
                return int32Value;
            }
            else if (reader.TryGetInt64(out var int64Value))
            {
                return int64Value;
            }
            else if (reader.TryGetDouble(out var doubleValue))
            {
                return doubleValue;
            }
            else
            {
                throw new InvalidOperationException("Unsupported number type found");
            }
        }
    }
}
