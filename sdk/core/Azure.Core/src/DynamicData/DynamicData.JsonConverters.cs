// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    public partial class DynamicData
    {
        // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L14
        private const string RoundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";

        private class DynamicDataDateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L130
                return DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }

            public override void Write(
                Utf8JsonWriter writer,
                DateTime dateTimeValue,
                JsonSerializerOptions options)
            {
                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#LL19C84-L23C11
                string value = dateTimeValue.Kind switch
                {
                    DateTimeKind.Utc => ((DateTimeOffset)dateTimeValue).ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture),
                    _ => throw new NotSupportedException($"DateTime {dateTimeValue} has a Kind of {dateTimeValue.Kind}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc."),
                };
                writer.WriteStringValue(value);
            }
        }

        private class DynamicDataDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L130
                return DateTimeOffset.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }

            public override void Write(
                Utf8JsonWriter writer,
                DateTimeOffset dateTimeValue,
                JsonSerializerOptions options)
            {
                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L29
                string value = dateTimeValue.ToUniversalTime().ToString(RoundtripZFormat, CultureInfo.InvariantCulture);
                writer.WriteStringValue(value);
            }
        }

        private class DynamicDataTimeSpanConverter : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/feature/v3/src/assets/Generator.Shared/TypeFormatters.cs#L137
                return TimeSpan.ParseExact(value, "c", CultureInfo.InvariantCulture);
            }

            public override void Write(
                Utf8JsonWriter writer,
                TimeSpan timeValue,
                JsonSerializerOptions options)
            {
                // From: https://github.com/Azure/autorest.csharp/blob/feature/v3/src/assets/Generator.Shared/TypeFormatters.cs#L37
                string value = timeValue.ToString("c", CultureInfo.InvariantCulture);
                writer.WriteStringValue(value);
            }
        }
    }
}
