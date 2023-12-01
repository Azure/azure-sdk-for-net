// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Azure.Core
{
    internal class TypeFormatters
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
}
