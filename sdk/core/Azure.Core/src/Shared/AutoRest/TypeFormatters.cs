// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml;

namespace Azure.Core
{
    internal class TypeFormatters
    {
        private const string RoundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
        public static string DefaultNumberFormat { get; } = "G";

        public static string ToString(bool value) => value ? "true" : "false";

        public static string ToString(DateTimeOffset value, string format) => format switch
        {
            "D" => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            "U" => value.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture),
            "O" when value.Offset == TimeSpan.Zero => value.ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
            "o" when value.Offset == TimeSpan.Zero => value.ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
            _ => value.ToString(format, CultureInfo.InvariantCulture)
        };

        public static string ToString(TimeSpan value, string format) => format switch
        {
            "P" => XmlConvert.ToString(value),
            _ => value.ToString(format, CultureInfo.InvariantCulture)
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
    }
}
