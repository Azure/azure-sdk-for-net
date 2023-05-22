// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    internal class UnixTimeDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/JsonElementExtensions.cs#L76
            long value = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(value).ToUniversalTime();
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset dateTimeValue,
            JsonSerializerOptions options)
        {
            // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/Utf8JsonWriterExtensions.cs#L64
            long value = dateTimeValue.ToUniversalTime().ToUnixTimeSeconds();
            writer.WriteNumberValue(value);
        }
    }
}
