// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetSevereWeatherAlertsOptions : WeatherBaseOptions
    {
        /// <summary> Return full details for the current conditions. </summary>
        public bool IncludeDetails { get; set; } = true;
    }
}