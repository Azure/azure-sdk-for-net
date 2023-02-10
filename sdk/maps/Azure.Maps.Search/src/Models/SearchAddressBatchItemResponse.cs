// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The result of the query. SearchAddressResponse if the query completed successfully, ErrorResponse otherwise. </summary>
    public partial class SearchAddressBatchItemResponse : SearchAddressResult
    {
        /// <summary> Initializes a new instance of SearchAddressBatchItemResponse. </summary>
        /// <param name="summary"> Summary object for a Search API response. </param>
        /// <param name="results"> A list of Search API results. </param>
        /// <param name="error"> The error object. </param>
        internal SearchAddressBatchItemResponse(SearchSummary summary, IReadOnlyList<SearchAddressResultItem> results, ErrorDetail error) : base(summary, results)
        {
            Summary = summary;
            ErrorDetail = error;
            ResponseError = new ResponseError(error?.Code, error?.Message);
        }

        /// <summary> The error object. </summary>
        [CodeGenMember("Error")]
        internal ErrorDetail ErrorDetail { get; }

        /// <summary> The response error. </summary>
        public ResponseError ResponseError { get; }
    }
}
