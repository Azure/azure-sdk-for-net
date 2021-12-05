// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("ReverseSearchAddressBatchItem")]
    public partial class ReverseSearchAddressBatchItem
    {
        [CodeGenMember("Response")]
        internal ReverseSearchAddressBatchItemResponse Response { get; }

        /// <summary> The error object. </summary>
        public ErrorDetail Error => Response.Error;

        /// <summary> The query parameter that was used to produce these search results. </summary>
        public string Query => Response.Query;
        /// <summary> The type of query being returned: NEARBY or NON_NEAR. </summary>
        public QueryType? QueryType => Response.QueryType;
        /// <summary> Time spent resolving the query, in milliseconds. </summary>
        public int? QueryTime => Response.QueryTime;
        /// <summary> Addresses array. </summary>
        public IReadOnlyList<ReverseSearchAddressResultItem> Addresses => Response.Addresses;
    }
}
