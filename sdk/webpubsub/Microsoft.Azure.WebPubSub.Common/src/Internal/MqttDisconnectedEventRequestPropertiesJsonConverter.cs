// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                        disconnectPacket = ReadDisconnectPacket(ref reader);
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

        writer.WriteBoolean(MqttDisconnectedEventRequestProperties.InitiatedByClientProperty, value.InitiatedByClient);

        if (value.DisconnectPacket != null)
        {
            writer.WritePropertyName(MqttDisconnectedEventRequestProperties.DisconnectPacketProperty);
            WriteDisconnectPacket(writer, value.DisconnectPacket);
        }

        writer.WriteEndObject();
    }

    private static MqttDisconnectPacketProperties? ReadDisconnectPacket(ref Utf8JsonReader reader)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        JsonElement element = jsonDocument.RootElement;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        MqttDisconnectReasonCode? code = null;
        IReadOnlyList<MqttUserProperty>? userProperties = null;

        if (element.TryGetProperty(MqttDisconnectPacketProperties.CodeProperty, out JsonElement codeElement))
        {
            code = (MqttDisconnectReasonCode)codeElement.GetInt32();
        }

        if (element.TryGetProperty(MqttDisconnectPacketProperties.UserPropertiesProperty, out JsonElement userPropertiesElement))
        {
            userProperties = ReadUserProperties(userPropertiesElement);
        }

        if (code == null)
        {
            throw new JsonException($"Missing required property '{MqttDisconnectPacketProperties.CodeProperty}'.");
        }

        return new MqttDisconnectPacketProperties(code.Value, userProperties);
    }

    private static IReadOnlyList<MqttUserProperty>? ReadUserProperties(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        List<MqttUserProperty> result = new();
        foreach (JsonElement property in element.EnumerateArray())
        {
            string? name = null;
            string? value = null;

            foreach (JsonProperty item in property.EnumerateObject())
            {
                if (item.NameEquals(MqttUserProperty.NamePropertyName))
                {
                    name = item.Value.GetString();
                }
                else if (item.NameEquals(MqttUserProperty.ValuePropertyName))
                {
                    value = item.Value.GetString();
                }
            }

            result.Add(new MqttUserProperty(name!, value!));
        }

        return result;
    }

    private static void WriteDisconnectPacket(Utf8JsonWriter writer, MqttDisconnectPacketProperties disconnectPacket)
    {
        writer.WriteStartObject();
        writer.WriteNumber(MqttDisconnectPacketProperties.CodeProperty, (int)disconnectPacket.Code);

        if (disconnectPacket.UserProperties != null)
        {
            writer.WritePropertyName(MqttDisconnectPacketProperties.UserPropertiesProperty);
            WriteUserProperties(writer, disconnectPacket.UserProperties);
        }

        writer.WriteEndObject();
    }

    private static void WriteUserProperties(Utf8JsonWriter writer, IReadOnlyList<MqttUserProperty> userProperties)
    {
        writer.WriteStartArray();
        foreach (MqttUserProperty property in userProperties)
        {
            writer.WriteStartObject();
            writer.WriteString(MqttUserProperty.NamePropertyName, property.Name);
            writer.WriteString(MqttUserProperty.ValuePropertyName, property.Value);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}
