// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal static class WebPubSubMessageExtensions
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
