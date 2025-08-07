// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    public partial class DynamicData
    {
        internal const string RoundTripFormat = "o";
        internal const string UnixFormat = "x";

        internal class DynamicDateTimeConverter : JsonConverter<DateTime>
        {
            public string Format { get; }

            public DynamicDateTimeConverter(string format)
            {
                Format = format;
            }

            public override DateTime Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (Format.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/JsonElementExtensions.cs#L76
                    long unixValue = reader.GetInt64();
                    DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(unixValue);
                    return offset.UtcDateTime;
                }

                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L130
                DateTime dateTimeValue = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                return dateTimeValue.ToUniversalTime();
            }

            public override void Write(
                Utf8JsonWriter writer,
                DateTime dateTimeValue,
                JsonSerializerOptions options)
            {
                if (Format.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#LL19C84-L23C11
                    long unixValue = dateTimeValue.Kind switch
                    {
                        DateTimeKind.Utc => ((DateTimeOffset)dateTimeValue).ToUnixTimeSeconds(),
                        _ => throw new NotSupportedException($"DateTime {dateTimeValue} has a Kind of {dateTimeValue.Kind}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc."),
                    };
                    writer.WriteNumberValue(unixValue);
                    return;
                }

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#LL19C84-L23C11
                string value = dateTimeValue.Kind switch
                {
                    DateTimeKind.Utc => dateTimeValue.ToUniversalTime().ToString(Format, CultureInfo.InvariantCulture),
                    _ => throw new NotSupportedException($"DateTime {dateTimeValue} has a Kind of {dateTimeValue.Kind}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc."),
                };
                writer.WriteStringValue(value);
            }
        }

        internal class DynamicDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public string Format { get; }

            public DynamicDateTimeOffsetConverter(string format)
            {
                Format = format;
            }

            public override DateTimeOffset Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (Format.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/JsonElementExtensions.cs#L76
                    long unixValue = reader.GetInt64();
                    return DateTimeOffset.FromUnixTimeSeconds(unixValue).ToUniversalTime();
                }

                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L130
                return DateTimeOffset.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }

            public override void Write(
                Utf8JsonWriter writer,
                DateTimeOffset dateTimeOffsetValue,
                JsonSerializerOptions options)
            {
                if (Format.Equals(UnixFormat, StringComparison.InvariantCultureIgnoreCase))
                {
                    // From: https://github.com/Azure/autorest.csharp/blob/bcc52a3d5788d03bb61c802619b1e3902214d304/src/assets/Generator.Shared/Utf8JsonWriterExtensions.cs#L64
                    long unixValue = dateTimeOffsetValue.ToUniversalTime().ToUnixTimeSeconds();
                    writer.WriteNumberValue(unixValue);
                    return;
                }

                // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L29
                string value = dateTimeOffsetValue.ToUniversalTime().UtcDateTime.ToString(Format, CultureInfo.InvariantCulture);
                writer.WriteStringValue(value);
            }
        }

        internal class DynamicTimeSpanConverter : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                string? value = reader.GetString() ??
                    throw new JsonException($"Failed to read 'string' value at JSON position {reader.Position}.");

                // From: https://github.com/Azure/autorest.csharp/blob/main/src/assets/Generator.Shared/TypeFormatters.cs#L137
                return TimeSpan.ParseExact(value, "c", CultureInfo.InvariantCulture);
            }

            public override void Write(
                Utf8JsonWriter writer,
                TimeSpan timeValue,
                JsonSerializerOptions options)
            {
                // From: https://github.com/Azure/autorest.csharp/blob/main/src/assets/Generator.Shared/TypeFormatters.cs#L37
                string value = timeValue.ToString("c", CultureInfo.InvariantCulture);
                writer.WriteStringValue(value);
            }
        }
    }
}
