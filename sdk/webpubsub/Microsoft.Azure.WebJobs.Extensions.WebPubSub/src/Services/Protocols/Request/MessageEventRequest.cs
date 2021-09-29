// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// User message event request.
    /// </summary>
    public sealed class MessageEventRequest : WebPubSubRequest
    {
        /// <summary>
        /// Message content.
        /// </summary>
        [JsonPropertyName("message")]
        public BinaryData Message { get; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType"), JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageDataType DataType { get; }

        /// <summary>
        /// Create <see cref="MessageResponse"/>.
        /// </summary>
        /// <param name="message">String message to return caller.</param>
        /// <param name="dataType">Message <see cref="MessageDataType"/>, default as Text.</param>
        /// <returns>A <see cref="MessageResponse"/> to return caller.</returns>
        public static MessageResponse CreateResponse(string message, MessageDataType dataType = MessageDataType.Text)
        {
            return new MessageResponse(message, dataType);
        }

        /// <summary>
        /// Create <see cref="MessageResponse"/>.
        /// </summary>
        /// <param name="message">BinaryData message to return caller.</param>
        /// <param name="dataType">Message <see cref="MessageDataType"/>.</param>
        /// <returns>A <see cref="MessageResponse"/> to return caller.</returns>
        public static MessageResponse CreateResponse(BinaryData message, MessageDataType dataType)
        {
            return new MessageResponse(message, dataType);
        }

        /// <summary>
        /// Create <see cref="ErrorResponse"/>.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A <see cref="ErrorResponse"/> to return caller.</returns>
        public static ErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
        {
            return new ErrorResponse(code, message);
        }

        internal MessageEventRequest(ConnectionContext connectionContext, BinaryData message, MessageDataType dataType)
            : base(connectionContext)
        {
            Message = message;
            DataType = dataType;
        }
    }
}
