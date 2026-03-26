// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        int? code = null;
        string? reason = null;
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
                    case MqttConnectEventErrorResponse.MqttProperty:
                        ReadMqttProperties(ref reader, out code, out reason, out userProperties);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        if (code == null)
        {
            throw new JsonException($"Missing required property `{MqttConnectEventErrorResponse.MqttProperty}`.");
        }

        return new MqttConnectEventErrorResponseContent(
            new MqttConnectEventErrorResponsePropertiesContent(code.Value, reason, userProperties));
    }

    public override void Write(Utf8JsonWriter writer, MqttConnectEventErrorResponse value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(MqttConnectEventErrorResponse.MqttProperty);

        writer.WriteStartObject();
        writer.WriteNumber(MqttConnectEventErrorResponseProperties.CodeProperty, value.Mqtt.Code);
        writer.WriteString(MqttConnectEventErrorResponseProperties.ReasonProperty, value.Mqtt.Reason);
        writer.WritePropertyName(MqttConnectEventErrorResponseProperties.UserPropertiesProperty);
        WriteUserProperties(writer, value.Mqtt.UserProperties);
        writer.WriteEndObject();

        writer.WriteEndObject();
    }

    private static void ReadMqttProperties(
        ref Utf8JsonReader reader,
        out int? code,
        out string? reason,
        out IReadOnlyList<MqttUserProperty>? userProperties)
    {
        code = null;
        reason = null;
        userProperties = null;

        using var document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement;

        if (element.TryGetProperty(MqttConnectEventErrorResponseProperties.CodeProperty, out JsonElement codeElement))
        {
            code = codeElement.GetInt32();
        }

        if (element.TryGetProperty(MqttConnectEventErrorResponseProperties.ReasonProperty, out JsonElement reasonElement))
        {
            reason = reasonElement.ValueKind == JsonValueKind.Null ? null : reasonElement.GetString();
        }

        if (element.TryGetProperty(MqttConnectEventErrorResponseProperties.UserPropertiesProperty, out JsonElement userPropertiesElement))
        {
            userProperties = ReadUserProperties(userPropertiesElement);
        }
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

    private static void WriteUserProperties(Utf8JsonWriter writer, IReadOnlyList<MqttUserProperty>? properties)
    {
        if (properties == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartArray();
        foreach (MqttUserProperty property in properties)
        {
            writer.WriteStartObject();
            writer.WriteString(MqttUserProperty.NamePropertyName, property.Name);
            writer.WriteString(MqttUserProperty.ValuePropertyName, property.Value);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}
