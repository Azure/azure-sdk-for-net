// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchAddressBatchItem")]
    public partial class SearchAddressBatchItem
    {
        [CodeGenMember("Response")]
        internal SearchAddressBatchItemResponse Response { get; }

        /// <summary> The error object. </summary>
        public ErrorDetail Error => Response.Error;

        /// <summary> The query parameter that was used to produce these search results. </summary>
        public string Query => Response.Query;
        /// <summary> The type of query being returned: NEARBY or NON_NEAR. </summary>
        public QueryType? QueryType => Response.QueryType;
        /// <summary> Time spent resolving the query, in milliseconds. </summary>
        public int? QueryTime => Response.QueryTime;
        /// <summary> Number of results in the response. </summary>
        public int? NumResults => Response.NumResults;
        /// <summary> Maximum number of responses that will be returned. </summary>
        public int? Top => Response.Top;
        /// <summary> The starting offset of the returned Results within the full Result set. </summary>
        public int? Skip => Response.Skip;
        /// <summary> The total number of Results found. </summary>
        public int? TotalResults => Response.TotalResults;
        /// <summary> The maximum fuzzy level required to provide Results. </summary>
        public int? FuzzyLevel => Response.FuzzyLevel;
        /// <summary> Indication when the internal search engine has applied a geospatial bias to improve the ranking of results.  In  some methods, this can be affected by setting the lat and lon parameters where available.  In other cases it is  purely internal. </summary>
        public LatLon GeoBias => Response.GeoBias;
        /// <summary> A list of Search API results. </summary>
        public IReadOnlyList<SearchAddressResultItem> Results => Response.Results;
    }
}
