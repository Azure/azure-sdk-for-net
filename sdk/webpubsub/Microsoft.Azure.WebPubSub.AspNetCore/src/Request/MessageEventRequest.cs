// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// User message event request.
    /// </summary>
    public sealed class MessageEventRequest : ServiceRequest
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

        internal MessageEventRequest(ConnectionContext connectionContext, BinaryData message, MessageDataType dataType)
            : base(connectionContext)
        {
            Message = message;
            DataType = dataType;
        }
    }
}
