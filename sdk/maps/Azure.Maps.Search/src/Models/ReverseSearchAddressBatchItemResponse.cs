// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The result of the query. SearchAddressReverseResponse if the query completed successfully, ErrorResponse otherwise. </summary>
    public partial class ReverseSearchAddressBatchItemResponse : ReverseSearchAddressResult
    {
        /// <summary> Initializes a new instance of ReverseSearchAddressBatchItemResponse. </summary>
        /// <param name="summary"> Summary object for a Search Address Reverse response. </param>
        /// <param name="addresses"> Addresses array. </param>
        /// <param name="error"> The error object. </param>
        internal ReverseSearchAddressBatchItemResponse(SearchSummary summary, IReadOnlyList<ReverseSearchAddressResultItem> addresses, ErrorDetail error) : base(summary, addresses)
        {
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