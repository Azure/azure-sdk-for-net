// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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