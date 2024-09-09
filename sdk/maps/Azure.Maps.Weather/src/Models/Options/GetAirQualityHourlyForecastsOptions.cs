// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetAirQualityHourlyForecastsOptions
    {
        /// <summary> Specifies the coordinates. </summary>
        public GeoPosition Coordinates { get; set; }
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public WeatherLanguage Language { get; set; }
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? Duration { get; set; }
        /// <summary> Boolean value that returns detailed information about each pollutant. </summary>
        public bool? IncludePollutantDetails { get; set; }
    }
}