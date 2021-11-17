// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to send message to a user.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToUserAction : WebPubSubAction
    {
        /// <summary>
        /// Target UserId.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Message to send.
        /// </summary>
        [JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public WebPubSubDataType DataType { get; set; } = WebPubSubDataType.Text;
    }
}
