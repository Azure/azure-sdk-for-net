// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetCurrentWeatherConditionsOptions : WeatherBaseOptions
    {
        /// <summary> Specifies to return the data in either metric units or imperial units. </summary>
        public WeatherDataUnit? Unit { get; set; }
        /// <summary> Return full details for the current conditions. </summary>
        public bool IncludeDetails { get; set; } = true;
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? DurationInHours { get; set; }
    }
}