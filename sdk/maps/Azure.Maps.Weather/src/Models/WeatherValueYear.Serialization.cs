// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System;
using System.Text.Json;

namespace Azure.Maps.Weather.Models
{
    [CodeGenSuppress("DeserializeWeatherValueYear", typeof(JsonElement))]
    public partial class WeatherValueYear
    {
        internal static WeatherValueYear DeserializeWeatherValueYear(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float? value = default;
            string unit = default;
            int? unitType = default;
            int? year = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    value = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("unit"u8))
                {
                    unit = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unitType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    unitType = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("year"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    year = Convert.ToInt32(property.Value.GetString());
                    continue;
                }
            }
            return new WeatherValueYear(value, unit, unitType, year);
        }
    }
}
