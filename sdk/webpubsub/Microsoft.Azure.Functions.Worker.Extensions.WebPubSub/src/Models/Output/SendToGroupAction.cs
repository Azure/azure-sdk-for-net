// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to send message to a group.
    /// </summary>
    public class SendToGroupAction : WebPubSubAction
    {
        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Message to send.
        /// </summary>
        [JsonConverter(typeof(System.BinaryDataJsonConverter))]
        public BinaryData Data { get; set; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public WebPubSubDataType DataType { get; set; } = WebPubSubDataType.Text;

        /// <summary>
        /// ConnectionIds to exclude.
        /// </summary>
        public IList<string> Excluded { get; set; } = new List<string>();
    }
}
