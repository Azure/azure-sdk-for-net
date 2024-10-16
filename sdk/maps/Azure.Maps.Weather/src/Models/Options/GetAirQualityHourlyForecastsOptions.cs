// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetAirQualityHourlyForecastsOptions : WeatherBaseOptions
    {
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? DurationInHours { get; set; }
        /// <summary> Boolean value that returns detailed information about each pollutant. </summary>
        public bool? IncludePollutantDetails { get; set; }
    }
}