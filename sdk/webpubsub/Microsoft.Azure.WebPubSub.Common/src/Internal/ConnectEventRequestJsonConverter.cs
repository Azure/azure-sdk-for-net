// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class ConnectEventRequestJsonConverter : JsonConverter<ConnectEventRequest>
    {
        public override ConnectEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            // Tricky part to create a temp request.
            return new ConnectEventRequest(
                null,
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.ClaimsProperty)),
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.QueryProperty)),
                JsonSerializationHelpers.ReadStringArray(element.GetProperty(ConnectEventRequest.SubprotocolsProperty)),
                JsonSerializationHelpers.ReadClientCertificates(element.GetProperty(ConnectEventRequest.ClientCertificatesProperty)),
                JsonSerializationHelpers.ReadStringArrayDictionary(element.GetProperty(ConnectEventRequest.HeadersProperty)));
        }

        public override void Write(Utf8JsonWriter writer, ConnectEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(ConnectEventRequest.ClaimsProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Claims);

            writer.WritePropertyName(ConnectEventRequest.QueryProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Query);

            writer.WritePropertyName(ConnectEventRequest.HeadersProperty);
            JsonSerializationHelpers.WriteStringArrayDictionary(writer, value.Headers);

            writer.WritePropertyName(ConnectEventRequest.SubprotocolsProperty);
            JsonSerializationHelpers.WriteStringArray(writer, value.Subprotocols);

            writer.WritePropertyName(ConnectEventRequest.ClientCertificatesProperty);
            JsonSerializationHelpers.WriteClientCertificates(writer, value.ClientCertificates);

            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(WebPubSubEventRequest.ConnectionContextProperty);
                JsonSerializationHelpers.WriteConnectionContext(writer, value.ConnectionContext);
            }

            writer.WriteEndObject();
        }
    }
}
