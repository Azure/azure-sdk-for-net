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
    /// The message representing sending event to server.
    /// </summary>
    public class SendEventMessage : WebPubSubMessage
    {
        /// <summary>
        /// The optional ack-id
        /// </summary>
        public long? AckId { get; }

        /// <summary>
        /// Type of the data
        /// </summary>
        public WebPubSubDataType DataType { get; }

        /// <summary>
        /// The data content
        /// </summary>
        public BinaryData Data { get; }

        /// <summary>
        /// The name of custom event
        /// </summary>
        public string EventName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendEventMessage"/> class.
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="data">The data content</param>
        /// <param name="dataType">Type of the data</param>
        /// <param name="ackId">The optional ack-id</param>
        public SendEventMessage(string eventName, BinaryData data, WebPubSubDataType dataType, long? ackId)
        {
            EventName = eventName;
            AckId = ackId;
            DataType = dataType;
            Data = data;
        }
    }
}
