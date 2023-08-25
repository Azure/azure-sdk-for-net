// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using tisEvents = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Events available by event type.</summary>
    public enum EventDefinition
    {
        /// <summary>onTokenIssuanceStart event.</summary>
        [AuthenticationEventMetadata(typeof(tisEvents.TokenIssuanceStartRequest),
           "microsoft.graph.authenticationEvent.TokenIssuanceStart",
           "TokenIssuanceStart", responseTemplate: "CloudEventActionableTemplate.json")]
        TokenIssuanceStart
    }
}
