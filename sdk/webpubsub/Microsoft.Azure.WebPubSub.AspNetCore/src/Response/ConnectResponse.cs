// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response for connect event.
    /// </summary>
    public class ConnectResponse : ServiceResponse
    {
        /// <summary>
        /// UserId.
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Groups.
        /// </summary>
        [JsonPropertyName("groups")]
        public string[] Groups { get; set; }

        /// <summary>
        /// Subprotocol.
        /// </summary>
        [JsonPropertyName("subprotocol")]
        public string Subprotocol { get; set; }

        /// <summary>
        /// User roles.
        /// </summary>
        [JsonPropertyName("roles")]
        public string[] Roles { get; set; }
    }
}
