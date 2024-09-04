// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetTropicalStormSearchOptions
    {
        /// <summary> tmp </summary>
        public int Year { get; set; }
        /// <summary> tmp </summary>
        public string BasinId { get; set; }
        /// <summary> tmp </summary>
        public int? GovernmentStormId { get; set; }
    }
}