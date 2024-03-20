// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    /// <summary>Represents the Context Data Model Object.</summary>
    public class AuthenticationEventContext
    {
        /// <summary>Gets the correlation identifier.</summary>
        /// <value>The correlation identifier.</value>
        [JsonPropertyName("correlationId")]
        public Guid CorrelationId { get; set; }

        /// <summary>Gets the client.</summary>
        /// <value>The client.</value>
        [JsonPropertyName("client")]
        public AuthenticationEventContextClient Client { get; set; }

        /// <summary>Gets the authentication protocol.</summary>
        /// <value>The authentication protocol.</value>
        [JsonPropertyName("protocol")]
        [OneOf("OAUTH2.0", "SAML", "WS-FED", "unknownFutureValue", "")]
        public AuthenticationProtocolType AuthenticationProtocolType { get; set; }

        /// <summary>Gets the client service principal.</summary>
        /// <value>The client service principal.</value>
        [JsonPropertyName("clientServicePrincipal")]
        public AuthenticationEventContextServicePrincipal ClientServicePrincipal { get; set; }

        /// <summary>Gets the resource service principal.</summary>
        /// <value>The resource service principal.</value>
        [JsonPropertyName("resourceServicePrincipal")]
        public AuthenticationEventContextServicePrincipal ResourceServicePrincipal { get; set; }

        /// <summary>Gets the user.</summary>
        /// <value>The user.</value>
        [JsonPropertyName("user")]
        public AuthenticationEventContextUser User { get; set; }
    }
}