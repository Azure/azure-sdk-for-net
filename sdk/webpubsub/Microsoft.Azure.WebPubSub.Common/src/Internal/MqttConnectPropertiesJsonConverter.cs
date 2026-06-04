// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

internal class MqttConnectPropertiesJsonConverter : JsonConverter<MqttConnectProperties>
{
    public override MqttConnectProperties Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        MqttProtocolVersion? protocolVersion = null;
        string? username = null;
        string? password = null;
        IReadOnlyList<MqttUserProperty>? userProperties = null;

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
                    case MqttConnectProperties.ProtocolVersionProperty:
                        protocolVersion = (MqttProtocolVersion)reader.GetInt32();
                        break;

                    case MqttConnectProperties.UsernameProperty:
                        username = reader.TokenType == JsonTokenType.Null ? null : reader.GetString();
                        break;

                    case MqttConnectProperties.PasswordProperty:
                        password = reader.TokenType == JsonTokenType.Null ? null : reader.GetString();
                        break;

                    case MqttConnectProperties.UserPropertiesProperty:
                        userProperties = ReadUserProperties(ref reader);
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        // Ensure that the required properties are present
        if (protocolVersion == null)
        {
            throw new JsonException($"Missing required property '{MqttConnectProperties.ProtocolVersionProperty}'.");
        }

        return new MqttConnectProperties(protocolVersion.Value, username, password, userProperties);
    }

    public override void Write(Utf8JsonWriter writer, MqttConnectProperties value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber(MqttConnectProperties.ProtocolVersionProperty, (int)value.ProtocolVersion);
        writer.WriteString(MqttConnectProperties.UsernameProperty, value.Username);
        writer.WriteString(MqttConnectProperties.PasswordProperty, value.Password);

        writer.WritePropertyName(MqttConnectProperties.UserPropertiesProperty);
        WriteUserProperties(writer, value.UserProperties);

        writer.WriteEndObject();
    }

    private static IReadOnlyList<MqttUserProperty>? ReadUserProperties(ref Utf8JsonReader reader)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        JsonElement element = jsonDocument.RootElement;

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

    private static void WriteUserProperties(Utf8JsonWriter writer, IReadOnlyList<MqttUserProperty>? userProperties)
    {
        if (userProperties == null)
        {
            writer.WriteNullValue();
            return;
        }

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
