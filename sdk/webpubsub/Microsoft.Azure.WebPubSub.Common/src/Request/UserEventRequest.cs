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
        [JsonPropertyName("data"), JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Data { get; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType"), JsonConverter(typeof(JsonStringEnumConverter))]
        public WebPubSubDataType DataType { get; }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="data">String message to return caller.</param>
        /// <param name="dataType">Message <see cref="WebPubSubDataType"/>, default as Text.</param>
        /// <returns>A message response to return caller.</returns>
        public UserEventResponse CreateResponse(string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
        {
            return new UserEventResponse(data, dataType);
        }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="data">BinaryData message to return caller.</param>
        /// <param name="dataType">Message <see cref="WebPubSubDataType"/>.</param>
        /// <returns>A message response to return caller.</returns>
        public UserEventResponse CreateResponse(BinaryData data, WebPubSubDataType dataType)
        {
            return new UserEventResponse(data, dataType);
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

        internal UserEventRequest(WebPubSubConnectionContext connectionContext, BinaryData data, WebPubSubDataType dataType)
            : base(connectionContext)
        {
            Data = data;
            DataType = dataType;
        }

        internal UserEventRequest()
            : base(null)
        { }
    }
}
