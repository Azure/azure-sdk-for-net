// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing the data from groups.
    /// </summary>
    public class GroupDataMessage : WebPubSubMessage
    {
        /// <summary>
        /// Type of the data
        /// </summary>
        public WebPubSubDataType DataType { get; }

        /// <summary>
        /// The data content
        /// </summary>
        public BinaryData Data { get; }

        /// <summary>
        /// The sequence id. Only availble in reliable protocol.
        /// </summary>
        public long? SequenceId { get; }

        /// <summary>
        /// The group name
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// FromUserId
        /// </summary>
        public string FromUserId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDataMessage"/> class.
        /// </summary>
        /// <param name="group">The group name</param>
        /// <param name="dataType">Type of the data</param>
        /// <param name="data">The data content</param>
        /// <param name="sequenceId">The sequence id. Only availble in reliable protocol.</param>
        /// <param name="fromUserId">fromUserId.</param>
        public GroupDataMessage(string group, WebPubSubDataType dataType, BinaryData data, long? sequenceId, string fromUserId)
        {
            DataType = dataType;
            Data = data;
            SequenceId = sequenceId;
            Group = group;
            FromUserId = fromUserId;
        }
    }
}
