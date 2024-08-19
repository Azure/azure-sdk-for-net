// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure
{
    internal class ETagConverter: JsonConverter<ETag>
    {
        public override ETag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            if (value == null)
            {
                return default;
            }

            return new ETag(value);
        }

        public override void Write(Utf8JsonWriter writer, ETag value, JsonSerializerOptions options)
        {
            if (value == default)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.ToString("H"));
            }
        }
    }
}