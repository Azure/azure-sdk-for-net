// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubConnectionContextJsonConverter : JsonConverter<WebPubSubConnectionContext>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override WebPubSubConnectionContext ReadJson(JsonReader reader, Type objectType, WebPubSubConnectionContext existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, WebPubSubConnectionContext value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                writer.WritePropertyName("eventType");
                writer.WriteValue(value.EventType.ToString());
                writer.WritePropertyName("eventName");
                writer.WriteValue(value.EventName);
                writer.WritePropertyName("hub");
                writer.WriteValue(value.Hub);
                writer.WritePropertyName("connectionId");
                writer.WriteValue(value.ConnectionId);
                writer.WritePropertyName("userId");
                writer.WriteValue(value.UserId);
                writer.WritePropertyName("signature");
                writer.WriteValue(value.Signature);
                writer.WritePropertyName("origin");
                writer.WriteValue(value.Origin);
                writer.WritePropertyName("states");
                writer.WriteStartObject();
                foreach (var item in value.ConnectionStates)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteRawValue(item.Value.ToString());
                }
                writer.WriteEndObject();
                writer.WritePropertyName("header");
                serializer.Serialize(writer, value.Headers);
            }
            writer.WriteEndObject();
        }
    }
}
