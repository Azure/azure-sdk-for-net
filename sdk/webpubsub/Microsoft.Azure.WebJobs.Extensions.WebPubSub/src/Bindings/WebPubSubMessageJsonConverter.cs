// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class MessageJsonConverter : JsonConverter<WebPubSubMessage>
    {
        public override WebPubSubMessage ReadJson(JsonReader reader, Type objectType, WebPubSubMessage existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JToken.Load(reader);

            return new WebPubSubMessage(jObject.ToString());
        }
    
        public override void WriteJson(JsonWriter writer, WebPubSubMessage value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
