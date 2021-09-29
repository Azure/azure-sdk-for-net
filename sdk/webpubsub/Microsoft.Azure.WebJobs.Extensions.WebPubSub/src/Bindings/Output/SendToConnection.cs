// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebPubSub.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToConnection : WebPubSubOperation
    {
        public string ConnectionId { get; set; }

        public BinaryData Message { get; set; }

        public MessageDataType DataType { get; set; } = MessageDataType.Binary;
    }
}
