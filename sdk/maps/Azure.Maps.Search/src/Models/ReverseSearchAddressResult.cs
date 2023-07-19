// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("ReverseSearchAddressResult")]
    public partial class ReverseSearchAddressResult
    {
        [CodeGenMember("Summary")]
        internal SearchSummary Summary;

        /// <summary> The query parameter that was used to produce these search results. </summary>
        public string Query => Summary.Query;
        /// <summary> The type of query being returned: NEARBY or NON_NEAR. </summary>
        public MapsQueryType? QueryType => Summary.QueryType;
        /// <summary> Time spent resolving the query, in milliseconds. </summary>
        public int? QueryTime => Summary.QueryTime;
    }
}
