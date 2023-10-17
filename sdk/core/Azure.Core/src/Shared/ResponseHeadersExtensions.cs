// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Azure.Core
{
    internal static class ResponseHeadersExtensions
    {
        private static readonly string[] KnownFormats =
        {
            // "r", // RFC 1123, required output format but too strict for input
            "ddd, d MMM yyyy H:m:s 'GMT'", // RFC 1123 (r, except it allows both 1 and 01 for date and time)
            "ddd, d MMM yyyy H:m:s 'UTC'", // RFC 1123, UTC
            "ddd, d MMM yyyy H:m:s", // RFC 1123, no zone - assume GMT
            "d MMM yyyy H:m:s 'GMT'", // RFC 1123, no day-of-week
            "d MMM yyyy H:m:s 'UTC'", // RFC 1123, UTC, no day-of-week
            "d MMM yyyy H:m:s", // RFC 1123, no day-of-week, no zone
            "ddd, d MMM yy H:m:s 'GMT'", // RFC 1123, short year
            "ddd, d MMM yy H:m:s 'UTC'", // RFC 1123, UTC, short year
            "ddd, d MMM yy H:m:s", // RFC 1123, short year, no zone
            "d MMM yy H:m:s 'GMT'", // RFC 1123, no day-of-week, short year
            "d MMM yy H:m:s 'UTC'", // RFC 1123, UTC, no day-of-week, short year
            "d MMM yy H:m:s", // RFC 1123, no day-of-week, short year, no zone

            "dddd, d'-'MMM'-'yy H:m:s 'GMT'", // RFC 850
            "dddd, d'-'MMM'-'yy H:m:s 'UTC'", // RFC 850, UTC
            "dddd, d'-'MMM'-'yy H:m:s zzz", // RFC 850, offset
            "dddd, d'-'MMM'-'yy H:m:s", // RFC 850 no zone
            "ddd MMM d H:m:s yyyy", // ANSI C's asctime() format

            "ddd, d MMM yyyy H:m:s zzz", // RFC 5322
            "ddd, d MMM yyyy H:m:s", // RFC 5322 no zone
            "d MMM yyyy H:m:s zzz", // RFC 5322 no day-of-week
            "d MMM yyyy H:m:s", // RFC 5322 no day-of-week, no zone
        };

        public static bool TryGetValue(this ResponseHeaders headers, string name, out byte[]? value)
        {
            if (headers.TryGetValue(name, out string? stringValue))
            {
                value = Convert.FromBase64String(stringValue);
                return true;
            }

            value = null;
            return false;
        }

        public static bool TryGetValue(this ResponseHeaders headers, string name, out TimeSpan? value)
        {
            if (headers.TryGetValue(name, out string? stringValue))
            {
                value = XmlConvert.ToTimeSpan(stringValue);
                return true;
            }

            value = null;
            return false;
        }

        public static bool TryGetValue(this ResponseHeaders headers, string name, out DateTimeOffset? value)
        {
            if (headers.TryGetValue(name, out string? stringValue))
            {
                if (DateTimeOffset.TryParseExact(stringValue, "r", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out var dto) ||
                    DateTimeOffset.TryParseExact(stringValue, KnownFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowInnerWhite | DateTimeStyles.AssumeUniversal, out dto))
                {
                    value = dto;
                }
                else
                {
                    value = TypeFormatters.ParseDateTimeOffset(stringValue, "");
                }

                return true;
            }

            value = null;
            return false;
        }

        public static bool TryGetValue<T>(this ResponseHeaders headers, string name, out T? value) where T : struct
        {
            if (headers.TryGetValue(name, out string? stringValue))
            {
                value = (T)Convert.ChangeType(stringValue, typeof(T), CultureInfo.InvariantCulture);
                return true;
            }

            value = null;
            return false;
        }

        public static bool TryGetValue<T>(this ResponseHeaders headers, string name, out T? value) where T : class
        {
            if (headers.TryGetValue(name, out string? stringValue))
            {
                value = (T)Convert.ChangeType(stringValue, typeof(T), CultureInfo.InvariantCulture);
                return true;
            }

            value = null;
            return false;
        }

        public static bool TryGetValue(this ResponseHeaders headers, string prefix, out IDictionary<string, string> value)
        {
            value = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (HttpHeader item in headers)
            {
                if (item.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    value.Add(item.Name.Substring(prefix.Length), item.Value);
                }
            }

            return true;
        }
    }
}
