// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations
{
    /// <summary>
    /// Operation to send message to a group.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToGroup : WebPubSubOperation
    {
        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Message to send.
        /// </summary>
        [JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Message { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public MessageDataType DataType { get; set; } = MessageDataType.Binary;

        /// <summary>
        /// ConnectionIds to exclude.
        /// </summary>
        public string[] Excluded { get; set; }
    }
}
