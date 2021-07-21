// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class MessageResponse : ServiceResponse
    {
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(BinaryDataJsonConverter))]
        public BinaryData Message { get; set; }

        public MessageDataType DataType { get; set; } = MessageDataType.Text;
    }
}
