// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations
{
    /// <summary>
    /// Operation to send message to all.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToAll : WebPubSubOperation
    {
        /// <summary>
        /// Message to broadcast.
        /// </summary>
        [JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Message { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public MessageDataType DataType { get; set; } = MessageDataType.Binary;

        /// <summary>
        /// ConnectionIds to excluded.
        /// </summary>
        public string[] Excluded { get; set; }
    }
}
