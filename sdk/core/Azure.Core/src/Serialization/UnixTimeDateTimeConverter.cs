// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    internal class UnixTimeDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/JsonElementExtensions.cs#L76
            long value = reader.GetInt64();
            DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(value);
            return offset.DateTime.ToUniversalTime();
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options)
        {
            // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#LL19C84-L23C11
            long value = dateTimeValue.Kind switch
            {
                DateTimeKind.Utc => ((DateTimeOffset)dateTimeValue).ToUnixTimeSeconds(),
                _ => throw new NotSupportedException($"DateTime {dateTimeValue} has a Kind of {dateTimeValue.Kind}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc."),
            };
            writer.WriteNumberValue(value);
        }
    }
}
