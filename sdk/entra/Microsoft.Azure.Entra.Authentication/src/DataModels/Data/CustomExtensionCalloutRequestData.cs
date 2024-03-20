// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Or Data class that represents the inbound Json payload, also has helper functions for serialization.</summary>
    public abstract class CustomExtensionCalloutRequestData : CustomExtensionData
    {
        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("tenantId")]
        [RequireNonDefault]
        public Guid TenantId { get; set; }

        /// <summary>Gets the event identifier.</summary>
        /// <value>The event identifier.</value>
        [JsonPropertyName("authenticationEventListenerId")]
        [RequireNonDefault]
        public Guid AuthenticationEventListenerId { get; set; }

        /// <summary>Gets or sets the custom authentication extension identifier.</summary>
        /// <value>The custom authentication extension identifier. </value>
        [JsonPropertyName("customAuthenticationExtensionId")]
        [RequireNonDefault]
        public Guid CustomAuthenticationExtensionId { get; set; }

        /// <summary>Gets the context.</summary>
        /// <value>The context.</value>
        [JsonPropertyName("authenticationContext")]
        [Required]
        public AuthenticationEventContext AuthenticationContext { get; set; }
    }
}
