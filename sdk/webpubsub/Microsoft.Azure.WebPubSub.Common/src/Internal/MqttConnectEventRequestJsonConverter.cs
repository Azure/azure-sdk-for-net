// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class MqttConnectEventRequestJsonConverter : JsonConverter<MqttConnectEventRequest>
    {
        public override MqttConnectEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            var mqtt = JsonSerializer.Deserialize(
                element.GetProperty(MqttConnectEventRequest.MqttPropertyName).GetRawText(),
                WebPubSubCommonJsonSerializerContext.Default.MqttConnectProperties);

            return new MqttConnectEventRequest(
                null,
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.ClaimsProperty)),
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.QueryProperty)),
                JsonSerializationHelpers.ReadClientCertificates(element.GetProperty(ConnectEventRequest.ClientCertificatesProperty)),
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.HeadersProperty)),
                mqtt);
        }

        public override void Write(Utf8JsonWriter writer, MqttConnectEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(ConnectEventRequest.ClaimsProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Claims);

            writer.WritePropertyName(ConnectEventRequest.QueryProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Query);

            writer.WritePropertyName(ConnectEventRequest.HeadersProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Headers);

            writer.WritePropertyName(ConnectEventRequest.SubprotocolsProperty);
            JsonSerializationHelpers.WriteStringArray(writer, value.Subprotocols);

            writer.WritePropertyName(ConnectEventRequest.ClientCertificatesProperty);
            JsonSerializationHelpers.WriteClientCertificates(writer, value.ClientCertificates);

            writer.WritePropertyName(MqttConnectEventRequest.MqttPropertyName);
            JsonSerializer.Serialize(writer, value.Mqtt, WebPubSubCommonJsonSerializerContext.Default.MqttConnectProperties);

            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(WebPubSubEventRequest.ConnectionContextProperty);
                JsonSerializationHelpers.WriteConnectionContext(writer, value.ConnectionContext);
            }

            writer.WriteEndObject();
        }
    }
}
