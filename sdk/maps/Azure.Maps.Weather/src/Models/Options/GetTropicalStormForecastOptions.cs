// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetTropicalStormForecastOptions
    {
        /// <summary> tmp </summary>
        public int Year { get; set; }
        /// <summary> tmp </summary>
        public string BasinId { get; set; }
        /// <summary> tmp </summary>
        public int GovernmentStormId { get; set; }
        /// <summary> Specifies to return the data in either metric units or imperial units. </summary>
        public WeatherDataUnit? Unit { get; set; }
        /// <summary> tmp </summary>
        public bool? IncludeDetails { get; set; }
        /// <summary> tmp </summary>
        public bool? IncludeGeometricDetails { get; set; }
        /// <summary> tmp </summary>
        public bool? IncludeWindowGeometry { get; set; }
    }
}