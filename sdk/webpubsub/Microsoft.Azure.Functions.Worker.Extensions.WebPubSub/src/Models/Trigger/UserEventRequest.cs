// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// User message event request.
    /// </summary>
    public sealed class UserEventRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// Message content.
        /// </summary>
        [JsonConverter(typeof(System.BinaryDataJsonConverter))]
        [JsonPropertyName("data")]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        [JsonPropertyName("dataType")]
        public WebPubSubDataType DataType { get; set; }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="data">String message to return caller.</param>
        /// <param name="dataType">Message <see cref="WebPubSubDataType"/>, default as Text.</param>
        /// <returns>A message response to return caller.</returns>
        public static UserEventResponse CreateResponse(string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
        {
            return new UserEventResponse(data, dataType);
        }

        /// <summary>
        /// Create <see cref="UserEventResponse"/>.
        /// </summary>
        /// <param name="data">BinaryData message to return caller.</param>
        /// <param name="dataType">Message <see cref="WebPubSubDataType"/>.</param>
        /// <returns>A message response to return caller.</returns>
        public static UserEventResponse CreateResponse(BinaryData data, WebPubSubDataType dataType)
        {
            return new UserEventResponse(data, dataType);
        }

        /// <summary>
        /// Create <see cref="EventErrorResponse"/>.
        /// Methods works for Function Extensions. And AspNetCore SDK Hub methods can directly throw exception for error cases.
        /// </summary>
        /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
        /// <param name="message">Detail error message.</param>
        /// <returns>A error response to return caller and will drop connection.</returns>
        public static EventErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string message)
        {
            return new EventErrorResponse(code, message);
        }

        /// <summary>
        /// Constructor for Json serialize.
        /// </summary>
        public UserEventRequest()
        { }
    }
}
