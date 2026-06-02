// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

internal class MqttDisconnectPacketPropertiesJsonConverter : JsonConverter<MqttDisconnectPacketProperties>
{
    public override MqttDisconnectPacketProperties Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        MqttDisconnectReasonCode? code = null;
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
                    case MqttDisconnectPacketProperties.CodeProperty:
                        code = (MqttDisconnectReasonCode)reader.GetInt32();
                        break;

                    case MqttDisconnectPacketProperties.UserPropertiesProperty:
                        userProperties = ReadUserProperties(ref reader);
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        // Ensure that the required 'code' property is present
        if (code == null)
        {
            throw new JsonException($"Missing required property '{MqttDisconnectPacketProperties.CodeProperty}'.");
        }

        return new MqttDisconnectPacketProperties(code.Value, userProperties);
    }

    public override void Write(Utf8JsonWriter writer, MqttDisconnectPacketProperties value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteNumber(MqttDisconnectPacketProperties.CodeProperty, (int)value.Code);

        if (value.UserProperties != null)
        {
            writer.WritePropertyName(MqttDisconnectPacketProperties.UserPropertiesProperty);
            WriteUserProperties(writer, value.UserProperties);
        }

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
