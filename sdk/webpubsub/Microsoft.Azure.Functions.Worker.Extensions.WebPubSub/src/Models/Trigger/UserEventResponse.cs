// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Response for message events.
    /// </summary>
    [DataContract]
    public class UserEventResponse : WebPubSubEventResponse
    {
        private Dictionary<string, BinaryData> _states;

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
                    throw new ArgumentException("StatusCode shouldn't be set to errors in a normal user event.");
                }
            }
        }

        /// <summary>
        /// The connection states.
        /// </summary>
        [JsonPropertyName("states")]
        [JsonConverter(typeof(ConnectionStatesConverter))]
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates => _states;

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("data")]
        [JsonConverter(typeof(System.BinaryDataJsonConverter))]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType")]
        public WebPubSubDataType DataType { get; set; }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="data">BinaryData type message.</param>
        /// <param name="dataType">Message data type.</param>
        public UserEventResponse(BinaryData data, WebPubSubDataType dataType)
            : this()
        {
            Data = data;
            DataType = dataType;
        }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="data">String type message.</param>
        /// <param name="dataType">Message data type. Default set to text.</param>
        public UserEventResponse(string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
            : this(BinaryData.FromString(data), dataType)
        { }

        /// <summary>
        /// Default constructor for JsonSerialize
        /// </summary>
        public UserEventResponse() =>
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
        }
    }
}
