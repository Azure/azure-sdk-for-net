// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

internal class MqttUserPropertyJsonConverter : JsonConverter<MqttUserProperty>
{
    public override MqttUserProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        string name = null;
        string value = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            var propertyName = reader.GetString();
            reader.Read();

            switch (propertyName)
            {
                case MqttUserProperty.NamePropertyName:
                    name = reader.GetString();
                    break;
                case MqttUserProperty.ValuePropertyName:
                    value = reader.GetString();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        return new MqttUserProperty(name, value);
    }

    public override void Write(Utf8JsonWriter writer, MqttUserProperty value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString(MqttUserProperty.NamePropertyName, value.Name);
        writer.WriteString(MqttUserProperty.ValuePropertyName, value.Value);

        writer.WriteEndObject();
    }
}
