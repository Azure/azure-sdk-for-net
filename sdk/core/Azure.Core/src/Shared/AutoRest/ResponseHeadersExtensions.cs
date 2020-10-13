// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;
using System.Xml;

namespace Azure.Core
{
    internal static class ResponseHeadersExtensions
    {
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
                value = DateTimeOffset.Parse(stringValue, CultureInfo.InvariantCulture);
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
    }
}
