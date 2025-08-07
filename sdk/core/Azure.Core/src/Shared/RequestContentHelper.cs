// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core
{
    internal static class RequestContentHelper
    {
        public static RequestContent FromEnumerable<T>(IEnumerable<T> enumerable) where T: notnull
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                content.JsonWriter.WriteObjectValue(item);
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static RequestContent FromEnumerable(IEnumerable<BinaryData> enumerable)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                if (item == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
                    content.JsonWriter.WriteRawValue(item);
#else
                    JsonSerializer.Serialize(content.JsonWriter, JsonDocument.Parse(item.ToString()).RootElement);
#endif
                }
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static RequestContent FromDictionary<T>(IDictionary<string, T> dictionary) where T : notnull
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value);
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static RequestContent FromDictionary(IDictionary<string, BinaryData> dictionary)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);

                if (item.Value == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
                    content.JsonWriter.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(content.JsonWriter, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static RequestContent FromObject(object value)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(value);
            return content;
        }
        public static RequestContent FromObject(BinaryData value)
        {
            var content = new Utf8JsonRequestContent();
#if NET6_0_OR_GREATER
            content.JsonWriter.WriteRawValue(value);
#else
            JsonSerializer.Serialize(content.JsonWriter, JsonDocument.Parse(value).RootElement);
#endif
            return content;
        }
    }
}
