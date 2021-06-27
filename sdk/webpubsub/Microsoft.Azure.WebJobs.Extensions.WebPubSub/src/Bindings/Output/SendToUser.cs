// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToUser : WebPubSubOperation
    {
        public string UserId { get; set; }

        public BinaryData Message { get; set; }

        public MessageDataType DataType { get; set; } = MessageDataType.Binary;
    }
}
