// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        //IReadOnlyList<KeyValuePair<string, string>>? userProperties = null;

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
                        protocolVersion = JsonSerializer.Deserialize<MqttProtocolVersion>(ref reader, options);
                        break;

                    case MqttConnectProperties.UsernameProperty:
                        username = reader.GetString();
                        break;

                    case MqttConnectProperties.PasswordProperty:
                        password = reader.GetString();
                        break;

                    //case MqttConnectProperties.UserPropertiesProperty:
                    //    userProperties = JsonSerializer.Deserialize<IReadOnlyList<KeyValuePair<string, string>>>(ref reader, MqttUserPropertyConverterOptions);
                    //    break;
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

        return new MqttConnectProperties(protocolVersion.Value, username, password);
    }

    public override void Write(Utf8JsonWriter writer, MqttConnectProperties value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}