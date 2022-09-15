// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </summary>
    [CodeGenModel("ErrorResponse")]
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"> The error object. </param>
        internal ErrorResponse(ErrorDetail error)
        {
            _Error = error;
            Error = new ResponseError(error.Code, error.Message);
        }

        /// <summary> The error object. </summary>
        [CodeGenMember("Error")]
        internal ErrorDetail _Error { get; }

        /// <summary> The error object. </summary>
        public ResponseError Error { get; }
    }
}
