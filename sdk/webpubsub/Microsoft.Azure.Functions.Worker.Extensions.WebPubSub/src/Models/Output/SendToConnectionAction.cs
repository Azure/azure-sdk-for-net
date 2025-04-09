// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to send message to a connection.
    /// </summary>
    public class SendToConnectionAction : WebPubSubAction
    {
        /// <summary>
        /// Target ConnectionId.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Message to send.
        /// </summary>
        [JsonConverter(typeof(System.BinaryDataJsonConverter))]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public WebPubSubDataType DataType { get; set; } = WebPubSubDataType.Text;
    }
}
