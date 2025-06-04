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
                        code = JsonSerializer.Deserialize<MqttDisconnectReasonCode>(ref reader, options);
                        break;

                    case MqttDisconnectPacketProperties.UserPropertiesProperty:
                        userProperties = JsonSerializer.Deserialize<List<MqttUserProperty>>(ref reader, options);
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

        writer.WritePropertyName(MqttDisconnectPacketProperties.CodeProperty);
        JsonSerializer.Serialize(writer, value.Code, options);

        if (value.UserProperties != null)
        {
            writer.WritePropertyName(MqttDisconnectPacketProperties.UserPropertiesProperty);
            JsonSerializer.Serialize(writer, value.UserProperties, options);
        }

        writer.WriteEndObject();
    }
}