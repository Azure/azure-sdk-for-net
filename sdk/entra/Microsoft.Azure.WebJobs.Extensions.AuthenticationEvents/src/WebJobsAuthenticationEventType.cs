// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Types of events to listen for and attach a function to.</summary>
    public enum WebJobsAuthenticationEventType
    {
        /// <summary>When a token is issued, this event will be called and the ability to append claim to the token is enabled via the response.</summary>
        OnTokenIssuanceStart
    }
}
