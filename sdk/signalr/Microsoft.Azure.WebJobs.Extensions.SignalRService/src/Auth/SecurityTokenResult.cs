// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Defines the result of a security token validation.
    /// </summary>
    public sealed class SecurityTokenResult
    {
        /// <summary>
        /// Gets the status of validated principal.
        /// </summary>
        [JsonProperty("status")]
        public SecurityTokenStatus Status { get; }

        /// <summary>
        /// Gets the <see cref="Principal"/> which contains multiple claims-based identities after token validation.
        /// </summary>
        public ClaimsPrincipal Principal { get; }

        /// <summary>
        /// Gets any exception thrown on validating an invalid token.
        /// </summary>
        [JsonProperty("exception")]
        public Exception Exception { get; }

        private SecurityTokenResult(SecurityTokenStatus status, ClaimsPrincipal principal = null, Exception exception = null)
        {
            Status = status;
            Principal = principal;
            Exception = exception;
        }

        /// <summary>
        /// Static initializer for creating validation result of a valid token.
        /// </summary>
        public static SecurityTokenResult Success(ClaimsPrincipal principal) => new SecurityTokenResult(SecurityTokenStatus.Valid, principal: principal);

        /// <summary>
        /// Static initializer for creating validation result of an invalid token.
        /// </summary>
        public static SecurityTokenResult Error(Exception ex) => new SecurityTokenResult(SecurityTokenStatus.Error, exception: ex);

        /// <summary>
        /// Static initializer for creating validation result of an empty token.
        /// </summary>
        public static SecurityTokenResult Empty() => new SecurityTokenResult(SecurityTokenStatus.Empty);
    }
}