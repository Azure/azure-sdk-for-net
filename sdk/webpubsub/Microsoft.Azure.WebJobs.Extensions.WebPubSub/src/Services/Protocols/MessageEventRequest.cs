// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public sealed class MessageEventRequest : ServiceRequest
    {
        public BinaryData Message { get; }
        public MessageDataType DataType { get; }
        public override string Name => nameof(MessageEventRequest);

        public MessageEventRequest(BinaryData message, MessageDataType dataType)
            : base(false, true)
        {
            Message = message;
            DataType = dataType;
        }
    }
}
