// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class SearchPointOfInterestWithCountryFilterOptions: SearchPointOfInterestOptions
    {
        /// <summary> Comma separated string of country codes, e.g. FR,ES. This will limit the search to the specified countries. </summary>
        public IEnumerable<string> CountryFilter { get; set; }
    }
}
