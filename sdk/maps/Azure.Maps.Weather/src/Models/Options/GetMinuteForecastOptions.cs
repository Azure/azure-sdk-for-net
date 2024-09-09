// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetMinuteForecastOptions
    {
        /// <summary> Specifies the coordinates. </summary>
        public GeoPosition Coordinates { get; set; }
        /// <summary> Specifies time interval in minutes for the returned weather forecast. </summary>
        public int? Interval { get; set; }
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public WeatherLanguage Language { get; set; }
    }
}