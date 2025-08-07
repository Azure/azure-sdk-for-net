// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetAirQualityDailyForecastsOptions : WeatherBaseOptions
    {
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? DurationInDays { get; set; }
    }
}