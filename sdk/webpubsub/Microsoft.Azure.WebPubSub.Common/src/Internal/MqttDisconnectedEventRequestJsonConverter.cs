// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class MqttDisconnectedEventRequestJsonConverter : JsonConverter<MqttDisconnectedEventRequest>
    {
        public override MqttDisconnectedEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            var mqtt = JsonSerializer.Deserialize(
                element.GetProperty(MqttDisconnectedEventRequest.MqttProperty).GetRawText(),
                typeof(MqttDisconnectedEventRequestProperties),
                options) as MqttDisconnectedEventRequestProperties;

            return new MqttDisconnectedEventRequest(
                null,
                element.GetProperty(DisconnectedEventRequest.ReasonProperty).GetString(),
                mqtt);
        }

        public override void Write(Utf8JsonWriter writer, MqttDisconnectedEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(DisconnectedEventRequest.ReasonProperty, value.Reason);

            writer.WritePropertyName(MqttDisconnectedEventRequest.MqttProperty);
            JsonSerializer.Serialize(writer, value.Mqtt, typeof(MqttDisconnectedEventRequestProperties), options);

            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(WebPubSubEventRequest.ConnectionContextProperty);
                JsonSerializationHelpers.WriteConnectionContext(writer, value.ConnectionContext);
            }

            writer.WriteEndObject();
        }
    }
}
