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
        private class DefaultTimeSpanConverter : JsonConverter<TimeSpan>
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
