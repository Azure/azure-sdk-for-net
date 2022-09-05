// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.GeoJson;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> Summary object for a Search API response. </summary>
    [CodeGenModel("SearchSummary")]
    internal partial class SearchSummary
    {
        /// <summary> Internal GeoBias of type LatLongPairAbbreviated. Indication when the internal search engine has applied a geospatial bias to improve the ranking of results.  In  some methods, this can be affected by setting the lat and lon parameters where available.  In other cases it is  purely internal. </summary>
        [CodeGenMember("GeoBias")]
        internal LatLongPairAbbreviated GeoBiasInternal { get; }

        /// <summary> Number of results in the response. </summary>
        [CodeGenMember("NumResults")]
        internal int ResultCount { get; }

        /// <summary> Public GeoBias of type GeoPosition from Azure.Core.GeoJson. Indication when the internal search engine has applied a geospatial bias to improve the ranking of results.  In  some methods, this can be affected by setting the lat and lon parameters where available.  In other cases it is  purely internal. </summary>
        public GeoPosition GeoBias {
            get { return new GeoPosition((double) GeoBiasInternal.Lon, (double) GeoBiasInternal.Lat); }
        }
    }
}
