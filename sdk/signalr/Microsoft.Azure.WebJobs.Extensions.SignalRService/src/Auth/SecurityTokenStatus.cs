// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Represents the result of validating a security token supplied to a SignalR trigger.
    /// </summary>
    public enum SecurityTokenStatus
    {
        /// <summary>The token is present and valid.</summary>
        Valid,
        /// <summary>The token is present but failed validation.</summary>
        Error,
        /// <summary>No token was supplied.</summary>
        Empty
    }
}