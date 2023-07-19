// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The result of the query. SearchAddressReverseResponse if the query completed successfully, ErrorResponse otherwise. </summary>
    public partial class ReverseSearchAddressBatchItemResponse : ReverseSearchAddressResult
    {
        /// <summary> The error object. </summary>
        [CodeGenMember("Error")]
        internal ErrorDetail ErrorDetail { get; }

        /// <summary> The response error. </summary>
        public ResponseError ResponseError { get; }
    }
}
