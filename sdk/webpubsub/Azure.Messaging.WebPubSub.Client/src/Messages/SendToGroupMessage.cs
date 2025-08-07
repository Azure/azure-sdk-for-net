// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing sending message to group.
    /// </summary>
    public class SendToGroupMessage : WebPubSubMessage
    {
        /// <summary>
        /// The group name
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// The optional ack-id
        /// </summary>
        public long? AckId { get; }

        /// <summary>
        /// Optional. If set to true, this message is not echoed back to the same connection.
        /// </summary>
        public bool NoEcho { get; }

        /// <summary>
        /// Type of the data
        /// </summary>
        public WebPubSubDataType DataType { get; }

        /// <summary>
        /// The data content
        /// </summary>
        public BinaryData Data { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendToGroupMessage"/> class.
        /// </summary>
        /// <param name="group">The group name</param>
        /// <param name="data">The data content</param>
        /// <param name="dataType">Type of the data</param>
        /// <param name="ackId">The optional ack-id</param>
        /// <param name="noEcho">Optional. If set to true, this message is not echoed back to the same connection.</param>
        public SendToGroupMessage(string group, BinaryData data, WebPubSubDataType dataType, long? ackId, bool noEcho)
        {
            Group = group;
            AckId = ackId;
            NoEcho = noEcho;
            DataType = dataType;
            Data = data;
        }
    }
}
