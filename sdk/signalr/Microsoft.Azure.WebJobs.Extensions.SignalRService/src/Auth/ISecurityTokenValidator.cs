// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    ///  An abstraction for validating security token.
    /// </summary>
    public interface ISecurityTokenValidator
    {
        /// <summary>
        /// Validates security token from http request.
        /// </summary>
        /// <param name="request">Http request that was sent to azure function</param>
        /// <returns></returns>
        SecurityTokenResult ValidateToken(HttpRequest request);
    }
}