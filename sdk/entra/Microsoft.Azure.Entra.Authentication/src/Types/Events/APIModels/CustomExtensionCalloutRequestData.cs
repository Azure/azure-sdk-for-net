// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// This model represents the customExtensionData that is specific to an authentication event.
    /// This is shared by all authentication data event payloads.
    /// Individual events may have additional event-specific data.
    /// </summary>
    public abstract class CustomExtensionCalloutRequestData : CustomExtensionData
    {
        /// <summary>
        /// Default Constructor for Json Deserialization
        /// </summary>
        protected CustomExtensionCalloutRequestData()
        {
        }

        /// <summary>
        /// The tenant ID.
        /// </summary>
        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The event listener identifier. It is the id of the registered event listener policy that was executed.
        /// </summary>
        [JsonProperty("authenticationEventListenerId")]
        public string AuthenticationEventListenerId { get; set; }

        /// <summary>
        /// The custom extension identifier. It is the id of the registered custom extension policy that was executed.
        /// </summary>
        [JsonProperty("customAuthenticationExtensionId")]
        public string CustomAuthenticationExtensionId { get; set; }

        /// <summary>
        /// Information about the authentication that triggered the event/callout. Common to all authentication events.
        /// </summary>
        [JsonProperty("authenticationContext")]
        public AuthenticationEventContext AuthenticationContext { get; set; }
    }
}
