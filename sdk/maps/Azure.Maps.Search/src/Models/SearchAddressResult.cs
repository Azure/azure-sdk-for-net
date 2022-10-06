// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchAddressResult")]
    public partial class SearchAddressResult
    {
        [CodeGenMember("Summary")]
        internal SearchSummary Summary;

        /// <summary> The query parameter that was used to produce these search results. </summary>
        public string Query => Summary.Query;
        /// <summary> The type of query being returned: NEARBY or NON_NEAR. </summary>
        public MapsQueryType? QueryType => Summary.QueryType;
        /// <summary> Time spent resolving the query, in milliseconds. </summary>
        public int? QueryTime => Summary.QueryTime;
        /// <summary> Number of results in the response. </summary>
        public int? NumResults => Summary.ResultCount;
        /// <summary> Maximum number of responses that will be returned. </summary>
        public int? Top => Summary.Top;
        /// <summary> The starting offset of the returned Results within the full Result set. </summary>
        public int? Skip => Summary.Skip;
        /// <summary> The total number of Results found. </summary>
        public int? TotalResults => Summary.TotalResults;
        /// <summary> The maximum fuzzy level required to provide Results. </summary>
        public int? FuzzyLevel => Summary.FuzzyLevel;
        /// <summary> Indication when the internal search engine has applied a geospatial bias to improve the ranking of results.  In  some methods, this can be affected by setting the lat and lon parameters where available.  In other cases it is  purely internal. </summary>
        public GeoPosition GeoBias => Summary.GeoBias;
    }
}
