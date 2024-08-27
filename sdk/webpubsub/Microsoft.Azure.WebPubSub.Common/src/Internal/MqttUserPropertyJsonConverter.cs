// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

internal class MqttUserPropertyJsonConverter : JsonConverter<KeyValuePair<string, string>>
{
    private const string NamePropertyName = "name";
    private const string ValuePropertyName = "value";

    public override KeyValuePair<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case NamePropertyName:
                    name = reader.GetString();
                    break;
                case ValuePropertyName:
                    value = reader.GetString();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        if (name == null)
        {
            throw new JsonException($"Missing required property '{NamePropertyName}'.");
        }

        if (value == null)
        {
            throw new JsonException($"Missing required property '{ValuePropertyName}'.");
        }

        return new KeyValuePair<string, string>(name, value);
    }

    public override void Write(Utf8JsonWriter writer, KeyValuePair<string, string> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString(NamePropertyName, value.Key);
        writer.WriteString(ValuePropertyName, value.Value);

        writer.WriteEndObject();
    }
}
