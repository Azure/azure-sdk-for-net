// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Core
{
    internal static class XElementExtensions
    {
        public static byte[] GetBytesFromBase64Value(this XElement element, string format) => format switch
        {
            "U" => TypeFormatters.FromBase64UrlString(element.Value),
            _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
        };

        public static DateTimeOffset GetDateTimeOffsetValue(this XElement element, string format) => format switch
        {
            "D" => (DateTimeOffset)element,
            "S" => DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture),
            "R" => DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture),
            "U" => DateTimeOffset.FromUnixTimeSeconds((long)element),
            _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
        };

        public static TimeSpan GetTimeSpanValue(this XElement element, string format) => format switch
        {
            "P" => XmlConvert.ToTimeSpan(element.Value),
            _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
        };

        #pragma warning disable CA1801 //Parameter format of method GetObjectValue is never used. Remove the parameter or use it in the method body.
        public static object GetObjectValue(this XElement element, string format)
        #pragma warning restore
        {
            return element.Value;
        }
    }
}
