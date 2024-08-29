// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

internal class MqttDisconnectedEventRequestPropertiesJsonConverter : JsonConverter<MqttDisconnectedEventRequestProperties>
{
    public override MqttDisconnectedEventRequestProperties Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        bool? initiatedByClient = null;
        MqttDisconnectPacketProperties? disconnectPacket = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case MqttDisconnectedEventRequestProperties.InitiatedByClientProperty:
                        initiatedByClient = reader.GetBoolean();
                        break;

                    case MqttDisconnectedEventRequestProperties.DisconnectPacketProperty:
                        disconnectPacket = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(ref reader, options);
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        // Ensure that the required 'initiatedByClient' property is present
        if (initiatedByClient == null)
        {
            throw new JsonException($"Missing required property '{MqttDisconnectedEventRequestProperties.InitiatedByClientProperty}'.");
        }

        return new MqttDisconnectedEventRequestProperties(initiatedByClient.Value, disconnectPacket);
    }

    public override void Write(Utf8JsonWriter writer, MqttDisconnectedEventRequestProperties value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName(MqttDisconnectedEventRequestProperties.InitiatedByClientProperty);
        writer.WriteBooleanValue(value.InitiatedByClient);

        if (value.DisconnectPacket != null)
        {
            writer.WritePropertyName(MqttDisconnectedEventRequestProperties.DisconnectPacketProperty);
            JsonSerializer.Serialize(writer, value.DisconnectPacket, options);
        }

        writer.WriteEndObject();
    }
}