// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>Represents the WebJobsTokenIssuanceStartData (Root Element) Data Model Object.</summary>
    public class WebJobsTokenIssuanceStartData : WebJobsAuthenticationEventsTypedData
    {
        /// <summary>Gets the context.</summary>
        /// <value>The context.</value>
        [JsonPropertyName("authenticationContext")]
        [Required]
        public WebJobsAuthenticationEventsContext AuthenticationContext { get; set; }

        /// <summary>Json constructor for desearilization</summary>
        public WebJobsTokenIssuanceStartData()
        {
        }
    }
}