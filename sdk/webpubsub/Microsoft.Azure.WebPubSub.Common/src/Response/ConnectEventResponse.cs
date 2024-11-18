// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Response for connect event.
    /// </summary>
    [DataContract]
    public class ConnectEventResponse : WebPubSubEventResponse
    {
        private Dictionary<string, BinaryData> _states;

        [JsonIgnore]
        internal override WebPubSubStatusCode StatusCode
        {
            get
            {
                return WebPubSubStatusCode.Success;
            }
            set
            {
                if (value != WebPubSubStatusCode.Success)
                {
                    throw new ArgumentException("StatusCode shouldn't be set to errors in a normal connect event.");
                }
            }
        }

        /// <summary>
        /// The connection states.
        /// </summary>
        [IgnoreDataMember]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        public IReadOnlyDictionary<string, object> States { get; private set; }

        /// <summary>
        /// The connection states.
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates => _states;

        /// <summary>
        /// UserId.
        /// </summary>
        [DataMember(Name = "userId")]
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Groups.
        /// </summary>
        [DataMember(Name = "groups")]
        [JsonPropertyName("groups")]
        public string[] Groups { get; set; }

        /// <summary>
        /// Subprotocol.
        /// </summary>
        [DataMember(Name = "subprotocol")]
        [JsonPropertyName("subprotocol")]
        public string Subprotocol { get; set; }

        /// <summary>
        /// User roles.
        /// </summary>
        [DataMember(Name = "roles")]
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
            : this()
        {
            UserId = userId;
            Groups = groups?.ToArray();
            Subprotocol = subprotocol;
            Roles = roles?.ToArray();
        }

        /// <summary>
        /// Default constructor for JsonSerialize.
        /// </summary>
        public ConnectEventResponse() =>
            SetStatesDictionary(new Dictionary<string, BinaryData>());

        /// <summary>
        /// Set connection states.
        /// </summary>
        /// <param name="key">State key.</param>
        /// <param name="value">State value.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetState(string key, object value) =>
            SetState(key, BinaryData.FromObjectAsJson(value));

        /// <summary>
        /// Set connection states.
        /// </summary>
        /// <param name="key">State key.</param>
        /// <param name="value">State value.</param>
        public void SetState(string key, BinaryData value)
        {
            // In case user cleared states.
            if (_states == null)
            {
                SetStatesDictionary(new Dictionary<string, BinaryData>());
            }
            _states[key] = value;
        }

        /// <summary>
        /// Clear all states.
        /// </summary>
        public void ClearStates() => SetStatesDictionary(null);

        /// <summary>
        /// Update the dictionary backing both States and ConnectionStates.
        /// </summary>
        /// <param name="states">The new dictionary or null.</param>
        private void SetStatesDictionary(Dictionary<string, BinaryData> states)
        {
            _states = states;
            States = states != null ? new StringifiedDictionary(states) : null;
        }
    }
}
