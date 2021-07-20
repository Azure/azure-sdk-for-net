// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteNullStringValue(this Utf8JsonWriter writer, string propertyName, string value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteStringValue(value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullStringValue(this Utf8JsonWriter writer, string propertyName, DateTimeOffset? value, string format)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteStringValue(value.Value, format);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullStringValue<T>(this Utf8JsonWriter writer, string propertyName, T? value) where T : struct
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteStringValue(value.Value.ToString());
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, int? value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteNumberValue(value.Value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, long? value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteNumberValue(value.Value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullNumberValue(this Utf8JsonWriter writer, string propertyName, double? value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteNumberValue(value.Value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullBooleanValue(this Utf8JsonWriter writer, string propertyName, bool? value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteBooleanValue(value.Value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }

        public static void WriteNullObjectValue(this Utf8JsonWriter writer, string propertyName, IUtf8JsonSerializable value)
        {
            if (value != null)
            {
                writer.WritePropertyName(propertyName);
                writer.WriteObjectValue(value);
            }
            else
            {
                writer.WriteNull(propertyName);
            }
        }
    }
}
