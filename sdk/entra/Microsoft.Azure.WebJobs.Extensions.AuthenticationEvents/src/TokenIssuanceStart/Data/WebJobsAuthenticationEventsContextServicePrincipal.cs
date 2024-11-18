// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>Represents the Role Data Model Object.</summary>
    public class WebJobsAuthenticationEventsContextServicePrincipal
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("id")]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets the application identifier.</summary>
        /// <value>The application identifier.</value>
        [JsonPropertyName("appId")]
        public Guid AppId { get; set; }

        /// <summary>Gets the display name of the application.</summary>
        /// <value>The display name of the application.</value>
        [JsonPropertyName("appDisplayName")]
        public string AppDisplayName { get; set; }

        /// <summary>Gets the display name.</summary>
        /// <value>The display name.</value>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}