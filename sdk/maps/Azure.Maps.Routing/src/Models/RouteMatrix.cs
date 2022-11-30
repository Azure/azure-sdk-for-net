// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Matrix result object. </summary>
    public partial class RouteMatrix
    {
        /// <summary> Initializes a new instance of RouteMatrix. </summary>
        /// <param name="statusCode"> StatusCode property for the current cell in the input matrix. </param>
        /// <param name="response"> Response object of the current cell in the input matrix. </param>
        internal RouteMatrix(int? statusCode, RouteMatrixResultResponse response)
        {
            StatusCode = statusCode;
            Response = response;
            Summary = response.Summary;
        }

        /// <summary> Response object of the current cell in the input matrix. </summary>
        [CodeGenMember("Response")]
        internal RouteMatrixResultResponse Response { get; }

        /// <summary> Summary object for route section. </summary>
        public RouteLegSummary Summary { get; }
    }
}
