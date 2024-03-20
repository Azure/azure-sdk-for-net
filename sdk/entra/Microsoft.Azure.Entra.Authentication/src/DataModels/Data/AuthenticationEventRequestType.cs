// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    #region Global Enums

    /// <summary>The status of the incoming request.</summary>
    public enum AuthenticationEventRequestType
    {
        /// <summary>If there is any failures on the incoming status, the StatusMessage property will contain the reason for the failure.</summary>
        Failed,
        /// <summary>All check have passed except for the Token, which is invalid.</summary>
        TokenInvalid,
        /// <summary>Incoming request and token has passed all checks and is in a successful state.</summary>
        Successful,
        /// <summary>The incoming payload is invalid and failed validation checks</summary>
        ValidationError
    }
    #endregion
}
