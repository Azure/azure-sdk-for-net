// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebPubSub.Common;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    internal class SocketIOConnectJsonConverter : JsonConverter<SocketIOConnectRequest>
    {
        public override SocketIOConnectRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            return new SocketIOConnectRequest(
                @namespace: null,
                socketId: null,
                claims: ReadToObject<Dictionary<string, string[]>>(element, SocketIOConnectRequest.ClaimsProperty),
                query: ReadToObject<Dictionary<string, string[]>>(element, SocketIOConnectRequest.QueryProperty),
                certificates: ReadToObject<WebPubSubClientCertificate[]>(element, SocketIOConnectRequest.ClientCertificatesProperty),
                headers: ReadToObject<Dictionary<string, string[]>>(element, SocketIOConnectRequest.HeadersProperty));
        }

        public override void Write(Utf8JsonWriter writer, SocketIOConnectRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(SocketIOConnectRequest.NamespaceProperty);
            JsonSerializer.Serialize(writer, value.Namespace, options);
            writer.WritePropertyName(SocketIOConnectRequest.SocketIdProperty);
            JsonSerializer.Serialize(writer, value.SocketId, options);
            writer.WritePropertyName(SocketIOConnectRequest.ClaimsProperty);
            JsonSerializer.Serialize(writer, value.Claims, options);
            writer.WritePropertyName(SocketIOConnectRequest.QueryProperty);
            JsonSerializer.Serialize(writer, value.Query, options);
            writer.WritePropertyName(SocketIOConnectRequest.HeadersProperty);
            JsonSerializer.Serialize(writer, value.Headers, options);
            writer.WritePropertyName(SocketIOConnectRequest.ClientCertificatesProperty);
            JsonSerializer.Serialize(writer, value.ClientCertificates, options);
            writer.WriteEndObject();
        }

        private static TValue ReadToObject<TValue>(JsonElement element, string name)
        {
            var value = element.GetProperty(name);
            return JsonSerializer.Deserialize<TValue>(value.GetRawText());
        }
    }
}
