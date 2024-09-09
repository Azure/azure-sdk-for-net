// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetHourlyForecastOptions : WeatherBaseOptions
    {
        /// <summary> Specifies to return the data in either metric units or imperial units. </summary>
        public WeatherDataUnit? Unit { get; set; }
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? Duration { get; set; }
    }
}