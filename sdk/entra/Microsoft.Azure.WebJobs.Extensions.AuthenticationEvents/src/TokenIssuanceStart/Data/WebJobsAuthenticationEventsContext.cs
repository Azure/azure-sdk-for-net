// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>Represents the Context Data Model Object.</summary>
    public class WebJobsAuthenticationEventsContext
    {
        /// <summary>Gets the correlation identifier.</summary>
        /// <value>The correlation identifier.</value>
        [JsonPropertyName("correlationId")]
        public Guid CorrelationId { get; set; }

        /// <summary>Gets the client.</summary>
        /// <value>The client.</value>
        [JsonPropertyName("client")]
        public WebJobsAuthenticationEventsContextClient Client { get; set; }

        /// <summary>Gets the authentication protocol.</summary>
        /// <value>The authentication protocol.</value>
        [JsonPropertyName("protocol")]
        [OneOf("OAUTH2.0", "SAML", "WS-FED", "unknownFutureValue", "")]
        public string Protocol { get; set; }

        /// <summary>Gets the client service principal.</summary>
        /// <value>The client service principal.</value>
        [JsonPropertyName("clientServicePrincipal")]
        public WebJobsAuthenticationEventsContextServicePrincipal ClientServicePrincipal { get; set; }

        /// <summary>Gets the resource service principal.</summary>
        /// <value>The resource service principal.</value>
        [JsonPropertyName("resourceServicePrincipal")]
        public WebJobsAuthenticationEventsContextServicePrincipal ResourceServicePrincipal { get; set; }

        /// <summary>Gets the user.</summary>
        /// <value>The user.</value>
        [JsonPropertyName("user")]
        public WebJobsAuthenticationEventsContextUser User { get; set; }
    }
}