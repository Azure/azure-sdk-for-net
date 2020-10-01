// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("ErrorCodeValue")]
    internal enum ErrorCodeValue
    {
        /// <summary> invalidRequest. </summary>
        InvalidRequest,
        /// <summary> invalidArgument. </summary>
        InvalidArgument,
        /// <summary> internalServerError. </summary>
        InternalServerError,
        /// <summary> serviceUnavailable. </summary>
        ServiceUnavailable
    }
}
