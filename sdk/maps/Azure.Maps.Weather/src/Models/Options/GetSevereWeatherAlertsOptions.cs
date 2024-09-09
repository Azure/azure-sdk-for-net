// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetSevereWeatherAlertsOptions : WeatherBaseOptions
    {
        /// <summary> Return full details for the current conditions. </summary>
        public bool? Details { get; set; }
    }
}