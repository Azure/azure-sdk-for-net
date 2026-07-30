// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal static class JsonSerializationHelpers
    {
        private static readonly ConnectionStatesConverter ConnectionStatesConverter = new();

        internal static Dictionary<string, string[]> ReadStringArrayDictionary(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            Dictionary<string, string[]> result = [];
            foreach (JsonProperty property in element.EnumerateObject())
            {
                result[property.Name] = ReadStringArray(property.Value);
            }

            return result;
        }

        internal static string[] ReadStringArray(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            List<string> list = [];
            foreach (JsonElement item in element.EnumerateArray())
            {
                list.Add(item.GetString());
            }

            return list.ToArray();
        }

        internal static WebPubSubClientCertificate[] ReadClientCertificates(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            List<WebPubSubClientCertificate> list = [];
            foreach (JsonElement item in element.EnumerateArray())
            {
                WebPubSubClientCertificate certificate = ReadClientCertificate(item);
                if (certificate != null)
                {
                    list.Add(certificate);
                }
            }

            return list.ToArray();
        }

        internal static void WriteStringArrayDictionary(Utf8JsonWriter writer, IReadOnlyDictionary<string, string[]> values)
        {
            if (values == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();
            foreach (KeyValuePair<string, string[]> pair in values)
            {
                writer.WritePropertyName(pair.Key);
                WriteStringArray(writer, pair.Value);
            }
            writer.WriteEndObject();
        }

        internal static void WriteStringArray(Utf8JsonWriter writer, IReadOnlyList<string> values)
        {
            if (values == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartArray();
            foreach (string value in values)
            {
                writer.WriteStringValue(value);
            }
            writer.WriteEndArray();
        }

        internal static void WriteClientCertificates(Utf8JsonWriter writer, IReadOnlyList<WebPubSubClientCertificate> certificates)
        {
            if (certificates == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartArray();
            foreach (WebPubSubClientCertificate certificate in certificates)
            {
                writer.WriteStartObject();
                writer.WriteString(WebPubSubClientCertificate.ThumbprintProperty, certificate.Thumbprint);
                if (certificate.Content != null)
                {
                    writer.WriteString(WebPubSubClientCertificate.ContentProperty, certificate.Content);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }

        internal static void WriteConnectionContext(Utf8JsonWriter writer, WebPubSubConnectionContext connectionContext)
        {
            writer.WriteStartObject();
            writer.WriteNumber("eventType", (int)connectionContext.EventType);
            writer.WriteString("eventName", connectionContext.EventName);
            writer.WriteString("hub", connectionContext.Hub);
            writer.WriteString("connectionId", connectionContext.ConnectionId);
            writer.WriteString("userId", connectionContext.UserId);
            writer.WriteString("signature", connectionContext.Signature);
            writer.WriteString("origin", connectionContext.Origin);

            writer.WritePropertyName("states");
            ConnectionStatesConverter.Write(writer, connectionContext.ConnectionStates, options: null);

            writer.WritePropertyName("headers");
            WriteStringArrayDictionary(writer, connectionContext.Headers);

            if (connectionContext is MqttConnectionContext mqttConnectionContext)
            {
                writer.WriteString(MqttConnectionContext.PhysicalConnectionIdProperty, mqttConnectionContext.PhysicalConnectionId);
                writer.WriteString(MqttConnectionContext.SessionIdProperty, mqttConnectionContext.SessionId);
            }

            writer.WriteEndObject();
        }

        private static WebPubSubClientCertificate ReadClientCertificate(JsonElement element)
        {
            string thumbprint = null;
            string content = null;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals(WebPubSubClientCertificate.ThumbprintProperty))
                {
                    thumbprint = property.Value.GetString();
                }
                else if (property.NameEquals(WebPubSubClientCertificate.ContentProperty))
                {
                    content = property.Value.GetString();
                }
            }

            if (thumbprint == null && content == null)
            {
                return null;
            }

            return content == null ? new WebPubSubClientCertificate(thumbprint) : new WebPubSubClientCertificate(thumbprint, content);
        }
    }
}
