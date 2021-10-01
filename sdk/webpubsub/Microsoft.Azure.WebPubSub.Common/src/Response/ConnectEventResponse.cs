// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Response for connect event.
    /// </summary>
    public class ConnectEventResponse : WebPubSubEventResponse
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
        /// Create an instance of ConnectEventResponse
        /// </summary>
        /// <param name="userId">User Id of current connection.</param>
        /// <param name="groups">Groups belong of current connection.</param>
        /// <param name="subprotocol">Subprotocol to use for current connection.</param>
        /// <param name="roles">Roles belongs of current connection.</param>
        public ConnectEventResponse(
            string userId,
            IEnumerable<string> groups,
            string subprotocol,
            IEnumerable<string> roles)
        {
            UserId = userId;
            Groups = groups?.ToArray();
            Subprotocol = subprotocol;
            Roles = roles?.ToArray();
        }

        /// <summary>
        /// Default constructor for JsonSerialize.
        /// </summary>
        public ConnectEventResponse()
        { }

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
