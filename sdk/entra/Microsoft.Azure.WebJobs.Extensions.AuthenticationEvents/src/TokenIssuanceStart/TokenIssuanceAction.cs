// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions
{
    /// <summary>Actions for the onTokenIssuanceStart must inherit this.</summary>
    public abstract class TokenIssuanceAction : AuthenticationEventAction
    {
        /// <summary>Initializes a new instance of the <see cref="TokenIssuanceAction" /> class.</summary>
        public TokenIssuanceAction() : base() { }
    }
}
