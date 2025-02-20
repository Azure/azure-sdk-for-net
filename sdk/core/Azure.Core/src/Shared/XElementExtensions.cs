// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Xml.Linq;

namespace Azure.Core
{
    internal static class XElementExtensions
    {
        public static byte[] GetBytesFromBase64Value(this XElement element, string format) => format switch
        {
            "U" => TypeFormatters.FromBase64UrlString(element.Value),
            "D" => Convert.FromBase64String(element.Value),
            _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
        };

        public static DateTimeOffset GetDateTimeOffsetValue(this XElement element, string format) => format switch
        {
            "U" => DateTimeOffset.FromUnixTimeSeconds((long)element),
            _ => TypeFormatters.ParseDateTimeOffset(element.Value, format)
        };

        public static TimeSpan GetTimeSpanValue(this XElement element, string format) => TypeFormatters.ParseTimeSpan(element.Value, format);
        #pragma warning disable CA1801 //Parameter format of method GetObjectValue is never used. Remove the parameter or use it in the method body.
        public static object GetObjectValue(this XElement element, string format)
        #pragma warning restore
        {
            return element.Value;
        }
    }
}
