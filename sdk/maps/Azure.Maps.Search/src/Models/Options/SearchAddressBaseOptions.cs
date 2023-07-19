// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchAddressBaseOptions: SearchBaseOptions
    {
        /// <summary> A pair of coordinates (lon, lat) where results should be biased. E.g. -121.89, 37.337. </summary>
        public GeoPosition? Coordinates { get; set; }
        /// <summary> The radius in meters to for the results to be constrained to the defined area. </summary>
        public int? RadiusInMeters { get; set; }
        /// <summary> Comma separated string of country codes, e.g. FR,ES. This will limit the search to the specified countries. </summary>
        public IEnumerable<string> CountryFilter { get; set; }
    }
}
