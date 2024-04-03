// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Events available by event type.</summary>
    public enum AuthenticationEventDefinition
    {
        /// <summary>onTokenIssuanceStart event.</summary>
        [AuthenticationEventMetadata(typeof(TokenIssuanceStartRequest),
           "microsoft.graph.authenticationEvent.TokenIssuanceStart",
           "TokenIssuanceStart", responseTemplate: "CloudEventActionableTemplate.json")]
        TokenIssuanceStart
    }
}
