// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetMinuteWeatherForecastOptions : WeatherBaseOptions
    {
        /// <summary> Specifies time interval in minutes for the returned weather forecast. </summary>
        public int? IntervalInMinutes { get; set; }
    }
}