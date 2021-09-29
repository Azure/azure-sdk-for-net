// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response for message events.
    /// </summary>
    public class MessageResponse : WebPubSubResponse
    {
        internal Dictionary<string, object> States = new();

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message"), JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Message { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType"), JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageDataType DataType { get; set; }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="message">BinaryData type message.</param>
        /// <param name="dataType">Message data type.</param>
        public MessageResponse(BinaryData message, MessageDataType dataType)
        {
            Message = message;
            DataType = dataType;
        }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="message">String type message.</param>
        /// <param name="dataType">Message data type. Default set to text.</param>
        public MessageResponse(string message, MessageDataType dataType = MessageDataType.Text)
            : this(BinaryData.FromString(message), dataType)
        { }

        /// <summary>
        /// Default constructor for JsonSerialize
        /// </summary>
        public MessageResponse()
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
