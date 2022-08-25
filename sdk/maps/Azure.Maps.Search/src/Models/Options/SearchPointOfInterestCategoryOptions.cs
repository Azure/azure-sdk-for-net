// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchPointOfInterestCategoryOptions: SearchPointOfInterestOptions
    {
        /// <summary> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;, &quot;pizza&quot;). Must be properly URL encoded. </summary>
        public string query { get; set; }
        /// <summary> bounding box. </summary>
        public GeoBoundingBox BoundingBox { get; set; }
        /// <summary> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </summary>
        public bool? IsTypeAhead { get; set; }
        /// <summary>
        /// Hours of operation for a POI (Points of Interest). The availability of hours of operation will vary based on the data available. If not passed, then no opening hours information will be returned.
        /// Supported value: nextSevenDays
        /// </summary>
        public OperatingHoursRange? OperatingHours { get; set; }
        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        ///
        /// Available indexes are:
        ///
        ///  **Addr** = Address ranges
        ///
        ///  **Geo** = Geographies
        ///
        ///  **PAD** = Point Addresses
        ///
        ///  **POI** = Points of Interest
        ///
        ///  **Str** = Streets
        ///
        ///  **XStr** = Cross Streets (intersections)
        ///
        /// Value should be a comma separated list of index types (in any order) or **None** for no indexes.
        ///
        /// By default extended postal codes are included for all indexes except Geo. Extended postal code lists for geographies can be quite long so they have to be explicitly requested when needed.
        ///
        /// Usage examples:
        ///
        ///  extendedPostalCodesFor=POI
        ///
        ///  extendedPostalCodesFor=PAD,Addr,POI
        ///
        ///  extendedPostalCodesFor=None
        ///
        /// Extended postal code is returned as an **extendedPostalCode** property of an address. Availability is region-dependent.
        /// </summary>
        public new IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }
    }
}
