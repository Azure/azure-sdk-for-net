// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Client Service Principal represents the a subset of data about the service principal
    /// of the client application used for the authentication request/sign in.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AuthenticationEventContextServicePrincipal
    {
        /// <summary>
        /// The object ID of the service principle.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The application ID of the client app.
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// The application display name.
        /// </summary>
        [JsonProperty("appDisplayName")]
        public string AppDisplayName { get; set; }

        /// <summary>
        /// The service principle display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
