// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubEventTypeJsonConverter : JsonConverter<WebPubSubEventType>
    {
        private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            Converters = new[]
            {
                new StringEnumConverter()
            }
        });

        public override WebPubSubEventType ReadJson(JsonReader reader, Type objectType, WebPubSubEventType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return JsonSerializer.Deserialize<WebPubSubEventType>(reader);
        }

        public override void WriteJson(JsonWriter writer, WebPubSubEventType value, JsonSerializer serializer)
        {
            JsonSerializer.Serialize(writer, value);
        }
    }
}
