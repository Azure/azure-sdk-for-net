// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.ClientModel.Serialization;

internal class DynamicJsonDataOptions
{
    public DynamicJsonDataOptions()
    {
        // Set the default
        DateTimeFormat = DynamicJsonData.RoundTripFormat;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="options"></param>
    public DynamicJsonDataOptions(DynamicJsonDataOptions options)
    {
        PropertyNameFormat = options.PropertyNameFormat;
        DateTimeFormat = options.DateTimeFormat;
    }

    public JsonPropertyNames PropertyNameFormat { get; set; }

    public string DateTimeFormat { get; set; }

    internal static JsonSerializerOptions ToSerializerOptions(DynamicJsonDataOptions options)
    {
        JsonSerializerOptions serializerOptions = new()
        {
            Converters =
            {
                new DynamicJsonData.DynamicTimeSpanConverter(),
                new DynamicJsonData.DynamicDateTimeConverter(options.DateTimeFormat),
                new DynamicJsonData.DynamicDateTimeOffsetConverter(options.DateTimeFormat),
            }
        };

        switch (options.PropertyNameFormat)
        {
            case JsonPropertyNames.CamelCase:
                serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                break;
            case JsonPropertyNames.UseExact:
            default:
                break;
        }

        return serializerOptions;
    }

    internal static DynamicJsonDataOptions FromSerializerOptions(JsonSerializerOptions options)
    {
        DynamicJsonDataOptions value = new();

        JsonConverter? c = options.Converters.FirstOrDefault(c => c is DynamicJsonData.DynamicDateTimeConverter);
        if (c is DynamicJsonData.DynamicDateTimeConverter dtc)
        {
            value.DateTimeFormat = dtc.Format;
        }

        if (options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase)
        {
            value.PropertyNameFormat = JsonPropertyNames.CamelCase;
        }

        return value;
    }
}
