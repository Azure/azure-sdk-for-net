// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Amqp.Config
{
    internal class WebProxyConverter : JsonConverter<IWebProxy>
    {
        public override void WriteJson(JsonWriter writer, IWebProxy value, JsonSerializer serializer)
        {
            writer.WriteValue(value.GetProxy(new Uri("https://servicebus.windows.net")));
        }

        public override IWebProxy ReadJson(JsonReader reader, Type objectType, IWebProxy existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string proxy = (string) reader.Value;
            return !string.IsNullOrEmpty(proxy) ? new WebProxy(proxy) : null;
        }
    }
}