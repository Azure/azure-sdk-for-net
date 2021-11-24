// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Response for message events.
    /// </summary>
    public class UserEventResponse : WebPubSubEventResponse
    {
        private Dictionary<string, BinaryData> _states = new();

        /// <summary>
        /// The connection states.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, object> States { get; private set; }

        /// <summary>
        /// The connection states.
        /// </summary>
        public IReadOnlyDictionary<string, BinaryData> ConnectionStates => _states;

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("data"), JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType"), JsonConverter(typeof(JsonStringEnumConverter))]
        public WebPubSubDataType DataType { get; set; }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="data">BinaryData type message.</param>
        /// <param name="dataType">Message data type.</param>
        public UserEventResponse(BinaryData data, WebPubSubDataType dataType)
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
        public UserEventResponse()
        { }

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
                _states = new Dictionary<string, BinaryData>();
                States = new StringifiedDictionary(_states);
            }
            _states[key] = value;
        }

        /// <summary>
        /// Clear all states.
        /// </summary>
        public void ClearStates()
        {
            _states = null;
            States = null;
        }
    }
}
