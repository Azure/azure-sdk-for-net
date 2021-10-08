// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// User message event request.
    /// </summary>
    public sealed class UserEventRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// Message content.
        /// </summary>
        [JsonPropertyName("message"), JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Message { get; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType"), JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageDataType DataType { get; }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="message">String message to return caller.</param>
        /// <param name="dataType">Message <see cref="MessageDataType"/>, default as Text.</param>
        /// <returns>A message response to return caller.</returns>
        public UserEventResponse CreateResponse(string message, MessageDataType dataType = MessageDataType.Text)
        {
            return new UserEventResponse(message, dataType);
        }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="message">BinaryData message to return caller.</param>
        /// <param name="dataType">Message <see cref="MessageDataType"/>.</param>
        /// <returns>A message response to return caller.</returns>
        public UserEventResponse CreateResponse(BinaryData message, MessageDataType dataType)
        {
            return new UserEventResponse(message, dataType);
        }

        /// <summary>
        /// Create <see cref="EventErrorResponse"/>.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A error response to return caller and will drop connection.</returns>
        public EventErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
        {
            return new EventErrorResponse(code, message);
        }

        internal UserEventRequest(WebPubSubConnectionContext connectionContext, BinaryData message, MessageDataType dataType)
            : base(connectionContext)
        {
            Message = message;
            DataType = dataType;
        }

        internal UserEventRequest()
            : base(null)
        { }
    }
}
