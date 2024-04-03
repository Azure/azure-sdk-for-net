// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>Actions for the onTokenIssuanceStart must inherit this.</summary>
    public abstract class TokenIssuanceAction : WebJobsAuthenticationEventsAction
    {
        /// <summary>Initializes a new instance of the <see cref="TokenIssuanceAction" /> class.</summary>
        public TokenIssuanceAction() : base() { }
    }
}
