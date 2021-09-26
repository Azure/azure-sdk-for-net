// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class DisconnectedEventRequestJsonConverter : JsonConverter<DisconnectedEventRequest>
    {
        public override DisconnectedEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var element = JsonDocument.ParseValue(ref reader).RootElement;

            return new DisconnectedEventRequest(element.ReadString(DisconnectedEventRequest.ReasonProperty));
        }

        public override void Write(Utf8JsonWriter writer, DisconnectedEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(DisconnectedEventRequest.ReasonProperty);
            JsonSerializer.Serialize(writer, value.Reason, options);
            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(ServiceRequest.ConnectionContextProperty);
                JsonSerializer.Serialize(writer, value.ConnectionContext, options);
            }
            writer.WriteEndObject();
        }
    }
}
