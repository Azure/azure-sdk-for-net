// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public sealed class MessageEventRequest : ServiceRequest
    {
        public BinaryData Message { get; }
        public MessageDataType DataType { get; }

        public MessageEventRequest(BinaryData message, MessageDataType dataType)
        {
            Message = message;
            DataType = dataType;
        }
    }
}
