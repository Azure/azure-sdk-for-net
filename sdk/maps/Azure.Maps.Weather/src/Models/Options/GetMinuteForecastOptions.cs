// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetMinuteForecastOptions : WeatherBaseOptions
    {
        /// <summary> Specifies time interval in minutes for the returned weather forecast. </summary>
        public int? Interval { get; set; }
    }
}