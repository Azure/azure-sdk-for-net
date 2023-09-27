// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace System.ServiceModel.Rest.Experimental.Core.Serialization
{
    public static class ModelSerializationExtensions
    {
        // TODO: These are copied from shared source files. If they become
        // public we need to refactor and consolidate to a single place.

        #region JsonElement

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
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
            if (element.ValueKind == JsonValueKind.Null)
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

        #endregion

        #region Utf8JsonWriter
        public static void WriteStringValue(this Utf8JsonWriter writer, DateTimeOffset value, string format) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteStringValue(this Utf8JsonWriter writer, DateTime value, string format) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteStringValue(this Utf8JsonWriter writer, TimeSpan value, string format) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteStringValue(this Utf8JsonWriter writer, char value) =>
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));

        public static void WriteNonEmptyArray(this Utf8JsonWriter writer, string name, IReadOnlyList<string> values)
        {
            if (values.Any())
            {
                writer.WriteStartArray(name);
                foreach (var s in values)
                {
                    writer.WriteStringValue(s);
                }

                writer.WriteEndArray();
            }
        }

        public static void WriteBase64StringValue(this Utf8JsonWriter writer, byte[] value, string format)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            switch (format)
            {
                case "U":
                    writer.WriteStringValue(TypeFormatters.ToBase64UrlString(value));
                    break;
                case "D":
                    writer.WriteBase64StringValue(value);
                    break;
                default:
                    throw new ArgumentException($"Format is not supported: '{format}'", nameof(format));
            }
        }

        public static void WriteNumberValue(this Utf8JsonWriter writer, DateTimeOffset value, string format)
        {
            if (format != "U") throw new ArgumentOutOfRangeException(format, "Only 'U' format is supported when writing a DateTimeOffset as a Number.");

            writer.WriteNumberValue(value.ToUnixTimeSeconds());
        }

        public static void WriteObjectValue(this Utf8JsonWriter writer, object value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case IUtf8JsonWriteable serializable:
                    serializable.Write(writer);
                    break;
                case byte[] bytes:
                    writer.WriteBase64StringValue(bytes);
                    break;
                case BinaryData bytes:
                    writer.WriteBase64StringValue(bytes);
                    break;
                case System.Text.Json.JsonElement json:
                    json.WriteTo(writer);
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case decimal d:
                    writer.WriteNumberValue(d);
                    break;
                case double d:
                    if (double.IsNaN(d))
                    {
                        writer.WriteStringValue("NaN");
                    }
                    else
                    {
                        writer.WriteNumberValue(d);
                    }
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case long l:
                    writer.WriteNumberValue(l);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case Guid g:
                    writer.WriteStringValue(g);
                    break;
                case DateTimeOffset dateTimeOffset:
                    writer.WriteStringValue(dateTimeOffset, "O");
                    break;
                case DateTime dateTime:
                    writer.WriteStringValue(dateTime, "O");
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        writer.WriteObjectValue(pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                    break;
                case TimeSpan timeSpan:
                    writer.WriteStringValue(timeSpan, "P");
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }

        #endregion

        #region Type formatters
        private class TypeFormatters
        {
            private const string RoundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
            public static string DefaultNumberFormat { get; } = "G";

            public static string ToString(bool value) => value ? "true" : "false";

            public static string ToString(DateTime value, string format) => value.Kind switch
            {
                DateTimeKind.Utc => ToString((DateTimeOffset)value, format),
                _ => throw new NotSupportedException($"DateTime {value} has a Kind of {value.Kind}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc.")
            };

            public static string ToString(DateTimeOffset value, string format) => format switch
            {
                "D" => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                "U" => value.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture),
                "O" => value.ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
                "o" => value.ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
                "R" => value.ToString("r", CultureInfo.InvariantCulture),
                _ => value.ToString(format, CultureInfo.InvariantCulture)
            };

            public static string ToString(TimeSpan value, string format) => format switch
            {
                "P" => XmlConvert.ToString(value),
                _ => value.ToString(format, CultureInfo.InvariantCulture)
            };

            public static string ToString(byte[] value, string format) => format switch
            {
                "U" => ToBase64UrlString(value),
                "D" => Convert.ToBase64String(value),
                _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
            };

            public static string ToBase64UrlString(byte[] value)
            {
                var numWholeOrPartialInputBlocks = checked(value.Length + 2) / 3;
                var size = checked(numWholeOrPartialInputBlocks * 4);
                var output = new char[size];

                var numBase64Chars = Convert.ToBase64CharArray(value, 0, value.Length, output, 0);

                // Fix up '+' -> '-' and '/' -> '_'. Drop padding characters.
                int i = 0;
                for (; i < numBase64Chars; i++)
                {
                    var ch = output[i];
                    if (ch == '+')
                    {
                        output[i] = '-';
                    }
                    else if (ch == '/')
                    {
                        output[i] = '_';
                    }
                    else if (ch == '=')
                    {
                        // We've reached a padding character; truncate the remainder.
                        break;
                    }
                }

                return new string(output, 0, i);
            }

            public static byte[] FromBase64UrlString(string value)
            {
                var paddingCharsToAdd = GetNumBase64PaddingCharsToAddForDecode(value.Length);

                var output = new char[value.Length + paddingCharsToAdd];

                int i;
                for (i = 0; i < value.Length; i++)
                {
                    var ch = value[i];
                    if (ch == '-')
                    {
                        output[i] = '+';
                    }
                    else if (ch == '_')
                    {
                        output[i] = '/';
                    }
                    else
                    {
                        output[i] = ch;
                    }
                }

                for (; i < output.Length; i++)
                {
                    output[i] = '=';
                }

                return Convert.FromBase64CharArray(output, 0, output.Length);
            }

            private static int GetNumBase64PaddingCharsToAddForDecode(int inputLength)
            {
                switch (inputLength % 4)
                {
                    case 0:
                        return 0;
                    case 2:
                        return 2;
                    case 3:
                        return 1;
                    default:
                        throw new InvalidOperationException("Malformed input");
                }
            }

            public static DateTimeOffset ParseDateTimeOffset(string value, string format)
            {
                return format switch
                {
                    "U" => DateTimeOffset.FromUnixTimeSeconds(long.Parse(value, CultureInfo.InvariantCulture)),
                    _ => DateTimeOffset.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal)
                };
            }

            public static TimeSpan ParseTimeSpan(string value, string format) => format switch
            {
                "P" => XmlConvert.ToTimeSpan(value),
                _ => TimeSpan.ParseExact(value, format, CultureInfo.InvariantCulture)
            };

            public static string ConvertToString(object? value, string? format = null)
                => value switch
                {
                    null => "null",
                    string s => s,
                    bool b => ToString(b),
                    int or float or double or long or decimal => ((IFormattable)value).ToString(DefaultNumberFormat, CultureInfo.InvariantCulture),
                    byte[] b when format != null => ToString(b, format),
                    IEnumerable<string> s => string.Join(",", s),
                    DateTimeOffset dateTime when format != null => ToString(dateTime, format),
                    TimeSpan timeSpan when format != null => ToString(timeSpan, format),
                    TimeSpan timeSpan => XmlConvert.ToString(timeSpan),
                    Guid guid => guid.ToString(),
                    BinaryData binaryData => TypeFormatters.ConvertToString(binaryData.ToArray(), format),
                    _ => value.ToString()!
                };
        }
        #endregion
    }
}
