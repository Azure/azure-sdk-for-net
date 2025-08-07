// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>A representation an actionable onTokenIssuanceStart event response for preview_10_01_2021.</summary>
    public class WebJobsTokenIssuanceStartResponse : WebJobsActionableCloudEventResponse<WebJobsTokenIssuanceAction>
    {
        /// <summary>Gets the Cloud Event @odata.type.</summary>
        /// <value>Gets the Cloud Event @odata.type.</value>

        [OneOf("microsoft.graph.onTokenIssuanceStartResponseData")]
        internal override string DataTypeIdentifier => "microsoft.graph.onTokenIssuanceStartResponseData";
    }
}
