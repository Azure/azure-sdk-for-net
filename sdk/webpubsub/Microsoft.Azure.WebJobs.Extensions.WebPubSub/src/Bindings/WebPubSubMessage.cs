// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Message to communicate with service
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    [JsonConverter(typeof(WebPubSubMessageJsonConverter))]
    public class WebPubSubMessage
    {
        private readonly BinaryData _body;

        public WebPubSubMessage(Stream message)
        {
            _body = BinaryData.FromStream(message);
        }

        public WebPubSubMessage(string message)
        {
            _body = BinaryData.FromString(message);
        }

        public WebPubSubMessage(byte[] message)
        {
            _body = BinaryData.FromBytes(message);
        }

        public byte[] ToArray()
        {
            return _body.ToArray();
        }

        public override string ToString()
        {
            return _body.ToString();
        }

        public Stream ToStream()
        {
            return _body.ToStream();
        }

        public BinaryData ToBinaryData()
        {
            return _body;
        }
    }
}
