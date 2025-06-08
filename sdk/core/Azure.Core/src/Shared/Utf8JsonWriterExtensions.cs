// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Utf8JsonWriterExtensions
    {
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
    }
}
