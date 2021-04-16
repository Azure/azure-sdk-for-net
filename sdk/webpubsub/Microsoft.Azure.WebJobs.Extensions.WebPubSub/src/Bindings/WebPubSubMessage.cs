// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Message to communicate with service
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    [JsonConverter(typeof(MessageJsonConverter))]
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

    internal static class MessageExtensions
    {
        public static object Convert(this WebPubSubMessage message, Type targetType)
        {
            if (targetType == typeof(JObject))
            {
                return JObject.FromObject(message.ToArray());
            }

            if (targetType == typeof(Stream))
            {
                return message.ToStream();
            }

            if (targetType == typeof(byte[]))
            {
                return message.ToArray();
            }

            if (targetType == typeof(string))
            {
                return message.ToString();
            }

            return null;
        }
    }
}
