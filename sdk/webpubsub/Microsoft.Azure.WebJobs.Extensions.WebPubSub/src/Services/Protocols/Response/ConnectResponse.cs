// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response for connect event.
    /// </summary>
    public class ConnectResponse : WebPubSubResponse
    {
        internal Dictionary<string, object> States = new();

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


        /// <summary>
        /// Set connection states.
        /// </summary>
        /// <param name="key">State key.</param>
        /// <param name="value">State value.</param>
        public void SetState(string key, object value)
        {
            // In case user cleared states.
            if (States == null)
            {
                States = new Dictionary<string, object>();
            }
            States[key] = value;
        }

        /// <summary>
        /// Clear all states.
        /// </summary>
        public void ClearStates()
        {
            States = null;
        }
    }
}
