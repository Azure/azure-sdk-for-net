// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class DisconnectedEventRequestJsonConverter : JsonConverter<DisconnectedEventRequest>
    {
        public override DisconnectedEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            // Tricky part to temp set null to context.
            return new DisconnectedEventRequest(null, element.GetProperty(DisconnectedEventRequest.ReasonProperty).GetString());
        }

        public override void Write(Utf8JsonWriter writer, DisconnectedEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(DisconnectedEventRequest.ReasonProperty, value.Reason);

            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(WebPubSubEventRequest.ConnectionContextProperty);
                JsonSerializationHelpers.WriteConnectionContext(writer, value.ConnectionContext);
            }

            writer.WriteEndObject();
        }
    }
}
