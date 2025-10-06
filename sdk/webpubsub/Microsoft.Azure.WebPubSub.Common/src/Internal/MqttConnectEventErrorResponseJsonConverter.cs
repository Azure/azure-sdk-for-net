// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Ignore the properties in the base class <see cref="EventErrorResponse"/> during (de)serialization.
/// </summary>
internal class MqttConnectEventErrorResponseJsonConverter : JsonConverter<MqttConnectEventErrorResponse>
{
    public override MqttConnectEventErrorResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        MqttConnectEventErrorResponseProperties? mqtt = null;
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
                    case MqttConnectEventErrorResponse.MqttProperty:
                        mqtt = JsonSerializer.Deserialize<MqttConnectEventErrorResponseProperties>(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        if (mqtt == null)
        {
            throw new JsonException($"Missing required property `{MqttConnectEventErrorResponse.MqttProperty}`.");
        }
        return new MqttConnectEventErrorResponse(mqtt);
    }

    public override void Write(Utf8JsonWriter writer, MqttConnectEventErrorResponse value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(MqttConnectEventErrorResponse.MqttProperty);
        JsonSerializer.Serialize(writer, value.Mqtt, options);
        writer.WriteEndObject();
    }
}
