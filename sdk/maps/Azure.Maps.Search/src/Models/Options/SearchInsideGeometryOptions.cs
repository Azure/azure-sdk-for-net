// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchInsideGeometryOptions: SearchGeometryBaseOptions
    {
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
        public IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }

        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        ///
        /// Please refer to [Supported Languages](https://docs.microsoft.com/azure/azure-maps/supported-languages) for details.
        /// </summary>
        public string Language { get; set; }

        /// <summary> A comma separated list of indexes which should be utilized for the search. Item order does not matter. Available indexes are: Addr = Address range interpolation, Geo = Geographies, PAD = Point Addresses, POI = Points of interest, Str = Streets, Xstr = Cross Streets (intersections). </summary>
        public IEnumerable<SearchIndex> IndexFilter { get; set; }
    }
}
