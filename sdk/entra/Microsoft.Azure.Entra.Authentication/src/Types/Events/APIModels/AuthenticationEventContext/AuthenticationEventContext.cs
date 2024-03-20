// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// This model represents context about the authentication process that the callout originates from.
    /// This is included in all custom extension callouts that occur due to an authentication event.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AuthenticationEventContext
    {
        /// <summary>
        /// The correlation identifier for the request.
        /// </summary>
        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>
        /// The client context data that will be sent to the registered custom extension.
        /// </summary>
        [JsonProperty("client")]
        public AuthenticationEventContextClient Client { get; set; }

        /// <summary>
        /// The authentication protocol used for the request to AAD.
        /// </summary>
        [JsonProperty("protocol")]
        public AuthenticationProtocolType? Protocol { get; set; }

        /// <summary>
        /// The service principal data of the client application that will be sent to the registered custom extension.
        /// </summary>
        [JsonProperty("clientServicePrincipal")]
        public AuthenticationEventContextServicePrincipal ClientServicePrincipal { get; set; }

        /// <summary>
        /// The service principal data of the resource application that will be sent to the registered custom extension.
        /// </summary>
        [JsonProperty("resourceServicePrincipal")]
        public AuthenticationEventContextServicePrincipal ResourceServicePrincipal { get; set; }

        /// <summary>
        /// The user data that will be sent to the registered custom extension.
        /// </summary>
        [JsonProperty("user")]
        public AuthenticationEventContextUser User { get; set; }

        /// <summary>
        /// Create an empty AuthenticationEventContext
        /// </summary>
        [JsonConstructor]
        public AuthenticationEventContext()
        {
        }
    }
}
