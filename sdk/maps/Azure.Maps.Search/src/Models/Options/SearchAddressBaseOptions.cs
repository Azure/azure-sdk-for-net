// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class SearchAddressBaseOptions: SearchBaseOptions
    {
        /// <summary> bounding box. </summary>
        public BoundingBox BoundingBox { get; set; }
        /// <summary> Comma separated string of country codes, e.g. FR,ES. This will limit the search to the specified countries. </summary>
        public IEnumerable<string> CountryFilter { get; set; }
        /// <summary> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </summary>
        public bool? IsTypeAhead { get; set; }
        /// <summary> The radius in meters to for the results to be constrained to the defined area. </summary>
        public int? RadiusInMeters { get; set; }
    }
}
