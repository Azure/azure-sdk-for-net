// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    /// <summary>Represents the TokenIssuanceStartData (Root Element) Data Model Object.</summary>
    public class TokenIssuanceStartData : CustomExtensionCalloutRequestData
    {
        /// <summary>Gets the context.</summary>
        /// <value>The context.</value>
        [JsonPropertyName("authenticationContext")]
        [Required]
        public AuthenticationEventContext AuthenticationContext { get; set; }

        /// <summary>Json constructor for desearilization</summary>
        public TokenIssuanceStartData()
        {
        }
    }
}