// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteNullStringValue(this Utf8JsonWriter writer, string propertyName, string value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteNullStringValue(this Utf8JsonWriter writer, string propertyName, DateTimeOffset? value, string format) =>
            writer.WriteObjectValue(propertyName, value != null ? TypeFormatters.ToString(value.Value, format) : null);

        public static void WriteNullStringValue<T>(this Utf8JsonWriter writer, string propertyName, T? value) where T : struct =>
            writer.WriteObjectValue(propertyName, value?.ToString());

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, int? value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, long? value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, double? value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteNullBooleanValue(this Utf8JsonWriter writer, string propertyName, bool? value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteNullObjectValue(this Utf8JsonWriter writer, string propertyName, IUtf8JsonSerializable value) =>
            writer.WriteObjectValue(propertyName, value);

        public static void WriteObjectValue(this Utf8JsonWriter writer, string propertyName, object value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNull(propertyName);
                    break;
                case string s:
                    writer.WritePropertyName(propertyName);
                    writer.WriteStringValue(s);
                    break;
                case int i:
                    writer.WritePropertyName(propertyName);
                    writer.WriteNumberValue(i);
                    break;
                case long l:
                    writer.WritePropertyName(propertyName);
                    writer.WriteNumberValue(l);
                    break;
                case double d:
                    writer.WritePropertyName(propertyName);
                    writer.WriteNumberValue(d);
                    break;
                case bool b:
                    writer.WritePropertyName(propertyName);
                    writer.WriteBooleanValue(b);
                    break;
                case IUtf8JsonSerializable serializable:
                    writer.WritePropertyName(propertyName);
                    writer.WriteObjectValue(serializable);
                    break;
                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }
    }
}
