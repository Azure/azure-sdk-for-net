// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Geolocation
{
    /// <summary> Common error response for all Azure Resource Manager APIs to return error details for failed operations. This also follows the <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.odata.odataerror?view=odata-core-7.0.">(OData error response format)</see>. </summary>
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
