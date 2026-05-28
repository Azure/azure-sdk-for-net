// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Xml;

namespace Azure.Core
{
    internal static class JsonElementExtensions
    {
        public static object? GetObject(in this JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }
                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetObject());
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(item.GetObject());
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }

        public static byte[]? GetBytesFromBase64(in this JsonElement element, string format)
        {
            if (element.ValueKind== JsonValueKind.Null)
            {
                return null;
            }

            return format switch
            {
                "U" => TypeFormatters.FromBase64UrlString(element.GetRequiredString()),
                "D" => element.GetBytesFromBase64(),
                _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
            };
         }

        public static DateTimeOffset GetDateTimeOffset(in this JsonElement element, string format) => format switch
        {
            "U" when element.ValueKind == JsonValueKind.Number => DateTimeOffset.FromUnixTimeSeconds(element.GetInt64()),
            // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
            _ => TypeFormatters.ParseDateTimeOffset(element.GetString()!, format)
        };

        public static TimeSpan GetTimeSpan(in this JsonElement element, string format) =>
            // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
            TypeFormatters.ParseTimeSpan(element.GetString()!, format);

        public static char GetChar(this in JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.String)
            {
                var text = element.GetString();
                if (text == null || text.Length != 1)
                {
                    throw new NotSupportedException($"Cannot convert \"{text}\" to a Char");
                }
                return text[0];
            }
            else
            {
                throw new NotSupportedException($"Cannot convert {element.ValueKind} to a Char");
            }
        }

        [Conditional("DEBUG")]
        public static void ThrowNonNullablePropertyIsNull(this JsonProperty property)
        {
            throw new JsonException($"A property '{property.Name}' defined as non-nullable but received as null from the service. " +
                                    $"This exception only happens in DEBUG builds of the library and would be ignored in the release build");
        }

        public static string GetRequiredString(in this JsonElement element)
        {
            var value = element.GetString();
            if (value == null)
                throw new InvalidOperationException($"The requested operation requires an element of type 'String', but the target element has type '{element.ValueKind}'.");

            return value;
        }
    }
}
